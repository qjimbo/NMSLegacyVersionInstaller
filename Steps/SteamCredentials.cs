using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NMSLegacyVersionInstaller.Steps
{
    public partial class SteamCredentials : UserControl
    {
        public SteamCredentials()
        {
            InitializeComponent();
        }

        private void SteamCredentials_Load(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Program.Container.Next();
        }
    }
}
