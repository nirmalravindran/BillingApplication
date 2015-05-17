namespace BillingApplication.WinForms
{
    partial class CloseShift
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
            this.ddlSelectEmployee = new System.Windows.Forms.ComboBox();
            this.lblSelectEmployee = new System.Windows.Forms.Label();
            this.pnlPumps = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNewCashier = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblSales = new System.Windows.Forms.Label();
            this.lblClosing = new System.Windows.Forms.Label();
            this.lblOpening = new System.Windows.Forms.Label();
            this.lblPumpName = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlNewCashier = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlSelectEmployee
            // 
            this.ddlSelectEmployee.FormattingEnabled = true;
            this.ddlSelectEmployee.Location = new System.Drawing.Point(180, 12);
            this.ddlSelectEmployee.Name = "ddlSelectEmployee";
            this.ddlSelectEmployee.Size = new System.Drawing.Size(121, 21);
            this.ddlSelectEmployee.TabIndex = 0;
            this.ddlSelectEmployee.SelectedIndexChanged += new System.EventHandler(this.ddlSelectEmployee_SelectedIndexChanged);
            // 
            // lblSelectEmployee
            // 
            this.lblSelectEmployee.AutoSize = true;
            this.lblSelectEmployee.Location = new System.Drawing.Point(12, 15);
            this.lblSelectEmployee.Name = "lblSelectEmployee";
            this.lblSelectEmployee.Size = new System.Drawing.Size(100, 13);
            this.lblSelectEmployee.TabIndex = 1;
            this.lblSelectEmployee.Text = "Select an employee";
            // 
            // pnlPumps
            // 
            this.pnlPumps.AutoScroll = true;
            this.pnlPumps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPumps.Location = new System.Drawing.Point(15, 70);
            this.pnlPumps.Name = "pnlPumps";
            this.pnlPumps.Size = new System.Drawing.Size(1125, 381);
            this.pnlPumps.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblNewCashier);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Controls.Add(this.lblTest);
            this.panel1.Controls.Add(this.lblRate);
            this.panel1.Controls.Add(this.lblSales);
            this.panel1.Controls.Add(this.lblClosing);
            this.panel1.Controls.Add(this.lblOpening);
            this.panel1.Controls.Add(this.lblPumpName);
            this.panel1.Location = new System.Drawing.Point(15, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 25);
            this.panel1.TabIndex = 3;
            // 
            // lblNewCashier
            // 
            this.lblNewCashier.AutoSize = true;
            this.lblNewCashier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCashier.Location = new System.Drawing.Point(985, 5);
            this.lblNewCashier.Name = "lblNewCashier";
            this.lblNewCashier.Size = new System.Drawing.Size(95, 16);
            this.lblNewCashier.TabIndex = 20;
            this.lblNewCashier.Text = "New Cashier";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(868, 5);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(59, 16);
            this.lblAmount.TabIndex = 19;
            this.lblAmount.Text = "Amount";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.Location = new System.Drawing.Point(481, 5);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(60, 16);
            this.lblTest.TabIndex = 18;
            this.lblTest.Text = "Testing";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate.Location = new System.Drawing.Point(744, 5);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(41, 16);
            this.lblRate.TabIndex = 17;
            this.lblRate.Text = "Rate";
            // 
            // lblSales
            // 
            this.lblSales.AutoSize = true;
            this.lblSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSales.Location = new System.Drawing.Point(606, 5);
            this.lblSales.Name = "lblSales";
            this.lblSales.Size = new System.Drawing.Size(48, 16);
            this.lblSales.TabIndex = 16;
            this.lblSales.Text = "Sales";
            // 
            // lblClosing
            // 
            this.lblClosing.AutoSize = true;
            this.lblClosing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClosing.Location = new System.Drawing.Point(365, 5);
            this.lblClosing.Name = "lblClosing";
            this.lblClosing.Size = new System.Drawing.Size(60, 16);
            this.lblClosing.TabIndex = 15;
            this.lblClosing.Text = "Closing";
            // 
            // lblOpening
            // 
            this.lblOpening.AutoSize = true;
            this.lblOpening.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpening.Location = new System.Drawing.Point(249, 5);
            this.lblOpening.Name = "lblOpening";
            this.lblOpening.Size = new System.Drawing.Size(66, 16);
            this.lblOpening.TabIndex = 14;
            this.lblOpening.Text = "Opening";
            // 
            // lblPumpName
            // 
            this.lblPumpName.AutoSize = true;
            this.lblPumpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPumpName.Location = new System.Drawing.Point(3, 5);
            this.lblPumpName.Name = "lblPumpName";
            this.lblPumpName.Size = new System.Drawing.Size(92, 16);
            this.lblPumpName.TabIndex = 13;
            this.lblPumpName.Text = "Pump Name";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(786, 462);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Location = new System.Drawing.Point(867, 458);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 5;
            this.txtTotal.TabStop = false;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(867, 484);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 24);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(948, 484);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlNewCashier
            // 
            this.ddlNewCashier.FormattingEnabled = true;
            this.ddlNewCashier.Location = new System.Drawing.Point(985, 12);
            this.ddlNewCashier.Name = "ddlNewCashier";
            this.ddlNewCashier.Size = new System.Drawing.Size(121, 21);
            this.ddlNewCashier.TabIndex = 1;
            this.ddlNewCashier.SelectedIndexChanged += new System.EventHandler(this.ddlNewCashier_SelectedIndexChanged);
            // 
            // CloseShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 520);
            this.Controls.Add(this.ddlNewCashier);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlPumps);
            this.Controls.Add(this.lblSelectEmployee);
            this.Controls.Add(this.ddlSelectEmployee);
            this.Name = "CloseShift";
            this.Text = "Close Shift";
            this.Load += new System.EventHandler(this.CloseShift_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlSelectEmployee;
        private System.Windows.Forms.Label lblSelectEmployee;
        private System.Windows.Forms.Panel pnlPumps;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPumpName;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblOpening;
        private System.Windows.Forms.Label lblClosing;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblSales;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblNewCashier;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlNewCashier;
    }
}