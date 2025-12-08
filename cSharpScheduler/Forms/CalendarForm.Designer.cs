namespace cSharpScheduler
{
    partial class CalendarForm
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.btnCalendarBack = new System.Windows.Forms.Button();
            this.txtCalendarDesc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(125, 357);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // dgvCalendar
            // 
            this.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendar.Location = new System.Drawing.Point(60, 32);
            this.dgvCalendar.Name = "dgvCalendar";
            this.dgvCalendar.RowHeadersWidth = 51;
            this.dgvCalendar.RowTemplate.Height = 24;
            this.dgvCalendar.Size = new System.Drawing.Size(392, 269);
            this.dgvCalendar.TabIndex = 1;
            // 
            // btnCalendarBack
            // 
            this.btnCalendarBack.Location = new System.Drawing.Point(393, 585);
            this.btnCalendarBack.Name = "btnCalendarBack";
            this.btnCalendarBack.Size = new System.Drawing.Size(108, 40);
            this.btnCalendarBack.TabIndex = 2;
            this.btnCalendarBack.Text = "Back";
            this.btnCalendarBack.UseVisualStyleBackColor = true;
            this.btnCalendarBack.Click += new System.EventHandler(this.btnCalendarBack_Click);
            // 
            // txtCalendarDesc
            // 
            this.txtCalendarDesc.AutoSize = true;
            this.txtCalendarDesc.Location = new System.Drawing.Point(150, 322);
            this.txtCalendarDesc.Name = "txtCalendarDesc";
            this.txtCalendarDesc.Size = new System.Drawing.Size(213, 16);
            this.txtCalendarDesc.TabIndex = 3;
            this.txtCalendarDesc.Text = "Select a date to see appointments.";
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 637);
            this.Controls.Add(this.txtCalendarDesc);
            this.Controls.Add(this.btnCalendarBack);
            this.Controls.Add(this.dgvCalendar);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "CalendarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CalendarForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DataGridView dgvCalendar;
        private System.Windows.Forms.Button btnCalendarBack;
        private System.Windows.Forms.Label txtCalendarDesc;
    }
}