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
    public partial class DigitalPinTriggerForm : HomePLC.Forms.BaseForm
    {
        private DigitalPinTrigger fData = null;

        public bool PinState 
        { 
            get
            {
                if (cmbState.SelectedIndex == 0)
                    return false;
                else
                    return true;
            }

            set 
            {
                if (value == false)
                    cmbState.SelectedIndex = 0;
                else
                    cmbState.SelectedIndex = 1;
            } 
        }

        public DigitalPinTriggerForm(DigitalPinTrigger data)
        {
            InitializeComponent();
            fData = data;
        }

        private void PinTriggerForm_Load(object sender, EventArgs e)
        {
            txtName.Text = fData.Name;
            numPin.Value = (decimal)fData.pinNo;
            PinState = fData.pinState;

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
            fData.pinNo = (int) numPin.Value;
            fData.pinState = PinState;
        }

    }
}
