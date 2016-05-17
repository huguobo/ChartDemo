using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chartDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            iniChart();
        }
        public void iniChart() 
        {
            List<string> xData = new List<string> { "高工", "助工", "高级士官 ", "中级士官", "初级士官", "工程师", "兵" };
            List<int> yData1 = new List<int> { 10, 10, 10, 10, 10, 10, 10 };
            List<int> yData2 = new List<int> { 10, 20, 10, 10, 20, 10, 10 };

            chart1.Series[0].Points.DataBindXY(xData, yData1);
            chart1.Series[1].Points.DataBindXY(xData, yData2);


        }
    }
}
