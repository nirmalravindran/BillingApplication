namespace BillingApplication.WinForms
{
    partial class CashPaid
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
            this.grdCashReceipt = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCashReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCashReceipt
            // 
            this.grdCashReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCashReceipt.Location = new System.Drawing.Point(35, 40);
            this.grdCashReceipt.Name = "grdCashReceipt";
            this.grdCashReceipt.Size = new System.Drawing.Size(409, 206);
            this.grdCashReceipt.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(192, 278);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CashPaid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 326);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdCashReceipt);
            this.Name = "CashPaid";
            this.Text = "CashPaid";
            this.Load += new System.EventHandler(this.CashPaid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCashReceipt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCashReceipt;
        private System.Windows.Forms.Button btnClose;
    }
}