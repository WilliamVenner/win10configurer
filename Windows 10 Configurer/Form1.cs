using System.Collections.Generic;
using System.Windows.Forms;
using System.Management.Automation;
using Microsoft.Win32;
using System.Text;
using System.Diagnostics;
using System.IO;
using System;
using System.Security.Principal;

namespace Windows_10_Configurer
{
    public partial class Window : Form
    {
        int LastCheckedIndex;
        Dictionary<string, string> Config = new Dictionary<string, string>();
        StringBuilder DisabledApps = new StringBuilder();
        static bool IsElevated => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        StringBuilder PowerShellScript = new StringBuilder();

        public Window()
        {

            if (!IsElevated)
            {
                MessageBox.Show("You need to be running Windows 10 Configurer with administrator privileges in order to use the program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
                return;
            }

            InitializeComponent();

            string ConfigJSON = Properties.Resources.config;
            string[] splitn = ConfigJSON.Split('\n');
            foreach (string line in splitn)
            {
                string[] split = line.Split('>');
                bool m = false;
                int i = 0;
                foreach (string v in split)
                {
                    m = !m;
                    if (m == true)
                    {
                        Config.Add(v, split[i + 1]);
                    }
                    i += 1;
                }
            }

            foreach(KeyValuePair<string, string> conf in Config)
                OptionsList.Items.Add("Disable " + conf.Value);

        }

        private void ReinstallButton_Click(object sender, EventArgs e)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                OptionsList.Enabled = false;
                GoButton.Enabled = false;
                ReinstallButton.Enabled = false;
                using (FileStream PSFile = File.Create(Path.GetTempPath() + "windows10configurerpowershell_reinstall.ps1"))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("Get-AppxPackage -AllUsers| Foreach {Add-AppxPackage -DisableDevelopmentMode -Register \"$($_.InstallLocation)\\AppXManifest.xml\"}");
                    PSFile.Write(info, 0, info.Length);
                }
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "powershell.exe";
                psi.Arguments = "& '" + Path.GetTempPath() + "windows10configurerpowershell_reinstall.ps1'";
                Process process = new Process();
                process.StartInfo.Verb = "runas";
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(PowerShellExited_Reinstall);
                process.StartInfo = psi;
                process.Start();
            }
        }

        private void PowerShellExited_Reinstall(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully reinstalled all apps.");
            OptionsList.Invoke((Action)delegate
            {
                OptionsList.Enabled = true;
            });
            GoButton.Invoke((Action)delegate
            {
                GoButton.Enabled = true;
            });
            ReinstallButton.Invoke((Action)delegate
            {
                ReinstallButton.Enabled = true;
            });
            File.Delete(Path.GetTempPath() + "windows10configurerpowershell_reinstall.ps1");
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            StringBuilder PowerShellScript = new StringBuilder();
            foreach (string item in OptionsList.CheckedItems)
            {
                if (item == "Install Windows Photo Viewer")
                {
                    // http://www.howtogeek.com/225844/how-to-make-windows-photo-viewer-your-default-image-viewer-on-windows-10/
                    // Thanks to Edwin over at TenForums for locating the required registry settings.
                    // http://www.tenforums.com/software-apps/8930-windows-photo-viewer-gone-2.html#post290818

                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Applications\photoviewer.dll\shell\open", "MuiVerb", "@photoviewer.dll,-3043");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Applications\photoviewer.dll\shell\open\command", "@", @"hex(2):25,00,53,00,79,00,73,00,74,00,65,00,6d,00,52,00,6f,00,6f,00,74,00,25,\
00, 5c, 00, 53, 00, 79, 00, 73, 00, 74, 00, 65, 00, 6d, 00, 33, 00, 32, 00, 5c, 00, 72, 00, 75, 00,
6e, 00, 64, 00, 6c, 00, 6c, 00, 33, 00, 32, 00, 2e, 00, 65, 00, 78, 00, 65, 00, 20, 00, 22, 00, 25,
00, 50, 00, 72, 00, 6f, 00, 67, 00, 72, 00, 61, 00, 6d, 00, 46, 00, 69, 00, 6c, 00, 65, 00, 73, 00,
25, 00, 5c, 00, 57, 00, 69, 00, 6e, 00, 64, 00, 6f, 00, 77, 00, 73, 00, 20, 00, 50, 00, 68, 00, 6f,
00, 74, 00, 6f, 00, 20, 00, 56, 00, 69, 00, 65, 00, 77, 00, 65, 00, 72, 00, 5c, 00, 50, 00, 68, 00,
6f, 00, 74, 00, 6f, 00, 56, 00, 69, 00, 65, 00, 77, 00, 65, 00, 72, 00, 2e, 00, 64, 00, 6c, 00, 6c,
00, 22, 00, 2c, 00, 20, 00, 49, 00, 6d, 00, 61, 00, 67, 00, 65, 00, 56, 00, 69, 00, 65, 00, 77, 00,
5f, 00, 46, 00, 75, 00, 6c, 00, 6c, 00, 73, 00, 63, 00, 72, 00, 65, 00, 65, 00, 6e, 00, 20, 00, 25,
00, 31, 00, 00, 00");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Applications\photoviewer.dll\shell\open\DropTarget", "Clsid", "{FFE2A43C-56B9-4bf5-9A79-CC6D4285608A}");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Applications\photoviewer.dll\shell\print\command", "@", @"hex(2):25,00,53,00,79,00,73,00,74,00,65,00,6d,00,52,00,6f,00,6f,00,74,00,25,\
00, 5c, 00, 53, 00, 79, 00, 73, 00, 74, 00, 65, 00, 6d, 00, 33, 00, 32, 00, 5c, 00, 72, 00, 75, 00,
6e, 00, 64, 00, 6c, 00, 6c, 00, 33, 00, 32, 00, 2e, 00, 65, 00, 78, 00, 65, 00, 20, 00, 22, 00, 25,
00, 50, 00, 72, 00, 6f, 00, 67, 00, 72, 00, 61, 00, 6d, 00, 46, 00, 69, 00, 6c, 00, 65, 00, 73, 00,
25, 00, 5c, 00, 57, 00, 69, 00, 6e, 00, 64, 00, 6f, 00, 77, 00, 73, 00, 20, 00, 50, 00, 68, 00, 6f,
00, 74, 00, 6f, 00, 20, 00, 56, 00, 69, 00, 65, 00, 77, 00, 65, 00, 72, 00, 5c, 00, 50, 00, 68, 00,
6f, 00, 74, 00, 6f, 00, 56, 00, 69, 00, 65, 00, 77, 00, 65, 00, 72, 00, 2e, 00, 64, 00, 6c, 00, 6c,
00, 22, 00, 2c, 00, 20, 00, 49, 00, 6d, 00, 61, 00, 67, 00, 65, 00, 56, 00, 69, 00, 65, 00, 77, 00,
5f, 00, 46, 00, 75, 00, 6c, 00, 6c, 00, 73, 00, 63, 00, 72, 00, 65, 00, 65, 00, 6e, 00, 20, 00, 25,
00, 31, 00, 00, 00");
                    Registry.SetValue(@"HKEY_CLASSES_ROOT\Applications\photoviewer.dll\shell\print\DropTarget", "Clsid", "{60fd46de-f830-4894-a628-6fa81bc0190d}");
                } else
                {
                    string cleaned = item.Substring(8);
                    foreach (KeyValuePair<string, string> conf in Config)
                    {
                        if (conf.Value == cleaned)
                        {
                            DisabledApps.AppendLine(conf.Value.Substring(0,conf.Value.Length - 1));
                            PowerShellScript.AppendLine("Get-AppxPackage *" + conf.Key + "* | Remove-AppxPackage");
                            break;
                        }
                    }
                }
            }
            if (PowerShellScript.Length > 0)
            {
                OptionsList.Enabled = false;
                GoButton.Enabled = false;
                ReinstallButton.Enabled = false;
                using (FileStream PSFile = File.Create(Path.GetTempPath() + "windows10configurerpowershell.ps1"))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(PowerShellScript.ToString());
                    PSFile.Write(info, 0, info.Length);
                }
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "powershell.exe";
                psi.Arguments = "& '" + Path.GetTempPath() + "windows10configurerpowershell.ps1'";
                Process process = new Process();
                process.StartInfo.Verb = "runas";
                process.EnableRaisingEvents = true;
                process.Exited += new EventHandler(PowerShellExited);
                process.StartInfo = psi;
                process.Start();
            }
        }

        private void PowerShellExited(object sender, EventArgs e)
        {
            MessageBox.Show("Successfully disabled:\n\n" + DisabledApps.ToString(),"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisabledApps.Clear();
            OptionsList.Invoke((Action)delegate
            {
                OptionsList.Enabled = true;
            });
            GoButton.Invoke((Action)delegate
            {
                GoButton.Enabled = true;
            });
            ReinstallButton.Invoke((Action)delegate
            {
                ReinstallButton.Enabled = true;
            });
            File.Delete(Path.GetTempPath() + "windows10configurerpowershell.ps1");
        }

        private void OptionsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox clb = (CheckedListBox)sender;
            clb.ItemCheck -= OptionsList_ItemCheck;
            clb.SetItemCheckState(e.Index, e.NewValue);
            clb.ItemCheck += OptionsList_ItemCheck;

            if (OptionsList.CheckedItems.Count == 0)
                GoButton.Enabled = false;
            else
                GoButton.Enabled = true;
        }

        private void OptionsList_Click(object sender, EventArgs e)
        {
            if (LastCheckedIndex == OptionsList.SelectedIndex) return;
            LastCheckedIndex = OptionsList.SelectedIndex;
            OptionsList.SetItemChecked(OptionsList.SelectedIndex, !OptionsList.GetItemChecked(OptionsList.SelectedIndex));
        }
    }

    public class Config
    {
        public string PowerShellName;
        public string HumanName;
    }
}