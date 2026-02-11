namespace Air_Quality_Monitoring
{
    partial class UC_Alert
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.num_pm25_good = new System.Windows.Forms.NumericUpDown();
            this.num_pm25_normal = new System.Windows.Forms.NumericUpDown();
            this.num_pm25_bad = new System.Windows.Forms.NumericUpDown();
            this.num_pm10_good = new System.Windows.Forms.NumericUpDown();
            this.num_pm10_normal = new System.Windows.Forms.NumericUpDown();
            this.num_pm10_bad = new System.Windows.Forms.NumericUpDown();
            this.num_co2_good = new System.Windows.Forms.NumericUpDown();
            this.num_co2_normal = new System.Windows.Forms.NumericUpDown();
            this.num_co2_bad = new System.Windows.Forms.NumericUpDown();
            this.num_oxy_good = new System.Windows.Forms.NumericUpDown();
            this.num_oxy_normal = new System.Windows.Forms.NumericUpDown();
            this.num_oxy_bad = new System.Windows.Forms.NumericUpDown();
            this.lb_verybad = new System.Windows.Forms.Label();
            this.lb_bad = new System.Windows.Forms.Label();
            this.lb_normal = new System.Windows.Forms.Label();
            this.lb_good = new System.Windows.Forms.Label();
            this.lb_type = new System.Windows.Forms.Label();
            this.lb_temperature = new System.Windows.Forms.Label();
            this.lb_humidity = new System.Windows.Forms.Label();
            this.lb_oxygen = new System.Windows.Forms.Label();
            this.lb_co2 = new System.Windows.Forms.Label();
            this.lb_pm10 = new System.Windows.Forms.Label();
            this.lb_pm25 = new System.Windows.Forms.Label();
            this.lb_temp_verybad = new System.Windows.Forms.Label();
            this.lb_humid_verybad = new System.Windows.Forms.Label();
            this.lb_oxy_verybad = new System.Windows.Forms.Label();
            this.lb_co2_verybad = new System.Windows.Forms.Label();
            this.lb_pm10_verybad = new System.Windows.Forms.Label();
            this.lb_pm25_verybad = new System.Windows.Forms.Label();
            this.num_temp_good = new System.Windows.Forms.NumericUpDown();
            this.num_temp_normal = new System.Windows.Forms.NumericUpDown();
            this.num_temp_bad = new System.Windows.Forms.NumericUpDown();
            this.num_humid_good = new System.Windows.Forms.NumericUpDown();
            this.num_humid_normal = new System.Windows.Forms.NumericUpDown();
            this.num_humid_bad = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm25_good)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm25_normal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm25_bad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm10_good)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm10_normal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm10_bad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_co2_good)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_co2_normal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_co2_bad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_oxy_good)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_oxy_normal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_oxy_bad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_temp_good)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_temp_normal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_temp_bad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_humid_good)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_humid_normal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_humid_bad)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.num_pm25_good, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.num_pm25_normal, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.num_pm25_bad, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.num_pm10_good, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.num_pm10_normal, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.num_pm10_bad, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.num_co2_good, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.num_co2_normal, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.num_co2_bad, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.num_oxy_good, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.num_oxy_normal, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.num_oxy_bad, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lb_verybad, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_bad, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_normal, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_good, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_type, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_temperature, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_humidity, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lb_oxygen, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lb_co2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lb_pm10, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lb_pm25, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lb_temp_verybad, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lb_humid_verybad, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lb_oxy_verybad, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lb_co2_verybad, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.lb_pm10_verybad, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.lb_pm25_verybad, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.num_temp_good, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.num_temp_normal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.num_temp_bad, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.num_humid_good, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.num_humid_normal, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.num_humid_bad, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(706, 504);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // num_pm25_good
            // 
            this.num_pm25_good.DecimalPlaces = 1;
            this.num_pm25_good.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_pm25_good.Location = new System.Drawing.Point(140, 425);
            this.num_pm25_good.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_pm25_good.Name = "num_pm25_good";
            this.num_pm25_good.Size = new System.Drawing.Size(135, 21);
            this.num_pm25_good.TabIndex = 17;
            this.num_pm25_good.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_pm25_normal
            // 
            this.num_pm25_normal.DecimalPlaces = 1;
            this.num_pm25_normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_pm25_normal.Location = new System.Drawing.Point(282, 425);
            this.num_pm25_normal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_pm25_normal.Name = "num_pm25_normal";
            this.num_pm25_normal.Size = new System.Drawing.Size(135, 21);
            this.num_pm25_normal.TabIndex = 18;
            this.num_pm25_normal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_pm25_bad
            // 
            this.num_pm25_bad.DecimalPlaces = 1;
            this.num_pm25_bad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_pm25_bad.Location = new System.Drawing.Point(424, 425);
            this.num_pm25_bad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_pm25_bad.Name = "num_pm25_bad";
            this.num_pm25_bad.Size = new System.Drawing.Size(135, 21);
            this.num_pm25_bad.TabIndex = 19;
            this.num_pm25_bad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_pm10_good
            // 
            this.num_pm10_good.DecimalPlaces = 1;
            this.num_pm10_good.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_pm10_good.Location = new System.Drawing.Point(140, 348);
            this.num_pm10_good.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_pm10_good.Name = "num_pm10_good";
            this.num_pm10_good.Size = new System.Drawing.Size(135, 21);
            this.num_pm10_good.TabIndex = 14;
            this.num_pm10_good.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_pm10_normal
            // 
            this.num_pm10_normal.DecimalPlaces = 1;
            this.num_pm10_normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_pm10_normal.Location = new System.Drawing.Point(282, 348);
            this.num_pm10_normal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_pm10_normal.Name = "num_pm10_normal";
            this.num_pm10_normal.Size = new System.Drawing.Size(135, 21);
            this.num_pm10_normal.TabIndex = 15;
            this.num_pm10_normal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_pm10_bad
            // 
            this.num_pm10_bad.DecimalPlaces = 1;
            this.num_pm10_bad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_pm10_bad.Location = new System.Drawing.Point(424, 348);
            this.num_pm10_bad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_pm10_bad.Name = "num_pm10_bad";
            this.num_pm10_bad.Size = new System.Drawing.Size(135, 21);
            this.num_pm10_bad.TabIndex = 16;
            this.num_pm10_bad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_co2_good
            // 
            this.num_co2_good.DecimalPlaces = 1;
            this.num_co2_good.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_co2_good.Location = new System.Drawing.Point(140, 271);
            this.num_co2_good.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_co2_good.Name = "num_co2_good";
            this.num_co2_good.Size = new System.Drawing.Size(135, 21);
            this.num_co2_good.TabIndex = 11;
            this.num_co2_good.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_co2_normal
            // 
            this.num_co2_normal.DecimalPlaces = 1;
            this.num_co2_normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_co2_normal.Location = new System.Drawing.Point(282, 271);
            this.num_co2_normal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_co2_normal.Name = "num_co2_normal";
            this.num_co2_normal.Size = new System.Drawing.Size(135, 21);
            this.num_co2_normal.TabIndex = 12;
            this.num_co2_normal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_co2_bad
            // 
            this.num_co2_bad.DecimalPlaces = 1;
            this.num_co2_bad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_co2_bad.Location = new System.Drawing.Point(424, 271);
            this.num_co2_bad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_co2_bad.Name = "num_co2_bad";
            this.num_co2_bad.Size = new System.Drawing.Size(135, 21);
            this.num_co2_bad.TabIndex = 13;
            this.num_co2_bad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_oxy_good
            // 
            this.num_oxy_good.DecimalPlaces = 1;
            this.num_oxy_good.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_oxy_good.Location = new System.Drawing.Point(140, 194);
            this.num_oxy_good.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_oxy_good.Name = "num_oxy_good";
            this.num_oxy_good.Size = new System.Drawing.Size(135, 21);
            this.num_oxy_good.TabIndex = 8;
            this.num_oxy_good.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_oxy_normal
            // 
            this.num_oxy_normal.DecimalPlaces = 1;
            this.num_oxy_normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_oxy_normal.Location = new System.Drawing.Point(282, 194);
            this.num_oxy_normal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_oxy_normal.Name = "num_oxy_normal";
            this.num_oxy_normal.Size = new System.Drawing.Size(135, 21);
            this.num_oxy_normal.TabIndex = 9;
            this.num_oxy_normal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_oxy_bad
            // 
            this.num_oxy_bad.DecimalPlaces = 1;
            this.num_oxy_bad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_oxy_bad.Location = new System.Drawing.Point(424, 194);
            this.num_oxy_bad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_oxy_bad.Name = "num_oxy_bad";
            this.num_oxy_bad.Size = new System.Drawing.Size(135, 21);
            this.num_oxy_bad.TabIndex = 10;
            this.num_oxy_bad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_verybad
            // 
            this.lb_verybad.AutoSize = true;
            this.lb_verybad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_verybad.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_verybad.Location = new System.Drawing.Point(566, 1);
            this.lb_verybad.Name = "lb_verybad";
            this.lb_verybad.Size = new System.Drawing.Size(136, 35);
            this.lb_verybad.TabIndex = 4;
            this.lb_verybad.Text = "매우 나쁨";
            this.lb_verybad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_bad
            // 
            this.lb_bad.AutoSize = true;
            this.lb_bad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_bad.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_bad.Location = new System.Drawing.Point(424, 1);
            this.lb_bad.Name = "lb_bad";
            this.lb_bad.Size = new System.Drawing.Size(135, 35);
            this.lb_bad.TabIndex = 3;
            this.lb_bad.Text = "나쁨";
            this.lb_bad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_normal
            // 
            this.lb_normal.AutoSize = true;
            this.lb_normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_normal.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_normal.Location = new System.Drawing.Point(282, 1);
            this.lb_normal.Name = "lb_normal";
            this.lb_normal.Size = new System.Drawing.Size(135, 35);
            this.lb_normal.TabIndex = 2;
            this.lb_normal.Text = "보통";
            this.lb_normal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_good
            // 
            this.lb_good.AutoSize = true;
            this.lb_good.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_good.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_good.Location = new System.Drawing.Point(140, 1);
            this.lb_good.Name = "lb_good";
            this.lb_good.Size = new System.Drawing.Size(135, 35);
            this.lb_good.TabIndex = 1;
            this.lb_good.Text = "좋음";
            this.lb_good.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_type.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_type.Location = new System.Drawing.Point(4, 1);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(129, 35);
            this.lb_type.TabIndex = 0;
            this.lb_type.Text = "종류";
            this.lb_type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_temperature
            // 
            this.lb_temperature.AutoSize = true;
            this.lb_temperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_temperature.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_temperature.Location = new System.Drawing.Point(4, 37);
            this.lb_temperature.Name = "lb_temperature";
            this.lb_temperature.Size = new System.Drawing.Size(129, 76);
            this.lb_temperature.TabIndex = 5;
            this.lb_temperature.Text = "온도 (℃)";
            this.lb_temperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_humidity
            // 
            this.lb_humidity.AutoSize = true;
            this.lb_humidity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_humidity.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_humidity.Location = new System.Drawing.Point(4, 114);
            this.lb_humidity.Name = "lb_humidity";
            this.lb_humidity.Size = new System.Drawing.Size(129, 76);
            this.lb_humidity.TabIndex = 5;
            this.lb_humidity.Text = "습도 (%)";
            this.lb_humidity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_oxygen
            // 
            this.lb_oxygen.AutoSize = true;
            this.lb_oxygen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_oxygen.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_oxygen.Location = new System.Drawing.Point(4, 191);
            this.lb_oxygen.Name = "lb_oxygen";
            this.lb_oxygen.Size = new System.Drawing.Size(129, 76);
            this.lb_oxygen.TabIndex = 5;
            this.lb_oxygen.Text = "산소 (%)";
            this.lb_oxygen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_co2
            // 
            this.lb_co2.AutoSize = true;
            this.lb_co2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_co2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_co2.Location = new System.Drawing.Point(4, 268);
            this.lb_co2.Name = "lb_co2";
            this.lb_co2.Size = new System.Drawing.Size(129, 76);
            this.lb_co2.TabIndex = 5;
            this.lb_co2.Text = "ppm (이산화탄소)";
            this.lb_co2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_pm10
            // 
            this.lb_pm10.AutoSize = true;
            this.lb_pm10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_pm10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_pm10.Location = new System.Drawing.Point(4, 345);
            this.lb_pm10.Name = "lb_pm10";
            this.lb_pm10.Size = new System.Drawing.Size(129, 76);
            this.lb_pm10.TabIndex = 5;
            this.lb_pm10.Text = "미세먼지 (μg/m³)";
            this.lb_pm10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_pm25
            // 
            this.lb_pm25.AutoSize = true;
            this.lb_pm25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_pm25.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_pm25.Location = new System.Drawing.Point(4, 422);
            this.lb_pm25.Name = "lb_pm25";
            this.lb_pm25.Size = new System.Drawing.Size(129, 81);
            this.lb_pm25.TabIndex = 5;
            this.lb_pm25.Text = "초미세먼지 (μg/m³)";
            this.lb_pm25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_temp_verybad
            // 
            this.lb_temp_verybad.AutoSize = true;
            this.lb_temp_verybad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_temp_verybad.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_temp_verybad.Location = new System.Drawing.Point(566, 37);
            this.lb_temp_verybad.Name = "lb_temp_verybad";
            this.lb_temp_verybad.Size = new System.Drawing.Size(136, 76);
            this.lb_temp_verybad.TabIndex = 6;
            this.lb_temp_verybad.Text = "30 초과";
            this.lb_temp_verybad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_humid_verybad
            // 
            this.lb_humid_verybad.AutoSize = true;
            this.lb_humid_verybad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_humid_verybad.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_humid_verybad.Location = new System.Drawing.Point(566, 114);
            this.lb_humid_verybad.Name = "lb_humid_verybad";
            this.lb_humid_verybad.Size = new System.Drawing.Size(136, 76);
            this.lb_humid_verybad.TabIndex = 6;
            this.lb_humid_verybad.Text = "80 초과";
            this.lb_humid_verybad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_oxy_verybad
            // 
            this.lb_oxy_verybad.AutoSize = true;
            this.lb_oxy_verybad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_oxy_verybad.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_oxy_verybad.Location = new System.Drawing.Point(566, 191);
            this.lb_oxy_verybad.Name = "lb_oxy_verybad";
            this.lb_oxy_verybad.Size = new System.Drawing.Size(136, 76);
            this.lb_oxy_verybad.TabIndex = 6;
            this.lb_oxy_verybad.Text = "18 미만";
            this.lb_oxy_verybad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_co2_verybad
            // 
            this.lb_co2_verybad.AutoSize = true;
            this.lb_co2_verybad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_co2_verybad.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_co2_verybad.Location = new System.Drawing.Point(566, 268);
            this.lb_co2_verybad.Name = "lb_co2_verybad";
            this.lb_co2_verybad.Size = new System.Drawing.Size(136, 76);
            this.lb_co2_verybad.TabIndex = 6;
            this.lb_co2_verybad.Text = "1500 초과";
            this.lb_co2_verybad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_pm10_verybad
            // 
            this.lb_pm10_verybad.AutoSize = true;
            this.lb_pm10_verybad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_pm10_verybad.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_pm10_verybad.Location = new System.Drawing.Point(566, 345);
            this.lb_pm10_verybad.Name = "lb_pm10_verybad";
            this.lb_pm10_verybad.Size = new System.Drawing.Size(136, 76);
            this.lb_pm10_verybad.TabIndex = 6;
            this.lb_pm10_verybad.Text = "150 초과";
            this.lb_pm10_verybad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_pm25_verybad
            // 
            this.lb_pm25_verybad.AutoSize = true;
            this.lb_pm25_verybad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_pm25_verybad.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_pm25_verybad.Location = new System.Drawing.Point(566, 422);
            this.lb_pm25_verybad.Name = "lb_pm25_verybad";
            this.lb_pm25_verybad.Size = new System.Drawing.Size(136, 81);
            this.lb_pm25_verybad.TabIndex = 6;
            this.lb_pm25_verybad.Text = "75 이상";
            this.lb_pm25_verybad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // num_temp_good
            // 
            this.num_temp_good.DecimalPlaces = 1;
            this.num_temp_good.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_temp_good.Location = new System.Drawing.Point(140, 40);
            this.num_temp_good.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_temp_good.Name = "num_temp_good";
            this.num_temp_good.Size = new System.Drawing.Size(135, 21);
            this.num_temp_good.TabIndex = 7;
            this.num_temp_good.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_temp_normal
            // 
            this.num_temp_normal.DecimalPlaces = 1;
            this.num_temp_normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_temp_normal.Location = new System.Drawing.Point(282, 40);
            this.num_temp_normal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_temp_normal.Name = "num_temp_normal";
            this.num_temp_normal.Size = new System.Drawing.Size(135, 21);
            this.num_temp_normal.TabIndex = 7;
            this.num_temp_normal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_temp_bad
            // 
            this.num_temp_bad.DecimalPlaces = 1;
            this.num_temp_bad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_temp_bad.Location = new System.Drawing.Point(424, 40);
            this.num_temp_bad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_temp_bad.Name = "num_temp_bad";
            this.num_temp_bad.Size = new System.Drawing.Size(135, 21);
            this.num_temp_bad.TabIndex = 7;
            this.num_temp_bad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_humid_good
            // 
            this.num_humid_good.DecimalPlaces = 1;
            this.num_humid_good.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_humid_good.Location = new System.Drawing.Point(140, 117);
            this.num_humid_good.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_humid_good.Name = "num_humid_good";
            this.num_humid_good.Size = new System.Drawing.Size(135, 21);
            this.num_humid_good.TabIndex = 7;
            this.num_humid_good.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_humid_normal
            // 
            this.num_humid_normal.DecimalPlaces = 1;
            this.num_humid_normal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_humid_normal.Location = new System.Drawing.Point(282, 117);
            this.num_humid_normal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_humid_normal.Name = "num_humid_normal";
            this.num_humid_normal.Size = new System.Drawing.Size(135, 21);
            this.num_humid_normal.TabIndex = 7;
            this.num_humid_normal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_humid_bad
            // 
            this.num_humid_bad.DecimalPlaces = 1;
            this.num_humid_bad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.num_humid_bad.Location = new System.Drawing.Point(424, 117);
            this.num_humid_bad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_humid_bad.Name = "num_humid_bad";
            this.num_humid_bad.Size = new System.Drawing.Size(135, 21);
            this.num_humid_bad.TabIndex = 7;
            this.num_humid_bad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UC_Alert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_Alert";
            this.Size = new System.Drawing.Size(706, 504);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm25_good)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm25_normal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm25_bad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm10_good)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm10_normal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_pm10_bad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_co2_good)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_co2_normal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_co2_bad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_oxy_good)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_oxy_normal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_oxy_bad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_temp_good)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_temp_normal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_temp_bad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_humid_good)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_humid_normal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_humid_bad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lb_verybad;
        private System.Windows.Forms.Label lb_bad;
        private System.Windows.Forms.Label lb_normal;
        private System.Windows.Forms.Label lb_good;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label lb_temperature;
        private System.Windows.Forms.Label lb_humidity;
        private System.Windows.Forms.Label lb_oxygen;
        private System.Windows.Forms.Label lb_co2;
        private System.Windows.Forms.Label lb_pm10;
        private System.Windows.Forms.Label lb_pm25;
        private System.Windows.Forms.Label lb_temp_verybad;
        private System.Windows.Forms.Label lb_humid_verybad;
        private System.Windows.Forms.Label lb_oxy_verybad;
        private System.Windows.Forms.Label lb_co2_verybad;
        private System.Windows.Forms.Label lb_pm10_verybad;
        private System.Windows.Forms.Label lb_pm25_verybad;
        private System.Windows.Forms.NumericUpDown num_pm25_good;
        private System.Windows.Forms.NumericUpDown num_pm25_normal;
        private System.Windows.Forms.NumericUpDown num_pm25_bad;
        private System.Windows.Forms.NumericUpDown num_pm10_good;
        private System.Windows.Forms.NumericUpDown num_pm10_normal;
        private System.Windows.Forms.NumericUpDown num_pm10_bad;
        private System.Windows.Forms.NumericUpDown num_co2_good;
        private System.Windows.Forms.NumericUpDown num_co2_normal;
        private System.Windows.Forms.NumericUpDown num_co2_bad;
        private System.Windows.Forms.NumericUpDown num_oxy_good;
        private System.Windows.Forms.NumericUpDown num_oxy_normal;
        private System.Windows.Forms.NumericUpDown num_oxy_bad;
        private System.Windows.Forms.NumericUpDown num_temp_good;
        private System.Windows.Forms.NumericUpDown num_temp_normal;
        private System.Windows.Forms.NumericUpDown num_temp_bad;
        private System.Windows.Forms.NumericUpDown num_humid_good;
        private System.Windows.Forms.NumericUpDown num_humid_normal;
        private System.Windows.Forms.NumericUpDown num_humid_bad;
    }
}
