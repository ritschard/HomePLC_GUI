using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HomePLC.Model;

namespace HomePLC.Forms
{
    public partial class TimeTriggerForm : BaseForm
    {
        private TimeTrigger fData;

        public TimeTriggerForm(TimeTrigger data)
        {
            InitializeComponent();
            fData = data; 
        }

        private void TimeTriggerForm_CheckUI()
        {
            if (fData != null)
            {
                if (fData.TriggerMode == TimeTrigger.TimeTriggerType.RunOnce)
                {
                    chkRunOnce.Checked = true;
                    chkContinuous.Checked = false;
                }
                else
                {
                    chkContinuous.Checked = true;
                    chkRunOnce.Checked = false;
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            fData.TriggerAt = dtpTime.Value;
            fData.Name = txtName.Text;  
        }

        private void TimeTriggerForm_Load(object sender, EventArgs e)
        {
            dtpTime.Value = fData.TriggerAt;
            txtName.Text = fData.Name;

            lbAvailableActions.DataSource = fData.se;
            lbAvailableActions.DisplayMember = "Name";

            lbExecuteActions.DataSource = fData.selectedActions;
            lbExecuteActions.DisplayMember = "Name";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (var item in lbAvailableActions.SelectedItems)
            {
                if (!lbExecuteActions.Items.Contains(item))
                {
                    fData.selectedActions.Add(item as Script);
                }     
            }
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            fData.selectedActions.Remove(lbExecuteActions.SelectedItem as Script);
        }
                
        private void chkRunOnce_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRunOnce.Checked)
            {
                fData.TriggerMode = TimeTrigger.TimeTriggerType.RunOnce;
                chkContinuous.Checked = false;
            }
        }

        private void chkContinuous_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContinuous.Checked)
            {
                fData.TriggerMode = TimeTrigger.TimeTriggerType.Continuous;
                chkRunOnce.Checked = false;
            }
        }
    }
}
