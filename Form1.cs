using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Moq;
using CsvHelper; 


namespace Position_Comparator
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Compare Positional Data from one program to another using the program file paths as inputs 
        /// </summary>
        /// <param name="program_line_list"></param>

        private List<string> positonal_data_lines1 = new List<string>();
        private List<string> positonal_data_lines2 = new List<string>();
        public List<string> pos_lines;
        string point;
        string xAxis1;
        string yAxis1;
        string zAxis1;
        string w1;
        string p1;
        string r1;
        string xAxis2;
        string yAxis2;
        string zAxis2;
        string w2;
        string p2;
        string r2;
        List<string> data_only_list; // = new List<string>(); 
        List<string> position_difference_list; // = new List<string>(); 
        bool addLines = false;
        bool addLines2 = false;

        public Form1()
        {
            InitializeComponent();
        }

        //Main 
        private void main(string program_path1, string program_path2)
        {
            pos_range1(program_path1);
            pos_range2(program_path2); 
            position1_extractor(positonal_data_lines1);
            position2_extractor(positonal_data_lines2);

        }

        //PROGRAM 1 LIST: Creates list of lines starting at "/POS" and stops at "/END" omitting unneccsary lines 
        private void pos_range1(string program_path)
        {
            var program_path_lines = File.ReadAllLines(program_path);
            positonal_data_lines1 = new List<string>();
            addLines = false;

            int i = 0; 
            int start_index = 0;
            
            foreach(string line in program_path_lines)
            {
                i += 1; 
                if(line.Contains(@"/POS"))
                {
                    start_index = i;
                    addLines = true; 
                    //start_index = line.IndexOf(line); 
                }
                if(addLines==true)
                {
                    positonal_data_lines1.Add(line); 
                }
            }

            foreach(string item in positonal_data_lines1)
            {
                listBox_Lines.Items.Add(item); 
            }
            //return list
        }
        
        //PROGRAM 2 LIST: Creates list of lines starting at "/POS" and stops at "/END" omitting unneccsary lines 
        private void pos_range2(string program_path2)
        {
            var program_path_lines = File.ReadAllLines(program_path2);
            positonal_data_lines2 = new List<string>();
            addLines2 = false;

            int i = 0;
            int start_index = 0;

            foreach (string line in program_path_lines)
            {
                i += 1;
                if (line.Contains(@"/POS"))
                {
                    start_index = i;
                    addLines2 = true;
                    //start_index = line.IndexOf(line); 
                }
                if (addLines2 == true)
                {
                    positonal_data_lines2.Add(line);
                }
            }

            //return list
        }

        private void position1_extractor(List<string> program_line_list)
        {
            //var csv = StringBuilder(); 
             
            string csv_path = "";
            csv_path = @"C:\Users\sstafford\source\repos2\PositionPrograms\Position Comparator\position_data.csv";
            

            using(StreamWriter sw = File.CreateText("csv_path.csv"))
            {
                for(int i = 0; i < program_line_list.Count; i++)
                {
                    //var ln = String.Format("{0},{1}"); 
                    //sw.WriteLine(ln); 
                }
            }


            listBox_extractedPositions.Items.Clear(); 

            foreach (string line in program_line_list)
            {
         
                if (line.Contains(@"P["))
                {
                    string point = line.Split('{')[0] + "\n";
                    //data_only_list.Add(point);

                    listBox_extractedPositions.Items.Add(point);
                }
                if (line.Contains(@"X ="))
                {
                    string cart_pos_x = line.Split(',')[0];
                    textBox_posStart.Text = cart_pos_x;
                    //textBox_posEnd.Text = line.Replace(" ", String.Empty);
                    string remove_space_line = line;
                    string new_position_data_string = "";
                    new_position_data_string = Regex.Replace(remove_space_line, @"\s+", "");

                    //x axis point value only 
                    string x_axis1 = new_position_data_string.Split(',')[0];
                    string x_axis1_substring = x_axis1.Substring(2);
                    string x_axis1_num = x_axis1_substring.Replace("mm", "");

                    //y axis point value only 
                    string y_axis1 = new_position_data_string.Split(',')[1];
                    string y_axis1_substring = y_axis1.Substring(2);
                    string y_axis1_num = y_axis1_substring.Replace("mm", "");

                    //z axis point value only 
                    string z_axis1 = new_position_data_string.Split(',')[2];
                    string z_axis1_substring = z_axis1.Substring(2);
                    string z_axis1_num = z_axis1_substring.Replace("mm", "");

                    xAxis1 = x_axis1_num; // line.Substring(7, 8);
                    yAxis1 = y_axis1_num; // line.Substring(21, 8);
                    zAxis1 = z_axis1_num; // line.Substring(44, 8);
                                          // data_only_list.Add(xAxis1 + "," + yAxis1 + "," + zAxis1);

                    //int x_diff = Int32.Parse(xAxis2) - Int32.Parse(xAxis1);
                    //int y_diff = Int32.Parse(yAxis2) - Int32.Parse(yAxis1);
                    //int z_diff = Int32.Parse(zAxis2) - Int32.Parse(zAxis1);

                    //listBox_diff.Items.Add(x_diff + ", " + y_diff + ", " + z_diff); 
                    listBox_extractedPositions.Items.Add(@"X: " + xAxis1 + ", Y: " + yAxis1 + ", Z: " + zAxis1 + "\n");
                }

                if (line.Contains(@"W ="))
                {
                    string remove_space_line = line;
                    string new_rotation_data_string = "";
                    new_rotation_data_string = Regex.Replace(remove_space_line, @"\s+", "");

                    //w axis point value only 
                    string w_axis1 = new_rotation_data_string.Split(',')[0];
                    string w_axis1_substring = w_axis1.Substring(2);
                    string w_axis1_num = w_axis1_substring.Replace("deg", "");

                    //p axis point value only 
                    string p_axis1 = new_rotation_data_string.Split(',')[1];
                    string p_axis1_substring = p_axis1.Substring(2);
                    string p_axis1_num = p_axis1_substring.Replace("deg", "");

                    //r axis point value only 
                    string r_axis1 = new_rotation_data_string.Split(',')[2];
                    string r_axis1_substring = r_axis1.Substring(2);
                    string r_axis1_num = r_axis1_substring.Replace("deg", "");
  

                    w1 = w_axis1_num; //line.Substring(7, 8);
                    p1 = p_axis1_num; //line.Substring(21, 8);
                    r1 = r_axis1_num; //line.Substring(44, 8);
                    //int w_diff = Int32.Parse(w2) - Int32.Parse(w1);
                    //int p_diff = Int32.Parse(p2) - Int32.Parse(p1);
                    //int r_diff = Int32.Parse(r2) - Int32.Parse(r1);

                    //listBox_diff.Items.Add(w_diff + ", " + p_diff + ", " + r_diff); 

                    listBox_extractedPositions.Items.Add(@"W: " + w1 + ", P: " + p1 + ", R: " + r1 + "\n");
                    listBox_extractedPositions.Items.Add("\n");
                }
            }
        }

        private void position2_extractor(List<string> program2_line_list)
        {
            //data_only_list = new List<string>();
            listBox_extractedPositions2.Items.Clear();

            foreach (string line in program2_line_list)
            {
                if (line.Contains(@"P["))
                {
                    string point = line.Split('{')[0] + "\n";
                    //data_only_list.Add(point);

                    listBox_extractedPositions2.Items.Add(point);
                }
                if (line.Contains(@"X ="))
                {
                    string cart_pos_x = line.Split(',')[0];
                    string remove_space_line = line;
                    string new_position_data_string = "";
                    new_position_data_string = Regex.Replace(remove_space_line, @"\s+", "");

                    //x axis point value only 
                    string x_axis2 = new_position_data_string.Split(',')[0];
                    string x_axis2_substring = x_axis2.Substring(2);
                    string x_axis2_num = x_axis2_substring.Replace("mm", "");
                

                    //y axis point value only 
                    string y_axis2 = new_position_data_string.Split(',')[1];
                    string y_axis2_substring = y_axis2.Substring(2);
                    string y_axis2_num = y_axis2_substring.Replace("mm", "");
               

                    //y axis point value only 
                    string z_axis2 = new_position_data_string.Split(',')[2];
                    string z_axis2_substring = z_axis2.Substring(2);
                    string z_axis2_num = z_axis2_substring.Replace("mm", "");

                    xAxis2 = x_axis2_num; // line.Substring(7, 8);
                    yAxis2 = y_axis2_num; // line.Substring(21, 8);
                    zAxis2 = z_axis2_num; // line.Substring(44, 8);
                    //data_only_list.Add(xAxis1 + "," + yAxis1 + "," + zAxis1); 
                    listBox_extractedPositions2.Items.Add(@"X: " + xAxis2 + ", Y: " + yAxis2 + ", Z: " + zAxis2 + "\n"); 
                }

                if (line.Contains(@"W =   "))
                {
                    string remove_space_line = line;
                    string new_rotation_data_string2 = "";
                    new_rotation_data_string2 = Regex.Replace(remove_space_line, @"\s+", "");

                    //w axis point value only 
                    string w_axis2 = new_rotation_data_string2.Split(',')[0];
                    string w_axis2_substring = w_axis2.Substring(2);
                    string w_axis2_num = w_axis2_substring.Replace("deg", "");
                   

                    //p axis point value only 
                    string p_axis2 = new_rotation_data_string2.Split(',')[1];
                    string p_axis2_substring = p_axis2.Substring(2);
                    string p_axis2_num = p_axis2_substring.Replace("deg", "");
              

                    //r axis point value only 
                    string r_axis2 = new_rotation_data_string2.Split(',')[2];
                    string r_axis2_substring = r_axis2.Substring(2);
                    string r_axis2_num = r_axis2_substring.Replace("deg", "");
            

                    w2 = w_axis2_num; //line.Substring(7, 8);
                    p2 = p_axis2_num; //line.Substring(21, 8);
                    r2 = r_axis2_num; //line.Substring(44, 8);

                    textBox_w.Text = w2;
                    textBox_p.Text = p2;
                    textBox_r.Text = r2;
                    listBox_extractedPositions2.Items.Add(@"W: " + w2 + ", P: " + p2 + ", R: " + r2 + "\n");
                    listBox_extractedPositions2.Items.Add("\n");
                }
            }
        }

        private void position_difference()
        {
            position_difference_list = new List<string>();

            double x_diff = Double.Parse(xAxis2) - Double.Parse(xAxis1);
            double y_diff = Double.Parse(yAxis2) - Double.Parse(yAxis1);
            double z_diff = Double.Parse(zAxis2) - Double.Parse(zAxis1);
            double w_diff = Double.Parse(w2) - Double.Parse(w1);
            double p_diff = Double.Parse(p2) - Double.Parse(p1);
            double r_diff = Double.Parse(r2) - Double.Parse(r1); 

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox_robotProgramPath.Text) && !string.IsNullOrWhiteSpace(textBox_robotProgramPath2.Text))
            {
                main(textBox_robotProgramPath.Text, textBox_robotProgramPath2.Text); 
            }

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listBox_extractedPositions.Items.Clear();
            listBox_extractedPositions2.Items.Clear();
            listBox_diff.Items.Clear();
        }

        private void listBox_extractedPositions2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
