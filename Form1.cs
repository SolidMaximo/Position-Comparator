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
        
        string csv_path = @"C:\Users\sstafford\source\repos2\PositionPrograms\Position-Comparator\position_data.csv";
        string csv_path2 = @"C:\Users\sstafford\source\repos2\PositionPrograms\Position-Comparator\position2_data.csv";
        private void position1_extractor(List<string> program_line_list)
        {
            //var csv = StringBuilder(); 
            
            //var csv = new StringBuilder(); 

            listBox_extractedPositions.Items.Clear();
            using (var sw = new StreamWriter(csv_path)) // StreamWriter sw = File.CreateText(csv_path))
            {
                string old_point; 
                foreach (string line in program_line_list)
                {
                    if (line.Contains("MODIFIED	= DATE"))
                    {
                        textBox_old_last_mod_date.Text = line;
                    }

                    if (line.Contains(@"P["))
                    {
                        old_point = line.Split('{')[0] + "\n";
                       
                        //data_only_list.Add(point);
                        listBox_oldpoints.Items.Add(old_point);
                        //listBox_extractedPositions.Items.Add(point);
                    }
                    if (line.Contains(@"X ="))
                    {
                        string cart_pos_x = line.Split(',')[0];
                        //textBox_posStart.Text = cart_pos_x;
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
                        //listBox_extractedPositions.Items.Add(@"X: " + xAxis1 + ", Y: " + yAxis1 + ", Z: " + zAxis1 + "\n"); //currently used
                        listBox_extractedPositions.Items.Add(xAxis1 + ", " + yAxis1 + ", " + zAxis1);

                        //for (int i = 0; i < program_line_list.Count; i++)
                        //{
                        //var ln = String.Format("{0},{1},{3}", xAxis1, yAxis1, zAxis1);
                        //sw.WriteLine(ln);
                        //}

                        //File.WriteAllText(csv_path, csv.ToString());
                        var ln = String.Format("{0},{1},{2}", xAxis1, yAxis1, zAxis1);
                        sw.WriteLine(ln);

                    }
                    //
                    //if (line.Contains(@"W ="))
                    //{
                    //    string remove_space_line = line;
                    //    string new_rotation_data_string = "";
                    //    new_rotation_data_string = Regex.Replace(remove_space_line, @"\s+", "");
                    //
                    //    //w axis point value only 
                    //    string w_axis1 = new_rotation_data_string.Split(',')[0];
                    //    string w_axis1_substring = w_axis1.Substring(2);
                    //    string w_axis1_num = w_axis1_substring.Replace("deg", "");
                    //
                    //    //p axis point value only 
                    //    string p_axis1 = new_rotation_data_string.Split(',')[1];
                    //    string p_axis1_substring = p_axis1.Substring(2);
                    //    string p_axis1_num = p_axis1_substring.Replace("deg", "");
                    //
                    //    //r axis point value only 
                    //    string r_axis1 = new_rotation_data_string.Split(',')[2];
                    //    string r_axis1_substring = r_axis1.Substring(2);
                    //    string r_axis1_num = r_axis1_substring.Replace("deg", "");
                    //
                    //
                    //    w1 = w_axis1_num; //line.Substring(7, 8);
                    //    p1 = p_axis1_num; //line.Substring(21, 8);
                    //    r1 = r_axis1_num; //line.Substring(44, 8);
                    //                      //int w_diff = Int32.Parse(w2) - Int32.Parse(w1);
                    //                      //int p_diff = Int32.Parse(p2) - Int32.Parse(p1);
                    //                      //int r_diff = Int32.Parse(r2) - Int32.Parse(r1);
                    //
                    //    //listBox_diff.Items.Add(w_diff + ", " + p_diff + ", " + r_diff); 
                    //
                    //    listBox_extractedPositions.Items.Add(w1 + ", " + p1 + ", " + r1 + "\n");
                    //    listBox_extractedPositions.Items.Add("\n");
                    //
                    //    var ln = String.Format("{0},{1},{2}", w1, p1, r1);
                    //    sw.WriteLine(ln);
                    //}

                    if(xAxis1!=null)
                    {
                        //var ln = String.Format("{0},{1},{2}", xAxis1, yAxis1, zAxis1);
                        //sw.WriteLine(ln);
                        //w1.Flush(); 
                    }


                }
            }
 
        }

        private void position2_extractor(List<string> program2_line_list)
        {
            //data_only_list = new List<string>();
            

            //StreamWriter sw = File.CreateText(csv_path); 
           

            listBox_extractedPositions2.Items.Clear();
            using (StreamWriter sw = File.CreateText(csv_path2))
            {
                string new_point; 
                foreach (string line in program2_line_list)
                {
                    if (line.Contains("MODIFIED	= DATE"))
                    {
                        textBox_new_last_mod_date.Text = line;
                    }
                    if (line.Contains(@"P["))
                    {
                        new_point = line.Split('{')[0] + "\n";
                        listBox_newpoints.Items.Add(new_point); 
                        //data_only_list.Add(point);
                    
                        //listBox_extractedPositions2.Items.Add(point);
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
                        listBox_extractedPositions2.Items.Add(xAxis2 + ", " + yAxis2 + ", " + zAxis2);

                        var ln = String.Format("{0},{1},{2}", xAxis2, yAxis2, zAxis2);
                        sw.WriteLine(ln);
                    }

                    /*
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
                    
                        var ln = String.Format("{0},{1},{2}", w2, p2, r2);
                        sw.WriteLine(ln);
                    }
                    */
                }
            }
            
        }

        private void position_difference(string csv1, string csv2)
        {
            List<string> listX = new List<string>();
            List<string> listY = new List<string>();
            List<string> listZ = new List<string>();
            List<string> listX2 = new List<string>();
            List<string> listY2 = new List<string>();
            List<string> listZ2 = new List<string>();

            using (var reader = new StreamReader(@"C:\Users\sstafford\source\repos2\PositionPrograms\Position-Comparator\position_data.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listX.Add(values[0]);
                    listY.Add(values[1]);
                    listZ.Add(values[2]);
                }
            }

            using (var reader2 = new StreamReader(@"C:\Users\sstafford\source\repos2\PositionPrograms\Position-Comparator\position_data.csv"))
            {

                while (!reader2.EndOfStream)
                {
                    var line = reader2.ReadLine();
                    var values = line.Split(',');

                    listX2.Add(values[0]);
                    listY2.Add(values[1]);
                    listZ2.Add(values[2]);
                }
            }

            bool list_continue; 
            using (var csv_diff = new StreamWriter(@"C:\Users\sstafford\source\repos2\PositionPrograms\Position-Comparator\position_data_results.csv"))
            {
                int x1 = 0;
                int x2 = 0;

                while (true)
                {
                    foreach (string item in listX)
                    {
                        //int x1 = Int32.Parse(item);
                        
                        Int32.TryParse(item, out x1);

                        foreach (string item2 in listX2)
                        {
                            //int x2 = Int32.Parse(item2);
                            
                            Int32.TryParse(item, out x2);
                            //var ln = String.Format("{0},{1},{2}", w2, p2, r2);
                        }

                    }

                    int x_diff = x1 - x2;
                    csv_diff.WriteLine(x_diff);
                }


        }

            //position_difference_list = new List<string>();
            //
            //double x_diff = Double.Parse(xAxis2) - Double.Parse(xAxis1);
            //double y_diff = Double.Parse(yAxis2) - Double.Parse(yAxis1);
            //double z_diff = Double.Parse(zAxis2) - Double.Parse(zAxis1);
            //double w_diff = Double.Parse(w2) - Double.Parse(w1);
            //double p_diff = Double.Parse(p2) - Double.Parse(p1);
            //double r_diff = Double.Parse(r2) - Double.Parse(r1); 


            //Lines, 1, 3, 5, ... are XYZ, Lines 2, 4, 6, ... are Xr, Yr, Zr
            //using (StreamReader sr = new StreamReader(csv1))
            {

                //string currentLine;
                // currentLine will be null when the StreamReader reaches the end of file
                //while ((currentLine = sr.ReadLine()) != null)
                //{
                //    // Search, case insensitive, if the currentLine contains the searched keyword
                //    if (currentLine.IndexOf("I/RPTGEN", StringComparison.CurrentCultureIgnoreCase) >= 0)
                //    {
                //        Console.WriteLine(currentLine);
                //    }
                //}
            }

        }

        private void diff_test()
        {
            int x1 = 0;
            int y1 = 0;
            int z1 = 0;
            int w1 = 0;
            int p1 = 0;
            int r1 = 0;
            int x2 = 0;
            int y2 = 0;
            int z2 = 0;
            int w2 = 0;
            int p2 = 0;
            int r2 = 0;

            int x_diff = x1 - x2;
            int y_diff = y1 - x2;
            int z_diff = z1 - x2;
            int w_diff = w1 - x2;
            int p_diff = p1 - x2;
            int r_diff = r1 - x2;

            foreach (string line in listBox_extractedPositions.Items)
            {
                if(line.Length>0)
                {


                }
            }
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

        private void button_compare_Click(object sender, EventArgs e)
        {
            //position_difference(csv_path, csv_path2);
            calc_diff(); 
        }
        private string remove_empty_lines(string lines)
        {
            return Regex.Replace(lines, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();
        }
        private PointsManager pointsManager = new PointsManager();
        //private OldCartesianData oldCartesianData = new OldCartesianData(); 
        private void calc_diff()
        {
            pointsManager.load_cartesian_data(csv_path, csv_path2);
            //List<double> op = pointsManager.get_new_cartesian_data() as List<double>(); 
            //var oldpoints = pointsManager.get_old_cartesian_data();
            //var newpoints = pointsManager.get_new_cartesian_data(); 

            var old_x = new List<double>();
            var old_y = new List<double>();
            var old_z = new List<double>();
            var new_x = new List<double>();
            var new_y = new List<double>();
            var new_z = new List<double>();

            foreach (OldCartesianData point in pointsManager.get_old_cartesian_data())
            {
                //listBox_diff.Items.Add(point.x1.ToString());
                old_x.Add(point.x1);
                old_y.Add(point.y1);
                old_z.Add(point.z1); 
            }
            foreach(NewCartesianData point in pointsManager.get_new_cartesian_data())
            {
                //listBox_diff.Items.Add(point.x2.ToString());
                new_x.Add(point.x2);
                new_y.Add(point.y2);
                new_z.Add(point.z2);
            }

            //option 1 is to do all math in PointsManager Class under the calc_diff function
            //option 2 is to compare the lists above and create a "difference" list. 

            int old_count = listBox_extractedPositions.Items.ToString().Count();
            int new_count = listBox_extractedPositions2.Items.ToString().Count();
            //int new_x_count = new_x.Count();
            textBox_oldCount.Text = old_count.ToString();
            textBox_newCount.Text = new_count.ToString();
            if(old_count==new_count) //method only works if the same number of points are detected. 
            {
                for (int i = 0; i < 9; i++)
                {
                    //listBox_diff.Items.Add("New X: " + new_x[i] + ", Old X: " + old_x[i]); 
                    //listBox_diff.Items.Add("")
                    if(!Math.Abs(new_x[i] - old_x[i]).Equals(0) || !Math.Abs(new_y[i] - old_y[i]).Equals(0) || !Math.Abs(new_z[i] - old_z[i]).Equals(0))
                    {
                        listBox_diff.Items.Add(@"P[" + (i + 1) + @"]    " +
                            "X: " + Math.Round(Math.Abs(new_x[i] - old_x[i]),3).ToString() + ", " +
                            "Y: " + Math.Round(Math.Abs(new_y[i] - old_y[i]),3).ToString() + ", " +
                            "Z: " + Math.Round(Math.Abs(new_z[i] - old_z[i]),3).ToString());
                    }
                    else
                    {
                        //skip line 

                        //method to list what points have been added or removed needs to be created
                        //currently, the method does not check if a point number has been changed which
                        //which can be problematic due to fanuc point numbers could be out of order
                        //listBox_diff.Items.Add("Addition points added or removed since last backup");
                    }

                }
                for (int i = 9; i < old_count; i++)
                {
                    if (!Math.Abs(new_x[i] - old_x[i]).Equals(0) || !Math.Abs(new_y[i] - old_y[i]).Equals(0) || !Math.Abs(new_z[i] - old_z[i]).Equals(0))
                    {
                        listBox_diff.Items.Add(@"P[" + (i + 1) + @"]  " +
                            "X: " + Math.Round(Math.Abs(new_x[i] - old_x[i]), 3).ToString() + ", " +
                            "Y: " + Math.Round(Math.Abs(new_y[i] - old_y[i]), 3).ToString() + ", " +
                            "Z: " + Math.Round(Math.Abs(new_z[i] - old_z[i]), 3).ToString());
                    }
                    else
                    {
                        //skip line 

                        //method to list what points have been added or removed needs to be created
                        //currently, the method does not check if a point number has been changed which
                        //which can be problematic due to fanuc point numbers could be out of order
                        //listBox_diff.Items.Add("Addition points added or removed since last backup");
                    }
                }
            }

            
            //resultString = Regex.Replace(subjectString, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);

            //var x_diff = old_x.
            var x_diff = old_x.Except(new_x).ToList();
            var y_diff = old_y.Except(new_y).ToList();
            var z_diff = old_z.Except(new_z).ToList();

            foreach(double x in x_diff)
            {
                //listBox_diff.Items.Add(x.ToString()); 
            }
            //listBox_diff.Items.AddRange()
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public class PointsManager
    {
        public List<OldCartesianData> old_cartesian_data = new List<OldCartesianData>();
        public List<NewCartesianData> new_cartesian_data = new List<NewCartesianData>();

        public double distance_change(double x1, double y1, double z1, double p1, double w1, double r1,
            double x2, double y2, double z2, double p2, double w2, double r2)
        {
            return Math.Abs(x2 - x1) + Math.Abs(y2 - y1) + Math.Abs(z2 - z1) + Math.Abs(p2 - p1) + Math.Abs(w2 - w1) + Math.Abs(r2 - r1);  
        }

        public bool load_cartesian_data(string old_filepath, string new_filepath)
        {
            old_cartesian_data = new List<OldCartesianData>();
            new_cartesian_data = new List<NewCartesianData>();
            //new_cartesian_data = new List<NewCartesianData>(); 
            foreach (string row in File.ReadLines(old_filepath, Encoding.GetEncoding(1252)))
            {
                if (String.IsNullOrWhiteSpace(row.Replace(",", "")))
                {
                    continue;
                }
                //rowResult = row.Replace(",,,", ",0,0,0");
                //string entityName = row.Split(',')[3];

                //I need to only check for xyz for now to verify list 
                try
                {
                    old_cartesian_data.Add(
                        new OldCartesianData(
                            row.Split(',')[0], //x1
                            row.Split(',')[1], //y1
                            row.Split(',')[2] //z1
                            //row.Split(',')[3], //p1
                            //row.Split(',')[4], //w1
                            //row.Split(',')[5],  //r1
                            //row.Split(',')[6], //x2 placeholder
                            //row.Split(',')[7], //y2 placeholder
                            //row.Split(',')[8], //z2 placeholder
                            //row.Split(',')[9], //p2 placeholder
                            //row.Split(',')[10], //w2 placeholder
                            //row.Split(',')[11]  //r2 placeholder
                            )); 
                }
                catch (Exception e)
                {
                    //debug
                    //Debug.Print(e.Message); 
                    //MessageBox.Show("Error: " + e.Message); 
                    return false; 
                }
            }

            foreach (string row in File.ReadLines(new_filepath, Encoding.GetEncoding(1252)))
            {
                if (String.IsNullOrWhiteSpace(row.Replace(",", "")))
                {
                    continue;
                }

                //rowResult = row.Replace(",,,", ",0,0,0");
                //string entityName = row.Split(',')[3];
                try
                {
                    //new_cartesian_data = newcartesian_data.Skip(5).ToList(); 
                    new_cartesian_data.Add(
                        new NewCartesianData(
                            row.Split(',')[0], //x1
                            row.Split(',')[1], //y1
                            row.Split(',')[2] //z1
                            //row.Split(',')[3], //p1
                            //row.Split(',')[4], //w1
                            //row.Split(',')[5], //r1
                            //row.Split(',')[6], //x2
                            //row.Split(',')[7], //y2
                            //row.Split(',')[8], //z2
                            //row.Split(',')[9], //p2
                            //row.Split(',')[10], //w2
                            //row.Split(',')[11]  //r2
                            ));
                }
                catch (Exception e)
                {
                    //debug
                    //Debug.Print(e.Message); 
                    //MessageBox.Show("Error: " + e.Message); 
                    return false;
                }
            }
            return true; 
        }
        public List<OldCartesianData> get_old_cartesian_data()//string p_robot, string p_operation)
        {
            //return cartesian_data
            //    .Where(ocd => ocd.x1.Equals().Where(ocd => ocd.y1 != 0).Where(ocd => ocd.z1 != 0)
            //    .Where(ocd => ocd.p1 != 0).Where(ocd => ocd.w1 != 0).Where(ocd => ocd.r1 != 0)
            //    .Where(ocd => ocd.x2 != 0).Where(ocd => ocd.y2 != 0).Where(ocd => ocd.z2 != 0)
            //    .Where(ocd => ocd.p2 != 0).Where(ocd => ocd.w2 != 0).Where(ocd => ocd.r2 != 0).ToList();
            return old_cartesian_data; 
        }
        public List<NewCartesianData> get_new_cartesian_data()
        {
            //return new_cartesian_data
            //    .Where(ocd => ocd.x2 != 0).Where(ocd => ocd.y2 != 0).Where(ocd => ocd.z2 != 0)
            //    .Where(ocd => ocd.p2 != 0).Where(ocd => ocd.w2 != 0).Where(ocd => ocd.r2 != 0).ToList();
            return new_cartesian_data; 
        }
    }

    public class OldCartesianData
    {
        //public double x_diff;
        //public double y_diff;
        //public double z_diff;
        //public double p_diff;
        //public double w_diff;
        //public double r_diff;
    
        public double x1;
        public double y1;
        public double z1;
        public double p1;
        public double w1;
        public double r1;
    
        public OldCartesianData(string x_1, string y_1, string z_1)//, string p_1, string w_1, string r_1)
        {
            //convert cartesian data from first point from string to double
            if (double.TryParse(x_1, out x1) == true)
                x1 = Convert.ToDouble(x_1);
            if (double.TryParse(y_1, out y1) == true)
                y1 = Convert.ToDouble(y_1);
            if (double.TryParse(z_1, out z1) == true)
                z1 = Convert.ToDouble(z_1);
            //if (double.TryParse(p_1, out p1) == true)
            //    p1 = Convert.ToDouble(p_1);
            //if (double.TryParse(w_1, out w1) == true)
            //    w1 = Convert.ToDouble(w_1);
            //if (double.TryParse(r_1, out r1) == true)
            //    r1 = Convert.ToDouble(r_1);
        }
    }

    public class NewCartesianData
    {
        public double x2;
        public double y2;
        public double z2;
        public double p2;
        public double w2;
        public double r2;
    
        public NewCartesianData(string x_2, string y_2, string z_2)//, string p_2, string w_2, string r_2)
        {
            //convert cartesian data from second point from string to double
            if (double.TryParse(x_2, out x2) == true)
                x2 = Convert.ToDouble(x_2);
            if (double.TryParse(y_2, out y2) == true)
                y2 = Convert.ToDouble(y_2);
            if (double.TryParse(z_2, out z2) == true)
                z2 = Convert.ToDouble(z_2);
            //if (double.TryParse(p_2, out p2) == true)
            //    p2 = Convert.ToDouble(p_2);
            //if (double.TryParse(w_2, out w2) == true)
            //    w2 = Convert.ToDouble(w_2);
            //if (double.TryParse(r_2, out r2) == true)
            //    r2 = Convert.ToDouble(r_2);
        }
    }

   //public class CartesianData
   //{
   //    public double x1;
   //    public double y1;
   //    public double z1;
   //    public double p1;
   //    public double w1;
   //    public double r1;
   //
   //    public double x2;
   //    public double y2;
   //    public double z2;
   //    public double p2;
   //    public double w2;
   //    public double r2;
   //
   //    public CartesianData(string x_1, string y_1, string z_1, string p_1, string w_1, string r_1, string x_2, string y_2, string z_2, string p_2, string w_2, string r_2)
   //    {
   //        //convert cartesian data from first point from string to double
   //        if (double.TryParse(x_1, out x1) == true)
   //            x1 = Convert.ToDouble(x_1);
   //        if (double.TryParse(y_1, out y1) == true)
   //            y1 = Convert.ToDouble(y_1);
   //        if (double.TryParse(z_1, out z1) == true)
   //            z1 = Convert.ToDouble(z_1);
   //        if (double.TryParse(p_1, out p1) == true)
   //            p1 = Convert.ToDouble(p_1);
   //        if (double.TryParse(w_1, out w1) == true)
   //            w1 = Convert.ToDouble(w_1);
   //        if (double.TryParse(r_1, out r1) == true)
   //            r1 = Convert.ToDouble(r_1);
   //
   //        //convert cartesian data from second point from string to double
   //        if (double.TryParse(x_2, out x2) == true)
   //            x2 = Convert.ToDouble(x_2);
   //        if (double.TryParse(y_2, out y2) == true)
   //            y2 = Convert.ToDouble(y_2);
   //        if (double.TryParse(z_2, out z2) == true)
   //            z2 = Convert.ToDouble(z_2);
   //        if (double.TryParse(p_2, out p2) == true)
   //            p2 = Convert.ToDouble(p_2);
   //        if (double.TryParse(w_2, out w2) == true)
   //            w2 = Convert.ToDouble(w_2);
   //        if (double.TryParse(r_2, out r2) == true)
   //            r2 = Convert.ToDouble(r_2);
   //    }
   //}
}
