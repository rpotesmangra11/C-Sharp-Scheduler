namespace cSharpScheduler
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.dgvAppts = new System.Windows.Forms.DataGridView();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnModCustomer = new System.Windows.Forms.Button();
            this.btnDelCustomer = new System.Windows.Forms.Button();
            this.btnDeleteAppt = new System.Windows.Forms.Button();
            this.btnModAppt = new System.Windows.Forms.Button();
            this.btnAddAppt = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeColumns = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(146, 92);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.Size = new System.Drawing.Size(714, 471);
            this.dgvCustomers.TabIndex = 0;
            // 
            // dgvAppts
            // 
            this.dgvAppts.AllowUserToAddRows = false;
            this.dgvAppts.AllowUserToDeleteRows = false;
            this.dgvAppts.AllowUserToResizeColumns = false;
            this.dgvAppts.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAppts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppts.Location = new System.Drawing.Point(914, 92);
            this.dgvAppts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvAppts.Name = "dgvAppts";
            this.dgvAppts.RowHeadersWidth = 51;
            this.dgvAppts.Size = new System.Drawing.Size(714, 471);
            this.dgvAppts.TabIndex = 1;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(245, 590);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(364, 125);
            this.btnAddCustomer.TabIndex = 2;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnModCustomer
            // 
            this.btnModCustomer.Location = new System.Drawing.Point(245, 730);
            this.btnModCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModCustomer.Name = "btnModCustomer";
            this.btnModCustomer.Size = new System.Drawing.Size(364, 125);
            this.btnModCustomer.TabIndex = 3;
            this.btnModCustomer.Text = "Modify Customer";
            this.btnModCustomer.UseVisualStyleBackColor = true;
            this.btnModCustomer.Click += new System.EventHandler(this.btnModCustomer_Click);
            // 
            // btnDelCustomer
            // 
            this.btnDelCustomer.Location = new System.Drawing.Point(245, 870);
            this.btnDelCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelCustomer.Name = "btnDelCustomer";
            this.btnDelCustomer.Size = new System.Drawing.Size(364, 125);
            this.btnDelCustomer.TabIndex = 4;
            this.btnDelCustomer.Text = "Delete Customer";
            this.btnDelCustomer.UseVisualStyleBackColor = true;
            this.btnDelCustomer.Click += new System.EventHandler(this.btnDelCustomer_Click);
            // 
            // btnDeleteAppt
            // 
            this.btnDeleteAppt.Location = new System.Drawing.Point(1164, 870);
            this.btnDeleteAppt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteAppt.Name = "btnDeleteAppt";
            this.btnDeleteAppt.Size = new System.Drawing.Size(364, 125);
            this.btnDeleteAppt.TabIndex = 7;
            this.btnDeleteAppt.Text = "Delete Appointment";
            this.btnDeleteAppt.UseVisualStyleBackColor = true;
            this.btnDeleteAppt.Click += new System.EventHandler(this.btnDeleteAppt_Click);
            // 
            // btnModAppt
            // 
            this.btnModAppt.Location = new System.Drawing.Point(1164, 730);
            this.btnModAppt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModAppt.Name = "btnModAppt";
            this.btnModAppt.Size = new System.Drawing.Size(364, 125);
            this.btnModAppt.TabIndex = 6;
            this.btnModAppt.Text = "Modify Appointment";
            this.btnModAppt.UseVisualStyleBackColor = true;
            this.btnModAppt.Click += new System.EventHandler(this.btnModAppt_Click);
            // 
            // btnAddAppt
            // 
            this.btnAddAppt.Location = new System.Drawing.Point(1164, 590);
            this.btnAddAppt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddAppt.Name = "btnAddAppt";
            this.btnAddAppt.Size = new System.Drawing.Size(364, 125);
            this.btnAddAppt.TabIndex = 5;
            this.btnAddAppt.Text = "Add Appointment";
            this.btnAddAppt.UseVisualStyleBackColor = true;
            this.btnAddAppt.Click += new System.EventHandler(this.btnAddAppt_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.Location = new System.Drawing.Point(705, 656);
            this.btnCalendar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(364, 125);
            this.btnCalendar.TabIndex = 8;
            this.btnCalendar.Text = "Calendar";
            this.btnCalendar.UseVisualStyleBackColor = true;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(705, 790);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(364, 125);
            this.btnReports.TabIndex = 9;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1558, 972);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(201, 80);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1774, 1069);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnCalendar);
            this.Controls.Add(this.btnDeleteAppt);
            this.Controls.Add(this.btnModAppt);
            this.Controls.Add(this.btnAddAppt);
            this.Controls.Add(this.btnDelCustomer);
            this.Controls.Add(this.btnModCustomer);
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.dgvAppts);
            this.Controls.Add(this.dgvCustomers);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduler";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridView dgvAppts;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnModCustomer;
        private System.Windows.Forms.Button btnDelCustomer;
        private System.Windows.Forms.Button btnDeleteAppt;
        private System.Windows.Forms.Button btnModAppt;
        private System.Windows.Forms.Button btnAddAppt;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnExit;
    }
}

