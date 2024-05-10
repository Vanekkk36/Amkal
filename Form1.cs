using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaFootballGame
{
    public partial class Form1 : Form
    {
        private Point position;
        private bool dragging;
        public Form1()
        {
            InitializeComponent();
            bg1.MouseDown += MouseClickDown;
            bg1.MouseUp += MouseClickUp;
            bg1.MouseMove += MouseClickMove;
            bg2.MouseDown += MouseClickDown;
            bg2.MouseUp += MouseClickUp;
            bg2.MouseMove += MouseClickMove;

        }
        private void MouseClickDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            position.X = e.X;
            position.Y = e.Y;
        }
        private void MouseClickUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void MouseClickMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point currentPoint = PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(currentPoint.X - position.X, currentPoint.Y - position.Y + bg1.Top);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int speed = 10;
            bg1.Top += speed;
            bg2.Top += speed;

            if (bg1.Top >= 640)
            {
                bg1.Top = 0;
                bg2.Top = -640;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 10;
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left)&& player.Left > 150)
            {
                player.Left -= speed;
            }
            else if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && player.Right < 700)
            {
                player.Left += speed;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
