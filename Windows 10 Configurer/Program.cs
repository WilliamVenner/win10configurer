using System;
using System.Windows.Forms;

namespace Windows_10_Configurer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Window());
        }
    }
}
