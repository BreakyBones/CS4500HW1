// This is StartupForm.cs
// This is the designer to display the welcome message and a few instructions
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS4500HW1
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            DrawCard drawCard = new DrawCard();
            drawCard.Show();
            this.Hide();
        }
    }
}
// End of file