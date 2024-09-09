namespace railwaystation
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ZFA = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.ZDA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(883, 575);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(68, 575);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(784, 62);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "GD,50,1,0;DC,0,1,0;ZC,10,1,3;GD,100,1,0;DC,0,1,1;ZC,10,1,2;GD,40,1,0;GD,90,2,0;ZC" +
    ",10,2,1;GD,20,2,0;ZC,10,2,0;GD,80,2,0";
            // 
            // ZFA
            // 
            this.ZFA.Location = new System.Drawing.Point(1160, 575);
            this.ZFA.Name = "ZFA";
            this.ZFA.Size = new System.Drawing.Size(114, 62);
            this.ZFA.TabIndex = 2;
            this.ZFA.Text = "测试按钮2";
            this.ZFA.UseVisualStyleBackColor = true;
            this.ZFA.Click += new System.EventHandler(this.ZFA_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(1026, 575);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 62);
            this.textBox2.TabIndex = 3;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1344, 712);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.White;
            this.lineShape1.BorderWidth = 5;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 1250;
            this.lineShape1.X2 = 1325;
            this.lineShape1.Y1 = 19;
            this.lineShape1.Y2 = 19;
            // 
            // ZDA
            // 
            this.ZDA.Location = new System.Drawing.Point(1160, 486);
            this.ZDA.Name = "ZDA";
            this.ZDA.Size = new System.Drawing.Size(114, 62);
            this.ZDA.TabIndex = 5;
            this.ZDA.Text = "测试按钮1";
            this.ZDA.UseVisualStyleBackColor = true;
            this.ZDA.Click += new System.EventHandler(this.ZDA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1344, 712);
            this.Controls.Add(this.ZDA);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.ZFA);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "站场图";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ZFA;
        private System.Windows.Forms.TextBox textBox2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button ZDA;
    }
}

