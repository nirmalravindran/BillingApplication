namespace BillingApplication.WinForms
{
    partial class AddPump
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
            this.lblAddPump = new System.Windows.Forms.Label();
            this.lblPumpName = new System.Windows.Forms.Label();
            this.txtPumpName = new System.Windows.Forms.TextBox();
            this.txtOpeningReading = new System.Windows.Forms.TextBox();
            this.lblOpeningReading = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblLime = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddPump
            // 
            this.lblAddPump.AutoSize = true;
            this.lblAddPump.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddPump.Location = new System.Drawing.Point(12, 9);
            this.lblAddPump.Name = "lblAddPump";
            this.lblAddPump.Size = new System.Drawing.Size(158, 20);
            this.lblAddPump.TabIndex = 0;
            this.lblAddPump.Text = "Add Pump/Product";
            // 
            // lblPumpName
            // 
            this.lblPumpName.AutoSize = true;
            this.lblPumpName.Location = new System.Drawing.Point(13, 54);
            this.lblPumpName.Name = "lblPumpName";
            this.lblPumpName.Size = new System.Drawing.Size(107, 13);
            this.lblPumpName.TabIndex = 1;
            this.lblPumpName.Text = "Pump/Product Name";
            // 
            // txtPumpName
            // 
            this.txtPumpName.Location = new System.Drawing.Point(126, 51);
            this.txtPumpName.Name = "txtPumpName";
            this.txtPumpName.Size = new System.Drawing.Size(154, 20);
            this.txtPumpName.TabIndex = 2;
            // 
            // txtOpeningReading
            // 
            this.txtOpeningReading.Location = new System.Drawing.Point(126, 94);
            this.txtOpeningReading.Name = "txtOpeningReading";
            this.txtOpeningReading.Size = new System.Drawing.Size(154, 20);
            this.txtOpeningReading.TabIndex = 4;
            // 
            // lblOpeningReading
            // 
            this.lblOpeningReading.AutoSize = true;
            this.lblOpeningReading.Location = new System.Drawing.Point(12, 97);
            this.lblOpeningReading.Name = "lblOpeningReading";
            this.lblOpeningReading.Size = new System.Drawing.Size(90, 13);
            this.lblOpeningReading.TabIndex = 3;
            this.lblOpeningReading.Text = "Opening Reading";
            // 
            // txtRate
            // 
            this.txtRate.AcceptsReturn = true;
            this.txtRate.Location = new System.Drawing.Point(126, 142);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(154, 20);
            this.txtRate.TabIndex = 6;
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(13, 145);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(30, 13);
            this.lblRate.TabIndex = 5;
            this.lblRate.Text = "Rate";
            // 
            // lblLime
            // 
            this.lblLime.AutoSize = true;
            this.lblLime.Location = new System.Drawing.Point(2, 29);
            this.lblLime.Name = "lblLime";
            this.lblLime.Size = new System.Drawing.Size(295, 13);
            this.lblLime.TabIndex = 7;
            this.lblLime.Text = "---------------------------------------------------------------------------------" +
                "---------------";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(126, 178);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(207, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddPump
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 217);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblLime);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.txtOpeningReading);
            this.Controls.Add(this.lblOpeningReading);
            this.Controls.Add(this.txtPumpName);
            this.Controls.Add(this.lblPumpName);
            this.Controls.Add(this.lblAddPump);
            this.Name = "AddPump";
            this.Text = "Add a new Pump / Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddPump;
        private System.Windows.Forms.Label lblPumpName;
        private System.Windows.Forms.TextBox txtPumpName;
        private System.Windows.Forms.TextBox txtOpeningReading;
        private System.Windows.Forms.Label lblOpeningReading;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblLime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
    }
}