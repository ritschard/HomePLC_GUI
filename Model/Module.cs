using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using NLog;

namespace HomePLC.Model
{
    /// <summary>
    /// BoardType enumerator is used to indicate which device I/O board is used.
    /// </summary>
    public enum BoardType
    {
        Analog,
        Digital
    }
    /// <summary>
    /// ConnectionState enum is used for checking current connection state.
    /// </summary>
    public enum ConnectionState
    {
        Connecting,
        Connected,
        Disconnecting,
        Disconnected,
        UnableToConnect,
        ProtocolError
    }
    /// <summary>
    /// UpdateInfo enum is used for tracing parameter updates that are sent to device. 
    /// </summary>
    public enum UpdateInfo
    {
        IPAddressUpdated,
        PortUpdated,
        NetmaskUpdated,
        GatewayUpdated,
        RTCUpdated
    }

    public delegate void ConnectionEventHandler(Module sender, ConnectionState state);
    public delegate void NetworkUpdatedEventHandler(Module sender, UpdateInfo info, IPAddress address);
    public delegate void RTCUpdatedEventHandler(Module sender, UpdateInfo info, DateTime rtc, bool burnedToDevice);
    public delegate void AnalogPinChangedEventHandler(Module sender, int pinCount, byte value, bool onDevice);
    public delegate void DigitalPinChangedEventHandler(Module sender, int pinCount, bool value, bool onDevice);

    public class OutputDigitalPinCollection
    {
        private Module fParent;

        internal OutputDigitalPinCollection(Module Parent)
        {
            fParent = Parent;
        }
        public bool this[int index]
        {
            get
            {
                return fParent.GetOutputDigitalPin(index);
            }

            set
            {
                fParent.SetOutputDigitalPin(index, value);
            }
        }
    }
    public class OutputAnalogPinCollection
    {
        private Module fParent;

        internal OutputAnalogPinCollection(Module Parent)
        {
            fParent = Parent;
        }

        public byte this[int index]
        {
            get
            {
                return (fParent.GetOutputAnalogPin(index));
            }

            set
            {
                if ((value > 255) || (value < 0))
                    throw new HomePLCException("Vrednost " + value.ToString() + " nije dozvoljena za analogni pin!");

                fParent.SetOutputAnalogPin(index, value);
            }
        }

        public byte GetByteValue(int index)
        {
            return fParent.GetOutputAnalogPin(index);
        }

        public void SetByteValue(int index, byte value)
        {
            fParent.SetOutputAnalogPin(index, value);
        }
    }
    public class InputDigitalPinCollection
    {
        private Module fParent;

        internal InputDigitalPinCollection(Module Parent)
        {
            fParent = Parent;
        }

        public bool this[int index]
        {
            get
            {
                return fParent.GetInputDigitalPin(index);
            }           
        }
    }
    public class InputAnalogPinCollection
    {
        private Module fParent;

        internal InputAnalogPinCollection(Module Parent)
        {
            fParent = Parent;
        }

        public byte this[int index]
        {
            get
            {
                return (fParent.GetInputAnalogPin(index));
            }        
        }

        public byte GetByteValue(int index)
        {
            return fParent.GetInputAnalogPin(index);
        }
   
    }

    public class Module : IDisposable /* Module implements IDisposable interface for classes that are Disposable after use. */
    {
        public OutputDigitalPinCollection OutputDigitalPin;
        public OutputAnalogPinCollection OutputAnalogPin;
        public InputDigitalPinCollection InputDigitalPin;
        public InputAnalogPinCollection InputAnalogPin;
        
        private static Logger logger = LogManager.GetCurrentClassLogger();
                
        private TcpClient fTcp;                         // Connection client.
        private Thread fProcessThread;                  // Process message thread.
        private IPAddress fIpAddress;                   // IP Address to connect field.
        private int fPort;                              // Port to connect field.
        private bool fConnected = false;                // Connected flag field.
        private bool fDisposed = false;                 // Dispose mechanism flag field.
        private bool fProcessTerminated = false;        // Threaded process terminate flag field.
        private int fNrAnalogOutputPins = 0;            // Number of Analog OUTPUT pins field.
        private int fNrDigitalOutputPins = 0;           // Number of Digital OUTPUT pins field.
        private int fNrAnalogInputPins = 0;             // Number of Analog INPUT pins field.
        private int fNrDigitalInputPins = 0;            // Number of Digital INPUT pins field.
        private byte[] fOutputAnalogPins = null;        // Local array for storing values of Analog OUTPUTS field.
        private bool[] fOutputDigitalPins = null;       // Local array for storing states of Digital OUTPUTS field.
        private byte[] fInputAnalogPins = null;         // Local array for storing values of Analog INPUTS field.
        private bool[] fInputDigitalPins = null;        // Local array for storing states of Digital INPUTS field.
        private byte[] readBuffer = new byte[0];        // Tcp read buffer array field. 
        private BoardType fInputType;                   // INPUT Board Type field.
        private BoardType fOutputType;                  // OUTPUT Board Type field.
        private bool fAutoSyncOn = false;               // Auto Sync flag field.
        private int fAutoSyncInterval = 1000;           // Auto Sync interval (ms.) field.
        private DateTime fLastSync;                     // Auto Sync last time done field. 
        private DateTime fRTC;                          // Local RTC value.
        private bool fDebug;                            // Log messages to NLog flag field. 

        // MODULE CONSTRUCTOR METHOD //
        public Module(BoardType inputBoard, int inputPins, BoardType outputBoard, int outputPins) 
        {
            if (inputBoard == BoardType.Analog)
            {
                InputAnalogPin = new InputAnalogPinCollection(this);
                fInputType = BoardType.Analog;
                fNrAnalogInputPins = inputPins;
                fInputAnalogPins = new byte[inputPins]; 
            }
            else
            {
                InputDigitalPin = new InputDigitalPinCollection(this);
                fInputType = BoardType.Digital;
                fNrDigitalInputPins = inputPins;
                fInputDigitalPins = new bool[inputPins];
            }

            if (outputBoard == BoardType.Analog)
            {
                OutputAnalogPin = new OutputAnalogPinCollection(this);
                fOutputType = BoardType.Analog;
                fNrAnalogOutputPins = outputPins;
                fOutputAnalogPins = new byte[outputPins];
            }
            else
            {
                OutputDigitalPin = new OutputDigitalPinCollection(this);
                fOutputType = BoardType.Digital;
                fNrDigitalOutputPins = outputPins;
                fOutputDigitalPins = new bool[outputPins];
            }
                        
            fTcp = new TcpClient();
            fProcessThread = new Thread(new ThreadStart(MessageProcess));
            fProcessThread.Name = "Message Processor";
            fProcessThread.Start();
        }
        
        #region Pin management methods, events and interfaces
                   
        public event DigitalPinChangedEventHandler OutputDigitalPinChangedEvent;
        public event AnalogPinChangedEventHandler OutputAnalogPinChangedEvent;
        public event DigitalPinChangedEventHandler InputDigitalPinChangedEvent;
        public event AnalogPinChangedEventHandler InputAnalogPinChangedEvent;

        // PIN CHANGE EVENT METHODS //
        internal void OnDigitalOutputPinChanged(int index, bool value, bool onDevice) 
        {
            if (OutputDigitalPinChangedEvent != null)
            {
                Control ctrl = OutputDigitalPinChangedEvent.Target as Control;
                if (ctrl != null)
                {
                    ctrl.BeginInvoke(OutputDigitalPinChangedEvent, new object[] { this, index, value, onDevice });
                }
                else
                    OutputDigitalPinChangedEvent(this, index, value, onDevice);
            }
        }
        internal void OnAnalogOutputPinChanged(int index, byte value, bool onDevice)
        {
            if (OutputAnalogPinChangedEvent != null)
            {
                Control ctrl = OutputAnalogPinChangedEvent.Target as Control;
                if (ctrl != null)
                {
                    ctrl.BeginInvoke(OutputAnalogPinChangedEvent, new object[] { this, index, value, onDevice });
                }
                else
                    OutputAnalogPinChangedEvent(this, index, value, onDevice);
            }
        }
        internal void OnDigitalInputPinChanged(int index, bool value, bool onDevice)
        {
            if (InputDigitalPinChangedEvent != null)
            {
                Control ctrl = InputDigitalPinChangedEvent.Target as Control;
                if (ctrl != null)
                {
                    ctrl.BeginInvoke(InputDigitalPinChangedEvent, new object[] { this, index, value, onDevice });
                }
                else
                    InputDigitalPinChangedEvent(this, index, value, onDevice);
            }
        }
        internal void OnAnalogInputPinChanged(int index, byte value, bool onDevice)
        {
            if (InputAnalogPinChangedEvent != null)
            {
                Control ctrl = InputAnalogPinChangedEvent.Target as Control;
                if (ctrl != null)
                {
                    ctrl.BeginInvoke(InputAnalogPinChangedEvent, new object[] { this, index, value, onDevice });
                }
                else
                    InputAnalogPinChangedEvent(this, index, value, onDevice);
            }
        }

        // IO SET/GET  METHODS//
        internal void SetOutputDigitalPin(int index, bool value)
        {
            if ((index < 0) || (index > OutputDigitalPinCount - 1))
                throw new HomePLCException("Digitalni izlazni pin sa indeksom " + index.ToString() + " ne postoji!");

            PushMessage(new Message(MessageCmdType.SetDigitalPin, index, value));
            OnDigitalOutputPinChanged(index, value, false);
            
        }
        internal void SetOutputAnalogPin(int index, byte value)
        {
            if ((index < 0) || (index > OutputAnalogPinCount - 1))
                throw new HomePLCException("Analogni izlazni pin sa indeksom " + index.ToString() + " ne postoji!");

            PushMessage(new Message(MessageCmdType.SetAnalogPin, index, value));
            OnAnalogOutputPinChanged(index, value, false);

        }
        internal bool GetOutputDigitalPin(int index)
        {
            if ((index < 0) || (index > OutputDigitalPinCount - 1))
                throw new HomePLCException("Digitalni izlazni pin sa indeksom " + index.ToString() + " ne postoji!");

            bool result = fOutputDigitalPins[index];

            return result;
        }
        internal byte GetOutputAnalogPin(int index)
        {
            if ((index < 0) || (index > OutputAnalogPinCount - 1))
                throw new HomePLCException("Analogni izlazni pin sa indeksom " + index.ToString() + " ne postoji!");

            byte result = fOutputAnalogPins[index];

            return result;
        }
        internal bool GetInputDigitalPin(int index)
        {
            if ((index < 0) || (index > InputDigitalPinCount - 1))
                throw new HomePLCException("Digitalni izlazni pin sa indeksom " + index.ToString() + " ne postoji!");

            bool result = fInputDigitalPins[index];

            return result;
        }
        internal byte GetInputAnalogPin(int index)
        {
            if ((index < 0) || (index > InputAnalogPinCount - 1))
                throw new HomePLCException("Analogni izlazni pin sa indeksom " + index.ToString() + " ne postoji!");

            byte result = fInputAnalogPins[index];

            return result;
        }

        // COUNT OUTPUT PINS INTERFACE //
        public int OutputDigitalPinCount
        {
            get
            {
                return fNrDigitalOutputPins;
            }
        }
        public int OutputAnalogPinCount
        {
            get
            {
                return fNrAnalogOutputPins;
            }
        }

        // COUNT INPUT PINS INTERFACE //
        public int InputDigitalPinCount
        {
            get
            {
                return fNrDigitalInputPins;
            }
        }
        public int InputAnalogPinCount
        {
            get
            {
                return fNrAnalogInputPins;
            }
        }

        // IO BOARD TYPE INTERFACE //
        public BoardType InputBoard
        {
            get
            {
                return fInputType;  
            }
        }
        public BoardType OutputBoard
        {
            get
            {
                return fOutputType;
            }
        }
         
        #endregion

        #region Connection methods, events, interfaces

        public event ConnectionEventHandler ConnectionEvent;

        // CONNECTION METHODS //
        private void OnConnectionEvent(ConnectionState state)
        {
            if (ConnectionEvent != null)
            {
                Control ctrl = ConnectionEvent.Target as Control;
                if (ctrl != null)
                {
                    ctrl.BeginInvoke(ConnectionEvent, new object[] { this, state });
                }
                else
                    ConnectionEvent(this, state);
            }
        }
        private void CheckIsTcpConnected()
        {
            bool tcpState = fTcp.Connected;

            if (tcpState)
            {
                lock (this)
                    fConnected = true;
            }
            else
            {
                lock (this)
                    fConnected = false;
            }
        }
        public void Connect()
        {
            if (!Connected)
            {
                PushMessage(new Message(MessageCmdType.Connect));
                OnConnectionEvent(ConnectionState.Connecting);
            }
        }
        public void Disconnect()
        {
            if (Connected)
            {
                PushMessage(new Message(MessageCmdType.Disconnect));
                OnConnectionEvent(ConnectionState.Disconnecting);
            }
        }
        
        // CONNECTION INTERFACES //
        public bool Connected
        {
            get
            {
                bool result;

                lock (this) 
                    result = fConnected;
                return result;
            }
        }
        public IPAddress IpAddress
        {
            get
            {
                IPAddress result;

                lock (this) 
                    result = fIpAddress;
                return result;
            }
            set
            {
                lock (this) 
                    fIpAddress = value;
            }
        }
        public int Port
        {
            get
            {
                int result;

                lock (this) 
                    result = fPort;

                return result;
            }
            set
            {
                lock (this) 
                    fPort = value;
            }
        }

        #endregion

        #region Burn NET/RTC settings to flash events and methods

        public event NetworkUpdatedEventHandler NetworkUpdatedEvent;
        public event RTCUpdatedEventHandler RTCUpdatedEvent;

        // DEVICE SETTINGS METHODS // 
        private void OnNetDataChangedEvent(UpdateInfo update, IPAddress address)
        {
            if (NetworkUpdatedEvent != null)
            {
                Control ctrl = NetworkUpdatedEvent.Target as Control;
                if (ctrl != null)
                {
                    ctrl.BeginInvoke(NetworkUpdatedEvent, new object[] { this, update, address });
                }
                else
                    NetworkUpdatedEvent(this, update, address);
            }
        }
        private void OnRTCDataChangedEvent(UpdateInfo update, DateTime rtc, bool burnedToDevice)
        {
            if (RTCUpdatedEvent != null)
            {
                Control ctrl = RTCUpdatedEvent.Target as Control;
                if (ctrl != null)
                {
                    ctrl.BeginInvoke(RTCUpdatedEvent, new object[] { this, update, rtc, burnedToDevice });
                }
                else
                    RTCUpdatedEvent(this, update, rtc, burnedToDevice);
            }
        }

        public void SetIPAddress(IPAddress ip)
        {
            PushMessage(new Message(MessageCmdType.SetIPAddress, ip));
        }
        public void SetPort(int port)
        {
            PushMessage(new Message(MessageCmdType.SetPort, port));
        }
        public void SetNetmask(IPAddress netmask)
        {
            PushMessage(new Message(MessageCmdType.SetNetmask, netmask));
        }
        public void SetGateway(IPAddress gateway)
        {
            PushMessage(new Message(MessageCmdType.SetGateway, gateway));
        }
        public void SetRTC(DateTime rtc)
        {
            PushMessage(new Message(MessageCmdType.SetRTC, rtc));
        }

        #endregion

        #region Write/Read pin data and data parse methods

        // WRITE METHODS //
        private void WriteToDevice(byte command)
        {
            byte[] data = new byte[6] { 0xFF, 0x01, 0x00, command, 0xFF, 0x02 };
            fTcp.Client.Send(data);
            if (Debug) logger.Debug("SENT: " + BitConverter.ToString(data));
        }
        private void WriteToDevice(byte command, IPAddress value)
        {            
            int i = 5;
            byte[] data = new byte[50];

            data[0] = (byte)0xFF;
            data[1] = (byte)0x01;
            data[3] = (byte)command;

            foreach (byte val in value.GetAddressBytes())
            {
                if (val == 0xFF)
                {
                    data[i] = (byte)val;
                    i += 1;
                    data[i] = (byte)val;
                    i += 2;
                }
                else
                {
                    data[i] = (byte)val;
                    i += 2;
                }
            }

            data[i - 1] = (byte)0xFF;
            data[i] = (byte)0x02;

            fTcp.Client.Send(data);
            if (Debug) logger.Debug("SENT: " + BitConverter.ToString(data));
        }
        private void WriteToDevice(byte command, int value)
        {
            int i = 5;
            byte[] data = new byte[50];

            data[0] = 0xFF;
            data[1] = 0x01;
            data[3] = command;

            if (value == 0xFF)
            {
                data[i] = (byte)value;
                i += 1;
                data[i] = (byte)value;
                i += 2;
            }
            else
            {
                data[i] = (byte)value;
                i += 2;
            }
            data[i - 1] = (byte)0xFF;
            data[i] = (byte)0x02;

            fTcp.Client.Send(data);
            if (Debug) logger.Debug("SENT: " + BitConverter.ToString(data));
        }
        private void WriteToDevice(byte command, DateTime value)
        {
            byte[] time = new byte[4];
            time[3] = Convert.ToByte(value.DayOfWeek);
            time[2] = Convert.ToByte(value.Hour);
            time[1] = Convert.ToByte(value.Minute);
            time[0] = Convert.ToByte(value.Second);

            byte[] data = new byte[14] { 0xFF, 0x01, 0x00, command, 0x00, time[0], 0x00, time[1], 0x00, time[2], 0x00, time[3], 0xFF, 0x02 };
            fTcp.Client.Send(data);
            if (Debug) logger.Debug("SENT: " + BitConverter.ToString(data));

        }
        private void WriteToDevice(byte command, int pin, bool value)
        {
            byte val = Convert.ToByte(value);
            byte index = Convert.ToByte(pin);
            byte[] data = new byte[10] { 0xFF, 0x01, 0x00, command, 0x00, index, 0x00, val, 0xFF, 0x02 }; 
            fTcp.Client.Send(data);
            if (Debug) logger.Debug("SENT: " + BitConverter.ToString(data));
        }
        private void WriteToDevice(byte command, int pin, byte value)
        {
            int i = 7;
            byte[] data = new byte[50];

            data[0] = 0xFF;
            data[1] = 0x01;
            data[3] = command;
            data[5] = (byte) pin;

                if (value == 0xFF)
                {
                    data[i] = value;
                    i += 1;
                    data[i] = value;
                    i += 2;
                }
                else
                {
                    data[i] = value;
                    i += 2;
                }

            data[i - 1] = 0xFF;
            data[i] = 0x02;

            fTcp.Client.Send(data);
            if (Debug) logger.Debug("SENT: " + BitConverter.ToString(data));
        }

        // READ/PARSE/PROCESS METHODS //
        private void ReadData()
        {
            int available = fTcp.Client.Available;

            if (available > 0)
            {
                byte[] receivedBuffer = new byte[available];
                byte[] tmpBuffer = new byte[readBuffer.Length + receivedBuffer.Length];
                fTcp.Client.Receive(receivedBuffer);

                for (int i = 0; i < readBuffer.Length; i++)
                {
                    tmpBuffer[i] = readBuffer[i];
                }
                for (int i = 0; i < receivedBuffer.Length; i++)
                {
                    tmpBuffer[i + readBuffer.Length] = receivedBuffer[i];
                }

                readBuffer = tmpBuffer;
                ParseData(readBuffer);
            }
        }
        private void ParseData(byte[] buffer)
        {

            int bufferSize = buffer.Length - 4;
            short[] parsedToShort = new short[bufferSize / 2];

            int i = 2;
            int j = 0;

            if (buffer[0] == 0xFF && buffer[1] == 0x01)
            {
                if (buffer[buffer.Length - 2] == 0xFF && buffer[buffer.Length - 1] == 0x02)
                {

                    while (j < bufferSize / 2)
                    {
                        if (i > 4 && buffer[i - 1] == 0xFF && buffer[i] == 0xFF)
                        {
                            i++;
                        }
                        else
                        {
                            parsedToShort[j] = (short)(buffer[i++] << 8);
                            parsedToShort[j++] += buffer[i++];
                        }
                    }

                    var tempBuffer = new byte[readBuffer.Length - buffer.Length];

                    for (int x = 0; x < tempBuffer.Length; x++)
                    {
                        tempBuffer[x - buffer.Length] = readBuffer[x];
                    }
                    if (Debug) logger.Debug("RECEIVED: " + BitConverter.ToString(buffer));
                    readBuffer = tempBuffer;
                    ProcessData(parsedToShort);
                }
                else
                {
                    OnConnectionEvent(ConnectionState.ProtocolError);
                    logger.Error(BitConverter.ToString(buffer));
                }
            }
            else
            {
                OnConnectionEvent(ConnectionState.ProtocolError);
                logger.Error(BitConverter.ToString(buffer));
            }
        }
        private void ProcessData(short[] data)
        {
            int command = data[0];
            int pin = data[1];
            byte value = (byte) data[2];

            if (Debug)
            {
                // byte[] bytes = Array.ConvertAll(data, b => (byte)b); // Convert short[] to byte[]
                // logger.Debug("PARSED: " + BitConverter.ToString(bytes) + Environment.NewLine);
            }

            switch (command)
            {
                case 0xB0:      // SET DIGITAL OUTPUT ANSWARE
                    if (value > 0)
                        fOutputDigitalPins[pin] = true;
                    else
                        fOutputDigitalPins[pin] = false;
                    OnDigitalOutputPinChanged(pin, fOutputDigitalPins[pin], true);
                    break;
                    
                case 0xB1:      // SET ANALOG OUTPUT ANSWARE
                    fOutputAnalogPins[pin] = value;
                    OnAnalogOutputPinChanged(pin, fOutputAnalogPins[pin], true);
                    break;

                case 0xD0:      // GET DIGITAL OUTPUT ANSWARE
                    if (value > 0)
                        fOutputDigitalPins[pin] = true;
                    else
                        fOutputDigitalPins[pin] = false;
                    OnDigitalOutputPinChanged(pin, fOutputDigitalPins[pin], true);
                    break;
                    
                case 0xD1:      // GET ANALOG OUTPUT ANSWARE
                    fOutputAnalogPins[pin] = value;
                    OnAnalogOutputPinChanged(pin, fOutputAnalogPins[pin], true);
                    break;

                case 0x60:      // GET ALL (AUTO SYNC I/O) ANSWARE
                    int j = 0;
                    short[] time = new short[4];
                    byte[] oldOutputAnalogPins = new byte[OutputAnalogPinCount];
                    bool[] oldOutputDigitalPins = new bool[OutputDigitalPinCount];
                    byte[] oldInputAnalogPins = new byte[InputAnalogPinCount];
                    bool[] oldInputDigitalPins = new bool[InputDigitalPinCount];

                    // Copy old pin data, later comparation fire pin change event.  
                    if (fOutputAnalogPins != null)
                        Array.Copy(fOutputAnalogPins, oldOutputAnalogPins, fOutputAnalogPins.Length);
                    else
                        Array.Copy(fOutputDigitalPins, oldOutputDigitalPins, fOutputDigitalPins.Length);

                    if (fInputAnalogPins != null)
                        Array.Copy(fInputAnalogPins, oldInputAnalogPins, fInputAnalogPins.Length);
                    else
                        Array.Copy(fInputDigitalPins, oldInputDigitalPins, fInputDigitalPins.Length);
                        
                    if (fInputType == BoardType.Digital)
                    {
                        for (int i = 1; i < 9; ++i)
                        {
                            if (data[i] > 0)
                                fInputDigitalPins[i - 1] = true;
                            else
                                fInputDigitalPins[i - 1] = false;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < 7; ++i)
                        {
                            fInputAnalogPins[i - 1] = (byte) data[i];
                        }
                    }
                    
                    if (fOutputType == BoardType.Digital)
                    {
                        for (int i = 1; i < 9; ++i)
                        {
                            if (data[i + 8] > 0)
                                fOutputDigitalPins[i - 1] = true;
                            else
                                fOutputDigitalPins[i - 1] = false;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < 9; ++i)
                        {
                            fOutputAnalogPins[i - 1] = (byte)data[i + 8];
                        }
                    }
                    
                    for (int i = 17; i < 21; ++i)
                    {
                        time[j] = (short)data[i];
                        j++;
                    }
                    // Fire apropriate INPUT event if new value detected.
                    if (fInputDigitalPins != null)      
                    {
                        for (int i = 0; i < fInputDigitalPins.Length; i++)
                        {
                            if (fInputDigitalPins[i] != oldInputDigitalPins[i])
                            {
                                OnDigitalInputPinChanged(i, fInputDigitalPins[i], true);
                            }
                        }
                    }
                    else 
                    {
                        for (int i = 0; i < fInputAnalogPins.Length; i++)
                        {
                            if (fInputAnalogPins[i] != oldInputAnalogPins[i])
                            {
                                OnAnalogInputPinChanged(i, fInputAnalogPins[i], true);
                            }
                        }
                    }
                    // Fire apropriate OUTPUT event if new value detected.
                    if (fOutputDigitalPins != null)    
                    {
                        for (int i = 0; i < fOutputDigitalPins.Length; i++)
                        {
                            if (fOutputDigitalPins[i] != oldOutputDigitalPins[i])
                            {
                                OnDigitalOutputPinChanged(i, fOutputDigitalPins[i], true);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < fOutputAnalogPins.Length; i++)
                        {
                            if (fOutputAnalogPins[i] != oldOutputAnalogPins[i])
                            {
                                OnAnalogOutputPinChanged(i, fOutputAnalogPins[i], true);
                            }
                        }
                    }
                    // Update RTC data.
                    fRTC = new DateTime((int)DateTime.Now.Year, (int)DateTime.Now.Month, (int)DateTime.Now.Day, time[2], time[1], time[0]);
                    OnRTCDataChangedEvent(UpdateInfo.RTCUpdated, fRTC, false);
                    break;

                case 0x20:
                    string addrs = data[1].ToString() + "." + data[2].ToString() + "." + data[3].ToString() + "." + data[4].ToString();
                    IPAddress ip = IPAddress.Parse(addrs);      
                    OnNetDataChangedEvent(UpdateInfo.IPAddressUpdated, ip);
                    break;
                case 0x21:
                    string nmask = data[1].ToString() + "." + data[2].ToString() + "." + data[3].ToString() + "." + data[4].ToString();
                    IPAddress netmask = IPAddress.Parse(nmask);
                    OnNetDataChangedEvent(UpdateInfo.NetmaskUpdated, netmask);
                    break;
                case 0x22:
                    string gate = data[1].ToString() + "." + data[2].ToString() + "." + data[3].ToString() + "." + data[4].ToString();
                    IPAddress gateway = IPAddress.Parse(gate);
                    OnNetDataChangedEvent(UpdateInfo.GatewayUpdated, gateway);
                    break;
                case 0x24:
                    fRTC = new DateTime((int)DateTime.Now.Year, (int)DateTime.Now.Month, (int)DateTime.Now.Day, data[3], data[2], data[1]);
                    OnRTCDataChangedEvent(UpdateInfo.RTCUpdated, fRTC, true);
                    break;
                default:
                    OnConnectionEvent(ConnectionState.ProtocolError);
                    break;
            }
        }

        #endregion

        #region AutoSync methods and interfaces + Debug interface

        // AUTO SYNC INTERFACES //
        public bool AutoSync
        {
            get 
            {
                lock (this)
                return fAutoSyncOn; 
            }
            set 
            {
                lock (this)
                fAutoSyncOn = value;
            }
        }
        public int AutoSyncInterval
        {
            get
            {
                lock (this)
                    return fAutoSyncInterval;
            }
            set
            {
                lock (this)
                    fAutoSyncInterval = value;
            }
        }
        public DateTime LastSynced
        {
            get
            {
                lock (this)
                    return fLastSync;
            }
            set
            {
                lock (this)
                    fLastSync = value;
            }
        }

        // DO AUTO SYNC METHOD //
        private void DoAutoSync()
        {
            if (DateTime.Now > LastSynced.AddMilliseconds((double)AutoSyncInterval))
            {
                PushMessage(new Message(MessageCmdType.GetAll));
                LastSynced = DateTime.Now;
            }
        }

        // DEBUG LOG INTERFACES //
        public bool Debug
        {
            get
            {
                lock (this)
                    return fDebug;
            }
            set
            {
                lock (this)
                    fDebug = value;
            }
        }

        #endregion

        #region Thread procedure, interfaces and message queue

        private MessageList MessageQueue = new MessageList();

        private void PushMessage(Message item)
        {
            lock (this) 
                MessageQueue.Add(item);
        }
        private Message PopMessage()
        {
            Message result = null;

            lock (this)
            {
                if (MessageQueue.Count > 0)
                {
                    result = MessageQueue[0];
                    MessageQueue.Remove(result);
                }
            }
            return result;
        }

        // THREAD PROCESS //
        private void MessageProcess()
        {
            while (!ProcessTerminated)
            {
                Message item = PopMessage();

                if (item != null)
                {
                    CheckIsTcpConnected();

                    if (Connected)   // if connected
                    {
                        switch (item.mCommand)
                        {   // DISCONNECT //
                            case MessageCmdType.Disconnect:
                                try
                                {
                                    fTcp.Client.Disconnect(true);
                                    fTcp.Client.Close();
                                    fTcp.Close();
                                    fTcp = new TcpClient();
                                }
                                catch (Exception)
                                {
                                }
                                    lock (this)
                                        fConnected = false;
                                OnConnectionEvent(ConnectionState.Disconnected);
                                break;

                            // GET MESSAGES //
                            case MessageCmdType.GetDigitalPin:
                                WriteToDevice(0xC0, item.mPin);
                                break;
                            case MessageCmdType.GetAnalogPin:
                                WriteToDevice(0xC1, item.mPin);
                                break;
                            case MessageCmdType.GetAll:
                                WriteToDevice(0x50);
                                break;

                            // SET MESSAGES //
                            case MessageCmdType.SetDigitalPin:
                                WriteToDevice(0xA0, item.mPin, item.mDigitalValue);   
                                break;
                            case MessageCmdType.SetAnalogPin:
                                WriteToDevice(0xA1, item.mPin, item.mAnalogValue);
                                break;
                            case MessageCmdType.SetIPAddress:
                                WriteToDevice(0x10, item.mIPAddress);
                                break;
                            case MessageCmdType.SetNetmask:
                                WriteToDevice(0x11, item.mIPAddress);
                                break;
                            case MessageCmdType.SetGateway:
                                WriteToDevice(0x12, item.mIPAddress);
                                break;
                            case MessageCmdType.SetPort:
                                WriteToDevice(0x13, item.mPort);
                                break;
                            case MessageCmdType.SetRTC:
                                WriteToDevice(0x14, item.mRTC);
                                break;    
                        }
                    }
                    else  // if not connected
                    {
                        switch (item.mCommand)
                        {   // CONNECT //
                            case MessageCmdType.Connect:
                                try 
                                {
                                   fTcp.Connect(fIpAddress, fPort);
                                }
                                catch (Exception)
                                {
                                }

                                if (fTcp.Connected)
                                {
                                    lock (this)
                                        fConnected = true;
                                    OnConnectionEvent(ConnectionState.Connected);
                                }
                                else
                                {
                                    OnConnectionEvent(ConnectionState.UnableToConnect);
                                }
                                break;
                        }
                    }
                }
                Thread.Sleep(30); // Give some time to Send (30ms.)
                if (Connected)
                {
                    ReadData();

                    if (AutoSync)
                    {
                        DoAutoSync(); 
                    }
                }
                Thread.Sleep(50);
            }
        }

        // THREAD TERMINATION INTERFACE //
        private bool ProcessTerminated
        {
            get
            {
                bool result;
                lock (this)
                    result = fProcessTerminated;

                return result;
            }
            set
            {
                lock (this)
                    fProcessTerminated = value;
            }
        }

        #endregion

        #region Disposing function

        /*
         * Funcije za disposing su nam potrebne da zatvorimo konekciju onog momenta
         * kada zavrsimo sa koriscenjem objekta a ne kada garbage collector skonta
         * da smo mi zavrsili
         */

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!fDisposed)   // Dispose treba da se izvrsi samo jednom bez obzira koliko puta se zove
            {
                if (fProcessThread != null)
                {
                    ProcessTerminated = true;
                    fProcessThread.Join();
                }

                if (disposing)
                {
                    // Ovde zatvaramo managed resources ako ih ima (i.e. TcpClient i slicno)
                    if (fTcp != null)
                    {
                        fTcp.Close();
                    }
                }
                // ovde zatvaramo unmanaged resources ako ih ima

                fDisposed = true;
            }
        }

        ~Module()
        {
            Dispose(false);
        }

        #endregion
    }
    
#region Message and MessageList class, type enum...

    internal enum MessageCmdType
    {
        Connect,
        Disconnect,
        GetDigitalPin,
        GetAnalogPin,
        GetAll,
        SetDigitalPin,
        SetAnalogPin,
        SetIPAddress,
        SetNetmask,
        SetGateway,
        SetPort,
        SetRTC
    }

    internal class Message
    {
        internal MessageCmdType mCommand;
        internal int mPin;
        internal bool mDigitalValue;
        internal byte mAnalogValue;
        internal IPAddress mIPAddress;
        internal int mPort;
        internal DateTime mRTC;

        public Message(MessageCmdType cmd)
        {
            mCommand = cmd;
        }
        public Message(MessageCmdType cmd, IPAddress ip)
        {
            mCommand = cmd;
            mIPAddress = ip;
        }
        public Message(MessageCmdType cmd, int port)
        {
            mCommand = cmd;
            mPort = port;
        }
        public Message(MessageCmdType cmd, DateTime rtc)
        {
            mCommand = cmd;
            mRTC = rtc;
        }
        public Message(MessageCmdType cmd, int pin, bool digitalValue)
        {
            mCommand = cmd;
            mPin = pin;
            mDigitalValue = digitalValue;
        }
        public Message(MessageCmdType cmd, int pin, byte analogValue)
        {
            mCommand = cmd;
            mPin = pin;
            mAnalogValue = analogValue;
        }
    }

    internal class MessageList : List<Message>
    {
    }

#endregion

}
