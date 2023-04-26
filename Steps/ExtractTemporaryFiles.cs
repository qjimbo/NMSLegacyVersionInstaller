using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            Program.Container.Next();
        }
    }
}
