using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HomePLC
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Idle += new EventHandler(Application_Idle);
            Application.Run(new MainForm());
            Application.Idle -= new EventHandler(Application_Idle);
        }

        static void Application_Idle(object sender, EventArgs e)
        {
            HomePLC.Forms.UICheckDispatcher.TriggerCheckUI();
        }
    }
}
