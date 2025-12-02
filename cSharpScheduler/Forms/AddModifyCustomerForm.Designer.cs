namespace cSharpScheduler
{
    partial class AddModifyCustomerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.RichTextBox();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.txtPostal = new System.Windows.Forms.RichTextBox();
            this.txtPhone = new System.Windows.Forms.RichTextBox();
            this.btnAddCustomerSave = new System.Windows.Forms.Button();
            this.btnAddCustomerCancel = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Postal Code";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(75, 245);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(91, 15);
            this.lblPhoneNumber.TabIndex = 3;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(181, 74);
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 27);
            this.txtName.TabIndex = 4;
            this.txtName.Text = "";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(181, 130);
            this.txtAddress.Multiline = false;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(207, 27);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.Text = "";
            // 
            // txtPostal
            // 
            this.txtPostal.Location = new System.Drawing.Point(181, 186);
            this.txtPostal.Multiline = false;
            this.txtPostal.Name = "txtPostal";
            this.txtPostal.Size = new System.Drawing.Size(207, 27);
            this.txtPostal.TabIndex = 6;
            this.txtPostal.Text = "";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(181, 242);
            this.txtPhone.Multiline = false;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(207, 27);
            this.txtPhone.TabIndex = 7;
            this.txtPhone.Text = "";
            // 
            // btnAddCustomerSave
            // 
            this.btnAddCustomerSave.Location = new System.Drawing.Point(91, 314);
            this.btnAddCustomerSave.Name = "btnAddCustomerSave";
            this.btnAddCustomerSave.Size = new System.Drawing.Size(158, 41);
            this.btnAddCustomerSave.TabIndex = 8;
            this.btnAddCustomerSave.Text = "Save";
            this.btnAddCustomerSave.UseVisualStyleBackColor = true;
            this.btnAddCustomerSave.Click += new System.EventHandler(this.btnAddCustomerSave_Click);
            // 
            // btnAddCustomerCancel
            // 
            this.btnAddCustomerCancel.Location = new System.Drawing.Point(287, 314);
            this.btnAddCustomerCancel.Name = "btnAddCustomerCancel";
            this.btnAddCustomerCancel.Size = new System.Drawing.Size(158, 41);
            this.btnAddCustomerCancel.TabIndex = 9;
            this.btnAddCustomerCancel.Text = "Cancel";
            this.btnAddCustomerCancel.UseVisualStyleBackColor = true;
            this.btnAddCustomerCancel.Click += new System.EventHandler(this.btnAddCustomerCancel_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 9);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(84, 15);
            this.lblCustomer.TabIndex = 10;
            this.lblCustomer.Text = "Add Customer";
            // 
            // AddModifyCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 396);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnAddCustomerCancel);
            this.Controls.Add(this.btnAddCustomerSave);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtPostal);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddModifyCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.RichTextBox txtName;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.RichTextBox txtPostal;
        private System.Windows.Forms.RichTextBox txtPhone;
        private System.Windows.Forms.Button btnAddCustomerSave;
        private System.Windows.Forms.Button btnAddCustomerCancel;
        private System.Windows.Forms.Label lblCustomer;
    }
}