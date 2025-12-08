namespace cSharpScheduler.Forms
{
    partial class ReportsForm
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
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.btnNumApptTypes = new System.Windows.Forms.Button();
            this.btnUserSchedule = new System.Windows.Forms.Button();
            this.btnTotalMeetingsByCustomer = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReports
            // 
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(70, 35);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.RowHeadersWidth = 51;
            this.dgvReports.RowTemplate.Height = 28;
            this.dgvReports.Size = new System.Drawing.Size(660, 267);
            this.dgvReports.TabIndex = 0;
            // 
            // btnNumApptTypes
            // 
            this.btnNumApptTypes.Location = new System.Drawing.Point(100, 360);
            this.btnNumApptTypes.Name = "btnNumApptTypes";
            this.btnNumApptTypes.Size = new System.Drawing.Size(164, 65);
            this.btnNumApptTypes.TabIndex = 1;
            this.btnNumApptTypes.Text = "Number of Appointment Types By Month";
            this.btnNumApptTypes.UseVisualStyleBackColor = true;
            this.btnNumApptTypes.Click += new System.EventHandler(this.btnNumApptTypes_Click);
            // 
            // btnUserSchedule
            // 
            this.btnUserSchedule.Location = new System.Drawing.Point(318, 360);
            this.btnUserSchedule.Name = "btnUserSchedule";
            this.btnUserSchedule.Size = new System.Drawing.Size(164, 65);
            this.btnUserSchedule.TabIndex = 2;
            this.btnUserSchedule.Text = "Schedule for Each User";
            this.btnUserSchedule.UseVisualStyleBackColor = true;
            this.btnUserSchedule.Click += new System.EventHandler(this.btnUserSchedules_Click);
            // 
            // btnTotalMeetingsByCustomer
            // 
            this.btnTotalMeetingsByCustomer.Location = new System.Drawing.Point(536, 360);
            this.btnTotalMeetingsByCustomer.Name = "btnTotalMeetingsByCustomer";
            this.btnTotalMeetingsByCustomer.Size = new System.Drawing.Size(164, 65);
            this.btnTotalMeetingsByCustomer.TabIndex = 3;
            this.btnTotalMeetingsByCustomer.Text = "Total Meetings By Customer";
            this.btnTotalMeetingsByCustomer.UseVisualStyleBackColor = true;
            this.btnTotalMeetingsByCustomer.Click += new System.EventHandler(this.btnTotalMeetingsByCustomer_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(683, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 42);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnTotalMeetingsByCustomer);
            this.Controls.Add(this.btnUserSchedule);
            this.Controls.Add(this.btnNumApptTypes);
            this.Controls.Add(this.dgvReports);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Button btnNumApptTypes;
        private System.Windows.Forms.Button btnUserSchedule;
        private System.Windows.Forms.Button btnTotalMeetingsByCustomer;
        private System.Windows.Forms.Button btnClose;
    }
}