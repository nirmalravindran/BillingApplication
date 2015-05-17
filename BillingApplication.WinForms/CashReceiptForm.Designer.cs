namespace BillingApplication.WinForms
{
    partial class CashReceiptForm
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
            this.lblCashier = new System.Windows.Forms.Label();
            this.ddlCashier = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lblNaration = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCashier
            // 
            this.lblCashier.AutoSize = true;
            this.lblCashier.Location = new System.Drawing.Point(70, 39);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(42, 13);
            this.lblCashier.TabIndex = 4;
            this.lblCashier.Text = "Cashier";
            // 
            // ddlCashier
            // 
            this.ddlCashier.FormattingEnabled = true;
            this.ddlCashier.Location = new System.Drawing.Point(138, 39);
            this.ddlCashier.Name = "ddlCashier";
            this.ddlCashier.Size = new System.Drawing.Size(194, 21);
            this.ddlCashier.TabIndex = 1;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(70, 114);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(138, 114);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(118, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNaration
            // 
            this.lblNaration.AutoSize = true;
            this.lblNaration.Location = new System.Drawing.Point(70, 79);
            this.lblNaration.Name = "lblNaration";
            this.lblNaration.Size = new System.Drawing.Size(30, 13);
            this.lblNaration.TabIndex = 8;
            this.lblNaration.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(138, 76);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(194, 20);
            this.txtNote.TabIndex = 2;
            this.txtNote.Text = "Cash";
            // 
            // CashReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 193);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNaration);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblCashier);
            this.Controls.Add(this.ddlCashier);
            this.Name = "CashReceiptForm";
            this.Text = "Cash Receipt Form";
            this.Load += new System.EventHandler(this.CashReceiptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.ComboBox ddlCashier;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblNaration;
        private System.Windows.Forms.TextBox txtNote;
    }
}