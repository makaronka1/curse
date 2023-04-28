using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace test
{
    public partial class Form1 : Form
    {
        int count_second = 0;
        
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            chart1.ChartAreas[0].AxisY.Maximum = 45;
            chart1.ChartAreas[0].AxisY.Minimum = -5;

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";
            chart1.Series[0].XValueType = ChartValueType.DateTime;

            chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();
            chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.Interval = 5;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(numericUpDown1.Value);


            DateTime TimeNow = DateTime.Now;

            chart1.Series[0].Points.AddXY(TimeNow, value);

            count_second++;

            if (count_second == 60)
            {
                count_second -= 10;

                TimeSpan period = TimeSpan.FromSeconds(10);

                DateTime minX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum);
                DateTime maxX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum);


                chart1.ChartAreas[0].AxisX.Minimum = minX.Add(period).ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = maxX.Add(period).ToOADate();

                /*chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();
                chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();

                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
                chart1.ChartAreas[0].AxisX.Interval = 5;*/
            }
        }

    }
}
