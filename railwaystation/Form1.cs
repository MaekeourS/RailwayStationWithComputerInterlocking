using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace railwaystation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //PictureBox[] pic = new PictureBox[40];
        public class CustomPictureBox : PictureBox
        {
            public int Tag { get; set; }
        }
            Rail[] rails = new Rail[40];
        int i = 0;
        public enum types {track,turnout,crossing};   //track轨道，turnout道岔，crossing辙叉
        private void button1_Click(object sender, EventArgs e)
        {
            
            string[] input = textBox1.Text.Split(';');
            foreach (string s in input)
            {
                string TypeChoose = "GD"; 
                int Xp = 0, Line = 1,Other = 0;
                if (s == "")
                {
                    Xp += 50;
                }
                else
                {
                    string[] LocationAndSize = s.Split(',');
                    TypeChoose = LocationAndSize[0];
                    int.TryParse(LocationAndSize[1], out Xp);
                    int.TryParse(LocationAndSize[2], out Line);
                    int.TryParse(LocationAndSize[3], out Other);
                }
                
                rails[i] = new Rail();
                if (TypeChoose == "GD")
                {
                    rails[i].type = types.track;
                    rails[i].pic = new CustomPictureBox();
                    rails[i].pic.Location = new Point(Xp, Line * 55 + 50);
                    rails[i].Line = Line;
                    rails[i].pic.Size = new Size(50, 5);
                    rails[i].pic.BackColor = Color.White;
                    rails[i].pic.Tag = i;
                    rails[i].pic.Click += PictureBox_Click;
                    this.Controls.Add(rails[i].pic);
                    rails[i].j = i;
                    if (i >= 1 && rails[i].Line == rails[i - 1].Line)
                    {
                        rails[i].Left = rails[i - 1];
                        rails[i - 1].Right = rails[i];
                    }
                }
                else if (TypeChoose == "DC")
                {
                    rails[i].type = types.turnout;
                    rails[i].pic = new CustomPictureBox();
                    rails[i].pic.Location = new Point(Xp, Line * 55 + 65);
                    rails[i].Line = Line;
                    rails[i].pic.Size = new Size(30, 30);
                    rails[i].pic.BackColor = Color.Black;
                    if (Other == 0)
                        rails[i].pic.Image = Properties.Resources.P;
                    else
                        rails[i].pic.Image = Properties.Resources.N;
                    rails[i].pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    rails[i].pic.Tag = i;
                    rails[i].pic.Click += PictureBox_Click;
                    this.Controls.Add(rails[i].pic);
                }
                else if (TypeChoose == "ZC")
                {
                    rails[i].type = types.crossing;
                    rails[i].pic = new CustomPictureBox();
                    rails[i].pic.Location = new Point(Xp, Line * 55 + 37);
                    rails[i].Line = Line;
                    rails[i].pic.Size = new Size(50, 30);
                    rails[i].pic.BackColor = Color.Black;
                    rails[i].Condition = 0;
                    rails[i].Shape = Other;  //0->向上撇形，1->向上捺形，2->向下撇形，3->向下捺形
                    rails[i].pic.Image = Properties.Resources.crossingD;
                    rails[i].pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    rails[i].pic.Tag = i;
                    rails[i].pic.Click += PictureBox_Click;
                    this.Controls.Add(rails[i].pic);
                }
                
                i++;
            }
        }

        public class Rail
        {
            public Rail Left { get; set; }
            public Rail Right { get; set; }
            public Rail Up { get; set; }
            public Rail Down { get; set; }
            public int j { get; set; }
            public types type { get; set; }
            public int Shape { get; set; }  //0->向上撇形，1->向上捺形，2->向下撇形，3->向下捺形
            public int Condition { get; set; }  //0->定位，1->反位
            public int Line { get; set; }
            public CustomPictureBox pic { get; set; }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            CustomPictureBox clickedPictureBox = sender as CustomPictureBox;
            Rail railchosen = rails[clickedPictureBox.Tag];
            if (railchosen.type == types.track)
                if (clickedPictureBox.BackColor == Color.White)
                    clickedPictureBox.BackColor = Color.Red;
                else clickedPictureBox.BackColor = Color.White;
            else if (railchosen.type == types.crossing)
            {

                if (railchosen.Condition == 0)
                {
                    
                    if (railchosen.Shape == 0) railchosen.pic.Image = Properties.Resources.crossingFSP;
                    else if (railchosen.Shape == 1) railchosen.pic.Image = Properties.Resources.crossingFSN;
                    else if (railchosen.Shape == 2) railchosen.pic.Image = Properties.Resources.crossingFXP;
                    else if (railchosen.Shape == 3) railchosen.pic.Image = Properties.Resources.crossingFXN;
                    railchosen.Condition = 1;
                }

                else// if (railchosen.pic.Image == Properties.Resources.crossingFXP)
                {
                    railchosen.pic.Image = Properties.Resources.crossingD;
                    railchosen.Condition = 0;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int t = 0, lineChosen = 1;
            int.TryParse(textBox2.Text, out lineChosen);
            //PictureBox picing = new PictureBox();
            //picing = rails[0].pic;
            while (rails[t].Line != lineChosen)
            {
                t++;
            }
            for (;rails[t].Line == lineChosen;)
            {
                if (rails[t].pic.BackColor == Color.White)
                    rails[t].pic.BackColor = Color.Red;
                else rails[t].pic.BackColor = Color.White;
                if (rails[t].Right == null) break;
                t = rails[t].Right.j;
                //picing = rails[t].pic;
            } 
        }
    }
}
