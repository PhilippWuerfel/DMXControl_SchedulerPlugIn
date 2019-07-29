namespace SchedulerPlugin
{
    partial class AppointmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_appointmentName = new System.Windows.Forms.Label();
            this.lbl_startDate = new System.Windows.Forms.Label();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_time = new System.Windows.Forms.Label();
            this.chk_monday = new System.Windows.Forms.CheckBox();
            this.chk_tuesday = new System.Windows.Forms.CheckBox();
            this.chk_wednesday = new System.Windows.Forms.CheckBox();
            this.chk_thursday = new System.Windows.Forms.CheckBox();
            this.chk_friday = new System.Windows.Forms.CheckBox();
            this.chk_saturday = new System.Windows.Forms.CheckBox();
            this.chk_sunday = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.divider_vert_pattern = new System.Windows.Forms.Label();
            this.txt_numOfOccurences = new System.Windows.Forms.TextBox();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_appointmentName = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.grpbox_RecurPattern = new System.Windows.Forms.GroupBox();
            this.rdb_noPattern = new System.Windows.Forms.RadioButton();
            this.rdb_weekly = new System.Windows.Forms.RadioButton();
            this.rdb_daily = new System.Windows.Forms.RadioButton();
            this.grpbox_RangeOfRecur = new System.Windows.Forms.GroupBox();
            this.rdb_endBy = new System.Windows.Forms.RadioButton();
            this.rdb_numOfOccurrences = new System.Windows.Forms.RadioButton();
            this.rdb_noEndDate = new System.Windows.Forms.RadioButton();
            this.rdb_everyXDays = new System.Windows.Forms.RadioButton();
            this.rdb_everyDay = new System.Windows.Forms.RadioButton();
            this.txt_everyXDay = new System.Windows.Forms.TextBox();
            this.lbl_everyXDay = new System.Windows.Forms.Label();
            this.grpbox_RecurPatternValues = new System.Windows.Forms.GroupBox();
            this.lbl_lightSceneName = new System.Windows.Forms.Label();
            this.txt_lightSceneName = new System.Windows.Forms.TextBox();
            this.lb_lightSceneList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.grpbox_RecurPattern.SuspendLayout();
            this.grpbox_RangeOfRecur.SuspendLayout();
            this.grpbox_RecurPatternValues.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_appointmentName
            // 
            this.lbl_appointmentName.AutoSize = true;
            this.lbl_appointmentName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_appointmentName.Location = new System.Drawing.Point(3, 0);
            this.lbl_appointmentName.Name = "lbl_appointmentName";
            this.lbl_appointmentName.Size = new System.Drawing.Size(129, 34);
            this.lbl_appointmentName.TabIndex = 0;
            this.lbl_appointmentName.Text = "Name of Appointment";
            // 
            // lbl_startDate
            // 
            this.lbl_startDate.AutoSize = true;
            this.lbl_startDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_startDate.Location = new System.Drawing.Point(3, 34);
            this.lbl_startDate.Name = "lbl_startDate";
            this.lbl_startDate.Size = new System.Drawing.Size(129, 34);
            this.lbl_startDate.TabIndex = 1;
            this.lbl_startDate.Text = "Start date";
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(138, 37);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(190, 20);
            this.dateTimePicker_startDate.TabIndex = 3;
            this.dateTimePicker_startDate.ValueChanged += new System.EventHandler(this.DateTimePicker_startDate_ValueChanged);
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_time.Location = new System.Drawing.Point(3, 68);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(129, 34);
            this.lbl_time.TabIndex = 5;
            this.lbl_time.Text = "Start time";
            // 
            // chk_monday
            // 
            this.chk_monday.AutoSize = true;
            this.chk_monday.Location = new System.Drawing.Point(32, 14);
            this.chk_monday.Name = "chk_monday";
            this.chk_monday.Size = new System.Drawing.Size(64, 17);
            this.chk_monday.TabIndex = 11;
            this.chk_monday.Text = "Monday";
            this.chk_monday.UseVisualStyleBackColor = true;
            this.chk_monday.Visible = false;
            // 
            // chk_tuesday
            // 
            this.chk_tuesday.AutoSize = true;
            this.chk_tuesday.Location = new System.Drawing.Point(32, 37);
            this.chk_tuesday.Name = "chk_tuesday";
            this.chk_tuesday.Size = new System.Drawing.Size(67, 17);
            this.chk_tuesday.TabIndex = 12;
            this.chk_tuesday.Text = "Tuesday";
            this.chk_tuesday.UseVisualStyleBackColor = true;
            this.chk_tuesday.Visible = false;
            // 
            // chk_wednesday
            // 
            this.chk_wednesday.AutoSize = true;
            this.chk_wednesday.Location = new System.Drawing.Point(32, 60);
            this.chk_wednesday.Name = "chk_wednesday";
            this.chk_wednesday.Size = new System.Drawing.Size(83, 17);
            this.chk_wednesday.TabIndex = 13;
            this.chk_wednesday.Text = "Wednesday";
            this.chk_wednesday.UseVisualStyleBackColor = true;
            this.chk_wednesday.Visible = false;
            // 
            // chk_thursday
            // 
            this.chk_thursday.AutoSize = true;
            this.chk_thursday.Location = new System.Drawing.Point(32, 83);
            this.chk_thursday.Name = "chk_thursday";
            this.chk_thursday.Size = new System.Drawing.Size(70, 17);
            this.chk_thursday.TabIndex = 14;
            this.chk_thursday.Text = "Thursday";
            this.chk_thursday.UseVisualStyleBackColor = true;
            this.chk_thursday.Visible = false;
            // 
            // chk_friday
            // 
            this.chk_friday.AutoSize = true;
            this.chk_friday.Location = new System.Drawing.Point(32, 106);
            this.chk_friday.Name = "chk_friday";
            this.chk_friday.Size = new System.Drawing.Size(54, 17);
            this.chk_friday.TabIndex = 15;
            this.chk_friday.Text = "Friday";
            this.chk_friday.UseVisualStyleBackColor = true;
            this.chk_friday.Visible = false;
            // 
            // chk_saturday
            // 
            this.chk_saturday.AutoSize = true;
            this.chk_saturday.Location = new System.Drawing.Point(32, 129);
            this.chk_saturday.Name = "chk_saturday";
            this.chk_saturday.Size = new System.Drawing.Size(68, 17);
            this.chk_saturday.TabIndex = 16;
            this.chk_saturday.Text = "Saturday";
            this.chk_saturday.UseVisualStyleBackColor = true;
            this.chk_saturday.Visible = false;
            // 
            // chk_sunday
            // 
            this.chk_sunday.AutoSize = true;
            this.chk_sunday.Location = new System.Drawing.Point(32, 152);
            this.chk_sunday.Name = "chk_sunday";
            this.chk_sunday.Size = new System.Drawing.Size(62, 17);
            this.chk_sunday.TabIndex = 17;
            this.chk_sunday.Text = "Sunday";
            this.chk_sunday.UseVisualStyleBackColor = true;
            this.chk_sunday.Visible = false;
            // 
            // divider_vert_pattern
            // 
            this.divider_vert_pattern.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider_vert_pattern.Location = new System.Drawing.Point(120, 13);
            this.divider_vert_pattern.Name = "divider_vert_pattern";
            this.divider_vert_pattern.Size = new System.Drawing.Size(2, 155);
            this.divider_vert_pattern.TabIndex = 20;
            // 
            // txt_numOfOccurences
            // 
            this.txt_numOfOccurences.Location = new System.Drawing.Point(92, 42);
            this.txt_numOfOccurences.Name = "txt_numOfOccurences";
            this.txt_numOfOccurences.Size = new System.Drawing.Size(41, 20);
            this.txt_numOfOccurences.TabIndex = 23;
            this.txt_numOfOccurences.Text = "1";
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(92, 66);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_endDate.TabIndex = 25;
            this.dateTimePicker_endDate.Value = new System.DateTime(2019, 2, 17, 0, 0, 0, 0);
            this.dateTimePicker_endDate.ValueChanged += new System.EventHandler(this.DateTimePicker_endDate_ValueChanged);
            // 
            // dateTimePicker_startTime
            // 
            this.dateTimePicker_startTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_startTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_startTime.Location = new System.Drawing.Point(138, 71);
            this.dateTimePicker_startTime.Name = "dateTimePicker_startTime";
            this.dateTimePicker_startTime.ShowUpDown = true;
            this.dateTimePicker_startTime.Size = new System.Drawing.Size(190, 20);
            this.dateTimePicker_startTime.TabIndex = 31;
            this.dateTimePicker_startTime.Value = new System.DateTime(2019, 2, 17, 1, 44, 18, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "occurrences";
            // 
            // txt_appointmentName
            // 
            this.txt_appointmentName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_appointmentName.Location = new System.Drawing.Point(138, 3);
            this.txt_appointmentName.Name = "txt_appointmentName";
            this.txt_appointmentName.Size = new System.Drawing.Size(190, 20);
            this.txt_appointmentName.TabIndex = 27;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_cancel.Location = new System.Drawing.Point(165, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 21);
            this.btn_cancel.TabIndex = 28;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_ok.Location = new System.Drawing.Point(3, 3);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 21);
            this.btn_ok.TabIndex = 29;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.Btn_ok_Click);
            // 
            // grpbox_RecurPattern
            // 
            this.grpbox_RecurPattern.Controls.Add(this.rdb_noPattern);
            this.grpbox_RecurPattern.Controls.Add(this.rdb_weekly);
            this.grpbox_RecurPattern.Controls.Add(this.rdb_daily);
            this.grpbox_RecurPattern.Controls.Add(this.divider_vert_pattern);
            this.grpbox_RecurPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbox_RecurPattern.Location = new System.Drawing.Point(3, 105);
            this.grpbox_RecurPattern.Name = "grpbox_RecurPattern";
            this.grpbox_RecurPattern.Size = new System.Drawing.Size(129, 177);
            this.grpbox_RecurPattern.TabIndex = 32;
            this.grpbox_RecurPattern.TabStop = false;
            this.grpbox_RecurPattern.Text = "Recurrence pattern";
            // 
            // rdb_noPattern
            // 
            this.rdb_noPattern.AutoSize = true;
            this.rdb_noPattern.Checked = true;
            this.rdb_noPattern.Location = new System.Drawing.Point(6, 79);
            this.rdb_noPattern.Name = "rdb_noPattern";
            this.rdb_noPattern.Size = new System.Drawing.Size(73, 17);
            this.rdb_noPattern.TabIndex = 3;
            this.rdb_noPattern.TabStop = true;
            this.rdb_noPattern.Text = "no pattern";
            this.rdb_noPattern.UseVisualStyleBackColor = true;
            // 
            // rdb_weekly
            // 
            this.rdb_weekly.AutoSize = true;
            this.rdb_weekly.Location = new System.Drawing.Point(6, 42);
            this.rdb_weekly.Name = "rdb_weekly";
            this.rdb_weekly.Size = new System.Drawing.Size(58, 17);
            this.rdb_weekly.TabIndex = 1;
            this.rdb_weekly.TabStop = true;
            this.rdb_weekly.Text = "weekly";
            this.rdb_weekly.UseVisualStyleBackColor = true;
            this.rdb_weekly.CheckedChanged += new System.EventHandler(this.Rdb_weekly_CheckedChanged);
            // 
            // rdb_daily
            // 
            this.rdb_daily.AutoSize = true;
            this.rdb_daily.Location = new System.Drawing.Point(6, 19);
            this.rdb_daily.Name = "rdb_daily";
            this.rdb_daily.Size = new System.Drawing.Size(46, 17);
            this.rdb_daily.TabIndex = 0;
            this.rdb_daily.TabStop = true;
            this.rdb_daily.Text = "daily";
            this.rdb_daily.UseVisualStyleBackColor = true;
            this.rdb_daily.CheckedChanged += new System.EventHandler(this.Rdb_daily_CheckedChanged);
            // 
            // grpbox_RangeOfRecur
            // 
            this.grpbox_RangeOfRecur.Controls.Add(this.rdb_endBy);
            this.grpbox_RangeOfRecur.Controls.Add(this.rdb_numOfOccurrences);
            this.grpbox_RangeOfRecur.Controls.Add(this.rdb_noEndDate);
            this.grpbox_RangeOfRecur.Controls.Add(this.dateTimePicker_endDate);
            this.grpbox_RangeOfRecur.Controls.Add(this.txt_numOfOccurences);
            this.grpbox_RangeOfRecur.Controls.Add(this.label3);
            this.grpbox_RangeOfRecur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbox_RangeOfRecur.Location = new System.Drawing.Point(3, 161);
            this.grpbox_RangeOfRecur.Name = "grpbox_RangeOfRecur";
            this.grpbox_RangeOfRecur.Size = new System.Drawing.Size(325, 88);
            this.grpbox_RangeOfRecur.TabIndex = 33;
            this.grpbox_RangeOfRecur.TabStop = false;
            this.grpbox_RangeOfRecur.Text = "Range of recurrence";
            // 
            // rdb_endBy
            // 
            this.rdb_endBy.AutoSize = true;
            this.rdb_endBy.Location = new System.Drawing.Point(7, 66);
            this.rdb_endBy.Name = "rdb_endBy";
            this.rdb_endBy.Size = new System.Drawing.Size(58, 17);
            this.rdb_endBy.TabIndex = 34;
            this.rdb_endBy.TabStop = true;
            this.rdb_endBy.Text = "End by";
            this.rdb_endBy.UseVisualStyleBackColor = true;
            // 
            // rdb_numOfOccurrences
            // 
            this.rdb_numOfOccurrences.AutoSize = true;
            this.rdb_numOfOccurrences.Checked = true;
            this.rdb_numOfOccurrences.Location = new System.Drawing.Point(7, 43);
            this.rdb_numOfOccurrences.Name = "rdb_numOfOccurrences";
            this.rdb_numOfOccurrences.Size = new System.Drawing.Size(68, 17);
            this.rdb_numOfOccurrences.TabIndex = 1;
            this.rdb_numOfOccurrences.TabStop = true;
            this.rdb_numOfOccurrences.Text = "End after";
            this.rdb_numOfOccurrences.UseVisualStyleBackColor = true;
            // 
            // rdb_noEndDate
            // 
            this.rdb_noEndDate.AutoSize = true;
            this.rdb_noEndDate.Location = new System.Drawing.Point(7, 20);
            this.rdb_noEndDate.Name = "rdb_noEndDate";
            this.rdb_noEndDate.Size = new System.Drawing.Size(84, 17);
            this.rdb_noEndDate.TabIndex = 0;
            this.rdb_noEndDate.TabStop = true;
            this.rdb_noEndDate.Text = "No end date";
            this.rdb_noEndDate.UseVisualStyleBackColor = true;
            // 
            // rdb_everyXDays
            // 
            this.rdb_everyXDays.AutoSize = true;
            this.rdb_everyXDays.Location = new System.Drawing.Point(32, 23);
            this.rdb_everyXDays.Name = "rdb_everyXDays";
            this.rdb_everyXDays.Size = new System.Drawing.Size(51, 17);
            this.rdb_everyXDays.TabIndex = 21;
            this.rdb_everyXDays.TabStop = true;
            this.rdb_everyXDays.Text = "every";
            this.rdb_everyXDays.UseVisualStyleBackColor = true;
            this.rdb_everyXDays.Visible = false;
            // 
            // rdb_everyDay
            // 
            this.rdb_everyDay.AutoSize = true;
            this.rdb_everyDay.Location = new System.Drawing.Point(32, 46);
            this.rdb_everyDay.Name = "rdb_everyDay";
            this.rdb_everyDay.Size = new System.Drawing.Size(73, 17);
            this.rdb_everyDay.TabIndex = 22;
            this.rdb_everyDay.TabStop = true;
            this.rdb_everyDay.Text = "every Day";
            this.rdb_everyDay.UseVisualStyleBackColor = true;
            this.rdb_everyDay.Visible = false;
            // 
            // txt_everyXDay
            // 
            this.txt_everyXDay.Location = new System.Drawing.Point(89, 23);
            this.txt_everyXDay.Name = "txt_everyXDay";
            this.txt_everyXDay.Size = new System.Drawing.Size(41, 20);
            this.txt_everyXDay.TabIndex = 34;
            this.txt_everyXDay.Text = "0";
            this.txt_everyXDay.Visible = false;
            // 
            // lbl_everyXDay
            // 
            this.lbl_everyXDay.AutoSize = true;
            this.lbl_everyXDay.Location = new System.Drawing.Point(136, 25);
            this.lbl_everyXDay.Name = "lbl_everyXDay";
            this.lbl_everyXDay.Size = new System.Drawing.Size(29, 13);
            this.lbl_everyXDay.TabIndex = 34;
            this.lbl_everyXDay.Text = "days";
            this.lbl_everyXDay.Visible = false;
            // 
            // grpbox_RecurPatternValues
            // 
            this.grpbox_RecurPatternValues.Controls.Add(this.lbl_everyXDay);
            this.grpbox_RecurPatternValues.Controls.Add(this.rdb_everyXDays);
            this.grpbox_RecurPatternValues.Controls.Add(this.txt_everyXDay);
            this.grpbox_RecurPatternValues.Controls.Add(this.chk_sunday);
            this.grpbox_RecurPatternValues.Controls.Add(this.rdb_everyDay);
            this.grpbox_RecurPatternValues.Controls.Add(this.chk_saturday);
            this.grpbox_RecurPatternValues.Controls.Add(this.chk_friday);
            this.grpbox_RecurPatternValues.Controls.Add(this.chk_thursday);
            this.grpbox_RecurPatternValues.Controls.Add(this.chk_wednesday);
            this.grpbox_RecurPatternValues.Controls.Add(this.chk_tuesday);
            this.grpbox_RecurPatternValues.Controls.Add(this.chk_monday);
            this.grpbox_RecurPatternValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpbox_RecurPatternValues.Location = new System.Drawing.Point(138, 105);
            this.grpbox_RecurPatternValues.Name = "grpbox_RecurPatternValues";
            this.grpbox_RecurPatternValues.Size = new System.Drawing.Size(190, 177);
            this.grpbox_RecurPatternValues.TabIndex = 34;
            this.grpbox_RecurPatternValues.TabStop = false;
            // 
            // lbl_lightSceneName
            // 
            this.lbl_lightSceneName.AutoSize = true;
            this.lbl_lightSceneName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_lightSceneName.Location = new System.Drawing.Point(3, 0);
            this.lbl_lightSceneName.Name = "lbl_lightSceneName";
            this.lbl_lightSceneName.Size = new System.Drawing.Size(129, 25);
            this.lbl_lightSceneName.TabIndex = 36;
            this.lbl_lightSceneName.Text = "Name of Lightscene";
            // 
            // txt_lightSceneName
            // 
            this.txt_lightSceneName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_lightSceneName.Location = new System.Drawing.Point(138, 3);
            this.txt_lightSceneName.Name = "txt_lightSceneName";
            this.txt_lightSceneName.Size = new System.Drawing.Size(184, 20);
            this.txt_lightSceneName.TabIndex = 37;
            // 
            // lb_lightSceneList
            // 
            this.lb_lightSceneList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_lightSceneList.FormattingEnabled = true;
            this.lb_lightSceneList.Location = new System.Drawing.Point(3, 34);
            this.lb_lightSceneList.Name = "lb_lightSceneList";
            this.lb_lightSceneList.Size = new System.Drawing.Size(325, 121);
            this.lb_lightSceneList.TabIndex = 38;
            this.lb_lightSceneList.SelectedIndexChanged += new System.EventHandler(this.Lb_lightSceneList_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(704, 331);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.95563F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.04437F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_appointmentName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txt_appointmentName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_startDate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker_startDate, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.grpbox_RecurPatternValues, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl_time, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker_startTime, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.grpbox_RecurPattern, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 23);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(331, 285);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.grpbox_RangeOfRecur, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lb_lightSceneList, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(355, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.87719F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.56141F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.98246F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.22807F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(331, 285);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btn_cancel, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_ok, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 255);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(325, 27);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.81185F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.18815F));
            this.tableLayoutPanel5.Controls.Add(this.lbl_lightSceneName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txt_lightSceneName, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(325, 25);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 331);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "AppointmentForm";
            this.Text = "Add Appointment";
            this.grpbox_RecurPattern.ResumeLayout(false);
            this.grpbox_RecurPattern.PerformLayout();
            this.grpbox_RangeOfRecur.ResumeLayout(false);
            this.grpbox_RangeOfRecur.PerformLayout();
            this.grpbox_RecurPatternValues.ResumeLayout(false);
            this.grpbox_RecurPatternValues.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_appointmentName;
        private System.Windows.Forms.Label lbl_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.CheckBox chk_monday;
        private System.Windows.Forms.CheckBox chk_tuesday;
        private System.Windows.Forms.CheckBox chk_wednesday;
        private System.Windows.Forms.CheckBox chk_thursday;
        private System.Windows.Forms.CheckBox chk_friday;
        private System.Windows.Forms.CheckBox chk_saturday;
        private System.Windows.Forms.CheckBox chk_sunday;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label divider_vert_pattern;
        private System.Windows.Forms.TextBox txt_numOfOccurences;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_appointmentName;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startTime;
        private System.Windows.Forms.GroupBox grpbox_RecurPattern;
        private System.Windows.Forms.RadioButton rdb_weekly;
        private System.Windows.Forms.RadioButton rdb_daily;
        private System.Windows.Forms.RadioButton rdb_noPattern;
        private System.Windows.Forms.GroupBox grpbox_RangeOfRecur;
        private System.Windows.Forms.RadioButton rdb_endBy;
        private System.Windows.Forms.RadioButton rdb_numOfOccurrences;
        private System.Windows.Forms.RadioButton rdb_noEndDate;
        private System.Windows.Forms.Label lbl_everyXDay;
        private System.Windows.Forms.TextBox txt_everyXDay;
        private System.Windows.Forms.RadioButton rdb_everyDay;
        private System.Windows.Forms.RadioButton rdb_everyXDays;
        private System.Windows.Forms.GroupBox grpbox_RecurPatternValues;
        private System.Windows.Forms.Label lbl_lightSceneName;
        private System.Windows.Forms.TextBox txt_lightSceneName;
        private System.Windows.Forms.ListBox lb_lightSceneList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}