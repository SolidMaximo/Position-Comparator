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
    //public class PointManager
    //{
    //    public List<OldCartesianData> old_cartesian_data = new List<OldCartesianData>();
    //    public List<NewCartesianData> new_cartesian_data = new List<NewCartesianData>();
    //    private string rowResult;
    //
    //    public double distance_change(double x1, double y1, double z1, double p1, double w1, double r1,
    //        double x2, double y2, double z2, double p2, double w2, double r2)
    //    {
    //        return Math.Abs(x2 - x1) + Math.Abs(y2 - y1) + Math.Abs(z2 - z1) + Math.Abs(p2 - p1) + Math.Abs(w2 - w1) + Math.Abs(r2 - r1);
    //    }
    //
    //    public bool load_old_cartesian_data(string old_filepath, string new_filepath)
    //    {
    //        old_cartesian_data = new List<OldCartesianData>();
    //        new_cartesian_data = new List<NewCartesianData>();
    //        bool header_row = true;
    //
    //        foreach (string row in File.ReadLines(old_filepath, Encoding.GetEncoding(1252)))
    //        {
    //            //ignore the header row of the csv file
    //            if (header_row)
    //            {
    //                header_row = false;
    //                continue;
    //            }
    //
    //            if (String.IsNullOrWhiteSpace(row.Replace(",", "")))
    //            {
    //                continue;
    //            }
    //
    //            //rowResult = row.Replace(",,,", ",0,0,0");
    //            //string entityName = row.Split(',')[3];
    //            try
    //            {
    //                old_cartesian_data.Add(
    //                    new OldCartesianData(
    //                        row.Split(',')[0], //x1
    //                        row.Split(',')[1], //y1
    //                        row.Split(',')[2], //z1
    //                        row.Split(',')[3], //p1
    //                        row.Split(',')[4], //w1
    //                        row.Split(',')[5]  //r1
    //                        ));
    //            }
    //            catch (Exception e)
    //            {
    //                //debug
    //                //Debug.Print(e.Message); 
    //                //MessageBox.Show("Error: " + e.Message); 
    //                return false;
    //            }
    //        }
    //
    //        foreach (string row in File.ReadLines(new_filepath, Encoding.GetEncoding(1252)))
    //        {
    //            //ignore the header row of the csv file
    //            if (header_row)
    //            {
    //                header_row = false;
    //                continue;
    //            }
    //
    //            if (String.IsNullOrWhiteSpace(row.Replace(",", "")))
    //            {
    //                continue;
    //            }
    //
    //            //rowResult = row.Replace(",,,", ",0,0,0");
    //            //string entityName = row.Split(',')[3];
    //            try
    //            {
    //                new_cartesian_data.Add(
    //                    new NewCartesianData(
    //                        row.Split(',')[0], //x2
    //                        row.Split(',')[1], //y2
    //                        row.Split(',')[2], //z2
    //                        row.Split(',')[3], //p2
    //                        row.Split(',')[4], //w2
    //                        row.Split(',')[5]  //r2
    //                        ));
    //            }
    //            catch (Exception e)
    //            {
    //                //debug
    //                //Debug.Print(e.Message); 
    //                //MessageBox.Show("Error: " + e.Message); 
    //                return false;
    //            }
    //        }
    //        return true;
    //    }
    //}

    //public class OldCartesianData
    //{
    //    //public double x_diff;
    //    //public double y_diff;
    //    //public double z_diff;
    //    //public double p_diff;
    //    //public double w_diff;
    //    //public double r_diff;
    //
    //    public double x1;
    //    public double y1;
    //    public double z1;
    //    public double p1;
    //    public double w1;
    //    public double r1;
    //
    //    public OldCartesianData(string x_1, string y_1, string z_1, string p_1, string w_1, string r_1)
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
    //    }
    //}
    //
    //public class NewCartesianData
    //{
    //    public double x2;
    //    public double y2;
    //    public double z2;
    //    public double p2;
    //    public double w2;
    //    public double r2;
    //
    //    public NewCartesianData(string x_2, string y_2, string z_2, string p_2, string w_2, string r_2)
    //    {
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
