namespace HomePLC
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCompiledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIO = new System.Windows.Forms.TabPage();
            this.grpDigitalInputs = new System.Windows.Forms.GroupBox();
            this.btnI7D = new System.Windows.Forms.Button();
            this.btnI6D = new System.Windows.Forms.Button();
            this.btnI5D = new System.Windows.Forms.Button();
            this.btnI4D = new System.Windows.Forms.Button();
            this.btnI3D = new System.Windows.Forms.Button();
            this.btnI2D = new System.Windows.Forms.Button();
            this.btnI1D = new System.Windows.Forms.Button();
            this.btnI0D = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.grpAnalogInputs = new System.Windows.Forms.GroupBox();
            this.txtI7A = new System.Windows.Forms.TextBox();
            this.barI7A = new System.Windows.Forms.ProgressBar();
            this.txtI6A = new System.Windows.Forms.TextBox();
            this.barI6A = new System.Windows.Forms.ProgressBar();
            this.txtI5A = new System.Windows.Forms.TextBox();
            this.barI5A = new System.Windows.Forms.ProgressBar();
            this.txtI4A = new System.Windows.Forms.TextBox();
            this.barI4A = new System.Windows.Forms.ProgressBar();
            this.txtI3A = new System.Windows.Forms.TextBox();
            this.barI3A = new System.Windows.Forms.ProgressBar();
            this.txtI2A = new System.Windows.Forms.TextBox();
            this.barI2A = new System.Windows.Forms.ProgressBar();
            this.txtI1A = new System.Windows.Forms.TextBox();
            this.barI1A = new System.Windows.Forms.ProgressBar();
            this.txtI0A = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.barI0A = new System.Windows.Forms.ProgressBar();
            this.grpDigitalOutputs = new System.Windows.Forms.GroupBox();
            this.btnO7D = new System.Windows.Forms.Button();
            this.btnO6D = new System.Windows.Forms.Button();
            this.btnO5D = new System.Windows.Forms.Button();
            this.btnO4D = new System.Windows.Forms.Button();
            this.btnO3D = new System.Windows.Forms.Button();
            this.btnO2D = new System.Windows.Forms.Button();
            this.btnO1D = new System.Windows.Forms.Button();
            this.btnO0D = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grpAnalogOutputs = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.numO7A = new System.Windows.Forms.NumericUpDown();
            this.numO6A = new System.Windows.Forms.NumericUpDown();
            this.numO5A = new System.Windows.Forms.NumericUpDown();
            this.numO4A = new System.Windows.Forms.NumericUpDown();
            this.numO3A = new System.Windows.Forms.NumericUpDown();
            this.numO2A = new System.Windows.Forms.NumericUpDown();
            this.numO1A = new System.Windows.Forms.NumericUpDown();
            this.numO0A = new System.Windows.Forms.NumericUpDown();
            this.trackO7A = new System.Windows.Forms.TrackBar();
            this.trackO6A = new System.Windows.Forms.TrackBar();
            this.trackO5A = new System.Windows.Forms.TrackBar();
            this.trackO4A = new System.Windows.Forms.TrackBar();
            this.trackO3A = new System.Windows.Forms.TrackBar();
            this.trackO2A = new System.Windows.Forms.TrackBar();
            this.trackO1A = new System.Windows.Forms.TrackBar();
            this.trackO0A = new System.Windows.Forms.TrackBar();
            this.tabScript = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkTriggers = new System.Windows.Forms.CheckBox();
            this.chkActions = new System.Windows.Forms.CheckBox();
            this.panelScripts = new System.Windows.Forms.Panel();
            this.scriptDGV = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCompiledDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.scriptBS = new System.Windows.Forms.BindingSource(this.components);
            this.btnExportScripts = new System.Windows.Forms.Button();
            this.btnAddScript = new System.Windows.Forms.Button();
            this.brnImportScripts = new System.Windows.Forms.Button();
            this.btnTrigScript = new System.Windows.Forms.Button();
            this.btnExecScript = new System.Windows.Forms.Button();
            this.btnEditScript = new System.Windows.Forms.Button();
            this.btnRemScript = new System.Windows.Forms.Button();
            this.panelTriggers = new System.Windows.Forms.Panel();
            this.btnConfigTrigger = new System.Windows.Forms.Button();
            this.brnRemTriggers = new System.Windows.Forms.Button();
            this.btnAddTrigger = new System.Windows.Forms.Button();
            this.lbTriggers = new System.Windows.Forms.ListBox();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.chkDebugLog = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.chkUserLog = new System.Windows.Forms.CheckBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusCLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSpacerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusRTC = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSync = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.tbConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbSettings = new System.Windows.Forms.ToolStripButton();
            this.tbAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbRemote = new System.Windows.Forms.ToolStripButton();
            this.triggerBS = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabIO.SuspendLayout();
            this.grpDigitalInputs.SuspendLayout();
            this.grpAnalogInputs.SuspendLayout();
            this.grpDigitalOutputs.SuspendLayout();
            this.grpAnalogOutputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numO7A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO6A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO5A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO4A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO3A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO2A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO1A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO0A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO7A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO6A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO5A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO4A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO3A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO2A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO1A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO0A)).BeginInit();
            this.tabScript.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelScripts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scriptDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptBS)).BeginInit();
            this.panelTriggers.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.status.SuspendLayout();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triggerBS)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Transfer.png");
            this.imageList.Images.SetKeyName(1, "icon_setting.png");
            this.imageList.Images.SetKeyName(2, "Terminal.png");
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "HomePLC Script Files (*.hsc)|*.hsc";
            this.openFileDialog.Title = "Import HomePLC Script Collection";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "HomePLC script files (*.hsc)|*.hsc";
            this.saveFileDialog.Title = "Export HomePLC Script Collection";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 200;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 250;
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // isCompiledDataGridViewCheckBoxColumn
            // 
            this.isCompiledDataGridViewCheckBoxColumn.DataPropertyName = "IsCompiled";
            this.isCompiledDataGridViewCheckBoxColumn.HeaderText = "IsCompiled";
            this.isCompiledDataGridViewCheckBoxColumn.Name = "isCompiledDataGridViewCheckBoxColumn";
            this.isCompiledDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabIO);
            this.tabControl1.Controls.Add(this.tabScript);
            this.tabControl1.Controls.Add(this.tabLog);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ImageList = this.imageList;
            this.tabControl1.Location = new System.Drawing.Point(0, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 406);
            this.tabControl1.TabIndex = 47;
            // 
            // tabIO
            // 
            this.tabIO.BackColor = System.Drawing.SystemColors.Control;
            this.tabIO.Controls.Add(this.grpDigitalInputs);
            this.tabIO.Controls.Add(this.grpAnalogInputs);
            this.tabIO.Controls.Add(this.grpDigitalOutputs);
            this.tabIO.Controls.Add(this.grpAnalogOutputs);
            this.tabIO.ImageIndex = 0;
            this.tabIO.Location = new System.Drawing.Point(4, 39);
            this.tabIO.Name = "tabIO";
            this.tabIO.Padding = new System.Windows.Forms.Padding(3);
            this.tabIO.Size = new System.Drawing.Size(509, 363);
            this.tabIO.TabIndex = 0;
            this.tabIO.Text = "Input/Output  ";
            // 
            // grpDigitalInputs
            // 
            this.grpDigitalInputs.Controls.Add(this.btnI7D);
            this.grpDigitalInputs.Controls.Add(this.btnI6D);
            this.grpDigitalInputs.Controls.Add(this.btnI5D);
            this.grpDigitalInputs.Controls.Add(this.btnI4D);
            this.grpDigitalInputs.Controls.Add(this.btnI3D);
            this.grpDigitalInputs.Controls.Add(this.btnI2D);
            this.grpDigitalInputs.Controls.Add(this.btnI1D);
            this.grpDigitalInputs.Controls.Add(this.btnI0D);
            this.grpDigitalInputs.Controls.Add(this.label18);
            this.grpDigitalInputs.Controls.Add(this.label28);
            this.grpDigitalInputs.Controls.Add(this.label29);
            this.grpDigitalInputs.Controls.Add(this.label30);
            this.grpDigitalInputs.Controls.Add(this.label31);
            this.grpDigitalInputs.Controls.Add(this.label32);
            this.grpDigitalInputs.Controls.Add(this.label33);
            this.grpDigitalInputs.Controls.Add(this.label34);
            this.grpDigitalInputs.Enabled = false;
            this.grpDigitalInputs.Location = new System.Drawing.Point(8, 21);
            this.grpDigitalInputs.Name = "grpDigitalInputs";
            this.grpDigitalInputs.Size = new System.Drawing.Size(254, 332);
            this.grpDigitalInputs.TabIndex = 41;
            this.grpDigitalInputs.TabStop = false;
            this.grpDigitalInputs.Text = "Inputs: Digital";
            this.grpDigitalInputs.Visible = false;
            // 
            // btnI7D
            // 
            this.btnI7D.BackColor = System.Drawing.SystemColors.Control;
            this.btnI7D.Enabled = false;
            this.btnI7D.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnI7D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnI7D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnI7D.Location = new System.Drawing.Point(86, 291);
            this.btnI7D.Name = "btnI7D";
            this.btnI7D.Size = new System.Drawing.Size(125, 23);
            this.btnI7D.TabIndex = 47;
            this.btnI7D.Text = "OFF";
            this.btnI7D.UseVisualStyleBackColor = false;
            // 
            // btnI6D
            // 
            this.btnI6D.BackColor = System.Drawing.SystemColors.Control;
            this.btnI6D.Enabled = false;
            this.btnI6D.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnI6D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnI6D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnI6D.Location = new System.Drawing.Point(86, 253);
            this.btnI6D.Name = "btnI6D";
            this.btnI6D.Size = new System.Drawing.Size(125, 23);
            this.btnI6D.TabIndex = 46;
            this.btnI6D.Text = "OFF";
            this.btnI6D.UseVisualStyleBackColor = false;
            // 
            // btnI5D
            // 
            this.btnI5D.BackColor = System.Drawing.SystemColors.Control;
            this.btnI5D.Enabled = false;
            this.btnI5D.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnI5D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnI5D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnI5D.Location = new System.Drawing.Point(86, 215);
            this.btnI5D.Name = "btnI5D";
            this.btnI5D.Size = new System.Drawing.Size(125, 23);
            this.btnI5D.TabIndex = 45;
            this.btnI5D.Text = "OFF";
            this.btnI5D.UseVisualStyleBackColor = false;
            // 
            // btnI4D
            // 
            this.btnI4D.BackColor = System.Drawing.SystemColors.Control;
            this.btnI4D.Enabled = false;
            this.btnI4D.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnI4D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnI4D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnI4D.Location = new System.Drawing.Point(86, 177);
            this.btnI4D.Name = "btnI4D";
            this.btnI4D.Size = new System.Drawing.Size(125, 24);
            this.btnI4D.TabIndex = 44;
            this.btnI4D.Text = "OFF";
            this.btnI4D.UseVisualStyleBackColor = false;
            // 
            // btnI3D
            // 
            this.btnI3D.BackColor = System.Drawing.SystemColors.Control;
            this.btnI3D.Enabled = false;
            this.btnI3D.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnI3D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnI3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnI3D.Location = new System.Drawing.Point(86, 139);
            this.btnI3D.Name = "btnI3D";
            this.btnI3D.Size = new System.Drawing.Size(125, 24);
            this.btnI3D.TabIndex = 43;
            this.btnI3D.Text = "OFF";
            this.btnI3D.UseVisualStyleBackColor = false;
            // 
            // btnI2D
            // 
            this.btnI2D.BackColor = System.Drawing.SystemColors.Control;
            this.btnI2D.Enabled = false;
            this.btnI2D.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnI2D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnI2D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnI2D.Location = new System.Drawing.Point(86, 100);
            this.btnI2D.Name = "btnI2D";
            this.btnI2D.Size = new System.Drawing.Size(125, 24);
            this.btnI2D.TabIndex = 42;
            this.btnI2D.Text = "OFF";
            this.btnI2D.UseVisualStyleBackColor = false;
            // 
            // btnI1D
            // 
            this.btnI1D.BackColor = System.Drawing.SystemColors.Control;
            this.btnI1D.Enabled = false;
            this.btnI1D.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnI1D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnI1D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnI1D.Location = new System.Drawing.Point(86, 63);
            this.btnI1D.Name = "btnI1D";
            this.btnI1D.Size = new System.Drawing.Size(125, 24);
            this.btnI1D.TabIndex = 41;
            this.btnI1D.Text = "OFF";
            this.btnI1D.UseVisualStyleBackColor = false;
            // 
            // btnI0D
            // 
            this.btnI0D.BackColor = System.Drawing.SystemColors.Control;
            this.btnI0D.Enabled = false;
            this.btnI0D.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnI0D.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnI0D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnI0D.Location = new System.Drawing.Point(86, 25);
            this.btnI0D.Name = "btnI0D";
            this.btnI0D.Size = new System.Drawing.Size(125, 24);
            this.btnI0D.TabIndex = 40;
            this.btnI0D.Text = "OFF";
            this.btnI0D.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(47, 297);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "7";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(47, 259);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(13, 13);
            this.label28.TabIndex = 22;
            this.label28.Text = "6";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(47, 221);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(13, 13);
            this.label29.TabIndex = 21;
            this.label29.Text = "5";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(47, 183);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 13);
            this.label30.TabIndex = 20;
            this.label30.Text = "4";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(47, 143);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(13, 13);
            this.label31.TabIndex = 19;
            this.label31.Text = "3";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(47, 106);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(13, 13);
            this.label32.TabIndex = 18;
            this.label32.Text = "2";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(47, 69);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(13, 13);
            this.label33.TabIndex = 17;
            this.label33.Text = "1";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(47, 30);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(13, 13);
            this.label34.TabIndex = 16;
            this.label34.Text = "0";
            // 
            // grpAnalogInputs
            // 
            this.grpAnalogInputs.Controls.Add(this.txtI7A);
            this.grpAnalogInputs.Controls.Add(this.barI7A);
            this.grpAnalogInputs.Controls.Add(this.txtI6A);
            this.grpAnalogInputs.Controls.Add(this.barI6A);
            this.grpAnalogInputs.Controls.Add(this.txtI5A);
            this.grpAnalogInputs.Controls.Add(this.barI5A);
            this.grpAnalogInputs.Controls.Add(this.txtI4A);
            this.grpAnalogInputs.Controls.Add(this.barI4A);
            this.grpAnalogInputs.Controls.Add(this.txtI3A);
            this.grpAnalogInputs.Controls.Add(this.barI3A);
            this.grpAnalogInputs.Controls.Add(this.txtI2A);
            this.grpAnalogInputs.Controls.Add(this.barI2A);
            this.grpAnalogInputs.Controls.Add(this.txtI1A);
            this.grpAnalogInputs.Controls.Add(this.barI1A);
            this.grpAnalogInputs.Controls.Add(this.txtI0A);
            this.grpAnalogInputs.Controls.Add(this.label20);
            this.grpAnalogInputs.Controls.Add(this.label21);
            this.grpAnalogInputs.Controls.Add(this.label22);
            this.grpAnalogInputs.Controls.Add(this.label23);
            this.grpAnalogInputs.Controls.Add(this.label24);
            this.grpAnalogInputs.Controls.Add(this.label25);
            this.grpAnalogInputs.Controls.Add(this.label26);
            this.grpAnalogInputs.Controls.Add(this.label27);
            this.grpAnalogInputs.Controls.Add(this.barI0A);
            this.grpAnalogInputs.Enabled = false;
            this.grpAnalogInputs.Location = new System.Drawing.Point(8, 22);
            this.grpAnalogInputs.Name = "grpAnalogInputs";
            this.grpAnalogInputs.Size = new System.Drawing.Size(254, 332);
            this.grpAnalogInputs.TabIndex = 13;
            this.grpAnalogInputs.TabStop = false;
            this.grpAnalogInputs.Text = "Inputs: Analog";
            this.grpAnalogInputs.Visible = false;
            // 
            // txtI7A
            // 
            this.txtI7A.Location = new System.Drawing.Point(50, 294);
            this.txtI7A.Name = "txtI7A";
            this.txtI7A.ReadOnly = true;
            this.txtI7A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtI7A.Size = new System.Drawing.Size(43, 20);
            this.txtI7A.TabIndex = 39;
            this.txtI7A.Text = "0";
            // 
            // barI7A
            // 
            this.barI7A.Location = new System.Drawing.Point(109, 293);
            this.barI7A.Maximum = 255;
            this.barI7A.Name = "barI7A";
            this.barI7A.Size = new System.Drawing.Size(124, 23);
            this.barI7A.Step = 1;
            this.barI7A.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barI7A.TabIndex = 38;
            // 
            // txtI6A
            // 
            this.txtI6A.Location = new System.Drawing.Point(50, 256);
            this.txtI6A.Name = "txtI6A";
            this.txtI6A.ReadOnly = true;
            this.txtI6A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtI6A.Size = new System.Drawing.Size(43, 20);
            this.txtI6A.TabIndex = 37;
            this.txtI6A.Text = "0";
            // 
            // barI6A
            // 
            this.barI6A.Location = new System.Drawing.Point(109, 254);
            this.barI6A.Maximum = 255;
            this.barI6A.Name = "barI6A";
            this.barI6A.Size = new System.Drawing.Size(124, 23);
            this.barI6A.Step = 1;
            this.barI6A.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barI6A.TabIndex = 36;
            // 
            // txtI5A
            // 
            this.txtI5A.Location = new System.Drawing.Point(50, 218);
            this.txtI5A.Name = "txtI5A";
            this.txtI5A.ReadOnly = true;
            this.txtI5A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtI5A.Size = new System.Drawing.Size(43, 20);
            this.txtI5A.TabIndex = 35;
            this.txtI5A.Text = "0";
            // 
            // barI5A
            // 
            this.barI5A.Location = new System.Drawing.Point(109, 216);
            this.barI5A.Maximum = 255;
            this.barI5A.Name = "barI5A";
            this.barI5A.Size = new System.Drawing.Size(124, 23);
            this.barI5A.Step = 1;
            this.barI5A.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barI5A.TabIndex = 34;
            // 
            // txtI4A
            // 
            this.txtI4A.Location = new System.Drawing.Point(50, 180);
            this.txtI4A.Name = "txtI4A";
            this.txtI4A.ReadOnly = true;
            this.txtI4A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtI4A.Size = new System.Drawing.Size(43, 20);
            this.txtI4A.TabIndex = 33;
            this.txtI4A.Text = "0";
            // 
            // barI4A
            // 
            this.barI4A.Location = new System.Drawing.Point(109, 178);
            this.barI4A.Maximum = 255;
            this.barI4A.Name = "barI4A";
            this.barI4A.Size = new System.Drawing.Size(124, 23);
            this.barI4A.Step = 1;
            this.barI4A.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barI4A.TabIndex = 32;
            // 
            // txtI3A
            // 
            this.txtI3A.Location = new System.Drawing.Point(50, 140);
            this.txtI3A.Name = "txtI3A";
            this.txtI3A.ReadOnly = true;
            this.txtI3A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtI3A.Size = new System.Drawing.Size(43, 20);
            this.txtI3A.TabIndex = 31;
            this.txtI3A.Text = "0";
            // 
            // barI3A
            // 
            this.barI3A.Location = new System.Drawing.Point(109, 138);
            this.barI3A.Maximum = 255;
            this.barI3A.Name = "barI3A";
            this.barI3A.Size = new System.Drawing.Size(124, 23);
            this.barI3A.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barI3A.TabIndex = 30;
            // 
            // txtI2A
            // 
            this.txtI2A.Location = new System.Drawing.Point(50, 103);
            this.txtI2A.Name = "txtI2A";
            this.txtI2A.ReadOnly = true;
            this.txtI2A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtI2A.Size = new System.Drawing.Size(43, 20);
            this.txtI2A.TabIndex = 29;
            this.txtI2A.Text = "0";
            // 
            // barI2A
            // 
            this.barI2A.Location = new System.Drawing.Point(109, 101);
            this.barI2A.Maximum = 255;
            this.barI2A.Name = "barI2A";
            this.barI2A.Size = new System.Drawing.Size(124, 23);
            this.barI2A.Step = 1;
            this.barI2A.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barI2A.TabIndex = 28;
            // 
            // txtI1A
            // 
            this.txtI1A.Location = new System.Drawing.Point(50, 66);
            this.txtI1A.Name = "txtI1A";
            this.txtI1A.ReadOnly = true;
            this.txtI1A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtI1A.Size = new System.Drawing.Size(43, 20);
            this.txtI1A.TabIndex = 27;
            this.txtI1A.Text = "0";
            // 
            // barI1A
            // 
            this.barI1A.Location = new System.Drawing.Point(109, 64);
            this.barI1A.Maximum = 255;
            this.barI1A.Name = "barI1A";
            this.barI1A.Size = new System.Drawing.Size(124, 23);
            this.barI1A.Step = 1;
            this.barI1A.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barI1A.TabIndex = 26;
            // 
            // txtI0A
            // 
            this.txtI0A.Location = new System.Drawing.Point(50, 28);
            this.txtI0A.Name = "txtI0A";
            this.txtI0A.ReadOnly = true;
            this.txtI0A.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtI0A.Size = new System.Drawing.Size(43, 20);
            this.txtI0A.TabIndex = 25;
            this.txtI0A.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 297);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 13);
            this.label20.TabIndex = 23;
            this.label20.Text = "7";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 259);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(13, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "6";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(23, 221);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(13, 13);
            this.label22.TabIndex = 21;
            this.label22.Text = "5";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(23, 183);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(13, 13);
            this.label23.TabIndex = 20;
            this.label23.Text = "4";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(23, 145);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(13, 13);
            this.label24.TabIndex = 19;
            this.label24.Text = "3";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(23, 106);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(13, 13);
            this.label25.TabIndex = 18;
            this.label25.Text = "2";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(23, 69);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(13, 13);
            this.label26.TabIndex = 17;
            this.label26.Text = "1";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(23, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(13, 13);
            this.label27.TabIndex = 16;
            this.label27.Text = "0";
            // 
            // barI0A
            // 
            this.barI0A.Location = new System.Drawing.Point(109, 26);
            this.barI0A.Maximum = 255;
            this.barI0A.Name = "barI0A";
            this.barI0A.Size = new System.Drawing.Size(124, 23);
            this.barI0A.Step = 1;
            this.barI0A.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barI0A.TabIndex = 0;
            // 
            // grpDigitalOutputs
            // 
            this.grpDigitalOutputs.Controls.Add(this.btnO7D);
            this.grpDigitalOutputs.Controls.Add(this.btnO6D);
            this.grpDigitalOutputs.Controls.Add(this.btnO5D);
            this.grpDigitalOutputs.Controls.Add(this.btnO4D);
            this.grpDigitalOutputs.Controls.Add(this.btnO3D);
            this.grpDigitalOutputs.Controls.Add(this.btnO2D);
            this.grpDigitalOutputs.Controls.Add(this.btnO1D);
            this.grpDigitalOutputs.Controls.Add(this.btnO0D);
            this.grpDigitalOutputs.Controls.Add(this.label9);
            this.grpDigitalOutputs.Controls.Add(this.label8);
            this.grpDigitalOutputs.Controls.Add(this.label7);
            this.grpDigitalOutputs.Controls.Add(this.label6);
            this.grpDigitalOutputs.Controls.Add(this.label5);
            this.grpDigitalOutputs.Controls.Add(this.label4);
            this.grpDigitalOutputs.Controls.Add(this.label10);
            this.grpDigitalOutputs.Controls.Add(this.label11);
            this.grpDigitalOutputs.Enabled = false;
            this.grpDigitalOutputs.Location = new System.Drawing.Point(270, 22);
            this.grpDigitalOutputs.Name = "grpDigitalOutputs";
            this.grpDigitalOutputs.Size = new System.Drawing.Size(230, 332);
            this.grpDigitalOutputs.TabIndex = 8;
            this.grpDigitalOutputs.TabStop = false;
            this.grpDigitalOutputs.Text = "Outputs: Digital";
            this.grpDigitalOutputs.Visible = false;
            // 
            // btnO7D
            // 
            this.btnO7D.BackColor = System.Drawing.Color.Red;
            this.btnO7D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnO7D.Location = new System.Drawing.Point(64, 291);
            this.btnO7D.Name = "btnO7D";
            this.btnO7D.Size = new System.Drawing.Size(125, 24);
            this.btnO7D.TabIndex = 23;
            this.btnO7D.Text = "OFF";
            this.btnO7D.UseVisualStyleBackColor = false;
            this.btnO7D.Click += new System.EventHandler(this.btnD7_Click);
            // 
            // btnO6D
            // 
            this.btnO6D.BackColor = System.Drawing.Color.Red;
            this.btnO6D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnO6D.Location = new System.Drawing.Point(64, 253);
            this.btnO6D.Name = "btnO6D";
            this.btnO6D.Size = new System.Drawing.Size(125, 24);
            this.btnO6D.TabIndex = 22;
            this.btnO6D.Text = "OFF";
            this.btnO6D.UseVisualStyleBackColor = false;
            this.btnO6D.Click += new System.EventHandler(this.btnD6_Click);
            // 
            // btnO5D
            // 
            this.btnO5D.BackColor = System.Drawing.Color.Red;
            this.btnO5D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnO5D.Location = new System.Drawing.Point(64, 215);
            this.btnO5D.Name = "btnO5D";
            this.btnO5D.Size = new System.Drawing.Size(125, 24);
            this.btnO5D.TabIndex = 21;
            this.btnO5D.Text = "OFF";
            this.btnO5D.UseVisualStyleBackColor = false;
            this.btnO5D.Click += new System.EventHandler(this.btnD5_Click);
            // 
            // btnO4D
            // 
            this.btnO4D.BackColor = System.Drawing.Color.Red;
            this.btnO4D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnO4D.Location = new System.Drawing.Point(64, 177);
            this.btnO4D.Name = "btnO4D";
            this.btnO4D.Size = new System.Drawing.Size(125, 24);
            this.btnO4D.TabIndex = 20;
            this.btnO4D.Text = "OFF";
            this.btnO4D.UseVisualStyleBackColor = false;
            this.btnO4D.Click += new System.EventHandler(this.btnD4_Click);
            // 
            // btnO3D
            // 
            this.btnO3D.BackColor = System.Drawing.Color.Red;
            this.btnO3D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnO3D.Location = new System.Drawing.Point(64, 139);
            this.btnO3D.Name = "btnO3D";
            this.btnO3D.Size = new System.Drawing.Size(125, 24);
            this.btnO3D.TabIndex = 19;
            this.btnO3D.Text = "OFF";
            this.btnO3D.UseVisualStyleBackColor = false;
            this.btnO3D.Click += new System.EventHandler(this.btnD3_Click);
            // 
            // btnO2D
            // 
            this.btnO2D.BackColor = System.Drawing.Color.Red;
            this.btnO2D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnO2D.Location = new System.Drawing.Point(64, 100);
            this.btnO2D.Name = "btnO2D";
            this.btnO2D.Size = new System.Drawing.Size(125, 24);
            this.btnO2D.TabIndex = 18;
            this.btnO2D.Text = "OFF";
            this.btnO2D.UseVisualStyleBackColor = false;
            this.btnO2D.Click += new System.EventHandler(this.btnD2_Click);
            // 
            // btnO1D
            // 
            this.btnO1D.BackColor = System.Drawing.Color.Red;
            this.btnO1D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnO1D.Location = new System.Drawing.Point(64, 63);
            this.btnO1D.Name = "btnO1D";
            this.btnO1D.Size = new System.Drawing.Size(125, 24);
            this.btnO1D.TabIndex = 17;
            this.btnO1D.Text = "OFF";
            this.btnO1D.UseVisualStyleBackColor = false;
            this.btnO1D.Click += new System.EventHandler(this.btnD1_Click);
            // 
            // btnO0D
            // 
            this.btnO0D.BackColor = System.Drawing.Color.Red;
            this.btnO0D.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnO0D.Location = new System.Drawing.Point(64, 25);
            this.btnO0D.Name = "btnO0D";
            this.btnO0D.Size = new System.Drawing.Size(125, 24);
            this.btnO0D.TabIndex = 16;
            this.btnO0D.Text = "OFF";
            this.btnO0D.UseVisualStyleBackColor = false;
            this.btnO0D.Click += new System.EventHandler(this.btnD0_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "0";
            // 
            // grpAnalogOutputs
            // 
            this.grpAnalogOutputs.Controls.Add(this.label1);
            this.grpAnalogOutputs.Controls.Add(this.label2);
            this.grpAnalogOutputs.Controls.Add(this.label12);
            this.grpAnalogOutputs.Controls.Add(this.label36);
            this.grpAnalogOutputs.Controls.Add(this.label37);
            this.grpAnalogOutputs.Controls.Add(this.label38);
            this.grpAnalogOutputs.Controls.Add(this.label39);
            this.grpAnalogOutputs.Controls.Add(this.label40);
            this.grpAnalogOutputs.Controls.Add(this.numO7A);
            this.grpAnalogOutputs.Controls.Add(this.numO6A);
            this.grpAnalogOutputs.Controls.Add(this.numO5A);
            this.grpAnalogOutputs.Controls.Add(this.numO4A);
            this.grpAnalogOutputs.Controls.Add(this.numO3A);
            this.grpAnalogOutputs.Controls.Add(this.numO2A);
            this.grpAnalogOutputs.Controls.Add(this.numO1A);
            this.grpAnalogOutputs.Controls.Add(this.numO0A);
            this.grpAnalogOutputs.Controls.Add(this.trackO7A);
            this.grpAnalogOutputs.Controls.Add(this.trackO6A);
            this.grpAnalogOutputs.Controls.Add(this.trackO5A);
            this.grpAnalogOutputs.Controls.Add(this.trackO4A);
            this.grpAnalogOutputs.Controls.Add(this.trackO3A);
            this.grpAnalogOutputs.Controls.Add(this.trackO2A);
            this.grpAnalogOutputs.Controls.Add(this.trackO1A);
            this.grpAnalogOutputs.Controls.Add(this.trackO0A);
            this.grpAnalogOutputs.Location = new System.Drawing.Point(270, 21);
            this.grpAnalogOutputs.Name = "grpAnalogOutputs";
            this.grpAnalogOutputs.Size = new System.Drawing.Size(230, 332);
            this.grpAnalogOutputs.TabIndex = 45;
            this.grpAnalogOutputs.TabStop = false;
            this.grpAnalogOutputs.Text = "Outputs: Analog";
            this.grpAnalogOutputs.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "6";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "5";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(10, 175);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(13, 13);
            this.label36.TabIndex = 26;
            this.label36.Text = "4";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(11, 138);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(13, 13);
            this.label37.TabIndex = 25;
            this.label37.Text = "3";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(10, 101);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(13, 13);
            this.label38.TabIndex = 24;
            this.label38.Text = "2";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(11, 64);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(13, 13);
            this.label39.TabIndex = 23;
            this.label39.Text = "1";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(11, 27);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(13, 13);
            this.label40.TabIndex = 22;
            this.label40.Text = "0";
            // 
            // numO7A
            // 
            this.numO7A.Enabled = false;
            this.numO7A.Location = new System.Drawing.Point(167, 284);
            this.numO7A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numO7A.Name = "numO7A";
            this.numO7A.Size = new System.Drawing.Size(49, 20);
            this.numO7A.TabIndex = 21;
            this.numO7A.ValueChanged += new System.EventHandler(this.numO7A_ValueChanged);
            // 
            // numO6A
            // 
            this.numO6A.Enabled = false;
            this.numO6A.Location = new System.Drawing.Point(167, 247);
            this.numO6A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numO6A.Name = "numO6A";
            this.numO6A.Size = new System.Drawing.Size(49, 20);
            this.numO6A.TabIndex = 20;
            this.numO6A.ValueChanged += new System.EventHandler(this.numO6A_ValueChanged);
            // 
            // numO5A
            // 
            this.numO5A.Enabled = false;
            this.numO5A.Location = new System.Drawing.Point(167, 210);
            this.numO5A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numO5A.Name = "numO5A";
            this.numO5A.Size = new System.Drawing.Size(49, 20);
            this.numO5A.TabIndex = 19;
            this.numO5A.ValueChanged += new System.EventHandler(this.numO5A_ValueChanged);
            // 
            // numO4A
            // 
            this.numO4A.Enabled = false;
            this.numO4A.Location = new System.Drawing.Point(167, 173);
            this.numO4A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numO4A.Name = "numO4A";
            this.numO4A.Size = new System.Drawing.Size(49, 20);
            this.numO4A.TabIndex = 18;
            this.numO4A.ValueChanged += new System.EventHandler(this.numO4A_ValueChanged);
            // 
            // numO3A
            // 
            this.numO3A.Enabled = false;
            this.numO3A.Location = new System.Drawing.Point(167, 136);
            this.numO3A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numO3A.Name = "numO3A";
            this.numO3A.Size = new System.Drawing.Size(49, 20);
            this.numO3A.TabIndex = 17;
            this.numO3A.ValueChanged += new System.EventHandler(this.numO3A_ValueChanged);
            // 
            // numO2A
            // 
            this.numO2A.Enabled = false;
            this.numO2A.Location = new System.Drawing.Point(167, 99);
            this.numO2A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numO2A.Name = "numO2A";
            this.numO2A.Size = new System.Drawing.Size(49, 20);
            this.numO2A.TabIndex = 16;
            this.numO2A.ValueChanged += new System.EventHandler(this.numO2A_ValueChanged);
            // 
            // numO1A
            // 
            this.numO1A.Enabled = false;
            this.numO1A.Location = new System.Drawing.Point(167, 62);
            this.numO1A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numO1A.Name = "numO1A";
            this.numO1A.Size = new System.Drawing.Size(49, 20);
            this.numO1A.TabIndex = 15;
            this.numO1A.ValueChanged += new System.EventHandler(this.numO1A_ValueChanged);
            // 
            // numO0A
            // 
            this.numO0A.Enabled = false;
            this.numO0A.Location = new System.Drawing.Point(167, 25);
            this.numO0A.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numO0A.Name = "numO0A";
            this.numO0A.Size = new System.Drawing.Size(49, 20);
            this.numO0A.TabIndex = 10;
            this.numO0A.ValueChanged += new System.EventHandler(this.numO0A_ValueChanged);
            // 
            // trackO7A
            // 
            this.trackO7A.LargeChange = 20;
            this.trackO7A.Location = new System.Drawing.Point(26, 284);
            this.trackO7A.Maximum = 255;
            this.trackO7A.Name = "trackO7A";
            this.trackO7A.Size = new System.Drawing.Size(145, 45);
            this.trackO7A.TabIndex = 14;
            this.trackO7A.TickFrequency = 20;
            this.trackO7A.ValueChanged += new System.EventHandler(this.trackO7A_ValueChanged);
            // 
            // trackO6A
            // 
            this.trackO6A.LargeChange = 20;
            this.trackO6A.Location = new System.Drawing.Point(26, 247);
            this.trackO6A.Maximum = 255;
            this.trackO6A.Name = "trackO6A";
            this.trackO6A.Size = new System.Drawing.Size(145, 45);
            this.trackO6A.TabIndex = 12;
            this.trackO6A.TickFrequency = 20;
            this.trackO6A.ValueChanged += new System.EventHandler(this.trackO6A_ValueChanged);
            // 
            // trackO5A
            // 
            this.trackO5A.LargeChange = 20;
            this.trackO5A.Location = new System.Drawing.Point(26, 210);
            this.trackO5A.Maximum = 255;
            this.trackO5A.Name = "trackO5A";
            this.trackO5A.Size = new System.Drawing.Size(145, 45);
            this.trackO5A.TabIndex = 10;
            this.trackO5A.TickFrequency = 20;
            this.trackO5A.ValueChanged += new System.EventHandler(this.trackO5A_ValueChanged);
            // 
            // trackO4A
            // 
            this.trackO4A.LargeChange = 20;
            this.trackO4A.Location = new System.Drawing.Point(26, 173);
            this.trackO4A.Maximum = 255;
            this.trackO4A.Name = "trackO4A";
            this.trackO4A.Size = new System.Drawing.Size(145, 45);
            this.trackO4A.TabIndex = 8;
            this.trackO4A.TickFrequency = 20;
            this.trackO4A.ValueChanged += new System.EventHandler(this.trackO4A_ValueChanged);
            // 
            // trackO3A
            // 
            this.trackO3A.LargeChange = 20;
            this.trackO3A.Location = new System.Drawing.Point(26, 136);
            this.trackO3A.Maximum = 255;
            this.trackO3A.Name = "trackO3A";
            this.trackO3A.Size = new System.Drawing.Size(145, 45);
            this.trackO3A.TabIndex = 6;
            this.trackO3A.TickFrequency = 20;
            this.trackO3A.ValueChanged += new System.EventHandler(this.trackO3A_ValueChanged);
            // 
            // trackO2A
            // 
            this.trackO2A.LargeChange = 20;
            this.trackO2A.Location = new System.Drawing.Point(26, 99);
            this.trackO2A.Maximum = 255;
            this.trackO2A.Name = "trackO2A";
            this.trackO2A.Size = new System.Drawing.Size(145, 45);
            this.trackO2A.TabIndex = 4;
            this.trackO2A.TickFrequency = 20;
            this.trackO2A.ValueChanged += new System.EventHandler(this.trackO2A_ValueChanged);
            // 
            // trackO1A
            // 
            this.trackO1A.LargeChange = 20;
            this.trackO1A.Location = new System.Drawing.Point(26, 64);
            this.trackO1A.Maximum = 255;
            this.trackO1A.Name = "trackO1A";
            this.trackO1A.Size = new System.Drawing.Size(145, 45);
            this.trackO1A.TabIndex = 2;
            this.trackO1A.TickFrequency = 20;
            this.trackO1A.ValueChanged += new System.EventHandler(this.trackO1A_ValueChanged);
            // 
            // trackO0A
            // 
            this.trackO0A.LargeChange = 20;
            this.trackO0A.Location = new System.Drawing.Point(26, 25);
            this.trackO0A.Maximum = 255;
            this.trackO0A.Name = "trackO0A";
            this.trackO0A.Size = new System.Drawing.Size(145, 45);
            this.trackO0A.TabIndex = 0;
            this.trackO0A.TickFrequency = 20;
            this.trackO0A.ValueChanged += new System.EventHandler(this.trackO0A_ValueChanged);
            // 
            // tabScript
            // 
            this.tabScript.BackColor = System.Drawing.SystemColors.Control;
            this.tabScript.Controls.Add(this.splitContainer1);
            this.tabScript.ImageIndex = 1;
            this.tabScript.Location = new System.Drawing.Point(4, 39);
            this.tabScript.Name = "tabScript";
            this.tabScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabScript.Size = new System.Drawing.Size(509, 363);
            this.tabScript.TabIndex = 2;
            this.tabScript.Text = "Automation ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.chkTriggers);
            this.splitContainer1.Panel1.Controls.Add(this.chkActions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelScripts);
            this.splitContainer1.Panel2.Controls.Add(this.panelTriggers);
            this.splitContainer1.Size = new System.Drawing.Size(503, 357);
            this.splitContainer1.SplitterDistance = 27;
            this.splitContainer1.TabIndex = 10;
            // 
            // chkTriggers
            // 
            this.chkTriggers.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkTriggers.AutoSize = true;
            this.chkTriggers.Location = new System.Drawing.Point(251, 3);
            this.chkTriggers.Name = "chkTriggers";
            this.chkTriggers.Size = new System.Drawing.Size(86, 23);
            this.chkTriggers.TabIndex = 1;
            this.chkTriggers.Text = "Event Triggers";
            this.chkTriggers.UseVisualStyleBackColor = true;
            this.chkTriggers.CheckedChanged += new System.EventHandler(this.chkTriggers_CheckedChanged);
            // 
            // chkActions
            // 
            this.chkActions.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkActions.AutoSize = true;
            this.chkActions.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkActions.Checked = true;
            this.chkActions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActions.Location = new System.Drawing.Point(154, 3);
            this.chkActions.Name = "chkActions";
            this.chkActions.Size = new System.Drawing.Size(82, 23);
            this.chkActions.TabIndex = 0;
            this.chkActions.Text = "Action Scripts";
            this.chkActions.UseVisualStyleBackColor = true;
            this.chkActions.CheckedChanged += new System.EventHandler(this.chkActions_CheckedChanged);
            // 
            // panelScripts
            // 
            this.panelScripts.BackColor = System.Drawing.SystemColors.Control;
            this.panelScripts.Controls.Add(this.scriptDGV);
            this.panelScripts.Controls.Add(this.btnExportScripts);
            this.panelScripts.Controls.Add(this.btnAddScript);
            this.panelScripts.Controls.Add(this.brnImportScripts);
            this.panelScripts.Controls.Add(this.btnTrigScript);
            this.panelScripts.Controls.Add(this.btnExecScript);
            this.panelScripts.Controls.Add(this.btnEditScript);
            this.panelScripts.Controls.Add(this.btnRemScript);
            this.panelScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScripts.Location = new System.Drawing.Point(0, 0);
            this.panelScripts.Name = "panelScripts";
            this.panelScripts.Size = new System.Drawing.Size(503, 326);
            this.panelScripts.TabIndex = 8;
            // 
            // scriptDGV
            // 
            this.scriptDGV.AllowUserToAddRows = false;
            this.scriptDGV.AllowUserToDeleteRows = false;
            this.scriptDGV.AutoGenerateColumns = false;
            this.scriptDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.enabledDataGridViewCheckBoxColumn1,
            this.isCompiledDataGridViewCheckBoxColumn1});
            this.scriptDGV.DataSource = this.scriptBS;
            this.scriptDGV.Location = new System.Drawing.Point(8, 12);
            this.scriptDGV.Name = "scriptDGV";
            this.scriptDGV.ReadOnly = true;
            this.scriptDGV.RowHeadersWidth = 30;
            this.scriptDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scriptDGV.Size = new System.Drawing.Size(479, 206);
            this.scriptDGV.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn1.Width = 225;
            // 
            // enabledDataGridViewCheckBoxColumn1
            // 
            this.enabledDataGridViewCheckBoxColumn1.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn1.HeaderText = "Enabled";
            this.enabledDataGridViewCheckBoxColumn1.Name = "enabledDataGridViewCheckBoxColumn1";
            this.enabledDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.enabledDataGridViewCheckBoxColumn1.Width = 110;
            // 
            // isCompiledDataGridViewCheckBoxColumn1
            // 
            this.isCompiledDataGridViewCheckBoxColumn1.DataPropertyName = "IsCompiled";
            this.isCompiledDataGridViewCheckBoxColumn1.HeaderText = "IsCompiled";
            this.isCompiledDataGridViewCheckBoxColumn1.Name = "isCompiledDataGridViewCheckBoxColumn1";
            this.isCompiledDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.isCompiledDataGridViewCheckBoxColumn1.Width = 110;
            // 
            // scriptBS
            // 
            this.scriptBS.AllowNew = true;
            this.scriptBS.DataSource = typeof(HomePLC.Model.Script);
            this.scriptBS.CurrentChanged += new System.EventHandler(this.ScriptCurrentChanged);
            // 
            // btnExportScripts
            // 
            this.btnExportScripts.Location = new System.Drawing.Point(119, 253);
            this.btnExportScripts.Name = "btnExportScripts";
            this.btnExportScripts.Size = new System.Drawing.Size(105, 23);
            this.btnExportScripts.TabIndex = 7;
            this.btnExportScripts.Text = "Export";
            this.btnExportScripts.UseVisualStyleBackColor = true;
            this.btnExportScripts.Click += new System.EventHandler(this.btnExportScripts_Click);
            // 
            // btnAddScript
            // 
            this.btnAddScript.Location = new System.Drawing.Point(8, 224);
            this.btnAddScript.Name = "btnAddScript";
            this.btnAddScript.Size = new System.Drawing.Size(68, 23);
            this.btnAddScript.TabIndex = 1;
            this.btnAddScript.Text = "Add";
            this.btnAddScript.UseVisualStyleBackColor = true;
            this.btnAddScript.Click += new System.EventHandler(this.btnAddScript_Click);
            // 
            // brnImportScripts
            // 
            this.brnImportScripts.Location = new System.Drawing.Point(8, 253);
            this.brnImportScripts.Name = "brnImportScripts";
            this.brnImportScripts.Size = new System.Drawing.Size(105, 23);
            this.brnImportScripts.TabIndex = 6;
            this.brnImportScripts.Text = "Import";
            this.brnImportScripts.UseVisualStyleBackColor = true;
            this.brnImportScripts.Click += new System.EventHandler(this.brnImportScripts_Click);
            // 
            // btnTrigScript
            // 
            this.btnTrigScript.Location = new System.Drawing.Point(271, 224);
            this.btnTrigScript.Name = "btnTrigScript";
            this.btnTrigScript.Size = new System.Drawing.Size(105, 23);
            this.btnTrigScript.TabIndex = 4;
            this.btnTrigScript.Text = "Enable";
            this.btnTrigScript.UseVisualStyleBackColor = true;
            this.btnTrigScript.Click += new System.EventHandler(this.btnTrigScript_Click);
            // 
            // btnExecScript
            // 
            this.btnExecScript.Location = new System.Drawing.Point(382, 224);
            this.btnExecScript.Name = "btnExecScript";
            this.btnExecScript.Size = new System.Drawing.Size(105, 23);
            this.btnExecScript.TabIndex = 5;
            this.btnExecScript.Text = "Execute";
            this.btnExecScript.UseVisualStyleBackColor = true;
            this.btnExecScript.Click += new System.EventHandler(this.btnExecScript_Click);
            // 
            // btnEditScript
            // 
            this.btnEditScript.Location = new System.Drawing.Point(82, 224);
            this.btnEditScript.Name = "btnEditScript";
            this.btnEditScript.Size = new System.Drawing.Size(68, 23);
            this.btnEditScript.TabIndex = 2;
            this.btnEditScript.Text = "Edit";
            this.btnEditScript.UseVisualStyleBackColor = true;
            this.btnEditScript.Click += new System.EventHandler(this.btnEditScript_Click);
            // 
            // btnRemScript
            // 
            this.btnRemScript.Location = new System.Drawing.Point(156, 224);
            this.btnRemScript.Name = "btnRemScript";
            this.btnRemScript.Size = new System.Drawing.Size(68, 23);
            this.btnRemScript.TabIndex = 3;
            this.btnRemScript.Text = "Remove";
            this.btnRemScript.UseVisualStyleBackColor = true;
            this.btnRemScript.Click += new System.EventHandler(this.btnRemScript_Click);
            // 
            // panelTriggers
            // 
            this.panelTriggers.Controls.Add(this.btnConfigTrigger);
            this.panelTriggers.Controls.Add(this.brnRemTriggers);
            this.panelTriggers.Controls.Add(this.btnAddTrigger);
            this.panelTriggers.Controls.Add(this.lbTriggers);
            this.panelTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTriggers.Location = new System.Drawing.Point(0, 0);
            this.panelTriggers.Name = "panelTriggers";
            this.panelTriggers.Size = new System.Drawing.Size(503, 326);
            this.panelTriggers.TabIndex = 8;
            this.panelTriggers.Visible = false;
            // 
            // btnConfigTrigger
            // 
            this.btnConfigTrigger.Location = new System.Drawing.Point(343, 81);
            this.btnConfigTrigger.Name = "btnConfigTrigger";
            this.btnConfigTrigger.Size = new System.Drawing.Size(149, 23);
            this.btnConfigTrigger.TabIndex = 3;
            this.btnConfigTrigger.Text = "Configure";
            this.btnConfigTrigger.UseVisualStyleBackColor = true;
            this.btnConfigTrigger.Click += new System.EventHandler(this.btnConfigTrigger_Click);
            // 
            // brnRemTriggers
            // 
            this.brnRemTriggers.Location = new System.Drawing.Point(343, 41);
            this.brnRemTriggers.Name = "brnRemTriggers";
            this.brnRemTriggers.Size = new System.Drawing.Size(149, 23);
            this.brnRemTriggers.TabIndex = 2;
            this.brnRemTriggers.Text = "Remove";
            this.brnRemTriggers.UseVisualStyleBackColor = true;
            this.brnRemTriggers.Click += new System.EventHandler(this.brnRemTriggers_Click);
            // 
            // btnAddTrigger
            // 
            this.btnAddTrigger.Location = new System.Drawing.Point(343, 12);
            this.btnAddTrigger.Name = "btnAddTrigger";
            this.btnAddTrigger.Size = new System.Drawing.Size(149, 23);
            this.btnAddTrigger.TabIndex = 1;
            this.btnAddTrigger.Text = "Add";
            this.btnAddTrigger.UseVisualStyleBackColor = true;
            this.btnAddTrigger.Click += new System.EventHandler(this.btnAddTrigger_Click);
            // 
            // lbTriggers
            // 
            this.lbTriggers.FormattingEnabled = true;
            this.lbTriggers.Location = new System.Drawing.Point(8, 12);
            this.lbTriggers.Name = "lbTriggers";
            this.lbTriggers.Size = new System.Drawing.Size(329, 303);
            this.lbTriggers.TabIndex = 0;
            // 
            // tabLog
            // 
            this.tabLog.BackColor = System.Drawing.SystemColors.Control;
            this.tabLog.Controls.Add(this.btnClearLog);
            this.tabLog.Controls.Add(this.chkDebugLog);
            this.tabLog.Controls.Add(this.txtLog);
            this.tabLog.Controls.Add(this.chkUserLog);
            this.tabLog.ImageIndex = 2;
            this.tabLog.Location = new System.Drawing.Point(4, 39);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(509, 363);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "Log viewer  ";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(428, 20);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(73, 23);
            this.btnClearLog.TabIndex = 5;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // chkDebugLog
            // 
            this.chkDebugLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDebugLog.Location = new System.Drawing.Point(343, 20);
            this.chkDebugLog.Name = "chkDebugLog";
            this.chkDebugLog.Size = new System.Drawing.Size(73, 23);
            this.chkDebugLog.TabIndex = 4;
            this.chkDebugLog.Text = "&Debug";
            this.chkDebugLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDebugLog.UseVisualStyleBackColor = true;
            this.chkDebugLog.CheckedChanged += new System.EventHandler(this.chkDebugLog_CheckedChanged);
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Location = new System.Drawing.Point(6, 49);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(495, 305);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            this.txtLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtLog_LinkClicked);
            // 
            // chkUserLog
            // 
            this.chkUserLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUserLog.AutoSize = true;
            this.chkUserLog.Checked = true;
            this.chkUserLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserLog.Location = new System.Drawing.Point(244, 20);
            this.chkUserLog.Name = "chkUserLog";
            this.chkUserLog.Size = new System.Drawing.Size(93, 23);
            this.chkUserLog.TabIndex = 3;
            this.chkUserLog.Text = "User commands";
            this.chkUserLog.UseVisualStyleBackColor = true;
            this.chkUserLog.CheckedChanged += new System.EventHandler(this.chkUserLog_CheckedChanged);
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.SystemColors.Control;
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusCLabel,
            this.statusSpacerLabel,
            this.statusRTC,
            this.toolStripStatusLabel3,
            this.statusSync});
            this.status.Location = new System.Drawing.Point(0, 447);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(517, 22);
            this.status.TabIndex = 43;
            this.status.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // statusCLabel
            // 
            this.statusCLabel.Margin = new System.Windows.Forms.Padding(1, 3, 0, 2);
            this.statusCLabel.Name = "statusCLabel";
            this.statusCLabel.Size = new System.Drawing.Size(82, 17);
            this.statusCLabel.Text = "Disconnected.";
            // 
            // statusSpacerLabel
            // 
            this.statusSpacerLabel.Name = "statusSpacerLabel";
            this.statusSpacerLabel.Size = new System.Drawing.Size(259, 17);
            this.statusSpacerLabel.Spring = true;
            this.statusSpacerLabel.Text = "        ";
            // 
            // statusRTC
            // 
            this.statusRTC.Image = global::HomePLC.Properties.Resources.Clock;
            this.statusRTC.Name = "statusRTC";
            this.statusRTC.Size = new System.Drawing.Size(45, 17);
            this.statusRTC.Tag = "RTC";
            this.statusRTC.Text = "RTC";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = " ";
            // 
            // statusSync
            // 
            this.statusSync.Image = global::HomePLC.Properties.Resources.sync;
            this.statusSync.Name = "statusSync";
            this.statusSync.Size = new System.Drawing.Size(53, 17);
            this.statusSync.Text = "SYNC";
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.SystemColors.Control;
            this.toolbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbConnect,
            this.toolStripSeparator1,
            this.tbSettings,
            this.tbAbout,
            this.toolStripSeparator2,
            this.tbRemote});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Padding = new System.Windows.Forms.Padding(1);
            this.toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolbar.Size = new System.Drawing.Size(517, 41);
            this.toolbar.Stretch = true;
            this.toolbar.TabIndex = 42;
            this.toolbar.Text = "toolStrip1";
            // 
            // tbConnect
            // 
            this.tbConnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbConnect.Image = global::HomePLC.Properties.Resources.GreenButton;
            this.tbConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConnect.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.tbConnect.Name = "tbConnect";
            this.tbConnect.Size = new System.Drawing.Size(88, 36);
            this.tbConnect.Text = "&Connect";
            this.tbConnect.ToolTipText = "Connect   ";
            this.tbConnect.Click += new System.EventHandler(this.tbConnect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tbSettings
            // 
            this.tbSettings.Image = global::HomePLC.Properties.Resources.Settings_icon;
            this.tbSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.Size = new System.Drawing.Size(77, 36);
            this.tbSettings.Text = "&Settings";
            this.tbSettings.Click += new System.EventHandler(this.tbSettings_Click);
            // 
            // tbAbout
            // 
            this.tbAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbAbout.Image = global::HomePLC.Properties.Resources.GetInfoBlue;
            this.tbAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAbout.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tbAbout.Name = "tbAbout";
            this.tbAbout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbAbout.Size = new System.Drawing.Size(76, 36);
            this.tbAbout.Text = "A&bout";
            this.tbAbout.Click += new System.EventHandler(this.tbAbout_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tbRemote
            // 
            this.tbRemote.Image = global::HomePLC.Properties.Resources.remotePhoneOff;
            this.tbRemote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRemote.Name = "tbRemote";
            this.tbRemote.Size = new System.Drawing.Size(117, 36);
            this.tbRemote.Text = "Remote control";
            this.tbRemote.Click += new System.EventHandler(this.tbRemote_Click);
            // 
            // triggerBS
            // 
            this.triggerBS.DataSource = typeof(HomePLC.Model.BaseTrigger);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(517, 469);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.toolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "HomePLC ver. 1.0 Alpha";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabIO.ResumeLayout(false);
            this.grpDigitalInputs.ResumeLayout(false);
            this.grpDigitalInputs.PerformLayout();
            this.grpAnalogInputs.ResumeLayout(false);
            this.grpAnalogInputs.PerformLayout();
            this.grpDigitalOutputs.ResumeLayout(false);
            this.grpDigitalOutputs.PerformLayout();
            this.grpAnalogOutputs.ResumeLayout(false);
            this.grpAnalogOutputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numO7A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO6A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO5A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO4A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO3A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO2A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO1A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numO0A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO7A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO6A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO5A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO4A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO3A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO2A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO1A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackO0A)).EndInit();
            this.tabScript.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelScripts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scriptDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scriptBS)).EndInit();
            this.panelTriggers.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triggerBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDigitalOutputs;
        private System.Windows.Forms.Button btnO7D;
        private System.Windows.Forms.Button btnO6D;
        private System.Windows.Forms.Button btnO5D;
        private System.Windows.Forms.Button btnO4D;
        private System.Windows.Forms.Button btnO3D;
        private System.Windows.Forms.Button btnO2D;
        private System.Windows.Forms.Button btnO1D;
        private System.Windows.Forms.Button btnO0D;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpAnalogInputs;
        private System.Windows.Forms.TextBox txtI7A;
        private System.Windows.Forms.ProgressBar barI7A;
        private System.Windows.Forms.TextBox txtI6A;
        private System.Windows.Forms.ProgressBar barI6A;
        private System.Windows.Forms.TextBox txtI5A;
        private System.Windows.Forms.ProgressBar barI5A;
        private System.Windows.Forms.TextBox txtI4A;
        private System.Windows.Forms.ProgressBar barI4A;
        private System.Windows.Forms.TextBox txtI3A;
        private System.Windows.Forms.ProgressBar barI3A;
        private System.Windows.Forms.TextBox txtI2A;
        private System.Windows.Forms.ProgressBar barI2A;
        private System.Windows.Forms.TextBox txtI1A;
        private System.Windows.Forms.ProgressBar barI1A;
        private System.Windows.Forms.TextBox txtI0A;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ProgressBar barI0A;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton tbConnect;
        private System.Windows.Forms.ToolStripButton tbSettings;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statusCLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusSpacerLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.CheckBox chkDebugLog;
        private System.Windows.Forms.CheckBox chkUserLog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox grpAnalogOutputs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.NumericUpDown numO7A;
        private System.Windows.Forms.NumericUpDown numO6A;
        private System.Windows.Forms.NumericUpDown numO5A;
        private System.Windows.Forms.NumericUpDown numO4A;
        private System.Windows.Forms.NumericUpDown numO3A;
        private System.Windows.Forms.NumericUpDown numO2A;
        private System.Windows.Forms.NumericUpDown numO1A;
        private System.Windows.Forms.NumericUpDown numO0A;
        private System.Windows.Forms.TrackBar trackO7A;
        private System.Windows.Forms.TrackBar trackO6A;
        private System.Windows.Forms.TrackBar trackO5A;
        private System.Windows.Forms.TrackBar trackO4A;
        private System.Windows.Forms.TrackBar trackO3A;
        private System.Windows.Forms.TrackBar trackO2A;
        private System.Windows.Forms.TrackBar trackO1A;
        private System.Windows.Forms.TrackBar trackO0A;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnI0D;
        private System.Windows.Forms.Button btnI1D;
        private System.Windows.Forms.Button btnI2D;
        private System.Windows.Forms.Button btnI3D;
        private System.Windows.Forms.Button btnI4D;
        private System.Windows.Forms.Button btnI5D;
        private System.Windows.Forms.Button btnI6D;
        private System.Windows.Forms.Button btnI7D;
        private System.Windows.Forms.GroupBox grpDigitalInputs;
        private System.Windows.Forms.ToolStripStatusLabel statusRTC;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabIO;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        public System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton tbAbout;
        private System.Windows.Forms.ToolStripStatusLabel statusSync;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.TabPage tabScript;
        private System.Windows.Forms.Button btnExportScripts;
        private System.Windows.Forms.Button brnImportScripts;
        private System.Windows.Forms.Button btnExecScript;
        private System.Windows.Forms.Button btnTrigScript;
        private System.Windows.Forms.Button btnRemScript;
        private System.Windows.Forms.Button btnEditScript;
        private System.Windows.Forms.Button btnAddScript;
        private System.Windows.Forms.DataGridView scriptDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCompiledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelScripts;
        private System.Windows.Forms.Panel panelTriggers;
        private System.Windows.Forms.ListBox lbTriggers;
        private System.Windows.Forms.Button btnConfigTrigger;
        private System.Windows.Forms.Button brnRemTriggers;
        private System.Windows.Forms.Button btnAddTrigger;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.BindingSource scriptBS;
        private System.Windows.Forms.CheckBox chkTriggers;
        private System.Windows.Forms.CheckBox chkActions;
        private System.Windows.Forms.BindingSource triggerBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCompiledDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbRemote;

    }
}

