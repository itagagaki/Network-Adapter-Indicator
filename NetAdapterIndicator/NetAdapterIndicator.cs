// This file is part of the 'Network Adapter Indicator'.
// Repository: https://github.com/itagagaki/Network-Adapter-Indicator

using System;
using System.Windows.Forms;

namespace NetAdapterIndicator
{
    static class NetAdapterIndicator
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InvisibleForm());
        }
    }
}
