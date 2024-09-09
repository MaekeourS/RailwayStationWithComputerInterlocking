using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

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
        public class CustomLineShape : LineShape
        {
            public int Position { get; set; }
        }
        Rail[] rails = new Rail[100];
        int i = 0;
        public enum types {track,turnout,crossing};   //track轨道，turnout道岔，crossing辙叉
        private void button1_Click(object sender, EventArgs e)
        {
            ShapeContainer shapeContainer = new ShapeContainer();
            shapeContainer.Location = new System.Drawing.Point(0, 0);
            shapeContainer.Size = new System.Drawing.Size(1000, 1000);
            int Xp = 50, Length = 0, Line = 1, Other = 0,LineNow = 1;
            string[] input = textBox1.Text.Split(';');
            foreach (string s in input)
            {
                string TypeChoose = "GD";

                if (s == "") ;
                else
                {

                    string[] LocationAndSize = s.Split(',');
                    TypeChoose = LocationAndSize[0];
                    int.TryParse(LocationAndSize[1], out Length);
                    int.TryParse(LocationAndSize[2], out Line);
                    int.TryParse(LocationAndSize[3], out Other);
                }
                
                rails[i] = new Rail();
                if (LineNow != Line)
                {
                    LineNow = Line;
                    Xp = 50;
                }
                if (TypeChoose == "GD")
                {
                    rails[i].type = types.track;
                    //rails[i].pic = new CustomPictureBox();
                    //rails[i].pic.Location = new Point(Xp, Line * 55 + 50);
                    rails[i].RAIL = new CustomLineShape();
                    rails[i].RAIL.Name = i.ToString();
                    rails[i].RAIL.X1 = Xp;
                    rails[i].RAIL.Y1 = Line * 50 + 50;
                    rails[i].RAIL.X2 = rails[i].RAIL.X1 + Length;
                    rails[i].RAIL.Y2 = rails[i].RAIL.Y1;

                    Xp += Length;
                    rails[i].RAIL.BorderWidth = 5;
                    rails[i].RAIL.BorderColor = Color.White;
                    rails[i].RAIL.Tag = i;
                    rails[i].RAIL.Click += track_Click;
                    rails[i].Line = Line;
                    shapeContainer.Shapes.Add(rails[i].RAIL);
                    this.Controls.Add(shapeContainer);
                    //rails[i].pic.Size = new Size(50, 5);
                    //rails[i].pic.BackColor = Color.White;
                    //rails[i].pic.Tag = i;
                    //rails[i].pic.Click += PictureBox_Click;
                    //this.Controls.Add(rails[i].pic);
                    /*
                    rails[i].j = i;
                    if (i >= 1 && rails[i].Line == rails[i - 1].Line)
                    {
                        rails[i].Left = rails[i - 1];
                        rails[i - 1].Right = rails[i];
                    }
                    */
                }
                else if (TypeChoose == "DC")
                {
                    rails[i].type = types.turnout;
                    rails[i].RAIL = new CustomLineShape();
                    rails[i].RAIL.Name = i.ToString();
                    if (Other == 0)
                    {
                        rails[i].RAIL.X1 = Xp + 10;
                        rails[i].RAIL.Y1 = Line * 50 + 60;
                        rails[i].RAIL.X2 = rails[i].RAIL.X1 + 30;
                        rails[i].RAIL.Y2 = rails[i].RAIL.Y1 + 30;
                    }
                    else
                    {
                        rails[i].RAIL.X1 = Xp;
                        rails[i].RAIL.Y1 = Line * 50 + 60 ;
                        rails[i].RAIL.X2 = rails[i].RAIL.X1 - 30;
                        rails[i].RAIL.Y2 = rails[i].RAIL.Y1 + 30;
                    }

                    rails[i].RAIL.BorderWidth = 5;
                    rails[i].RAIL.BorderColor = Color.White;
                    rails[i].RAIL.Tag = i;
                    rails[i].RAIL.Click += track_Click;
                    rails[i].Line = Line;
                    shapeContainer.Shapes.Add(rails[i].RAIL);
                    this.Controls.Add(shapeContainer);
                    /*
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
                    */
                }
                else if (TypeChoose == "ZC")
                {
                    rails[i].type = types.crossing;
                    rails[i].RAIL = new CustomLineShape();
                    rails[i].RAIL.Name = i.ToString();
                    rails[i].Condition = 0;
                    rails[i].Shape = Other;  //0->向上撇形，1->向上捺形，2->向下撇形，3->向下捺形
                    rails[i].RAIL.X1 = Xp;
                    rails[i].RAIL.Y1 = Line * 50 + 50;
                    rails[i].RAIL.X2 = rails[i].RAIL.X1 + Length;
                    rails[i].RAIL.Y2 = rails[i].RAIL.Y1;
                    Xp += Length;
                    rails[i].RAIL.BorderWidth = 5;
                    rails[i].RAIL.BorderColor = Color.White;
                    rails[i].RAIL.Tag = i;
                    rails[i].RAIL.Click += track_Click;
                    rails[i].RAIL.DoubleClick += crossing_DoubleClick;
                    rails[i].Line = Line;
                    shapeContainer.Shapes.Add(rails[i].RAIL);
                    this.Controls.Add(shapeContainer);
                    /*
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
                    */
                }
                i++;
            }
            //this.Controls.Add(shapeContainer);
        }

        private void RAIL_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void track_Click(object sender, EventArgs e)
        {
            dynamic clickedLineShape = sender;
            if (clickedLineShape is CustomLineShape)
            {
                textBox2.Text = clickedLineShape.Tag.ToString();
                Rail railchosen = rails[clickedLineShape.Tag];
                if (clickedLineShape.BorderColor == Color.White)
                    clickedLineShape.BorderColor = Color.Red;
                else clickedLineShape.BorderColor = Color.White;
            }

        }
        private void crossing_DoubleClick(object sender, EventArgs e)
        {
            dynamic clickedLineShape = sender;
            if (clickedLineShape is CustomLineShape)
            {
                textBox2.Text = clickedLineShape.Tag.ToString();
                Rail railchosen = rails[clickedLineShape.Tag];
                if (railchosen.Condition == 0)
                {

                    if (railchosen.Shape == 0) railchosen.RAIL.Y2 -= 10;
                    else if (railchosen.Shape == 1) railchosen.RAIL.Y1 -= 10;
                    else if (railchosen.Shape == 2) railchosen.RAIL.Y1 += 10;
                    else if (railchosen.Shape == 3) railchosen.RAIL.Y2 += 10;
                    railchosen.Condition = 1;
                }

                else// if (railchosen.pic.Image == Properties.Resources.crossingFXP)
                {
                    if (railchosen.Shape == 0) railchosen.RAIL.Y2 += 10;
                    else if (railchosen.Shape == 1) railchosen.RAIL.Y1 += 10;
                    else if (railchosen.Shape == 2) railchosen.RAIL.Y1 -= 10;
                    else if (railchosen.Shape == 3) railchosen.RAIL.Y2 -= 10;
                    railchosen.Condition = 0;
                }
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
            public LineShape RAIL { get; set; }
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

        private void ZFA_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < i; j++)
            {
                if (rails[j].type == types.crossing)
                {
                    if (rails[j].Condition == 0)
                    {

                        if (rails[j].Shape == 0) rails[j].RAIL.Y2 -= 10;
                        else if (rails[j].Shape == 1) rails[j].RAIL.Y1 -= 10;
                        else if (rails[j].Shape == 2) rails[j].RAIL.Y1 += 10;
                        else if (rails[j].Shape == 3) rails[j].RAIL.Y2 += 10;
                        rails[j].Condition = 1;
                    }
                }
            }
        }

        private void ZDA_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < i; j++)
            {
                if (rails[j].type == types.crossing)
                {
                    if (rails[j].Condition == 1)
                    {

                        if (rails[j].Shape == 0) rails[j].RAIL.Y2 += 10;
                        else if (rails[j].Shape == 1) rails[j].RAIL.Y1 += 10;
                        else if (rails[j].Shape == 2) rails[j].RAIL.Y1 -= 10;
                        else if (rails[j].Shape == 3) rails[j].RAIL.Y2 -= 10;
                        rails[j].Condition = 0;
                    }
                }
            }
        }
    }
}
