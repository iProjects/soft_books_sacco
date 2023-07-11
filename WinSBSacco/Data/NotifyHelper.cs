using System; 
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CommonLib
{
   public static class NotifyHelper
    {
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.ComponentModel.IContainer components;

        public NotifyHelper()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            // Initialize contextMenu1 
            //this.contextMenu1.MenuItems.AddRange(
            //            new System.Windows.Forms.MenuItem[] { this.menuItem1 });
            //contextMenu1.MenuItems.Add("Exit", ExitApplication);
            // or using an anonymous method:
            //contextMenu1.MenuItems.Add("Exit", (s, e) => Application.Exit()); 

            // Initialize menuItem1 
            //this.menuItem1.Index = 0;
            //this.menuItem1.Text = "E&xit";
            //this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

            // Set up how the form should be displayed. 
            //this.ClientSize = new System.Drawing.Size(292, 266);
            //this.Text = "Notify Icon Example";

            // Create the NotifyIcon. 
            //this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);

            // The Icon property sets the icon that will appear 
            // in the systray for this application.
            //notifyIcon1.Icon = new Icon("appicon.ico");

            // The ContextMenu property sets the menu that will 
            // appear when the systray icon is right clicked.
            //notifyIcon1.ContextMenu = this.contextMenu1;
             
        }
        public bool NotifyMessage(string _Title, string _Text)
        {
            try
            {
                notifyIcon1.Text = "Soft Books Sacco";
                notifyIcon1.Icon = new Icon("Resources/Icons/Dollar.ico");
                contextMenu1.MenuItems.Add("Home", NavigateHome);
                contextMenu1.MenuItems.Add("Exit", ExitApplication);
                notifyIcon1.ContextMenu = this.contextMenu1;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = _Title;
                notifyIcon1.BalloonTipText = _Text;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(900000);

                return true;
            }
            catch (Exception ex)
            { 
                Utils.LogEventViewer(ex);
                return false;
            }
        }
        private void ExitApplication(object sender, EventArgs e)
        {
            try
            {
                NotifyMessage("Soft Books Sacco", "Exiting...");
                Application.Exit();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void NavigateHome(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://softwareproviders.co.ke/SoftBooksSacco.html");
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        

    }
}
