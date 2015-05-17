namespace BillingApplication.WinForms.UserControls
{
    partial class TankDip
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
            this.txtTankName = new System.Windows.Forms.TextBox();
            this.txtTankDip = new System.Windows.Forms.TextBox();
            this.txtTankVolume = new System.Windows.Forms.TextBox();
            this.txtTankReceipt = new System.Windows.Forms.TextBox();
            this.txtTankSales = new System.Windows.Forms.TextBox();
            this.txtTankDifference = new System.Windows.Forms.TextBox();
            this.txtPrevVolume = new System.Windows.Forms.TextBox();
            this.txtWaterDip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTankName
            // 
            this.txtTankName.Location = new System.Drawing.Point(3, 3);
            this.txtTankName.Name = "txtTankName";
            this.txtTankName.ReadOnly = true;
            this.txtTankName.Size = new System.Drawing.Size(125, 20);
            this.txtTankName.TabIndex = 0;
            this.txtTankName.TabStop = false;
            // 
            // txtTankDip
            // 
            this.txtTankDip.Location = new System.Drawing.Point(134, 3);
            this.txtTankDip.Name = "txtTankDip";
            this.txtTankDip.Size = new System.Drawing.Size(50, 20);
            this.txtTankDip.TabIndex = 1;
            this.txtTankDip.Text = "0";
            this.txtTankDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTankDip.Leave += new System.EventHandler(this.txtTankDip_Leave);
            // 
            // txtTankVolume
            // 
            this.txtTankVolume.Location = new System.Drawing.Point(246, 3);
            this.txtTankVolume.Name = "txtTankVolume";
            this.txtTankVolume.ReadOnly = true;
            this.txtTankVolume.Size = new System.Drawing.Size(75, 20);
            this.txtTankVolume.TabIndex = 2;
            this.txtTankVolume.TabStop = false;
            this.txtTankVolume.Text = "0";
            this.txtTankVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTankVolume.TextChanged += new System.EventHandler(this.txtTankVolume_TextChanged);
            // 
            // txtTankReceipt
            // 
            this.txtTankReceipt.Location = new System.Drawing.Point(408, 3);
            this.txtTankReceipt.Name = "txtTankReceipt";
            this.txtTankReceipt.ReadOnly = true;
            this.txtTankReceipt.Size = new System.Drawing.Size(75, 20);
            this.txtTankReceipt.TabIndex = 3;
            this.txtTankReceipt.TabStop = false;
            this.txtTankReceipt.Text = "0";
            this.txtTankReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTankSales
            // 
            this.txtTankSales.Location = new System.Drawing.Point(489, 3);
            this.txtTankSales.Name = "txtTankSales";
            this.txtTankSales.ReadOnly = true;
            this.txtTankSales.Size = new System.Drawing.Size(75, 20);
            this.txtTankSales.TabIndex = 4;
            this.txtTankSales.TabStop = false;
            this.txtTankSales.Text = "0";
            this.txtTankSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTankDifference
            // 
            this.txtTankDifference.Location = new System.Drawing.Point(570, 3);
            this.txtTankDifference.Name = "txtTankDifference";
            this.txtTankDifference.ReadOnly = true;
            this.txtTankDifference.Size = new System.Drawing.Size(50, 20);
            this.txtTankDifference.TabIndex = 5;
            this.txtTankDifference.TabStop = false;
            this.txtTankDifference.Text = "0";
            this.txtTankDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrevVolume
            // 
            this.txtPrevVolume.Location = new System.Drawing.Point(327, 3);
            this.txtPrevVolume.Name = "txtPrevVolume";
            this.txtPrevVolume.ReadOnly = true;
            this.txtPrevVolume.Size = new System.Drawing.Size(75, 20);
            this.txtPrevVolume.TabIndex = 6;
            this.txtPrevVolume.TabStop = false;
            this.txtPrevVolume.Text = "0";
            this.txtPrevVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWaterDip
            // 
            this.txtWaterDip.Location = new System.Drawing.Point(190, 3);
            this.txtWaterDip.Name = "txtWaterDip";
            this.txtWaterDip.Size = new System.Drawing.Size(50, 20);
            this.txtWaterDip.TabIndex = 7;
            this.txtWaterDip.Text = "0";
            this.txtWaterDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWaterDip.Leave += new System.EventHandler(this.txtWaterDip_Leave);
            // 
            // TankDip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.txtWaterDip);
            this.Controls.Add(this.txtPrevVolume);
            this.Controls.Add(this.txtTankDifference);
            this.Controls.Add(this.txtTankSales);
            this.Controls.Add(this.txtTankReceipt);
            this.Controls.Add(this.txtTankVolume);
            this.Controls.Add(this.txtTankDip);
            this.Controls.Add(this.txtTankName);
            this.Name = "TankDip";
            this.Size = new System.Drawing.Size(633, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTankName;
        private System.Windows.Forms.TextBox txtTankDip;
        private System.Windows.Forms.TextBox txtTankVolume;
        private System.Windows.Forms.TextBox txtTankReceipt;
        private System.Windows.Forms.TextBox txtTankSales;
        private System.Windows.Forms.TextBox txtTankDifference;
        private System.Windows.Forms.TextBox txtPrevVolume;
        private System.Windows.Forms.TextBox txtWaterDip;
    }
}
