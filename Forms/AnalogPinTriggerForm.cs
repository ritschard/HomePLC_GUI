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
    public partial class AnalogPinTriggerForm : HomePLC.Forms.BaseForm
    {
        private AnalogPinTrigger fData = null;

        public AnalogPinTriggerForm(AnalogPinTrigger data)
        {
            InitializeComponent();
            fData = data;
        }

        private void AnalogPinTriggerForm_Load(object sender, EventArgs e)
        {
            txtName.Text = fData.Name;
            numPin.Value = (decimal)fData.pinNo;
            numValue.Value = (decimal)fData.pinValue;

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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            fData.Name = txtName.Text;
            fData.pinNo = (int)numPin.Value;
            fData.pinValue = (byte)numValue.Value;
        }


    }
}
