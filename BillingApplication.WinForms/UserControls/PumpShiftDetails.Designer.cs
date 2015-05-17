using BillingApplication.WinForms.BillingServices;
namespace BillingApplication.WinForms.UserControls
{
    partial class PumpShiftDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPumpName = new System.Windows.Forms.Label();
            this.txtOpeningReading = new System.Windows.Forms.TextBox();
            this.txtClosingReading = new System.Windows.Forms.TextBox();
            this.txtTesting = new System.Windows.Forms.TextBox();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.ddlNextEmployee = new System.Windows.Forms.ComboBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPumpName
            // 
            this.lblPumpName.AutoSize = true;
            this.lblPumpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPumpName.Location = new System.Drawing.Point(3, 9);
            this.lblPumpName.Name = "lblPumpName";
            this.lblPumpName.Size = new System.Drawing.Size(59, 16);
            this.lblPumpName.TabIndex = 1;
            this.lblPumpName.Text = "Label 1";
            // 
            // txtOpeningReading
            // 
            this.txtOpeningReading.Location = new System.Drawing.Point(231, 9);
            this.txtOpeningReading.Name = "txtOpeningReading";
            this.txtOpeningReading.ReadOnly = true;
            this.txtOpeningReading.Size = new System.Drawing.Size(98, 20);
            this.txtOpeningReading.TabIndex = 4;
            this.txtOpeningReading.TabStop = false;
            this.txtOpeningReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtClosingReading
            // 
            this.txtClosingReading.Location = new System.Drawing.Point(350, 9);
            this.txtClosingReading.Name = "txtClosingReading";
            this.txtClosingReading.Size = new System.Drawing.Size(89, 20);
            this.txtClosingReading.TabIndex = 5;
            this.txtClosingReading.Text = "0.00";
            this.txtClosingReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTesting
            // 
            this.txtTesting.Location = new System.Drawing.Point(464, 9);
            this.txtTesting.Name = "txtTesting";
            this.txtTesting.Size = new System.Drawing.Size(101, 20);
            this.txtTesting.TabIndex = 7;
            this.txtTesting.Text = "0.00";
            this.txtTesting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSales
            // 
            this.txtSales.Location = new System.Drawing.Point(591, 9);
            this.txtSales.Name = "txtSales";
            this.txtSales.ReadOnly = true;
            this.txtSales.Size = new System.Drawing.Size(98, 20);
            this.txtSales.TabIndex = 9;
            this.txtSales.TabStop = false;
            this.txtSales.Text = "0.00";
            this.txtSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ddlNextEmployee
            // 
            this.ddlNextEmployee.FormattingEnabled = true;
            this.ddlNextEmployee.Location = new System.Drawing.Point(967, 8);
            this.ddlNextEmployee.Name = "ddlNextEmployee";
            this.ddlNextEmployee.Size = new System.Drawing.Size(121, 21);
            this.ddlNextEmployee.TabIndex = 12;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(728, 9);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(100, 20);
            this.txtRate.TabIndex = 11;
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.Leave += new System.EventHandler(this.txtRate_Leave);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(847, 8);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.TabStop = false;
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // PumpShiftDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.ddlNextEmployee);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.txtTesting);
            this.Controls.Add(this.txtClosingReading);
            this.Controls.Add(this.txtOpeningReading);
            this.Controls.Add(this.lblPumpName);
            this.Name = "PumpShiftDetails";
            this.Size = new System.Drawing.Size(1100, 41);
            this.Load += new System.EventHandler(this.PumpShiftDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label lblPumpName;
        private System.Windows.Forms.TextBox txtOpeningReading;
        private System.Windows.Forms.TextBox txtClosingReading;
        private System.Windows.Forms.TextBox txtTesting;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.ComboBox ddlNextEmployee;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.TextBox txtAmount;
    }
}
