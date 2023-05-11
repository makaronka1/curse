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
        int first_chart_count_second = 0;
        int second_chart_count_second = 0;
        int first_chart_currentId = 1;
        long second_chart_currentId = 1;
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;");
        
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            conn.Open();


        }
        TableLayoutPanel table = new TableLayoutPanel();

        public void graf_trand()
        {
            chart1.ChartAreas[0].AxisY.Maximum = 45; // Максимальные значение по оси Y
            chart1.ChartAreas[0].AxisY.Minimum = -5; // Минимальное значение по оси Y

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss"; // Формат оси X
            chart1.Series[0].XValueType = ChartValueType.DateTime;

            chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate(); // Максимальные значение по оси X
            chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate(); // Минимальное значение по оси X

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds; // Интервал отображения значений
            chart1.ChartAreas[0].AxisX.Interval = 5; // Значение интервала
                                                     // 
            chart2.ChartAreas[0].AxisY.Maximum = 45; // Максимальные значение по оси Y
            chart2.ChartAreas[0].AxisY.Minimum = -5; // Минимальное значение по оси Y

            chart2.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate(); // Максимальные значение по оси X
            chart2.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();

            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";  // Формат оси X
            chart2.Series[0].XValueType = ChartValueType.DateTime;

 // Минимальное значение по оси X

            chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds; // Интервал отображения значений
            chart2.ChartAreas[0].AxisX.Interval = 5; // Значение интервала
        }

        public void layout()
        {
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
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true; timer2.Enabled = true;
            // Включение таймера
            graf_trand();
            layout();
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

            table.Controls.Add(textBox2, 1, 1);
            table.SetRowSpan(textBox2, 1);



            textBox2.Dock = DockStyle.Fill;
            textBox1.Dock = DockStyle.Fill;
            button3.Dock = DockStyle.Fill;
            button2.Dock = DockStyle.Fill;
            button1.Dock = DockStyle.Fill; // заполняет ячейку
            chart1.Dock = DockStyle.Fill;
            chart2.Dock = DockStyle.Fill;
            chart3.Dock = DockStyle.Fill;

            // Добавление элементов на таблицу
            

            // Добавление таблицы на форму
            
            // Настройки элемента chart1

/*            chart1.ChartAreas[0].AxisY.Maximum = 45; // Максимальные значение по оси Y
            chart1.ChartAreas[0].AxisY.Minimum = -5; // Минимальное значение по оси Y

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss"; // Формат оси X
            chart1.Series[0].XValueType = ChartValueType.DateTime;

            chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate(); // Максимальные значение по оси X
            chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate(); // Минимальное значение по оси X

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds; // Интервал отображения значений
            chart1.ChartAreas[0].AxisX.Interval = 5; // Значение интервала      */    

            // Настройки элемента chart2



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
            first_chart_count_second++;
            DateTime TimeNow = DateTime.Now;

            
            string sql = "SELECT val FROM value_table WHERE id=@id";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", first_chart_currentId); ;
            int value = (int)command.ExecuteScalar();
            if(first_chart_currentId == 12)
            {
                first_chart_currentId = 1;
            }
            // Обновляем график с новыми данными
            chart1.Series[0].Points.AddXY(TimeNow, value);
            first_chart_currentId++;

            textBox1.Text = Convert.ToString(value);


            if (first_chart_count_second == 60)
            {
                first_chart_count_second -= 10;

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

        private DateTime time_now()
        {
            DateTime TimeNow = DateTime.Now;
            return TimeNow;
        } 

        private Int64 last_id()
        {
            NpgsqlCommand sql_count = new NpgsqlCommand("SELECT COUNT(*) FROM value_table", conn);
            Int64 lastid = Convert.ToInt64(sql_count.ExecuteScalar());
            return lastid;
        }
        private int last_val(long lastid)
        {
            string sql = "SELECT val FROM value_table WHERE id=@id";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", lastid);
            int value = (int)command.ExecuteScalar();
            return value;
        }
        private DateTime time_from_db()
        {
            NpgsqlCommand dbtime = new NpgsqlCommand("SELECT time FROM value_table WHERE id=@id", conn);
            dbtime.Parameters.AddWithValue("@id", last_id());
            DateTime time = (DateTime)dbtime.ExecuteScalar();
            time = time.ToLocalTime();
            return time;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            second_chart_count_second++;
            NpgsqlCommand rand = new NpgsqlCommand("INSERT INTO value_table (val) VALUES (floor(random() * 40) + 1)", conn);
            rand.ExecuteNonQuery();
/*            string sql = "SELECT val FROM value_table WHERE id=@id";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", last_id());
            int value = (int)command.ExecuteScalar();*/
            
/*            NpgsqlCommand dbtime = new NpgsqlCommand("SELECT time FROM value_table WHERE id=@id", conn);
            dbtime.Parameters.AddWithValue("@id", last_id());
            DateTime time = (DateTime)dbtime.ExecuteScalar();
            time = time.ToLocalTime();*/
            textBox3.Text = time_from_db().ToString();
            textBox4.Text = time_now().ToString();



            chart2.Series[0].Points.AddXY(time_from_db(), last_val(last_id()));
/*            second_chart_currentId++;*/

            textBox2.Text = Convert.ToString(last_val(last_id()));

            if (second_chart_count_second == 60)
            {
                second_chart_count_second -= 10;

                TimeSpan period = TimeSpan.FromSeconds(10);

                DateTime minX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum);
                DateTime maxX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum);

                chart2.ChartAreas[0].AxisX.Maximum = maxX.Add(period).ToOADate();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chart1.Visible)
            {
                textBox1.Visible = false;
                chart1.Visible = false;
                chart2.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                textBox2.Visible = false;
                chart1.Visible = true;
                chart2.Visible = false;
                textBox1.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "выборка")
            {
                chart3.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
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
                chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();
                chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
                first_chart_count_second = 0;

            }
            if (chart2.Visible == true) 
            {
                chart2.Series[0].Points.Clear();
                chart2.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate();
                chart2.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();
                second_chart_count_second = 0;
            }
            if (chart3.Visible == true) 
            {
                chart3.Series[0].Points.Clear();
            }
        }


    }
}
