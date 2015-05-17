namespace BillingApplication.WinForms.UserControls
{
    partial class ProductDip
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
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.txtDifference = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(4, 4);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(100, 20);
            this.txtProduct.TabIndex = 0;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(110, 4);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(75, 20);
            this.txtStock.TabIndex = 1;
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSales
            // 
            this.txtSales.Location = new System.Drawing.Point(191, 4);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(75, 20);
            this.txtSales.TabIndex = 2;
            this.txtSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDifference
            // 
            this.txtDifference.Location = new System.Drawing.Point(272, 4);
            this.txtDifference.Name = "txtDifference";
            this.txtDifference.Size = new System.Drawing.Size(75, 20);
            this.txtDifference.TabIndex = 3;
            this.txtDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ProductDip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.txtDifference);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtProduct);
            this.Name = "ProductDip";
            this.Size = new System.Drawing.Size(359, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.TextBox txtDifference;
    }
}
