// This file is part of the 'Network Adapter Indicator'.
// Repository: https://github.com/itagagaki/Network-Adapter-Indicator

using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace NetAdapterIndicator
{
    public partial class InvisibleForm : Form
    {
        #region Global Variables
        NotifyIcon currentIcon;
        Icon upIcon, downIcon;
        #endregion

        #region Main Form (entry point)
        public InvisibleForm()
        {
            InitializeComponent();

            // Load icons.
            upIcon = new Icon("Adapter_Up.ico");
            downIcon = new Icon("Adapter_Down.ico");
            currentIcon = new NotifyIcon();
            currentIcon.Icon = downIcon;
            currentIcon.Visible = true;

            // Create menu items.
            MenuItem quitMenuItem = new MenuItem("Quit");
            quitMenuItem.Click += quitMenuItem_Click;

            // Create a context menu for the icon.
            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(quitMenuItem);
            currentIcon.ContextMenu = contextMenu;
            UpdateIndicator();

            // Hide the form because we don't need it, this is a notification tray application.
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            // Set up a listener to listen for events where network availability or address has changed.
            NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(OnNetworkAvailabilityChanged);
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler(OnNetworkAddressChanged);
        }
        #endregion

        #region Context Menu Event Handlers
        /// <summary>
        /// Handler on 'Quit' is clicked. Close the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void quitMenuItem_Click(object sender, EventArgs e)
        {
            //NetAdapterStatusWorkerThread.Abort();
            currentIcon.Dispose();
            upIcon.Dispose();
            downIcon.Dispose();
            this.Close();
        }
        #endregion

        #region Network Event Handlers
        /// <summary>
        /// Network availability changed event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNetworkAvailabilityChanged(object sender, EventArgs e)
        {
            UpdateIndicator();
        }
        /// <summary>
        /// Network address changed event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNetworkAddressChanged(object sender, EventArgs e)
        {
            UpdateIndicator();
        }
        #endregion

        /// <summary>
        /// Update the indicator to show whether we are currently connected to the VPN.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateIndicator()
        {
            // Check if at least one adapter with a name starting with 'VPN' is Up.
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            bool up = false;
            foreach (NetworkInterface adapter in nics)
            {
                if (adapter.Name.StartsWith("VPN") && adapter.OperationalStatus == OperationalStatus.Up)
                {
                    up = true;
                    break;
                }
            }
            // Update the icon.
            currentIcon.Icon = up ? upIcon : downIcon;
        }
    }
}
