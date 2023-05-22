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
using System.Windows.Forms.DataVisualization.Charting.Utilities;


namespace test
{

    public partial class Form1 : Form
    {
        int press_count = 0;
        int first_chart_count_second = 0;
        int second_chart_count_second = 0;
        static string connection = "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=1234;";
        static NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder(connection);
        NpgsqlConnection conn = new NpgsqlConnection(connection);
        string server = builder.Host;
        string port = builder.Port.ToString();
        string database = builder.Database;
        string userId = builder.Username;
        string password = builder.Password;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            chart3.MouseWheel += Chart3_MouseWheel;
            chart3.AxisScrollBarClicked += Chart3_AxisScrollBarClicked;
            chart2.MouseWheel += Chart3_MouseWheel;
            chart2.AxisScrollBarClicked += Chart3_AxisScrollBarClicked;
            conn.Open();
        }
        private void Chart3_MouseWheel(object sender, MouseEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;

            if (e.Delta < 0) // Прокрутка вниз - увеличение масштаба
            {
                double xMin = xAxis.ScaleView.ViewMinimum;
                double xMax = xAxis.ScaleView.ViewMaximum;
                double posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
                double posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
                xAxis.ScaleView.Zoom(posXStart, posXFinish);
            }
            else // Прокрутка вверх - уменьшение масштаба
            {
                double xMin = xAxis.ScaleView.ViewMinimum;
                double xMax = xAxis.ScaleView.ViewMaximum;
                double posXStart = xAxis.PixelPositionToValue(e.Location.X) - (xMax - xMin);
                double posXFinish = xAxis.PixelPositionToValue(e.Location.X) + (xMax - xMin);
                xAxis.ScaleView.Zoom(posXStart, posXFinish);
            }
        }
        private void Chart3_AxisScrollBarClicked(object sender, ScrollBarEventArgs e)
        {
            var chart = (Chart)sender;
            var xAxis = chart.ChartAreas[0].AxisX;

            if (e.ButtonType == ScrollBarButtonType.SmallIncrement || e.ButtonType == ScrollBarButtonType.SmallDecrement)
            {
                double xMin = xAxis.ScaleView.ViewMinimum;
                double xMax = xAxis.ScaleView.ViewMaximum;
                double posXStart = xAxis.PixelPositionToValue(chart.Width / 4) - (xMax - xMin) / 4;
                double posXFinish = xAxis.PixelPositionToValue(chart.Width / 4) + (xMax - xMin) / 4;
                xAxis.ScaleView.Zoom(posXStart, posXFinish);
            }
        }

        TableLayoutPanel table = new TableLayoutPanel();

        public void graf_trand()
        {
            chart1.ChartAreas[0].AxisY.Maximum = 45; // Максимальные значение по оси Y
            chart1.ChartAreas[0].AxisY.Minimum = -5; // Минимальное значение по оси Y

            /*chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;*/
            chart1.Series[0].ToolTip = "X = #VALX{dd/MM/yyyy HH:mm:ss}, Y = #VALY";
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss"; // Формат оси X
            chart1.Series[0].XValueType = ChartValueType.DateTime;

            chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate(); // Максимальные значение по оси X
            chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate(); // Минимальное значение по оси X

            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds; // Интервал отображения значений
            chart1.ChartAreas[0].AxisX.Interval = 5;

            chart2.Series[0].ToolTip = "X = #VALX{dd/MM/yyyy HH:mm:ss}, Y = #VALY"; 
            chart2.ChartAreas[0].AxisY.Maximum = 45; // Максимальные значение по оси Y
            chart2.ChartAreas[0].AxisY.Minimum = -5; // Минимальное значение по оси Y

            chart2.ChartAreas[0].AxisX.Maximum = DateTime.Now.AddMinutes(1).ToOADate(); // Максимальные значение по оси X
            chart2.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate();

            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm:ss";  // Формат оси X
            chart2.Series[0].XValueType = ChartValueType.DateTime;

            chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds; // Интервал отображения значений
            chart2.ChartAreas[0].AxisX.Interval = 5;

            chart3.ChartAreas[0].AxisY.Maximum = 45; // Максимальные значение по оси Y
            chart3.ChartAreas[0].AxisY.Minimum = -5; // Минимальное значение по оси Y

            chart3.ChartAreas[0].AxisX.LabelStyle.Format = "H:mm"; // Формат оси X
            chart3.Series[0].XValueType = ChartValueType.DateTime;



            chart3.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes; // Интервал отображения значений
            chart3.ChartAreas[0].AxisX.Interval = 10; // Значение интервала
            chart3.Series[0].ToolTip = "X = #VALX{dd/MM/yyyy HH:mm:ss}, Y = #VALY";




        }
       
        public void layout()
        {
            table.Dock = DockStyle.Fill; // занимает все место на форме
            table.ColumnCount = 4; // 3 столбца
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            table.RowCount = 6; // 2 строки
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));// 50% высоты для каждой строки
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));

            this.Controls.Add(table);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true; timer2.Enabled = true;
            // Включение таймераa
            graf_trand();

            layout();

            table.Controls.Add(change, 1, 0); // кнопка в первой ячейке. колонки и строки
            table.SetColumnSpan(change, 2); // занимает 2 столбца
            table.Controls.Add(viborka, 3, 0); // кнопка в первой ячейке. колонки и строки
            table.SetColumnSpan(viborka, 1); // занимает 2 столбца
            table.Controls.Add(reset, 3, 1); // кнопка в первой ячейке. колонки и строки
            table.SetColumnSpan(reset, 1);

            table.Controls.Add(chart1, 0, 0);
            table.SetRowSpan(chart1, 6);
            table.SetColumnSpan(chart1, 1);

            table.Controls.Add(chart2, 0, 0);
            table.SetRowSpan(chart2, 6);
            table.SetColumnSpan(chart2, 1);

            table.Controls.Add(chart3, 0, 0);
            table.SetRowSpan(chart3, 6);
            table.SetColumnSpan(chart3, 1);

            table.Controls.Add(textBoxCurentVal, 2, 1);
            table.SetColumnSpan(textBoxCurentVal, 1);
            table.SetRowSpan(textBoxCurentVal, 1);

            table.Controls.Add(labelInfo, 1, 4);
            table.SetRowSpan(labelInfo, 1);
            table.SetColumnSpan(labelInfo, 3);
            
            table.Controls.Add(CurentTimelabel, 3, 2);
            table.SetRowSpan(CurentTimelabel, 1);
            table.SetColumnSpan(CurentTimelabel, 1);

            CurentTimelabel.Anchor = AnchorStyles.Right;
            CurentTimelabel.Anchor = AnchorStyles.Top;



            labelInfo.Dock = DockStyle.Fill;
            labelInfo.Anchor = AnchorStyles.Right;
            labelInfo.Anchor = AnchorStyles.Bottom;
            
            textBoxCurentVal.Dock = DockStyle.Fill;
            reset.Dock = DockStyle.Fill;
            viborka.Dock = DockStyle.Fill;
            change.Dock = DockStyle.Fill; // заполняет ячейку
            chart1.Dock = DockStyle.Fill;
            chart2.Dock = DockStyle.Fill;
            chart3.Dock = DockStyle.Fill;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime TimeToChart = time_from_db().ToLocalTime();
            int ValToChart = last_val(last_id());

            chart2.Series[0].Points.AddXY(TimeToChart, ValToChart);
            chart1.Series[0].Points.AddXY(TimeToChart, ValToChart);
        }

        private void selection()
        {
            
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
            return time;
        }
        private DateTime test_time_from_db(int id)
        {
            NpgsqlCommand dbtime = new NpgsqlCommand("SELECT time FROM value_table WHERE id=@id", conn);
            dbtime.Parameters.AddWithValue("@id", id);
            DateTime time = (DateTime)dbtime.ExecuteScalar();
            return time.ToLocalTime();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

            second_chart_count_second++;
            first_chart_count_second++;
            NpgsqlCommand rand = new NpgsqlCommand("INSERT INTO value_table (val) VALUES (floor(random() * 40) + 1)", conn);
            rand.ExecuteNonQuery();
            textBoxCurentVal.Text = Convert.ToString(last_val(last_id()));
            CurentTimelabel.Text = time_from_db().ToLocalTime().ToString();
            textBoxCurentTIme.Text = time_from_db().ToString();
            labelInfo.Text = ("Server = " + server + " UserId = " + userId + " Database = " + database + " Port = " + port);
            if (second_chart_count_second == 60)
            {
                second_chart_count_second -= 10;

                TimeSpan period = TimeSpan.FromSeconds(10);

                DateTime minX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum);
                DateTime maxX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum);

                chart2.ChartAreas[0].AxisX.Maximum = maxX.Add(period).ToOADate();

            }
            if (first_chart_count_second == 60)
            {
                first_chart_count_second -= 10;

                TimeSpan period = TimeSpan.FromSeconds(10);

                DateTime minX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Minimum);
                DateTime maxX = DateTime.FromOADate(chart1.ChartAreas[0].AxisX.Maximum);


                chart1.ChartAreas[0].AxisX.Minimum = minX.Add(period).ToOADate();
                chart1.ChartAreas[0].AxisX.Maximum = maxX.Add(period).ToOADate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chart1.Visible)
            {
                chart2.Visible = true;
                textBoxCurentVal.Visible = true;
                chart1.Visible = false;
            }
            else
            {
                chart1.Visible = true;
                chart2.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (viborka.Text == "выборка")
            {
                chart3.Visible = true;
                textBoxCurentVal.Visible = false;
                chart2.Visible = false;
                chart1.Visible = false;
                change.Visible = false;
                viborka.Text = "к графикам";
                table.Controls.Add(viborka, 3, 0);
                table.SetColumnSpan(viborka, 1);

            }
            else
            {
                viborka.Text = "выборка";
                chart3.Visible =false;
                chart2.Visible = false;
                chart1.Visible = true;
                change.Visible = true;
                textBoxCurentVal.Visible = true;
                table.Controls.Add(viborka, 3, 0);
                table.SetColumnSpan(viborka, 1);
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
                press_count = 0;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(timer2.Enabled == true)
            {
                timer2.Stop();
            }
            else
            {
                timer2.Start();
            }
            chart3.Series[0].Points.Clear();
/*            chart2.Visible = false;
            chart1.Visible = false;*/
            string secondDateError = "Выбранная дата больше, чем текущая" ;
            

            try
            {
                NpgsqlCommand sqllastTimeDate = new NpgsqlCommand("SELECT time FROM value_table WHERE time >= date_trunc('day', @dateTimePickerSecondDate) ORDER BY time DESC LIMIT 1", conn);
                sqllastTimeDate.Parameters.AddWithValue("dateTimePickerSecondDate", dateTimePickerSecondDate.Value.Date);
                DateTime lastTimeDate = (DateTime)sqllastTimeDate.ExecuteScalar();
                lastTimeDate = lastTimeDate.AddHours(3);
                label4.Text = lastTimeDate.ToString();
            }
            catch 
            {
                ErrorForm errorForm = new ErrorForm(secondDateError);
                errorForm.ShowDialog();
            }


            NpgsqlCommand sqlfirstTimeDate = new NpgsqlCommand("SELECT time FROM value_table WHERE time <= date_trunc('day', @dateTimePickerFirstDate) + INTERVAL '1 day' - INTERVAL '1 second' ORDER BY time ASC LIMIT 1", conn);
            sqlfirstTimeDate.Parameters.AddWithValue("dateTimePickerFirstDate", dateTimePickerFirstDate.Value.Date);
            DateTime firstTimeDate = (DateTime)sqlfirstTimeDate.ExecuteScalar();
            firstTimeDate = firstTimeDate.AddHours(3);
            label3.Text = firstTimeDate.ToString();

            NpgsqlCommand sqlallval = new NpgsqlCommand("SELECT time, val FROM value_table WHERE time BETWEEN date_trunc('day', @start_date) AND date_trunc('day', @end_date) + INTERVAL '1 day' - INTERVAL '1 second' ORDER BY time;", conn);
            sqlallval.Parameters.AddWithValue("start_date", dateTimePickerFirstDate.Value.Date);
            sqlallval.Parameters.AddWithValue("end_date", dateTimePickerSecondDate.Value.Date);

            using (NpgsqlDataReader reader = sqlallval.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Чтение значения времени и значения из базы данных
                    DateTime timestamp = reader.GetDateTime(0).ToLocalTime();
                    double value = reader.GetDouble(1);

                    chart3.Series[0].Points.AddXY(timestamp, value);
                }
                /* using (NpgsqlCommand sqlallval = new NpgsqlCommand(query, conn))
                 {
                     sqlallval.Parameters.AddWithValue("start_date", firstTimeDate);
                     sqlallval.Parameters.AddWithValue("end_date", lastTimeDate);

                     using (NpgsqlDataReader reader = sqlallval.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             DateTime timestamp = reader.GetDateTime(0).ToLocalTime();
                             double value = reader.GetDouble(0);
                             chart3.Series[0].Points.AddXY(timestamp.ToOADate(), value);
                         }
                     }*/




                /*                if (press_count == 0)
                                {
                                    chart3.ChartAreas[0].AxisX.Maximum = lastTimeDate.AddMinutes(3).ToOADate(); // Максимальные значение по оси X
                                    chart3.ChartAreas[0].AxisX.Minimum = DateTime.Now.ToOADate(); // Минимальное значение по оси X

                                }*/
            }
/*            chart3.Series[0].Points.AddXY(time_now(), 12);
            press_count++;*/
 /*           using (NpgsqlDataReader reader = sqlallval.ExecuteReader())
            {



                while (reader.Read())
                {
                    // Чтение значения времени и значения из базы данных
                    *//*DateTime timestamp = reader.GetDateTime(0).ToLocalTime();*//*
                    DateTime timestamp = DateTime.Now;
                    double value = reader.GetDouble(1);

                    chart3.Series[0].Points.AddXY(timestamp.ToOADate(), value);
                }
            }*/



            /*int firstid = Convert.ToInt32(firstidbox.Text);
            int secondid = Convert.ToInt32(secondidbox.Text);
            int result = secondid - firstid;

            NpgsqlCommand testzal = new NpgsqlCommand("SELECT val FROM value_table where id=@id", conn);
            NpgsqlCommand test2zal = new NpgsqlCommand("SELECT time FROM value_table where id=@id", conn);
            testzal.Parameters.AddWithValue("@id", firstid);
            test2zal.Parameters.AddWithValue("@id", firstid);
            int valuezal = (int)testzal.ExecuteScalar();
            DateTime testtimezal = (DateTime)test2zal.ExecuteScalar();
            DateTime setszal = testtimezal.ToLocalTime();
            if (press_count == 0)
            {
                chart3.ChartAreas[0].AxisX.Maximum = setszal.AddMinutes(3).ToOADate(); // Максимальные значение по оси X
                chart3.ChartAreas[0].AxisX.Minimum = setszal.ToOADate(); // Минимальное значение по оси X
            }

            for (int i = 0; i < result; i++)
            {
                NpgsqlCommand test = new NpgsqlCommand("SELECT val FROM value_table where id=@id", conn);
                NpgsqlCommand test2 = new NpgsqlCommand("SELECT time FROM value_table where id=@id", conn);
                test.Parameters.AddWithValue("@id", firstid+i);
                test2.Parameters.AddWithValue("@id", firstid+i);
                int value = (int)test.ExecuteScalar();
                DateTime testtime = (DateTime)test2.ExecuteScalar();
                DateTime sets = testtime.ToLocalTime(); 
                textBox2.Text = value.ToString();
                chart3.Series[0].Points.AddXY(sets, value);
                
            }
            press_count++;
            //tb3
*/
        }
    }
}
