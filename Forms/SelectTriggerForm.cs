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
    public partial class SelectTriggerForm : BaseForm
    {
        public Type TriggerType;

        public SelectTriggerForm()
        {
            InitializeComponent();
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            switch(lbTriggers.SelectedIndex)
            {
                case 0:
                    TriggerType = typeof(AnalogPinTrigger);
                    break;
                case 1:
                    TriggerType = typeof(DigitalPinTrigger);
                    break;
                case 2:
                    TriggerType = typeof(TimeTrigger);
                    break;
            }
        }
    }
}
