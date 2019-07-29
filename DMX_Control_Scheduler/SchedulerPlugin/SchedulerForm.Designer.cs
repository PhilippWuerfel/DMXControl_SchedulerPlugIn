namespace SchedulerPlugin
{
    partial class SchedulerForm
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
            this.calendar_month_scheduler = new System.Windows.Forms.MonthCalendar();
            this.btn_loadAppointments = new System.Windows.Forms.Button();
            this.btn_saveAppointments = new System.Windows.Forms.Button();
            this.btn_addAppointment = new System.Windows.Forms.Button();
            this.btn_editAppointment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_delAppointment = new System.Windows.Forms.Button();
            this.gv_appointmentList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_SortByStartDateTime = new System.Windows.Forms.Button();
            this.chkbox_isSchedulerRunning = new System.Windows.Forms.CheckBox();
            this.TestButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gv_appointmentList)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // calendar_month_scheduler
            // 
            this.calendar_month_scheduler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendar_month_scheduler.Location = new System.Drawing.Point(24, 92);
            this.calendar_month_scheduler.Name = "calendar_month_scheduler";
            this.calendar_month_scheduler.TabIndex = 0;
            this.calendar_month_scheduler.TodayDate = new System.DateTime(2018, 12, 1, 0, 0, 0, 0);
            // 
            // btn_loadAppointments
            // 
            this.btn_loadAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_loadAppointments.Location = new System.Drawing.Point(3, 3);
            this.btn_loadAppointments.Name = "btn_loadAppointments";
            this.btn_loadAppointments.Size = new System.Drawing.Size(119, 26);
            this.btn_loadAppointments.TabIndex = 4;
            this.btn_loadAppointments.Text = "Load Appointments";
            this.btn_loadAppointments.UseVisualStyleBackColor = true;
            this.btn_loadAppointments.Click += new System.EventHandler(this.Btn_loadAppointments_Click);
            // 
            // btn_saveAppointments
            // 
            this.btn_saveAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_saveAppointments.Location = new System.Drawing.Point(128, 3);
            this.btn_saveAppointments.Name = "btn_saveAppointments";
            this.btn_saveAppointments.Size = new System.Drawing.Size(119, 26);
            this.btn_saveAppointments.TabIndex = 5;
            this.btn_saveAppointments.Text = "Save Appointments";
            this.btn_saveAppointments.UseVisualStyleBackColor = true;
            this.btn_saveAppointments.Click += new System.EventHandler(this.Btn_saveAppointments_Click);
            // 
            // btn_addAppointment
            // 
            this.btn_addAppointment.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_addAppointment.Location = new System.Drawing.Point(3, 3);
            this.btn_addAppointment.Name = "btn_addAppointment";
            this.btn_addAppointment.Size = new System.Drawing.Size(97, 23);
            this.btn_addAppointment.TabIndex = 6;
            this.btn_addAppointment.Text = "Add";
            this.btn_addAppointment.UseVisualStyleBackColor = true;
            this.btn_addAppointment.Click += new System.EventHandler(this.Btn_addAppointment_Click);
            // 
            // btn_editAppointment
            // 
            this.btn_editAppointment.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_editAppointment.Location = new System.Drawing.Point(154, 3);
            this.btn_editAppointment.Name = "btn_editAppointment";
            this.btn_editAppointment.Size = new System.Drawing.Size(97, 23);
            this.btn_editAppointment.TabIndex = 7;
            this.btn_editAppointment.Text = "Edit";
            this.btn_editAppointment.UseVisualStyleBackColor = true;
            this.btn_editAppointment.Click += new System.EventHandler(this.Btn_editAppointment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(213, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 34);
            this.label1.TabIndex = 8;
            this.label1.Text = "Planned Appointments:";
            // 
            // btn_delAppointment
            // 
            this.btn_delAppointment.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_delAppointment.Location = new System.Drawing.Point(432, 3);
            this.btn_delAppointment.Name = "btn_delAppointment";
            this.btn_delAppointment.Size = new System.Drawing.Size(97, 23);
            this.btn_delAppointment.TabIndex = 9;
            this.btn_delAppointment.Text = "Delete";
            this.btn_delAppointment.UseVisualStyleBackColor = true;
            this.btn_delAppointment.Click += new System.EventHandler(this.Btn_delAppointment_Click);
            // 
            // gv_appointmentList
            // 
            this.gv_appointmentList.AllowUserToAddRows = false;
            this.gv_appointmentList.AllowUserToDeleteRows = false;
            this.gv_appointmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_appointmentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv_appointmentList.Location = new System.Drawing.Point(213, 86);
            this.gv_appointmentList.Name = "gv_appointmentList";
            this.gv_appointmentList.ReadOnly = true;
            this.gv_appointmentList.Size = new System.Drawing.Size(532, 205);
            this.gv_appointmentList.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.63043F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.36957F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.gv_appointmentList, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.calendar_month_scheduler, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkbox_isSchedulerRunning, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TestButton, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.82803F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.82803F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.92607F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.28405F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 346);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.44828F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.44828F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.10345F));
            this.tableLayoutPanel3.Controls.Add(this.btn_addAppointment, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_delAppointment, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_editAppointment, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(213, 297);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(532, 29);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.62375F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.62375F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.12874F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.62375F));
            this.tableLayoutPanel2.Controls.Add(this.btn_loadAppointments, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_saveAppointments, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_SortByStartDateTime, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(213, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(532, 28);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // btn_SortByStartDateTime
            // 
            this.btn_SortByStartDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SortByStartDateTime.Location = new System.Drawing.Point(407, 3);
            this.btn_SortByStartDateTime.Name = "btn_SortByStartDateTime";
            this.btn_SortByStartDateTime.Size = new System.Drawing.Size(122, 26);
            this.btn_SortByStartDateTime.TabIndex = 15;
            this.btn_SortByStartDateTime.Text = "Sort by Start Date";
            this.btn_SortByStartDateTime.UseVisualStyleBackColor = true;
            this.btn_SortByStartDateTime.Click += new System.EventHandler(this.btn_SortByStartDateTime_Click);
            // 
            // chkbox_isSchedulerRunning
            // 
            this.chkbox_isSchedulerRunning.AutoSize = true;
            this.chkbox_isSchedulerRunning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkbox_isSchedulerRunning.Location = new System.Drawing.Point(18, 18);
            this.chkbox_isSchedulerRunning.Name = "chkbox_isSchedulerRunning";
            this.chkbox_isSchedulerRunning.Size = new System.Drawing.Size(189, 28);
            this.chkbox_isSchedulerRunning.TabIndex = 14;
            this.chkbox_isSchedulerRunning.Text = "Run Scheduler";
            this.chkbox_isSchedulerRunning.UseVisualStyleBackColor = true;
            this.chkbox_isSchedulerRunning.CheckedChanged += new System.EventHandler(this.chkbox_isSchedulerRunning_CheckedChanged);
            // 
            // TestButton
            // 
            this.TestButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestButton.Location = new System.Drawing.Point(18, 297);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(189, 29);
            this.TestButton.TabIndex = 15;
            this.TestButton.Text = "TestButton";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Visible = false;
            // 
            // SchedulerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 346);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SchedulerForm";
            this.Text = "DMX Scheduler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SchedulerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.gv_appointmentList)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar_month_scheduler;
        private System.Windows.Forms.Button btn_loadAppointments;
        private System.Windows.Forms.Button btn_saveAppointments;
        private System.Windows.Forms.Button btn_addAppointment;
        private System.Windows.Forms.Button btn_editAppointment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_delAppointment;
        private System.Windows.Forms.DataGridView gv_appointmentList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox chkbox_isSchedulerRunning;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_SortByStartDateTime;
        private System.Windows.Forms.Button TestButton;
    }
}