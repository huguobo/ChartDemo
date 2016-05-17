using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace chartDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            iniChart();
        }
        public void iniChart() 
        {
            List<string> xData = new List<string> { "高工", "助工", "高级士官 ", "中级士官", "初级士官", "工程师", "兵" };
            List<int> yData = new List<int> {10,20,30,40,20,40,10 };
            //yData[0] = 100;//动态得到数据库中的值即可
            SqlConnection conn= new SqlConnection();
            conn.ConnectionString = "server=127.0.0.1;database=test;user=sa;pwd=199259"; ;
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            string zyName = "专业一";
            cmd.CommandText = "select 高工 from rybz where 专业='" + zyName + "'";
            //SqlDataReader dr = cmd.ExecuteReader();
            //yData[1] = Convert.ToInt32(dr);
            //dr.Close();
            SqlDataAdapter sda = new SqlDataAdapter(cmd.CommandText,conn);
            
            DataSet ds = new DataSet();
            sda.Fill(ds);
            MessageBox.Show(yData[0].ToString());
            yData[0]=Convert.ToInt32(ds.Tables[0].Rows[0]["高工"]);
            MessageBox.Show(yData[0].ToString());
            conn.Close();
           

            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            chart1.Series[0].Points.DataBindXY(xData, yData);
        }
    }
}
