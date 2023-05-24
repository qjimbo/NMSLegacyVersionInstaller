using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using ConsoleControl;
using ConsoleControlAPI;

namespace NMSLegacyVersionInstaller.Steps
{
    public partial class DepotDownloader : UserControl
    {
        public class DepotDownloaderCommand
        {
            public DepotDownloaderCommand(string folder, string args, string name, string icon)
            {
                this.folder = folder;
                this.args = args;
                this.name = name;
                this.icon = icon;
            }
            public string folder { get; set; }
            public string args { get; set; }
            public string name { get; set; } // Used on final step
            public string icon { get; set; } // Used on final step
        }

        public string DepotDownloaderPath;
        public List<DepotDownloaderCommand> DepotDownloaderCommands;
        public int DepotDownloaderCommandIndex = -1;
        public int DepotDownloaderAttempt = 1;
        public string InstallationPath;
        public string InstallationLogPath;

        public DepotDownloader()
        {
            InitializeComponent();
        }
        private ConsoleControl.ConsoleControl console;
        

        private void SteamDoLogin_Load(object sender, EventArgs e)
        {
            var credentials = NMSLegacyVersionInstaller.Container.FindStep<SteamCredentials>();
            string username = credentials.txtUsername.Text;
            string password = credentials.txtPassword.Text;
            Steam.Username = username;
            var selectversion = NMSLegacyVersionInstaller.Container.FindStep<SelectVersion>();
            InstallationPath = selectversion.txtPath.Text;
            InstallationLogPath = Path.Combine(InstallationPath, "Log");

            if (!Directory.Exists(InstallationPath))
                Directory.CreateDirectory(InstallationPath);
            if (!Directory.Exists(InstallationLogPath))
                Directory.CreateDirectory(InstallationLogPath);

            DepotDownloaderPath = Path.Combine(Program.TempFileLocation, "DepotDownloader.exe");

            DepotDownloaderCommands = new List<DepotDownloaderCommand>();

            if (selectversion.rb01.Checked)
            {
                string downloadPath = Path.Combine(InstallationPath, "no_mans_sky_v1.09.1");
                string args = " -app 275850 -depot 275851 -manifest 7324577403707723494 -dir \"" + downloadPath + "\" -username " + username + " -password " + password + " -remember-password";
                DepotDownloaderCommands.Add(new DepotDownloaderCommand(downloadPath,args,"No Man's Sky Initial Release", "01_icon.ico"));                
            }

            if (selectversion.rb02.Checked)
            {
                string downloadPath = Path.Combine(InstallationPath, "no_mans_sky_v1.13");
                string args = " -app 275850 -depot 275851 -manifest 2123008115602074603 -dir \"" + downloadPath + "\" -username " + username + " -password " + password + " -remember-password";
                DepotDownloaderCommands.Add(new DepotDownloaderCommand(downloadPath, args, "No Man's Sky Foundation", "02_icon.ico"));
            }

            if (selectversion.rb03.Checked)
            {
                string downloadPath = Path.Combine(InstallationPath, "no_mans_sky_v1.24");
                string args = " -app 275850 -depot 275851 -manifest 3749359456608052294 -dir \"" + downloadPath + "\" -username " + username + " -password " + password + " -remember-password";
                DepotDownloaderCommands.Add(new DepotDownloaderCommand(downloadPath, args, "No Man's Sky Path Finder", "03_icon.ico"));
            }

            if (selectversion.rb04.Checked)
            {
                string downloadPath = Path.Combine(InstallationPath, "no_mans_sky_v1.38");
                string args = " -app 275850 -depot 275851 -manifest 8262658978126728861 -dir \"" + downloadPath + "\" -username " + username + " -password " + password + " -remember-password";
                DepotDownloaderCommands.Add(new DepotDownloaderCommand(downloadPath, args, "No Man's Sky Atlas Rises", "04_icon.ico"));
            }

            console = new ConsoleControl.ConsoleControl();
            console.Width = pnlConsole.Width;
            console.Height = pnlConsole.Height;
            console.IsInputEnabled = true;
            console.Font = TextBox.DefaultFont;
            console.ProcessInterface.OnProcessExit += OnProcessExit;

            pnlConsole.Controls.Add(console);

            console.Focus();
            Program.Container.SetStepsEnabled(false);
            DepotDownloaderAttempt = 1;
            StartNextDepotDownload();
            
        }

        private void StartNextDepotDownload()
        {
            BeginInvoke((MethodInvoker)(() => { // Threadsafe
                int lineCount = console.InternalRichTextBox.Lines.Count();
                string lastLine = lineCount >= 2 ? console.InternalRichTextBox.Lines[lineCount - 2] : "";
            

                if (lastLine.ToLower().Contains("error"))
                {
                    if (DepotDownloaderAttempt == 3)
                    {
                        console.WriteOutput("Error Downloading after 3 attempts, unable to download." + Environment.NewLine, Color.Red);
                        Program.Container.btnNext.Text = "Finish";
                        return;
                    }
                    DepotDownloaderAttempt++;
                    console.WriteOutput("Error Downloading, Retrying..." + Environment.NewLine, Color.Red);
                }
                else
                {
                    DepotDownloaderCommandIndex++;
                }
                if (DepotDownloaderCommandIndex == DepotDownloaderCommands.Count())
                {
                    console.WriteOutput("Complete", Color.Lime);

                    
                    File.WriteAllText(Path.Combine(InstallationLogPath,"01_DepotDownloaderLog-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"),console.InternalRichTextBox.Text);

                    Program.Container.SetStepsEnabled(true);
                    Program.Container.Next();
                    return;
                }
                var thisCommand = DepotDownloaderCommands[DepotDownloaderCommandIndex];
                DepotDownloaderAttempt = 1;
                console.WriteOutput("Downloading " + Path.GetFileName(thisCommand.folder) + Environment.NewLine, Color.Lime);
                new Thread(() =>
                {
                    Thread.Sleep(3000);
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        console.StartProcess(DepotDownloaderPath, thisCommand.args);
                    }));
                }).Start();
               
                
            }));
        }

        private void OnProcessExit(object sender, ProcessEventArgs args)
        {
            StartNextDepotDownload();
        }
    }
}
