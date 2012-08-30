using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using HomePLC.Model;
using HomePLC.Forms;
using NLog;
using NLog.Config;
using NLog.Targets;
using System.ServiceModel;

namespace HomePLC
{    
    public partial class MainForm : BaseForm
    {                
        private Module mdl = null;
        private BoardType inputBoard;
        private BoardType outputBoard;
        private ScriptEngine scriptEngine;
        private TriggerEngine triggerEngine = null;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private bool logCommands = true;
        private TriggeringEvent myEvent = null;
        private RemoteServiceHost myServiceHost = null;

        public bool LogCommands
        {
            get { return logCommands; }
            set { logCommands = value; }
        }

        public class ToolStripOverride : ToolStripSystemRenderer // ToolStripProfessionalRenderer
        {
            public ToolStripOverride() { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                
            }
        }
        
        private void ScriptCurrentChanged(object sender, EventArgs e)
        {
            if (scriptBS.Current != null)
            {
                btnAddScript.Enabled = true;
                btnEditScript.Enabled = true;
                btnRemScript.Enabled = true;
                btnTrigScript.Enabled = true;
                btnExecScript.Enabled = true;
            }
            else
            {
                btnAddScript.Enabled = true;
                btnEditScript.Enabled = false;
                btnRemScript.Enabled = false;
                btnTrigScript.Enabled = false;
                btnExecScript.Enabled = false;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            toolbar.Renderer = new ToolStripOverride();
            scriptEngine = new ScriptEngine();
            scriptBS.DataSource = scriptEngine;
            ScriptCurrentChanged(null, null);
            triggerEngine = new TriggerEngine();
            triggerBS.DataSource = triggerEngine;
            myServiceHost = new RemoteServiceHost();
        }

        #region // FORM LOAD/CLOSE METHODS //
        private void MainForm_Load(object sender, EventArgs e)
        {
            //toolbar.Renderer = new ToolStripOverride();
            InitLog();
            InitModule(Properties.Settings.Default.devInputBoard, Properties.Settings.Default.devOutputBoard);

            timer1.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mdl.Disconnect();
            mdl.Dispose();
            GC.Collect();
        }
        #endregion
       
        #region // INIT METHODS //
        private void InitLog()
        {
            LoggingConfiguration config = new LoggingConfiguration();
            RichTextBoxTarget control = new RichTextBoxTarget();
            control.Name = "RichTextBox";
            control.Layout = "${date:format=HH\\:mm\\:ss} |   ${message}";
            control.ControlName = "txtLog";
            control.FormName = "MainForm";
            control.AutoScroll = true;
            control.MaxLines = 10000;
            control.UseDefaultRowColoringRules = true;
            control.WordColoringRules.Add(new RichTextBoxWordColoringRule("True", "Green", "White", FontStyle.Bold));
            control.WordColoringRules.Add(new RichTextBoxWordColoringRule("False", "Red", "White", FontStyle.Bold));
            control.WordColoringRules.Add(new RichTextBoxWordColoringRule("SENT:", "Orange", "White"));
            control.WordColoringRules.Add(new RichTextBoxWordColoringRule("RECEIVED:", "Green", "White"));
            control.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Info", "ControlText", "White"));
            control.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Debug", "Gray", "White"));
            control.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Warn", "DarkRed", "Control"));
            control.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Error", "White", "DarkRed", FontStyle.Bold));
            control.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Fatal", "Yellow", "DarkRed", FontStyle.Bold));
            config.AddTarget(control.Name, control);

            FileTarget fileTarget = new FileTarget();
            fileTarget.Name = "LogFile";
            fileTarget.Layout = "${date:format=HH\\:MM\\:ss} | ${level} | ${message}";
            fileTarget.CreateDirs = true;
            fileTarget.FileName = "${basedir}/logs/${date:format=yyyy-MM-dd}.log";
            fileTarget.ArchiveAboveSize = 5000000;
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Rolling;
            fileTarget.MaxArchiveFiles = 10;
            fileTarget.ArchiveFileName = "${basedir}/logs/archive/${date:format=yyyy-MM-dd}.log";

            LoggingRule rule1 = new LoggingRule("*", LogLevel.Debug, control);
            config.LoggingRules.Add(rule1);
            LoggingRule rule2 = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(rule2);

            LogManager.Configuration = config;
        }
        
        private void InitModule(BoardType input, BoardType output)
        {
            if (input == BoardType.Analog)
            {
                inputBoard = BoardType.Analog;
                grpAnalogInputs.Visible = true;
                grpDigitalInputs.Visible = false;
            }
            else 
            {
                inputBoard = BoardType.Digital;
                grpDigitalInputs.Visible = true;
                grpAnalogInputs.Visible = true;
            }

            if (output == BoardType.Analog)
            {
                outputBoard = BoardType.Analog;
                grpAnalogOutputs.Visible = true;
                grpDigitalOutputs.Visible = false;
            }
            else
            {
                outputBoard = BoardType.Digital;
                grpDigitalOutputs.Visible = true;
                grpAnalogOutputs.Visible = false;
            }

            if (mdl != null)
            {
                mdl.Disconnect();
                mdl.Dispose();
                mdl = new Module(inputBoard, 8, outputBoard, 8);
            }
            else
            {
                mdl = new Module(inputBoard, 8, outputBoard, 8);
            }

            mdl.IpAddress = IPAddress.Parse(Properties.Settings.Default.clientIP);
            mdl.Port = Int32.Parse(Properties.Settings.Default.clientPort);

            if (Properties.Settings.Default.clientAlwaysSync)
            {
                statusSync.Enabled = true;
                mdl.AutoSync = true;
                mdl.AutoSyncInterval = (int)Properties.Settings.Default.clientSynTime;
            }
            else
            {
                statusSync.Enabled = false;
                mdl.AutoSync = false;
            }

            // SUBSCRIPTIONS TO MODULE EVENTS //
            mdl.ConnectionEvent += new ConnectionEventHandler(ConnectionEventUpdated);
            mdl.NetworkUpdatedEvent += new NetworkUpdatedEventHandler(NetworkInfoUpdated);
            mdl.RTCUpdatedEvent += new RTCUpdatedEventHandler(RTCUpdated);
            mdl.OutputDigitalPinChangedEvent += new DigitalPinChangedEventHandler(OutputDigitalPinUpdated);
            mdl.OutputAnalogPinChangedEvent += new AnalogPinChangedEventHandler(OutputAnalogPinUpdated);
            mdl.InputDigitalPinChangedEvent += new DigitalPinChangedEventHandler(InputDigitalPinUpdated);
            mdl.InputAnalogPinChangedEvent += new AnalogPinChangedEventHandler(InputAnalogPinUpdated);
        }
        
        private void InitAutoSync()
        {
            if (Properties.Settings.Default.clientAlwaysSync)
            {
                statusSync.Enabled = true;
                mdl.AutoSync = true;
                mdl.AutoSyncInterval = (int)Properties.Settings.Default.clientSynTime;
                if (LogCommands) logger.Info("Auto Sync enabled. Auto Sync will occur every {0} sec.", (mdl.AutoSyncInterval / 1000).ToString());
            }
            else
            {
                statusSync.Enabled = false;
                mdl.AutoSync = false;
                if (LogCommands) logger.Info("Auto Sync disabled.");
            }
        }
        #endregion
               
        #region // MODULE I/O, CONNECTION AND SETTINGS UPDATE EVENT HANDLING METHODS //
        void ConnectionEventUpdated(Module sender, HomePLC.Model.ConnectionState state)
        {
            switch (state)
            {
                case HomePLC.Model.ConnectionState.Connecting:
                    statusCLabel.Text = "Connecting...";
                    break;
                case HomePLC.Model.ConnectionState.Connected:
                    tbConnect.Text = "Dis&connect";
                    tbConnect.Image = Properties.Resources.RedButton;
                    grpDigitalOutputs.Enabled = true;
                    grpAnalogOutputs.Enabled = true;
                    grpDigitalInputs.Enabled = true;
                    grpAnalogInputs.Enabled = true;
                    statusCLabel.Text = "Connected.";
                    logger.Trace("GUI connected to HomePLC module!");
                    break;
                case HomePLC.Model.ConnectionState.Disconnected:
                    tbConnect.Text = "&Connect";
                    tbConnect.Image = Properties.Resources.GreenButton;
                    grpDigitalOutputs.Enabled = false;
                    grpAnalogOutputs.Enabled = false;
                    grpDigitalInputs.Enabled = false;
                    grpAnalogInputs.Enabled = false;
                    statusCLabel.Text = "Disconnected.";
                    logger.Trace(" GUI disconnected from HomePLC module!");
                    break;
                case HomePLC.Model.ConnectionState.UnableToConnect:
                    statusCLabel.Text = "Unable to connect!";
                    logger.Error("Unable to connect to HomePLC! Check network cable, etc...");
                    break;
                case HomePLC.Model.ConnectionState.ProtocolError:
                    logger.Error("HomePLC report's Protocol error!");
                    break;
                case HomePLC.Model.ConnectionState.Disconnecting:
                    tbConnect.Text = "&Connect";
                    tbConnect.Image = Properties.Resources.GreenButton;
                    grpDigitalOutputs.Enabled = false;
                    grpAnalogInputs.Enabled = false;
                    grpAnalogOutputs.Enabled = false;
                    grpDigitalInputs.Enabled = false;
                    break;
            }
        }
        
        void NetworkInfoUpdated(Module sender, UpdateInfo update, IPAddress address)
        {
            switch (update)
            {
                case UpdateInfo.IPAddressUpdated:
                    logger.Info("Device IP address updated to: {0} !", address.ToString());
                    Properties.Settings.Default.devIP = address.ToString();
                    Properties.Settings.Default.Save();
                    break;
                case UpdateInfo.NetmaskUpdated:
                    logger.Info("Device Netmask updated to: {0} !", address.ToString());
                    Properties.Settings.Default.devNetmask = address.ToString();
                    Properties.Settings.Default.Save();
                    break;
                case UpdateInfo.GatewayUpdated:
                    logger.Info("Device Gateway updated to: {0} !", address.ToString());
                    Properties.Settings.Default.devNetmask = address.ToString();
                    Properties.Settings.Default.Save();
                    break;       
            }
        }
        
        void RTCUpdated(Module sender, UpdateInfo update, DateTime rtc, bool burnedToDevice)
        {
            switch (update)
            {
                case UpdateInfo.RTCUpdated:
                    statusRTC.Text = rtc.ToString();
                    Properties.Settings.Default.rtcTime = rtc;
                    Properties.Settings.Default.Save();
                    if (burnedToDevice)
                        logger.Info("Device Real Time Clock updated to: {0} !", rtc.ToString());
                    break;
                }
        }

        void OutputDigitalPinUpdated(Module sender, int pin, bool value, bool onDevice)
        {
            if (onDevice)
            {
                switch (pin)
                {
                    case 0:
                        if (value)
                        {
                            btnO0D.Text = "ON";
                            btnO0D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnO0D.Text = "OFF";
                            btnO0D.BackColor = Color.Red;
                        }
                        break;

                    case 1:
                        if (value)
                        {
                            btnO1D.Text = "ON";
                            btnO1D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnO1D.Text = "OFF";
                            btnO1D.BackColor = Color.Red;
                        }
                        break;

                    case 2:
                        if (value)
                        {
                            btnO2D.Text = "ON";
                            btnO2D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnO2D.Text = "OFF";
                            btnO2D.BackColor = Color.Red;
                        }
                        break;

                    case 3:
                        if (value)
                        {
                            btnO3D.Text = "ON";
                            btnO3D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnO3D.Text = "OFF";
                            btnO3D.BackColor = Color.Red;
                        }
                        break;

                    case 4:
                        if (value)
                        {
                            btnO4D.Text = "ON";
                            btnO4D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnO4D.Text = "OFF";
                            btnO4D.BackColor = Color.Red;
                        }
                        break;

                    case 5:
                        if (value)
                        {
                            btnO5D.Text = "ON";
                            btnO5D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnO5D.Text = "OFF";
                            btnO5D.BackColor = Color.Red;
                        }
                        break;

                    case 6:
                        if (value)
                        {
                            btnO6D.Text = "ON";
                            btnO6D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnO6D.Text = "OFF";
                            btnO6D.BackColor = Color.Red;
                        }
                        break;

                    case 7:
                        if (value)
                        {
                            btnO7D.Text = "ON";
                            btnO7D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnO7D.Text = "OFF";
                            btnO7D.BackColor = Color.Red;
                        }
                        break;
                }
                logger.Info("Digital OUTPUT pin: " + pin.ToString() + ", STATE changed to: " + value.ToString());
            }
            else
            {
                if (LogCommands) logger.Info("Changing digital output pin: " + pin.ToString() + " state to: " + value.ToString());
            }
        }

        void OutputAnalogPinUpdated(Module sender, int pin, byte value, bool onDevice)
        {
            if (onDevice)
            {
                switch (pin)
                {
                    case 0:
                        trackO0A.Value = value;
                        numO0A.Value = value;
                        break;
                    case 1:
                        trackO1A.Value = value;
                        numO1A.Value = value;
                        break;
                    case 2:
                        trackO2A.Value = value;
                        numO2A.Value = value;
                        break;
                    case 3:
                        trackO3A.Value = value;
                        numO3A.Value = value;
                        break;
                    case 4:
                        trackO4A.Value = value;
                        numO4A.Value = value;
                        break;
                    case 5:
                        trackO5A.Value = value;
                        numO5A.Value = value;
                        break;
                    case 6:
                        trackO6A.Value = value;
                        numO6A.Value = value;
                        break;
                    case 7:
                        trackO7A.Value = value;
                        numO7A.Value = value;
                        break;
                }
                logger.Info("Analog OUTPUT pin: " + pin.ToString() + ", VALUE changed to: " + value.ToString());
            }
            else
            {
                if (LogCommands) logger.Info("Changing analog output pin: " + pin.ToString() + " value to: " + value.ToString());
            }
        }

        void InputDigitalPinUpdated(Module sender, int pin, bool value, bool onDevice)
        {
            if (onDevice)
            {
                switch (pin)
                {
                    case 0:
                        if (value)
                        {
                            btnI0D.Text = "ON";
                            btnI0D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnI0D.Text = "OFF";
                            btnI0D.BackColor = Color.Red;
                        }
                        break;

                    case 1:
                        if (value)
                        {
                            btnI1D.Text = "ON";
                            btnI1D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnI1D.Text = "OFF";
                            btnI1D.BackColor = Color.Red;
                        }
                        break;

                    case 2:
                        if (value)
                        {
                            btnI2D.Text = "ON";
                            btnI2D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnI2D.Text = "OFF";
                            btnI2D.BackColor = Color.Red;
                        }
                        break;

                    case 3:
                        if (value)
                        {
                            btnI3D.Text = "ON";
                            btnI3D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnI3D.Text = "OFF";
                            btnI3D.BackColor = Color.Red;
                        }
                        break;

                    case 4:
                        if (value)
                        {
                            btnI4D.Text = "ON";
                            btnI4D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnI4D.Text = "OFF";
                            btnI4D.BackColor = Color.Red;
                        }
                        break;

                    case 5:
                        if (value)
                        {
                            btnI5D.Text = "ON";
                            btnI5D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnI5D.Text = "OFF";
                            btnI5D.BackColor = Color.Red;
                        }
                        break;

                    case 6:
                        if (value)
                        {
                            btnI6D.Text = "ON";
                            btnI6D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnI6D.Text = "OFF";
                            btnI6D.BackColor = Color.Red;
                        }
                        break;

                    case 7:
                        if (value)
                        {
                            btnI7D.Text = "ON";
                            btnI7D.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            btnI7D.Text = "OFF";
                            btnI7D.BackColor = Color.Red;
                        }
                        break;
                }
                myEvent = new TriggeringEvent(TriggeringEventType.ModuleEvent, pin, value);
                logger.Info("Digital INPUT pin: " + pin.ToString() + ", STATE changed to: " + value.ToString());
            }
        }

        void InputAnalogPinUpdated(Module sender, int pin, byte value, bool onDevice)
        {
            if (onDevice)
            {
                switch (pin)
                {
                    case 0:
                        barI0A.Value = value;
                        txtI0A.Text = value.ToString();
                        break;

                    case 1:
                        barI1A.Value = value;
                        txtI1A.Text = value.ToString();
                        break;

                    case 2:
                        barI2A.Value = value;
                        txtI2A.Text = value.ToString();
                        break;

                    case 3:
                        barI3A.Value = value;
                        txtI3A.Text = value.ToString();
                        break;

                    case 4:
                        barI4A.Value = value;
                        txtI4A.Text = value.ToString();
                        break;

                    case 5:
                        barI5A.Value = value;
                        txtI5A.Text = value.ToString();
                        break;

                    case 6:
                        barI6A.Value = value;
                        txtI6A.Text = value.ToString();
                        break;

                    case 7:
                        barI7A.Value = value;
                        txtI7A.Text = value.ToString();
                        break;
                }
                logger.Info("Analog INPUT pin: " + pin.ToString() + ", VALUE changed to: " + value.ToString());
            }
        }
        #endregion

        #region // DIGITAL OUTPUT BUTTONS CLICK METHODS//
        private void btnD0_Click(object sender, EventArgs e)
        {
            if (btnO0D.Text == "OFF")
                mdl.OutputDigitalPin[0] = true;
            else
                mdl.OutputDigitalPin[0] = false;
        }
       
        private void btnD1_Click(object sender, EventArgs e)
        {
            if (btnO1D.Text == "OFF")
                mdl.OutputDigitalPin[1] = true;
            else
                mdl.OutputDigitalPin[1] = false;
        }
        
        private void btnD2_Click(object sender, EventArgs e)
        {
            if (btnO2D.Text == "OFF")
                mdl.OutputDigitalPin[2] = true;
            else
                mdl.OutputDigitalPin[2] = false;
        }
        
        private void btnD3_Click(object sender, EventArgs e)
        {
            if (btnO3D.Text == "OFF")
                mdl.OutputDigitalPin[3] = true;
            else
                mdl.OutputDigitalPin[3] = false;
        }
        
        private void btnD4_Click(object sender, EventArgs e)
        {
            if (btnO4D.Text == "OFF")
                mdl.OutputDigitalPin[4] = true;
            else
                mdl.OutputDigitalPin[4] = false;
        }
        
        private void btnD5_Click(object sender, EventArgs e)
        {
            if (btnO5D.Text == "OFF")
                mdl.OutputDigitalPin[5] = true;
            else
                mdl.OutputDigitalPin[5] = false;
        }
        
        private void btnD6_Click(object sender, EventArgs e)
        {
            if (btnO6D.Text == "OFF")
                mdl.OutputDigitalPin[6] = true;
            else
                mdl.OutputDigitalPin[6] = false;
        }
        
        private void btnD7_Click(object sender, EventArgs e)
        {
            if (btnO7D.Text == "OFF")
                mdl.OutputDigitalPin[7] = true;
            else
                mdl.OutputDigitalPin[7] = false;
        }
        #endregion

        #region // ANALOG OUTPUT TRACKBAR VALUE AND NUMERIC CONTROL METHODS//
        private void trackO0A_ValueChanged(object sender, EventArgs e)
        {
            numO0A.Value = trackO0A.Value;
        }
        
        private void trackO1A_ValueChanged(object sender, EventArgs e)
        {
            numO1A.Value = trackO1A.Value;
        }
        
        private void trackO2A_ValueChanged(object sender, EventArgs e)
        {
            numO2A.Value = trackO2A.Value;
        }
        
        private void trackO3A_ValueChanged(object sender, EventArgs e)
        {
            numO3A.Value = trackO3A.Value;
        }
        
        private void trackO4A_ValueChanged(object sender, EventArgs e)
        {
            numO4A.Value = trackO4A.Value;
        }
        
        private void trackO5A_ValueChanged(object sender, EventArgs e)
        {
            numO5A.Value = trackO5A.Value;
        }
        
        private void trackO6A_ValueChanged(object sender, EventArgs e)
        {
            numO6A.Value = trackO6A.Value;
        }
        
        private void trackO7A_ValueChanged(object sender, EventArgs e)
        {
            numO7A.Value = trackO7A.Value;
        }


        private void numO0A_ValueChanged(object sender, EventArgs e)
        {
            mdl.OutputAnalogPin[0] = (byte)numO0A.Value;  
        }
        
        private void numO1A_ValueChanged(object sender, EventArgs e)
        {
            mdl.OutputAnalogPin[1] = (byte)numO1A.Value;
        }
        
        private void numO2A_ValueChanged(object sender, EventArgs e)
        {
            mdl.OutputAnalogPin[2] = (byte)numO2A.Value;
        }
        
        private void numO3A_ValueChanged(object sender, EventArgs e)
        {
            mdl.OutputAnalogPin[3] = (byte)numO3A.Value;
        }
        
        private void numO4A_ValueChanged(object sender, EventArgs e)
        {
            mdl.OutputAnalogPin[4] = (byte)numO4A.Value;
        }
        
        private void numO5A_ValueChanged(object sender, EventArgs e)
        {
            mdl.OutputAnalogPin[5] = (byte)numO5A.Value;
        }
        
        private void numO6A_ValueChanged(object sender, EventArgs e)
        {
            mdl.OutputAnalogPin[6] = (byte)numO6A.Value;
        }
        
        private void numO7A_ValueChanged(object sender, EventArgs e)
        {
            mdl.OutputAnalogPin[7] = (byte)numO7A.Value;
        }
        #endregion

        #region // TOOLBAR BUTTONS //
        private void tbConnect_Click(object sender, EventArgs e)
        {
            if (tbConnect.Text == "&Connect")
                mdl.Connect();
            else
                mdl.Disconnect();
        }

        private void tbSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingz = new SettingsForm();
            settingz.ShowDialog(this);

            if (settingz.DialogResult == DialogResult.OK)
            {   // Write data into PLC
                if (settingz.BurnNetData)
                { 
                    mdl.SetIPAddress(IPAddress.Parse(settingz.DevIP));
                    mdl.SetNetmask(IPAddress.Parse(settingz.DevMask));
                    mdl.SetGateway(IPAddress.Parse(settingz.DevGate));
                }
                if (settingz.BurnRTCData)
                {
                    mdl.SetRTC(settingz.RTCdata);
                }
                if (mdl.InputBoard != settingz.Input || mdl.OutputBoard != settingz.Output)
                {
                    InitModule(settingz.Input, settingz.Output);
                }
                if (mdl.AutoSyncInterval != settingz.SyncTime)
                {
                    mdl.AutoSyncInterval = (int) settingz.SyncTime;
                }
                if (mdl.AutoSync != settingz.ApplicationSyncCheck)
                {
                    InitAutoSync();
                }
            }
        }

        private void tbRemote_Click(object sender, EventArgs e)
        {
            if (!myServiceHost.IsStarted)
            {
                myServiceHost.Start();

                if (myServiceHost.IsStarted)
                {
                    tbRemote.Image = Properties.Resources.remotePhoneOn;
                    logger.Debug(myServiceHost.HostUri.ToString());
                }
            }
            else
            {
                myServiceHost.Stop();
                if (!myServiceHost.IsStarted)
                    tbRemote.Image = Properties.Resources.remotePhoneOff;

            }
        }

        private void tbAbout_Click(object sender, EventArgs e)
        {
            using (AboutForm af = new AboutForm())
            {
                af.ShowDialog(this);
            }
        }
        #endregion

        #region // LOGVIEW BUTTONS //
        private void chkUserLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUserLog.Checked)
            {
                LogCommands = true;
            }
            else
            {
                LogCommands = false;
            }
        }  
      
        private void chkDebugLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDebugLog.Checked)
            {
                mdl.Debug = true;
            }
            else
            {
                mdl.Debug = false;
            }
        }
        
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }
        #endregion

        #region // AUTOMATIZATION TAB //
        /* SCRIPTS */
        private void btnAddScript_Click(object sender, EventArgs e)
        {
            Script s = new Script("Script " + scriptEngine.Count.ToString());

            using (EditScriptForm edtSF = new EditScriptForm(s))
            {
                if (edtSF.ShowDialog(this) == DialogResult.OK)
                {
                    scriptEngine.Add(s);
                }
            }       
        }
        
        private void btnEditScript_Click(object sender, EventArgs e)
        {
            Script s = scriptBS.Current as Script;
            
            if (s != null)
            {
                using (EditScriptForm edtSF = new EditScriptForm(s))
                {
                    edtSF.ShowDialog(this);
                }
            }
        }
        
        private void btnRemScript_Click(object sender, EventArgs e)
        {
            Script s = scriptBS.Current as Script;
            scriptEngine.Remove(s);
        }
        
        private void btnTrigScript_Click(object sender, EventArgs e)
        {
            Script s = scriptBS.Current as Script;

            if (s != null)
            {
                s.Enabled = !s.Enabled;
            }
        }
        
        private void btnExecScript_Click(object sender, EventArgs e)
        {
            Script s = scriptBS.Current as Script;

            if (s != null)
            {
                s.Execute(mdl);
            }
        }
        
        private void btnExportScripts_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                scriptEngine.Save(saveFileDialog.FileName);
            }
        }
        
        private void brnImportScripts_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                scriptEngine.Load(openFileDialog.FileName);
                ScriptCurrentChanged(null, null);
            }
        }
        
        /* TRIGGERS */
        private void chkTriggers_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTriggers.Checked)
            {
                chkActions.Checked = false;
                panelTriggers.Visible = true;
                panelScripts.Visible = false;
            }
        }
        
        private void chkActions_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActions.Checked)
            {
                chkTriggers.Checked = false;
                panelScripts.Visible = true;
                panelTriggers.Visible = false;
            }
        }
        
        private void btnAddTrigger_Click(object sender, EventArgs e)
        {
            using (SelectTriggerForm form = new SelectTriggerForm())
            { 
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Type triggerType = form.TriggerType;

                    BaseTrigger item = (Activator.CreateInstance(triggerType)) as BaseTrigger;
                    
                    if (item.ConfigureSelf(scriptEngine))
                    {
                        triggerEngine.Triggers.Add(item);
                        lbTriggers.Items.Add(item);
                    }
                }
            }
        }
        
        private void brnRemTriggers_Click(object sender, EventArgs e)
        {
            if (lbTriggers.SelectedItem != null)
            {
                triggerEngine.Triggers.Remove(lbTriggers.SelectedItem as BaseTrigger);
                lbTriggers.Items.Remove(lbTriggers.SelectedItem);
            }
        }
        
        private void btnConfigTrigger_Click(object sender, EventArgs e)
        {
            if (lbTriggers.SelectedItem != null)
            {
                if (lbTriggers.SelectedItem is BaseTrigger)
                {
                    BaseTrigger item = lbTriggers.SelectedItem as BaseTrigger;
                    item.ConfigureSelf(scriptEngine);
                }
            }
        }
        #endregion

        // HELPER METHODS
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (triggerEngine.Triggers.Count > 0)
            {
                if (myEvent != null)
                {
                    ProcessDogadjaj(myEvent);
                }

                myEvent = new TriggeringEvent(TriggeringEventType.TimeEvent, DateTime.Now);
                ProcessDogadjaj(myEvent);
            }
        }
        
        private void ProcessDogadjaj(TriggeringEvent dogadjaj)
        {
            foreach (BaseTrigger item in triggerEngine.Triggers)
            {
                if (item.InterestedInEvent(dogadjaj))
                {
                    item.Trigger(dogadjaj,mdl);
                    break;
                }
            }
        }

        
    } 
}
