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
using ConsoleControl;
using ConsoleControlAPI;

namespace NMSLegacyVersionInstaller.Steps
{
    public partial class FinalSteps : UserControl
    {
        public FinalSteps()
        {
            InitializeComponent();
        }
        private ConsoleControl.ConsoleControl console;
        public int currentCommandIndex = 0;
        public DepotDownloader depotDownloader;
        public string extras;

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
            depotDownloader = NMSLegacyVersionInstaller.Container.FindStep<DepotDownloader>();

            // Extras
            extras = Path.Combine(depotDownloader.InstallationPath, "Extras");
            console.WriteOutput("Extracting Extras..." + Environment.NewLine, Color.Lime);
            Program.ExtractInstallerFiles("NMSLegacyVersionInstaller.InstallerExtras.", extras);
            Program.CreateShortcutWithIcon(Path.Combine(depotDownloader.InstallationPath, "SmartSaveFolder.lnk"), Path.Combine(extras, "SmartSaveFolder.exe"));

            // Start Task
            currentCommandIndex = 0;
            console.ProcessInterface.OnProcessExit += AfterUnpack;
            BeforeUnpack();
        }

        private void BeforeUnpack()
        {
            BeginInvoke((MethodInvoker)(() =>
            { // Threadsafe
                var thisCommand = depotDownloader.DepotDownloaderCommands[currentCommandIndex];
                var binaries = Path.Combine(thisCommand.folder, "Binaries");
                var NMSexePath = Path.Combine(binaries, "NMS.exe");

                console.WriteOutput("Processing " + Path.GetFileName(thisCommand.folder) + Environment.NewLine, Color.Lime);

                console.WriteOutput("Replace steam_api64.dll.." + Environment.NewLine, Color.Orange);
                File.Copy(Path.Combine(Program.TempFileLocation, "steam_api64.dll"), Path.Combine(binaries, "steam_api64.dll"), true);

                console.WriteOutput("Running Steamless..." + Environment.NewLine, Color.Orange);

                new Thread(() =>
                {
                    Thread.Sleep(3000);
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        console.StartProcess(Path.Combine(Program.TempFileLocation, "Steamless.CLI.exe"), "\"" + NMSexePath + "\"");
                    }));
                }).Start();
            }));
        }

        private void AfterUnpack(object sender, ProcessEventArgs args)
        {
            BeginInvoke((MethodInvoker)(() =>
            { // Threadsafe
                var thisCommand = depotDownloader.DepotDownloaderCommands[currentCommandIndex];

                // After Steamless
                var binaries = Path.Combine(thisCommand.folder, "Binaries");
                var NMSexePath = Path.Combine(binaries, "NMS.exe");
                var unpackedNMSexePath = Path.Combine(binaries, "NMS.exe.unpacked.exe");

                if (File.Exists(unpackedNMSexePath))
                {
                    console.WriteOutput("Moving Unpacked File..." + Environment.NewLine, Color.Orange);
                    File.Move(NMSexePath, NMSexePath + ".bak");
                    File.Move(unpackedNMSexePath, NMSexePath);
                }

                var iconPath = Path.Combine(extras, thisCommand.icon);
                Program.CreateShortcutWithIcon(Path.Combine(depotDownloader.InstallationPath, thisCommand.name + ".lnk"), NMSexePath, iconPath);


                if (currentCommandIndex < depotDownloader.DepotDownloaderCommands.Count - 1)
                {
                    currentCommandIndex++;
                    BeforeUnpack(); // Next Unpack
                }
                else
                {
                    console.WriteOutput("Complete" + Environment.NewLine, Color.Lime);
                    File.WriteAllText(Path.Combine(depotDownloader.InstallationLogPath, "02_FinalStepsLog-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt"), console.InternalRichTextBox.Text);

                    Program.Container.SetStepsEnabled(true);
                    Program.Container.Next();
                }
            }));
        }


    }
}
