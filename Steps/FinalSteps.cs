using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Threading;

namespace NMSLegacyVersionInstaller.Steps
{
    public partial class FinalSteps : UserControl
    {
        public FinalSteps()
        {
            InitializeComponent();
        }
        private ConsoleControl.ConsoleControl console;
        public int FinalStepIndex = 0;

        private void FinalSteps_Load(object sender, EventArgs e)
        {
            // Console Set Up
            console = new ConsoleControl.ConsoleControl();
            console.Width = pnlConsole.Width;
            console.Height = pnlConsole.Height;
            console.IsInputEnabled = true;
            console.Font = TextBox.DefaultFont;

            pnlConsole.Controls.Add(console);

            console.Focus();
            Program.Container.SetStepsEnabled(false);
            var depotdownloader = NMSLegacyVersionInstaller.Container.FindStep<DepotDownloader>();

            // Extras
            string extras = Path.Combine(depotdownloader.InstallationPath, "Extras");
            console.WriteOutput("Extracting Extras..." + Environment.NewLine, Color.Lime);
            Program.ExtractInstallerFiles("NMSLegacyVersionInstaller.InstallerExtras.", extras);
            Program.CreateShortcutWithIcon(Path.Combine(depotdownloader.InstallationPath, "SmartSaveFolder.lnk"), Path.Combine(extras, "SmartSaveFolder.exe"));

            // Start Tasks

            foreach (var thisCommand in depotdownloader.DepotDownloaderCommands)
            {
                
                var folder = thisCommand.folder;
                 console.WriteOutput("Processing " + Path.GetFileName(thisCommand.folder) + Environment.NewLine, Color.Lime);

                //steam_api64.dll
                var binaries = Path.Combine(folder, "Binaries");
                console.WriteOutput("Replace steam_api64.dll.." + Environment.NewLine, Color.Orange);
                File.Copy(Path.Combine(Program.TempFileLocation, "steam_api64.dll"), Path.Combine(binaries, "steam_api64.dll"), true);

                //steamstub
                console.WriteOutput("Running Steamless..." + Environment.NewLine, Color.Orange);
                var NMSexePath = Path.Combine(binaries, "NMS.exe");
                var unpackedNMSexePath = Path.Combine(binaries, "NMS.exe.unpacked.exe");
                
                
                console.StartProcess(Path.Combine(Program.TempFileLocation, "Steamless.CLI.exe"), "\"" + NMSexePath + "\"");

                do
                {
                    Thread.Sleep(500);
                    Application.DoEvents();
                } while (console.IsProcessRunning);

                try
                {
                    console.StopProcess();
                }
                catch { }

                if (File.Exists(unpackedNMSexePath))
                {
                    console.WriteOutput("Moving Unpacked File..." + Environment.NewLine, Color.Orange);
                    File.Move(NMSexePath, NMSexePath + ".bak");
                    File.Move(unpackedNMSexePath, NMSexePath);
                }

                //shortcut
                var iconPath = Path.Combine(extras, thisCommand.icon);
                Program.CreateShortcutWithIcon(Path.Combine(depotdownloader.InstallationPath, thisCommand.name + ".lnk"), NMSexePath, iconPath);

            }

            console.WriteOutput("Complete" + Environment.NewLine, Color.Lime);
            File.WriteAllText(Path.Combine(depotdownloader.InstallationLogPath, "02_FinalStepsLog-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), console.InternalRichTextBox.Text);

            Program.Container.SetStepsEnabled(true);
            Program.Container.Next();
        }




    }
}
