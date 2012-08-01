namespace HomePLC.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGui = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.digitalOut = new System.Windows.Forms.RadioButton();
            this.analogOut = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkAlwaysSync = new System.Windows.Forms.CheckBox();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAppPort = new System.Windows.Forms.TextBox();
            this.txtAppIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.digitalInput = new System.Windows.Forms.RadioButton();
            this.analogInput = new System.Windows.Forms.RadioButton();
            this.tabModule = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkBurnRTC = new System.Windows.Forms.CheckBox();
            this.chkCurrentTime = new System.Windows.Forms.CheckBox();
            this.dateRTC = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkBurnNetwork = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDevGateway = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDevMask = new System.Windows.Forms.TextBox();
            this.txtDevIP = new System.Windows.Forms.TextBox();
            this.txtDevPort = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.refreshTimePicker = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tabGui.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabModule.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGui);
            this.tabControl.Controls.Add(this.tabModule);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(377, 276);
            this.tabControl.TabIndex = 5;
            // 
            // tabGui
            // 
            this.tabGui.BackColor = System.Drawing.SystemColors.Window;
            this.tabGui.Controls.Add(this.groupBox1);
            this.tabGui.Controls.Add(this.groupBox7);
            this.tabGui.Controls.Add(this.groupBox6);
            this.tabGui.Controls.Add(this.groupBox3);
            this.tabGui.Controls.Add(this.groupBox2);
            this.tabGui.Location = new System.Drawing.Point(4, 22);
            this.tabGui.Name = "tabGui";
            this.tabGui.Padding = new System.Windows.Forms.Padding(3);
            this.tabGui.Size = new System.Drawing.Size(369, 250);
            this.tabGui.TabIndex = 1;
            this.tabGui.Text = "Application";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.digitalOut);
            this.groupBox1.Controls.Add(this.analogOut);
            this.groupBox1.Location = new System.Drawing.Point(272, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(90, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Board";
            // 
            // digitalOut
            // 
            this.digitalOut.Location = new System.Drawing.Point(17, 47);
            this.digitalOut.Name = "digitalOut";
            this.digitalOut.Size = new System.Drawing.Size(54, 17);
            this.digitalOut.TabIndex = 1;
            this.digitalOut.Text = "Digital";
            this.digitalOut.UseVisualStyleBackColor = true;
            this.digitalOut.CheckedChanged += new System.EventHandler(this.digitalOut_CheckedChanged);
            // 
            // analogOut
            // 
            this.analogOut.Location = new System.Drawing.Point(17, 24);
            this.analogOut.Name = "analogOut";
            this.analogOut.Size = new System.Drawing.Size(58, 17);
            this.analogOut.TabIndex = 0;
            this.analogOut.Text = "Analog";
            this.analogOut.CheckedChanged += new System.EventHandler(this.analogOut_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(7, 179);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(355, 65);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Log Viewer";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.chkAlwaysSync);
            this.groupBox6.Controls.Add(this.numTime);
            this.groupBox6.Location = new System.Drawing.Point(7, 98);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(256, 74);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Syncronisation";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "AutoSync interval:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ms.";
            // 
            // chkAlwaysSync
            // 
            this.chkAlwaysSync.AutoSize = true;
            this.chkAlwaysSync.Checked = global::HomePLC.Properties.Settings.Default.clientAlwaysSync;
            this.chkAlwaysSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlwaysSync.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::HomePLC.Properties.Settings.Default, "clientAlwaysSync", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkAlwaysSync.Location = new System.Drawing.Point(16, 24);
            this.chkAlwaysSync.Name = "chkAlwaysSync";
            this.chkAlwaysSync.Size = new System.Drawing.Size(230, 17);
            this.chkAlwaysSync.TabIndex = 4;
            this.chkAlwaysSync.Text = "Start AutoSync when connected to device.";
            this.chkAlwaysSync.UseVisualStyleBackColor = true;
            this.chkAlwaysSync.CheckedChanged += new System.EventHandler(this.chkAlwaysSync_CheckedChanged);
            // 
            // numTime
            // 
            this.numTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::HomePLC.Properties.Settings.Default, "clientSynTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numTime.Location = new System.Drawing.Point(132, 44);
            this.numTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.Size = new System.Drawing.Size(85, 20);
            this.numTime.TabIndex = 12;
            this.numTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTime.Value = global::HomePLC.Properties.Settings.Default.clientSynTime;
            this.numTime.ValueChanged += new System.EventHandler(this.numTime_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAppPort);
            this.groupBox3.Controls.Add(this.txtAppIP);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(6, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 75);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Network";
            // 
            // txtAppPort
            // 
            this.txtAppPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::HomePLC.Properties.Settings.Default, "clientPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtAppPort.Location = new System.Drawing.Point(167, 44);
            this.txtAppPort.Name = "txtAppPort";
            this.txtAppPort.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAppPort.Size = new System.Drawing.Size(72, 20);
            this.txtAppPort.TabIndex = 3;
            this.txtAppPort.Text = global::HomePLC.Properties.Settings.Default.clientPort;
            // 
            // txtAppIP
            // 
            this.txtAppIP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::HomePLC.Properties.Settings.Default, "clientIP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtAppIP.Location = new System.Drawing.Point(124, 18);
            this.txtAppIP.Name = "txtAppIP";
            this.txtAppIP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAppIP.Size = new System.Drawing.Size(115, 20);
            this.txtAppIP.TabIndex = 2;
            this.txtAppIP.Text = global::HomePLC.Properties.Settings.Default.clientIP;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "IP Address:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.digitalInput);
            this.groupBox2.Controls.Add(this.analogInput);
            this.groupBox2.Location = new System.Drawing.Point(272, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(90, 75);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Board";
            // 
            // digitalInput
            // 
            this.digitalInput.Location = new System.Drawing.Point(17, 47);
            this.digitalInput.Name = "digitalInput";
            this.digitalInput.Size = new System.Drawing.Size(54, 17);
            this.digitalInput.TabIndex = 3;
            this.digitalInput.Text = "Digital";
            this.digitalInput.UseVisualStyleBackColor = true;
            this.digitalInput.CheckedChanged += new System.EventHandler(this.digitalInput_CheckedChanged);
            // 
            // analogInput
            // 
            this.analogInput.Location = new System.Drawing.Point(17, 24);
            this.analogInput.Name = "analogInput";
            this.analogInput.Size = new System.Drawing.Size(58, 17);
            this.analogInput.TabIndex = 2;
            this.analogInput.Text = "Analog";
            this.analogInput.UseVisualStyleBackColor = true;
            this.analogInput.CheckedChanged += new System.EventHandler(this.analogInput_CheckedChanged);
            // 
            // tabModule
            // 
            this.tabModule.BackColor = System.Drawing.SystemColors.Window;
            this.tabModule.Controls.Add(this.groupBox5);
            this.tabModule.Controls.Add(this.groupBox4);
            this.tabModule.Location = new System.Drawing.Point(4, 22);
            this.tabModule.Name = "tabModule";
            this.tabModule.Padding = new System.Windows.Forms.Padding(3);
            this.tabModule.Size = new System.Drawing.Size(369, 250);
            this.tabModule.TabIndex = 0;
            this.tabModule.Text = "Device";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.chkBurnRTC);
            this.groupBox5.Controls.Add(this.chkCurrentTime);
            this.groupBox5.Controls.Add(this.dateRTC);
            this.groupBox5.Location = new System.Drawing.Point(6, 171);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(358, 73);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RTC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Time:";
            // 
            // chkBurnRTC
            // 
            this.chkBurnRTC.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBurnRTC.Location = new System.Drawing.Point(256, 19);
            this.chkBurnRTC.Name = "chkBurnRTC";
            this.chkBurnRTC.Size = new System.Drawing.Size(92, 43);
            this.chkBurnRTC.TabIndex = 11;
            this.chkBurnRTC.Text = "Upload to device";
            this.chkBurnRTC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBurnRTC.UseVisualStyleBackColor = true;
            this.chkBurnRTC.CheckedChanged += new System.EventHandler(this.chkBurnRTC_CheckedChanged);
            // 
            // chkCurrentTime
            // 
            this.chkCurrentTime.AutoSize = true;
            this.chkCurrentTime.Location = new System.Drawing.Point(160, 45);
            this.chkCurrentTime.Name = "chkCurrentTime";
            this.chkCurrentTime.Size = new System.Drawing.Size(85, 17);
            this.chkCurrentTime.TabIndex = 1;
            this.chkCurrentTime.Text = "Current time.";
            this.chkCurrentTime.UseVisualStyleBackColor = true;
            this.chkCurrentTime.CheckedChanged += new System.EventHandler(this.chkCurrentTime_CheckedChanged);
            // 
            // dateRTC
            // 
            this.dateRTC.CustomFormat = "  ddd dd, hh:mm:ss";
            this.dateRTC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateRTC.Location = new System.Drawing.Point(57, 19);
            this.dateRTC.Name = "dateRTC";
            this.dateRTC.Size = new System.Drawing.Size(188, 20);
            this.dateRTC.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkBurnNetwork);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtDevGateway);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtDevMask);
            this.groupBox4.Controls.Add(this.txtDevIP);
            this.groupBox4.Controls.Add(this.txtDevPort);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 159);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Network";
            // 
            // chkBurnNetwork
            // 
            this.chkBurnNetwork.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBurnNetwork.Location = new System.Drawing.Point(256, 99);
            this.chkBurnNetwork.Name = "chkBurnNetwork";
            this.chkBurnNetwork.Size = new System.Drawing.Size(92, 44);
            this.chkBurnNetwork.TabIndex = 10;
            this.chkBurnNetwork.Text = "Upload to device";
            this.chkBurnNetwork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBurnNetwork.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Subnet mask:";
            // 
            // txtDevGateway
            // 
            this.txtDevGateway.Location = new System.Drawing.Point(113, 123);
            this.txtDevGateway.Name = "txtDevGateway";
            this.txtDevGateway.Size = new System.Drawing.Size(132, 20);
            this.txtDevGateway.TabIndex = 7;
            this.txtDevGateway.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Default Gateway:";
            // 
            // txtDevMask
            // 
            this.txtDevMask.Location = new System.Drawing.Point(114, 92);
            this.txtDevMask.Name = "txtDevMask";
            this.txtDevMask.Size = new System.Drawing.Size(131, 20);
            this.txtDevMask.TabIndex = 6;
            this.txtDevMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDevIP
            // 
            this.txtDevIP.Location = new System.Drawing.Point(114, 30);
            this.txtDevIP.Name = "txtDevIP";
            this.txtDevIP.Size = new System.Drawing.Size(131, 20);
            this.txtDevIP.TabIndex = 4;
            this.txtDevIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDevPort
            // 
            this.txtDevPort.Location = new System.Drawing.Point(114, 61);
            this.txtDevPort.Name = "txtDevPort";
            this.txtDevPort.Size = new System.Drawing.Size(131, 20);
            this.txtDevPort.TabIndex = 5;
            this.txtDevPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(233, 294);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(314, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // refreshTimePicker
            // 
            this.refreshTimePicker.Tick += new System.EventHandler(this.refreshTimePicker_Tick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 324);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabGui.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabModule.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabGui;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAppPort;
        private System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.TextBox txtAppIP;
        private System.Windows.Forms.CheckBox chkAlwaysSync;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton digitalInput;
        private System.Windows.Forms.RadioButton analogInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton digitalOut;
        private System.Windows.Forms.RadioButton analogOut;
        private System.Windows.Forms.TabPage tabModule;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkBurnRTC;
        private System.Windows.Forms.CheckBox chkCurrentTime;
        private System.Windows.Forms.DateTimePicker dateRTC;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkBurnNetwork;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDevGateway;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDevMask;
        private System.Windows.Forms.TextBox txtDevIP;
        private System.Windows.Forms.TextBox txtDevPort;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer refreshTimePicker;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox7;
    }
}