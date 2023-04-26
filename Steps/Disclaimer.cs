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

namespace NMSLegacyVersionInstaller.Steps
{
    public partial class Disclaimer : UserControl
    {
        public Disclaimer()
        {
            InitializeComponent();
        }

        private void Disclaimer_Load(object sender, EventArgs e)
        {            
             txtDisclaimer.Text = Properties.Resources.Disclaimer;            
        }
    }
}
