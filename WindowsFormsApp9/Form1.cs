using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        private Player player;
        int speed = 2;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(press);
            player = new Player(new Point(this.Width / 2, this.Height / 2));
            FormClosing += new FormClosingEventHandler(close);
            timer = new Timer(1);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            updateGame();
        }

        public void close(object sender, FormClosingEventArgs args)
        {
            player.stop();
            timer.Stop();
            timer.Dispose();
        }
        protected override void OnPaint(PaintEventArgs args)
        {
            player.paint(args.Graphics);
        }

        public void press(object sender, KeyEventArgs key)
        {
            if(player.currentDirection() == Direction.Stop)
            {
                player.setDirection(key.KeyCode);
                player.start();
            }
            else
            {
                player.setDirection(key.KeyCode);
            }
            
        }

        private void updateGame()
        {
            Graphics graphics = CreateGraphics();
            graphics.Clear(BackColor);
            player.paint(graphics);
        }
        public void print(object e, PaintEventArgs args)
        {
            MessageBox.Show("swrfvg");
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Graphics graphics = this.CreateGraphics();
        //    graphics.Clear(BackColor);
        //    Point point = new Point((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        //    Point point1 = new Point((int)numericUpDown3.Value, (int)numericUpDown4.Value);
        //    graphics.DrawLine(new Pen(Brushes.Orange, 3), point, point1);
        //}
    }
}
