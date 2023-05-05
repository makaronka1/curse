using System;
using Npgsql;
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
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;");
        
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            conn.Open();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true; // Включение таймера

            
            string sql = "SELECT val FROM value_table WHERE id=3" ;
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            int name = (int)command.ExecuteScalar();
            textBox1.Text = Convert.ToString(name);
            // Создание таблицы
            TableLayoutPanel table = new TableLayoutPanel();
            table.Controls.Add(button1, 2, 0); // кнопка в первой ячейке. колонки и строки
            table.SetColumnSpan(button1, 1); // занимает 2 столбца

            table.Controls.Add(chart1, 0, 0);
            table.SetRowSpan(chart1, 2);
            table.SetColumnSpan(chart1, 1);

            table.Dock = DockStyle.Fill; // занимает все место на форме
            table.ColumnCount = 3; // 3 столбца
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            table.RowCount = 2; // 2 строки
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F)); // 50% высоты для каждой строки
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));

            this.Controls.Add(table);

            /*            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
                        table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));*/

            button1.Dock = DockStyle.Fill; // заполняет ячейку

            // Добавление элементов на таблицу
;

            // Добавление таблицы на форму
            
            // Настройки элемента chart1

            chart1.ChartAreas[0].AxisY.Maximum = 45; // Максимальные значение по оси Y
            chart1.ChartAreas[0].AxisY.Minimum = -5; // Минимальное значение по оси Y

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss"; // Формат оси X
            chart1.Series[0].XValueType = ChartValueType.DateTime;

            chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate(); // Максимальные значение по оси X
            chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate(); // Минимальное значение по оси X

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds; // Интервал отображения значений
            chart1.ChartAreas[0].AxisX.Interval = 5; // Значение интервала

            /*chart1.MaximumSize = new Size(1500, 800); // Максимальный размер графика chart1*/
            

            // Привязка графика chart1 к сторонам контейнера
            chart1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom 
            | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;


            // Настройки элемента chart2

            chart2.ChartAreas[0].AxisY.Maximum = 45; // Максимальные значение по оси Y
            chart2.ChartAreas[0].AxisY.Minimum = -5; // Минимальное значение по оси Y

            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";  // Формат оси X
            chart2.Series[0].XValueType = ChartValueType.DateTime;

            chart2.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate(); // Максимальные значение по оси X
            chart2.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate(); // Минимальное значение по оси X

            chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds; // Интервал отображения значений
            chart2.ChartAreas[0].AxisX.Interval = 5; // Значение интервала

            /*chart2.MaximumSize = new Size(1500, 800);*/ // Максимальный размер графика chart2

            // Привязка графика chart2 к сторонам контейнера
            chart2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // Настройки элемента button1

            // Привязка кнопки button1 к сторонам контейнера
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
            | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

             // Максимальный размер элемента
            button1.AutoSize = true;
            
            




            // Настройки элемента numericUpDown1

            numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(numericUpDown1.Value);


            DateTime TimeNow = DateTime.Now;

            chart1.Series[0].Points.AddXY(TimeNow, value);
            chart2.Series[0].Points.AddXY(TimeNow, value);

            count_second++;

            if (count_second == 60)
            {
                count_second -= 10;

                TimeSpan period = TimeSpan.FromSeconds(10);

                DateTime minX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum);
                DateTime maxX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum);


                chart1.ChartAreas[0].AxisX.Minimum = minX.Add(period).ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = maxX.Add(period).ToOADate();

                chart2.ChartAreas[0].AxisX.Maximum = maxX.Add(period).ToOADate();

                /*chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();
                chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();

                chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
                chart1.ChartAreas[0].AxisX.Interval = 5;*/
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chart1.Visible)
            {
                chart1.Visible = false;
                chart2.Visible = true;
            }
            else
            {
                chart1.Visible = true;
                chart2.Visible = false;
            }
        }
    }
}
