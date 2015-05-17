namespace BillingApplication.WinForms
{
    partial class CheckBills
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
            this.btnShowBills = new System.Windows.Forms.Button();
            this.ddlCashier = new System.Windows.Forms.ComboBox();
            this.lblCashier = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnShowBills
            // 
            this.btnShowBills.Location = new System.Drawing.Point(108, 95);
            this.btnShowBills.Name = "btnShowBills";
            this.btnShowBills.Size = new System.Drawing.Size(75, 23);
            this.btnShowBills.TabIndex = 0;
            this.btnShowBills.Text = "Show Bills";
            this.btnShowBills.UseVisualStyleBackColor = true;
            this.btnShowBills.Click += new System.EventHandler(this.btnShowBills_Click);
            // 
            // ddlCashier
            // 
            this.ddlCashier.FormattingEnabled = true;
            this.ddlCashier.Location = new System.Drawing.Point(81, 30);
            this.ddlCashier.Name = "ddlCashier";
            this.ddlCashier.Size = new System.Drawing.Size(194, 21);
            this.ddlCashier.TabIndex = 1;
            // 
            // lblCashier
            // 
            this.lblCashier.AutoSize = true;
            this.lblCashier.Location = new System.Drawing.Point(13, 30);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(42, 13);
            this.lblCashier.TabIndex = 2;
            this.lblCashier.Text = "Cashier";
            // 
            // CheckBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 130);
            this.Controls.Add(this.lblCashier);
            this.Controls.Add(this.ddlCashier);
            this.Controls.Add(this.btnShowBills);
            this.MinimizeBox = false;
            this.Name = "CheckBills";
            this.Text = "CheckBills";
            this.Load += new System.EventHandler(this.CheckBills_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowBills;
        private System.Windows.Forms.ComboBox ddlCashier;
        private System.Windows.Forms.Label lblCashier;
    }
}