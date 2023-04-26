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
using System.Diagnostics;

namespace NMSLegacyVersionInstaller.Steps
{
    public partial class Complete : UserControl
    {
        public Complete()
        {
            InitializeComponent();
        }

        private void Complete_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var depotdownloader = NMSLegacyVersionInstaller.Container.FindStep<DepotDownloader>();
            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "explorer.exe";
            startInfo.Arguments = depotdownloader.InstallationPath;

            // Start the process.
            Process.Start(startInfo);

        }


    }
}
