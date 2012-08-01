namespace HomePLC.Forms
{
    partial class TimeTriggerForm
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
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAvailableActions = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbExecuteActions = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkContinuous = new System.Windows.Forms.CheckBox();
            this.chkRunOnce = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = "dd. MM. yyyy   -  HH:mm";
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(76, 45);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(253, 20);
            this.dtpTime.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(189, 260);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(270, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(76, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(253, 20);
            this.txtName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Trigger time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Actions to execute:";
            // 
            // lbAvailableActions
            // 
            this.lbAvailableActions.FormattingEnabled = true;
            this.lbAvailableActions.Location = new System.Drawing.Point(7, 35);
            this.lbAvailableActions.Name = "lbAvailableActions";
            this.lbAvailableActions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAvailableActions.Size = new System.Drawing.Size(142, 82);
            this.lbAvailableActions.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Available actions:";
            // 
            // lbExecuteActions
            // 
            this.lbExecuteActions.FormattingEnabled = true;
            this.lbExecuteActions.Location = new System.Drawing.Point(187, 35);
            this.lbExecuteActions.Name = "lbExecuteActions";
            this.lbExecuteActions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbExecuteActions.Size = new System.Drawing.Size(142, 82);
            this.lbExecuteActions.TabIndex = 20;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(155, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(26, 23);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRem
            // 
            this.btnRem.Location = new System.Drawing.Point(155, 80);
            this.btnRem.Name = "btnRem";
            this.btnRem.Size = new System.Drawing.Size(26, 23);
            this.btnRem.TabIndex = 22;
            this.btnRem.Text = "<";
            this.btnRem.UseVisualStyleBackColor = true;
            this.btnRem.Click += new System.EventHandler(this.btnRem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAvailableActions);
            this.groupBox1.Controls.Add(this.lbExecuteActions);
            this.groupBox1.Controls.Add(this.btnRem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 128);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkContinuous);
            this.groupBox2.Controls.Add(this.chkRunOnce);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpTime);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 108);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trigger ";
            // 
            // chkContinuous
            // 
            this.chkContinuous.AutoSize = true;
            this.chkContinuous.Location = new System.Drawing.Point(203, 79);
            this.chkContinuous.Name = "chkContinuous";
            this.chkContinuous.Size = new System.Drawing.Size(79, 17);
            this.chkContinuous.TabIndex = 19;
            this.chkContinuous.Text = "Continuous";
            this.chkContinuous.UseVisualStyleBackColor = true;
            this.chkContinuous.CheckedChanged += new System.EventHandler(this.chkContinuous_CheckedChanged);
            // 
            // chkRunOnce
            // 
            this.chkRunOnce.AutoSize = true;
            this.chkRunOnce.Location = new System.Drawing.Point(108, 79);
            this.chkRunOnce.Name = "chkRunOnce";
            this.chkRunOnce.Size = new System.Drawing.Size(73, 17);
            this.chkRunOnce.TabIndex = 18;
            this.chkRunOnce.Text = "Run once";
            this.chkRunOnce.UseVisualStyleBackColor = true;
            this.chkRunOnce.CheckedChanged += new System.EventHandler(this.chkRunOnce_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Run mode:";
            // 
            // ModuleTriggerForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 290);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModuleTriggerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Time Trigger ";
            this.CheckUI += new HomePLC.Forms.OnCheckUI(this.TimeTriggerForm_CheckUI);
            this.Load += new System.EventHandler(this.TimeTriggerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbAvailableActions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbExecuteActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkContinuous;
        private System.Windows.Forms.CheckBox chkRunOnce;
        private System.Windows.Forms.Label label5;
    }
}