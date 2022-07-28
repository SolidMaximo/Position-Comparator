
namespace Position_Comparator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_robotProgramPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_posEnd = new System.Windows.Forms.TextBox();
            this.textBox_posStart = new System.Windows.Forms.TextBox();
            this.button_start = new System.Windows.Forms.Button();
            this.listBox_Lines = new System.Windows.Forms.ListBox();
            this.textBox_xAxis = new System.Windows.Forms.TextBox();
            this.textBox_yAxis = new System.Windows.Forms.TextBox();
            this.textBox_zAxis = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox_extractedPositions = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_r = new System.Windows.Forms.TextBox();
            this.textBox_w = new System.Windows.Forms.TextBox();
            this.textBox_p = new System.Windows.Forms.TextBox();
            this.listBox_diff = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_robotProgramPath2 = new System.Windows.Forms.TextBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.listBox_extractedPositions2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox_robotProgramPath
            // 
            this.textBox_robotProgramPath.Location = new System.Drawing.Point(89, 22);
            this.textBox_robotProgramPath.Name = "textBox_robotProgramPath";
            this.textBox_robotProgramPath.Size = new System.Drawing.Size(407, 20);
            this.textBox_robotProgramPath.TabIndex = 0;
            this.textBox_robotProgramPath.Text = "D:\\Robot\\Backups\\VW\\416\\Cell49\\2022-07-20T07-20-07_all\\10R2\\sty1app1.ls";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Program Path";
            // 
            // textBox_posEnd
            // 
            this.textBox_posEnd.Location = new System.Drawing.Point(89, 100);
            this.textBox_posEnd.Name = "textBox_posEnd";
            this.textBox_posEnd.Size = new System.Drawing.Size(130, 20);
            this.textBox_posEnd.TabIndex = 2;
            // 
            // textBox_posStart
            // 
            this.textBox_posStart.Location = new System.Drawing.Point(89, 74);
            this.textBox_posStart.Name = "textBox_posStart";
            this.textBox_posStart.Size = new System.Drawing.Size(130, 20);
            this.textBox_posStart.TabIndex = 3;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(420, 71);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // listBox_Lines
            // 
            this.listBox_Lines.FormattingEnabled = true;
            this.listBox_Lines.Location = new System.Drawing.Point(268, 426);
            this.listBox_Lines.Name = "listBox_Lines";
            this.listBox_Lines.Size = new System.Drawing.Size(215, 108);
            this.listBox_Lines.TabIndex = 6;
            // 
            // textBox_xAxis
            // 
            this.textBox_xAxis.Location = new System.Drawing.Point(89, 130);
            this.textBox_xAxis.Name = "textBox_xAxis";
            this.textBox_xAxis.Size = new System.Drawing.Size(56, 20);
            this.textBox_xAxis.TabIndex = 7;
            // 
            // textBox_yAxis
            // 
            this.textBox_yAxis.Location = new System.Drawing.Point(89, 158);
            this.textBox_yAxis.Name = "textBox_yAxis";
            this.textBox_yAxis.Size = new System.Drawing.Size(56, 20);
            this.textBox_yAxis.TabIndex = 8;
            // 
            // textBox_zAxis
            // 
            this.textBox_zAxis.Location = new System.Drawing.Point(89, 186);
            this.textBox_zAxis.Name = "textBox_zAxis";
            this.textBox_zAxis.Size = new System.Drawing.Size(56, 20);
            this.textBox_zAxis.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Z:";
            // 
            // listBox_extractedPositions
            // 
            this.listBox_extractedPositions.FormattingEnabled = true;
            this.listBox_extractedPositions.Location = new System.Drawing.Point(503, 12);
            this.listBox_extractedPositions.Name = "listBox_extractedPositions";
            this.listBox_extractedPositions.Size = new System.Drawing.Size(238, 368);
            this.listBox_extractedPositions.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "R:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "W:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "P:";
            // 
            // textBox_r
            // 
            this.textBox_r.Location = new System.Drawing.Point(174, 186);
            this.textBox_r.Name = "textBox_r";
            this.textBox_r.Size = new System.Drawing.Size(56, 20);
            this.textBox_r.TabIndex = 16;
            // 
            // textBox_w
            // 
            this.textBox_w.Location = new System.Drawing.Point(174, 158);
            this.textBox_w.Name = "textBox_w";
            this.textBox_w.Size = new System.Drawing.Size(56, 20);
            this.textBox_w.TabIndex = 15;
            // 
            // textBox_p
            // 
            this.textBox_p.Location = new System.Drawing.Point(174, 131);
            this.textBox_p.Name = "textBox_p";
            this.textBox_p.Size = new System.Drawing.Size(56, 20);
            this.textBox_p.TabIndex = 14;
            // 
            // listBox_diff
            // 
            this.listBox_diff.FormattingEnabled = true;
            this.listBox_diff.Location = new System.Drawing.Point(1013, 12);
            this.listBox_diff.Name = "listBox_diff";
            this.listBox_diff.Size = new System.Drawing.Size(238, 368);
            this.listBox_diff.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Program Path";
            // 
            // textBox_robotProgramPath2
            // 
            this.textBox_robotProgramPath2.Location = new System.Drawing.Point(89, 48);
            this.textBox_robotProgramPath2.Name = "textBox_robotProgramPath2";
            this.textBox_robotProgramPath2.Size = new System.Drawing.Size(407, 20);
            this.textBox_robotProgramPath2.TabIndex = 21;
            this.textBox_robotProgramPath2.Text = "D:\\Robot\\Backups\\VW\\416\\Cell49\\2022-07-26T10-24-48_all\\10R2\\sty1app1.ls";
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(420, 100);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 23;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // listBox_extractedPositions2
            // 
            this.listBox_extractedPositions2.FormattingEnabled = true;
            this.listBox_extractedPositions2.Location = new System.Drawing.Point(758, 12);
            this.listBox_extractedPositions2.Name = "listBox_extractedPositions2";
            this.listBox_extractedPositions2.Size = new System.Drawing.Size(238, 368);
            this.listBox_extractedPositions2.TabIndex = 24;
            this.listBox_extractedPositions2.SelectedIndexChanged += new System.EventHandler(this.listBox_extractedPositions2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 388);
            this.Controls.Add(this.listBox_extractedPositions2);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_robotProgramPath2);
            this.Controls.Add(this.listBox_diff);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_r);
            this.Controls.Add(this.textBox_w);
            this.Controls.Add(this.textBox_p);
            this.Controls.Add(this.listBox_extractedPositions);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_zAxis);
            this.Controls.Add(this.textBox_yAxis);
            this.Controls.Add(this.textBox_xAxis);
            this.Controls.Add(this.listBox_Lines);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.textBox_posStart);
            this.Controls.Add(this.textBox_posEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_robotProgramPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_robotProgramPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_posEnd;
        private System.Windows.Forms.TextBox textBox_posStart;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.ListBox listBox_Lines;
        private System.Windows.Forms.TextBox textBox_xAxis;
        private System.Windows.Forms.TextBox textBox_yAxis;
        private System.Windows.Forms.TextBox textBox_zAxis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox_extractedPositions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_r;
        private System.Windows.Forms.TextBox textBox_w;
        private System.Windows.Forms.TextBox textBox_p;
        private System.Windows.Forms.ListBox listBox_diff;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_robotProgramPath2;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.ListBox listBox_extractedPositions2;
    }
}

