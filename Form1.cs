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
        int currentId = 1;
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;");
        
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            conn.Open();
        }
        TableLayoutPanel table = new TableLayoutPanel();


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true; // Включение таймера

            // Создание таблицы
            
            table.Controls.Add(button1, 2, 0); // кнопка в первой ячейке. колонки и строки
            table.SetColumnSpan(button1, 1); // занимает 2 столбца
            table.Controls.Add(button2, 1, 0); // кнопка в первой ячейке. колонки и строки
            table.SetColumnSpan(button2, 1); // занимает 2 столбца
            table.Controls.Add(button3, 2, 1); // кнопка в первой ячейке. колонки и строки
            table.SetColumnSpan(button3, 1);

            table.Controls.Add(chart1, 0, 0);
            table.SetRowSpan(chart1, 3);
            table.SetColumnSpan(chart1, 1);

            table.Controls.Add(chart2, 0, 0);
            table.SetRowSpan(chart2, 3);
            table.SetColumnSpan(chart2, 1);

            table.Controls.Add(chart3, 0, 0);
            table.SetRowSpan(chart3, 3);
            table.SetColumnSpan(chart3, 1);

            table.Controls.Add(textBox1, 1, 1);
            table.SetRowSpan(textBox1, 1);

            table.Dock = DockStyle.Fill; // занимает все место на форме
            table.ColumnCount = 3; // 3 столбца
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            table.RowCount = 3; // 2 строки
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));// 50% высоты для каждой строки
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));

            this.Controls.Add(table);

            textBox1.Dock = DockStyle.Fill;
            button3.Dock = DockStyle.Fill;
            button2.Dock = DockStyle.Fill;
            button1.Dock = DockStyle.Fill; // заполняет ячейку
            chart1.Dock = DockStyle.Fill;
            chart2.Dock = DockStyle.Fill;
            chart3.Dock = DockStyle.Fill;

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

            // Настройки элемента chart2

            chart2.ChartAreas[0].AxisY.Maximum = 45; // Максимальные значение по оси Y
            chart2.ChartAreas[0].AxisY.Minimum = -5; // Минимальное значение по оси Y

            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";  // Формат оси X
            chart2.Series[0].XValueType = ChartValueType.DateTime;

            chart2.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate(); // Максимальные значение по оси X
            chart2.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate(); // Минимальное значение по оси X

            chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds; // Интервал отображения значений
            chart2.ChartAreas[0].AxisX.Interval = 5; // Значение интервала

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        /*int value = Convert.ToInt32(numericUpDown1.Value);


        DateTime TimeNow = DateTime.Now;
        string sql = "SELECT val FROM value_table WHERE id=3";
        NpgsqlCommand command = new NpgsqlCommand(sql, conn);
        int name = (int)command.ExecuteScalar();
        chart1.Series[0].Points.AddXY(TimeNow, name);
        chart2.Series[0].Points.AddXY(TimeNow, name);
*/
            count_second++;
            DateTime TimeNow = DateTime.Now;

            

            string sql = "SELECT val FROM value_table WHERE id=@id";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", currentId); ;
            int value = (int)command.ExecuteScalar();
            if(currentId == 12)
            {
                currentId = 1;
            }
            // Обновляем график с новыми данными
            chart1.Series[0].Points.AddXY(TimeNow, value);
            chart2.Series[0].Points.AddXY(TimeNow, value);
            currentId++;

            textBox1.Text = Convert.ToString(value);





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

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "выборка")
            {
                chart3.Visible = true;
                textBox1.Visible = false;
                chart2.Visible = false;
                chart1.Visible = false;
                button1.Visible = false;
                button2.Text = "к графикам";
                table.Controls.Add(button2, 2, 0); 
            }
            else
            {
                button2.Text = "выборка";
                textBox1.Visible = true;
                chart3.Visible =false;
                chart2.Visible = false;
                chart1.Visible = true;
                button1.Visible = true;
                table.Controls.Add(button2, 1, 0);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chart1.Visible == true)
            {
                chart1.Series[0].Points.Clear();
            }
            if (chart2.Visible == true) 
            {
                chart2.Series[0].Points.Clear();
            }
            if (chart3.Visible == true) 
            {
                chart3.Series[0].Points.Clear();
            }
        }
    }
}
