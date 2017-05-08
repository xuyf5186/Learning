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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewGameBtn_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.ShowDialog();
            
        }
    }
}
