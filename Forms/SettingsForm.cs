using System;
using System.Windows.Forms;
using HomePLC.Model;

namespace HomePLC.Forms
{
    public partial class SettingsForm : BaseForm
    {
        
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.devOutputBoard == BoardType.Analog)
                analogOut.Checked = true;
            else
                digitalOut.Checked = true;

            if (Properties.Settings.Default.devInputBoard == BoardType.Analog)
                analogInput.Checked = true;
            else
                digitalInput.Checked = true;

            txtDevIP.Text = Properties.Settings.Default.devIP;
            txtDevPort.Text = Properties.Settings.Default.devPort;
            txtDevMask.Text = Properties.Settings.Default.devNetmask;
            txtDevGateway.Text = Properties.Settings.Default.devGateway;
            dateRTC.Value = Properties.Settings.Default.rtcTime;
        }

        public BoardType Output
        {
            get { return Properties.Settings.Default.devOutputBoard; }
            set { Properties.Settings.Default.devOutputBoard = value; }
        }
        public BoardType Input
        {
            get { return Properties.Settings.Default.devInputBoard; }
            set { Properties.Settings.Default.devInputBoard = value; }
        }
        public string ApplicationIP
        {
            get { return txtAppIP.Text; }
        }
        public string ApplicationPort
        {
            get { return txtAppPort.Text; }
        }
        public bool ApplicationSyncCheck
        {
            get { return chkAlwaysSync.Checked; }
        }
        public decimal SyncTime
        {
            get { return numTime.Value; }
        }
        public bool BurnNetData
        {
            get { return chkBurnNetwork.Checked; }
            set { }
        }
        public bool BurnRTCData
        {
            get { return chkBurnRTC.Checked; }
            set { }
        }
        public string DevIP
        {
            get { return txtDevIP.Text; }
            set { }
        }
        public string DevPort
        {
            get { return txtDevPort.Text; }
            set { }
        }
        public string DevMask
        {
            get { return txtDevMask.Text; }
            set { }
        }
        public string DevGate
        {
            get { return txtDevGateway.Text; }
            set { }
        }
        public DateTime RTCdata
        {
            get { return dateRTC.Value; }
            set { }
        }

        private void chkAlwaysSync_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void analogOut_CheckedChanged(object sender, EventArgs e)
        {
            if (analogOut.Checked)
                Output = BoardType.Analog;
            else
                Output = BoardType.Digital;
        }
        private void digitalOut_CheckedChanged(object sender, EventArgs e)
        {
            if (digitalOut.Checked)
                Output = BoardType.Digital;
            else
                Output = BoardType.Analog;
        }

        private void analogInput_CheckedChanged(object sender, EventArgs e)
        {
            if (analogInput.Checked)
                Input = BoardType.Analog;
            else
                Input = BoardType.Digital;
        }
        private void digitalInput_CheckedChanged(object sender, EventArgs e)
        {
            if (digitalInput.Checked)
                Input = BoardType.Digital;
            else
                Input = BoardType.Analog;
        }
        private void numTime_ValueChanged(object sender, EventArgs e)
        {
            if (numTime.Value < 1000)
                numTime.Value = 1000;
            else if (numTime.Value > 9999999)
                numTime.Value = 9999999;
            Properties.Settings.Default.clientSynTime = numTime.Value;
        }
     
        // TAB 2 : Device  settings //
        private void chkCurrentTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCurrentTime.Checked)
                refreshTimePicker.Start();
            else
                refreshTimePicker.Stop();
        }
        private void refreshTimePicker_Tick(object sender, EventArgs e)
        {
            dateRTC.Value = DateTime.Now;
        }  
        private void chkBurnNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBurnNetwork.Checked)
                BurnNetData = true;
            else
                BurnNetData = false;
        }
        private void chkBurnRTC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBurnRTC.Checked)
                BurnRTCData = true;
            else
                BurnRTCData = false;
                
        }

        // OK / CLOSE BUTTOS//
        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            this.Dispose();
        }
        
    }

}
