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
    public partial class startMenuForm : Form
    {
        public startMenuForm()
        {
            InitializeComponent();
        }
        private void cmdStart_Click(object sender, EventArgs e)
            //Loads the SnakeGame form.
        {
            SnakeGameForm frm = new SnakeGameForm();
            frm.Show();
            
        }
        private void cmdScores_Click(object sender, EventArgs e)
            //loads the high scores form.
        {
            ScoresForm frm = new ScoresForm();
            frm.Show();
        }
    }
}
