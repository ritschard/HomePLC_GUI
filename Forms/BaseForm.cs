using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HomePLC.Forms
{
    public delegate void OnCheckUI();

    public partial class BaseForm : Form, IUICheckable
    {       
        public event OnCheckUI CheckUI;

        public BaseForm()
        {
            InitializeComponent();
            UICheckDispatcher.RegisterUICheckable(this);
        }

        ~BaseForm()
        {
            UICheckDispatcher.UnregisterUICheckable(this);
        }
                
        #region IUICheckable Members

        void IUICheckable.FireCheckUI()
        {
            if (CheckUI != null)
            {
                CheckUI();
            }
        }

        #endregion
    }
}
