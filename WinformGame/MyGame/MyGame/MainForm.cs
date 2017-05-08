using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGame
{
    public partial class MainForm : Form
    {
        public Home home;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            home = new Home();
            home.Show();
            TabGroup.Controls.Clear();
            TabGroup.Controls.Add(home);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            home.Dispose();
        }
    }
}
