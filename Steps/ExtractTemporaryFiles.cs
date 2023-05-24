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

namespace NMSLegacyVersionInstaller.Steps
{
    public partial class ExtractTemporaryFiles : UserControl
    {
        public ExtractTemporaryFiles()
        {
            InitializeComponent();
        }

        private void ExtractTemporaryFiles_Load(object sender, EventArgs e)
        {
            Program.TempFileLocation = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Program.ExtractInstallerFiles("NMSLegacyVersionInstaller.InstallerFiles.", Program.TempFileLocation);
            Program.ExtractInstallerFiles("NMSLegacyVersionInstaller.InstallerFilesPlugins.", Path.Combine(Program.TempFileLocation,"Plugins"));

            // Verify DepotDownloader Will Work
            string ddTestRunOutput = string.Empty;

            using (Process process = new Process())
            {
                process.StartInfo.FileName = Path.Combine(Program.TempFileLocation, "DepotDownloader.exe");
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.OutputDataReceived += (s, p) => ddTestRunOutput += p.Data + Environment.NewLine;
                process.ErrorDataReceived += (s, p) => ddTestRunOutput += p.Data + Environment.NewLine;

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }

            // Error reported by "RaveDave" for Debug Testing
            /*
            ddTestRunOutput = @"A fatal error occurred. The required library hostfxr.dll could not be found.
If this is a self-contained application, that library should exist in [].
If this is a framework-dependent application, install the runtime in the global location [C:\Program Files\dotnet] or use the DOTNET_ROOT environment variable to specify the runtime location or register the runtime location in [HKLM\SOFTWARE\dotnet\Setup\InstalledVersions\x64\InstallLocation].

The .NET runtime can be found at:
  
https://aka.ms/dotnet-core-applaunch?missing_runtime=true&arch=x64&rid=win10-x64&apphost_version=6.0.4";
            */

            if (ddTestRunOutput.Contains("A fatal error occurred"))
            {
                string pattern = @"(https?://\S+)"; // Regex pattern to match URLs starting with http:// or https://
                var match = System.Text.RegularExpressions.Regex.Match(ddTestRunOutput, pattern);
                string url = match.Success ? match.Value : "";

                string message = "DepotDownloader is required to download No Man's Sky and reported an error:" + Environment.NewLine + ddTestRunOutput + Environment.NewLine;

                if (!string.IsNullOrEmpty(url))
                {
                    message += "-------------" + Environment.NewLine + "Do you wish to download and install the required package(s) now?";

                    var output = MessageBox.Show(message, "DepotDownload Compatibility Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (output == DialogResult.Yes)
                    {
                        Process.Start(url);
                    }
                }
                else
                {
                    MessageBox.Show(message, "DepotDownload Compatibility Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            Program.Container.Next();
        }
    }
}
