using System;
using System.Windows.Forms;
using Microsoft.WindowsCE.Forms;

namespace SuperCAL_CE
{
    partial class Main
    {
        private MainMenu MainMenu = new MainMenu();
        private MenuItem AboutBtn = new MenuItem();
        private MenuItem ToolsBtn = new MenuItem();
        private MenuItem Tools_OSK = new MenuItem();
        private MenuItem Tools_Seperator = new MenuItem();
        private MenuItem Tools_ShowProcesses = new MenuItem();
        private void InitializeMainMenu()
        {
            MainMenu.MenuItems.Add(ToolsBtn);
            ToolsBtn.MenuItems.Add(Tools_OSK);
            ToolsBtn.MenuItems.Add(Tools_Seperator);
            ToolsBtn.MenuItems.Add(Tools_ShowProcesses);
            MainMenu.MenuItems.Add(AboutBtn);
            Tools_Seperator.Text = "-";
            ToolsBtn.Text = "Tools";
            Tools_OSK.Text = "On Screen Keyboard";
            Tools_ShowProcesses.Text = "Show Running Processes";
            AboutBtn.Text = "About";
            AboutBtn.Click += AboutBtn_Click;
            Tools_ShowProcesses.Click += Tools_ShowProcesses_Click;
            Tools_OSK.Click += Tools_OSK_Click;
            Menu = MainMenu;
        }
        private void Tools_OSK_Click(object sender, EventArgs e)
        {
            InputPanel ip = new InputPanel();
            foreach (InputMethod im in ip.InputMethods)
            {
                if (im.Name == "LargeKB")
                {
                    ip.CurrentInputMethod = im;
                    break;
                }
            }
            ip.Enabled = true;
            Logger.Good("Opened OSK.");
        }
        private void Tools_ShowProcesses_Click(object sender, EventArgs e)
        {
             foreach (ProcessCE process in ProcessCE.GetProcesses())
             {
                 Logger.Log("PID: " + process.handle.ToInt32() + " Name: " + process.processName);
             }
        }
        private void AboutBtn_Click(object sender, EventArgs e)
        {
            Logger.Log("Super CAL CE 2019, by Dylan Bickerstaff.");
        }
    }
}
