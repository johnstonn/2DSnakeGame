using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake
{
    public partial class startMenu : Form
    {
        public startMenu()
        {
            InitializeComponent();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            //Loads the SnakeGame form.
            SnakeGame frm = new SnakeGame();
            frm.Show();
            
        }

        private void cmdScores_Click(object sender, EventArgs e)
        {
            //loads the high scores form.
            Scores frm = new Scores();
            frm.Show();
        }
    }
}
