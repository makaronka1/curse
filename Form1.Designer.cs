namespace test
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.change = new System.Windows.Forms.Button();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.viborka = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.textBoxCurentTIme = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.CurentTimelabel = new System.Windows.Forms.Label();
            this.textBoxCurentVal = new System.Windows.Forms.TextBox();
            this.secondidbox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.firstidbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerFirstDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSecondDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 1);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.LabelBorderWidth = 0;
            series1.Legend = "Legend1";
            series1.MarkerBorderWidth = 0;
            series1.MarkerSize = 1;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1250, 537);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "График напряжения";
            this.chart1.Titles.Add(title1);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(12, 1);
            this.chart2.Name = "chart2";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series2.MarkerBorderWidth = 3;
            series2.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(1250, 537);
            this.chart2.TabIndex = 8;
            this.chart2.Text = "chart2";
            title2.Name = "Title1";
            title2.Text = "Тренд";
            this.chart2.Titles.Add(title2);
            this.chart2.Visible = false;
            // 
            // change
            // 
            this.change.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.change.AutoSize = true;
            this.change.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.change.Location = new System.Drawing.Point(1430, 72);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(183, 26);
            this.change.TabIndex = 9;
            this.change.Text = "поменять режим графика";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart3
            // 
            this.chart3.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart3.Legends.Add(legend3);
            this.chart3.Location = new System.Drawing.Point(12, 1);
            this.chart3.Name = "chart3";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series3.Legend = "Legend1";
            series3.MarkerSize = 10;
            series3.Name = "Series1";
            series3.ToolTip = "Chart3.Series[0].ToolTip = \" 0 : X = #VALX{F2} , Y = #VALY{F2}\"; ";
            this.chart3.Series.Add(series3);
            this.chart3.Size = new System.Drawing.Size(1250, 537);
            this.chart3.TabIndex = 11;
            this.chart3.Text = "chart3";
            title3.Name = "Title1";
            title3.Text = "Выборка";
            this.chart3.Titles.Add(title3);
            this.chart3.Visible = false;
            // 
            // viborka
            // 
            this.viborka.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.viborka.AutoSize = true;
            this.viborka.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.viborka.Location = new System.Drawing.Point(1382, 72);
            this.viborka.Name = "viborka";
            this.viborka.Size = new System.Drawing.Size(73, 26);
            this.viborka.TabIndex = 12;
            this.viborka.Text = "выборка";
            this.viborka.UseVisualStyleBackColor = true;
            this.viborka.Click += new System.EventHandler(this.button2_Click);
            // 
            // reset
            // 
            this.reset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.reset.AutoSize = true;
            this.reset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reset.Location = new System.Drawing.Point(1382, 49);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(55, 26);
            this.reset.TabIndex = 13;
            this.reset.Text = "сброс";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // textBoxCurentTIme
            // 
            this.textBoxCurentTIme.Location = new System.Drawing.Point(1339, 305);
            this.textBoxCurentTIme.Name = "textBoxCurentTIme";
            this.textBoxCurentTIme.Size = new System.Drawing.Size(191, 22);
            this.textBoxCurentTIme.TabIndex = 16;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.Location = new System.Drawing.Point(1339, 365);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(2, 20);
            this.labelInfo.TabIndex = 17;
            // 
            // CurentTimelabel
            // 
            this.CurentTimelabel.AutoSize = true;
            this.CurentTimelabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurentTimelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurentTimelabel.Location = new System.Drawing.Point(1382, 157);
            this.CurentTimelabel.Name = "CurentTimelabel";
            this.CurentTimelabel.Size = new System.Drawing.Size(2, 27);
            this.CurentTimelabel.TabIndex = 18;
            // 
            // textBoxCurentVal
            // 
            this.textBoxCurentVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCurentVal.Location = new System.Drawing.Point(1351, 193);
            this.textBoxCurentVal.Name = "textBoxCurentVal";
            this.textBoxCurentVal.Size = new System.Drawing.Size(179, 30);
            this.textBoxCurentVal.TabIndex = 14;
            // 
            // secondidbox
            // 
            this.secondidbox.Location = new System.Drawing.Point(1339, 463);
            this.secondidbox.Name = "secondidbox";
            this.secondidbox.Size = new System.Drawing.Size(100, 22);
            this.secondidbox.TabIndex = 19;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1445, 463);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1303, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // firstidbox
            // 
            this.firstidbox.Location = new System.Drawing.Point(1339, 409);
            this.firstidbox.Name = "firstidbox";
            this.firstidbox.Size = new System.Drawing.Size(100, 22);
            this.firstidbox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1282, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "curentval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1257, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "curenttimedb";
            // 
            // dateTimePickerFirstDate
            // 
            this.dateTimePickerFirstDate.Location = new System.Drawing.Point(1077, 258);
            this.dateTimePickerFirstDate.Name = "dateTimePickerFirstDate";
            this.dateTimePickerFirstDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFirstDate.TabIndex = 25;
            // 
            // dateTimePickerSecondDate
            // 
            this.dateTimePickerSecondDate.Location = new System.Drawing.Point(1077, 287);
            this.dateTimePickerSecondDate.Name = "dateTimePickerSecondDate";
            this.dateTimePickerSecondDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerSecondDate.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1130, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1130, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1581, 539);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerSecondDate);
            this.Controls.Add(this.dateTimePickerFirstDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstidbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.secondidbox);
            this.Controls.Add(this.CurentTimelabel);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxCurentTIme);
            this.Controls.Add(this.textBoxCurentVal);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.viborka);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.change);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.Button viborka;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBoxCurentTIme;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label CurentTimelabel;
        private System.Windows.Forms.TextBox textBoxCurentVal;
        private System.Windows.Forms.TextBox secondidbox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox firstidbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerFirstDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerSecondDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

