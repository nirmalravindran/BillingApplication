namespace BillingApplication.WinForms
{
    partial class ShiftSummary
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
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.grdBills = new System.Windows.Forms.DataGridView();
            this.lblCreditTotal = new System.Windows.Forms.Label();
            this.txtTotalCreditSales = new System.Windows.Forms.TextBox();
            this.lblSalesAmount = new System.Windows.Forms.Label();
            this.txtTotalSalesAmount = new System.Windows.Forms.TextBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.txtCashPaid = new System.Windows.Forms.TextBox();
            this.lblShortageOrExcess = new System.Windows.Forms.Label();
            this.txtShortageOrExcess = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.btnRemoveBill = new System.Windows.Forms.Button();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.grdExpences = new System.Windows.Forms.DataGridView();
            this.txtTotalExpences = new System.Windows.Forms.TextBox();
            this.lblTotalExpences = new System.Windows.Forms.Label();
            this.lblExpences = new System.Windows.Forms.Label();
            this.btnAddCash = new System.Windows.Forms.Button();
            this.btnCashPaid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdBills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExpences)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(13, 36);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(51, 16);
            this.lblEmployeeName.TabIndex = 0;
            this.lblEmployeeName.Text = "label1";
            // 
            // grdBills
            // 
            this.grdBills.AllowUserToAddRows = false;
            this.grdBills.AllowUserToDeleteRows = false;
            this.grdBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBills.Location = new System.Drawing.Point(16, 67);
            this.grdBills.Name = "grdBills";
            this.grdBills.ReadOnly = true;
            this.grdBills.Size = new System.Drawing.Size(499, 126);
            this.grdBills.TabIndex = 1;
            this.grdBills.TabStop = false;
            // 
            // lblCreditTotal
            // 
            this.lblCreditTotal.AutoSize = true;
            this.lblCreditTotal.Location = new System.Drawing.Point(133, 205);
            this.lblCreditTotal.Name = "lblCreditTotal";
            this.lblCreditTotal.Size = new System.Drawing.Size(90, 13);
            this.lblCreditTotal.TabIndex = 2;
            this.lblCreditTotal.Text = "Total Credit Sales";
            // 
            // txtTotalCreditSales
            // 
            this.txtTotalCreditSales.Location = new System.Drawing.Point(245, 202);
            this.txtTotalCreditSales.Name = "txtTotalCreditSales";
            this.txtTotalCreditSales.ReadOnly = true;
            this.txtTotalCreditSales.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCreditSales.TabIndex = 3;
            this.txtTotalCreditSales.TabStop = false;
            this.txtTotalCreditSales.Text = "0.00";
            this.txtTotalCreditSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSalesAmount
            // 
            this.lblSalesAmount.AutoSize = true;
            this.lblSalesAmount.Location = new System.Drawing.Point(24, 406);
            this.lblSalesAmount.Name = "lblSalesAmount";
            this.lblSalesAmount.Size = new System.Drawing.Size(99, 13);
            this.lblSalesAmount.TabIndex = 4;
            this.lblSalesAmount.Text = "Total Sales Amount";
            // 
            // txtTotalSalesAmount
            // 
            this.txtTotalSalesAmount.Location = new System.Drawing.Point(136, 403);
            this.txtTotalSalesAmount.Name = "txtTotalSalesAmount";
            this.txtTotalSalesAmount.ReadOnly = true;
            this.txtTotalSalesAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalSalesAmount.TabIndex = 5;
            this.txtTotalSalesAmount.TabStop = false;
            this.txtTotalSalesAmount.Text = "0.00";
            this.txtTotalSalesAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Location = new System.Drawing.Point(24, 439);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(55, 13);
            this.lblCash.TabIndex = 6;
            this.lblCash.Text = "Cash Paid";
            // 
            // txtCashPaid
            // 
            this.txtCashPaid.Location = new System.Drawing.Point(135, 436);
            this.txtCashPaid.Name = "txtCashPaid";
            this.txtCashPaid.ReadOnly = true;
            this.txtCashPaid.Size = new System.Drawing.Size(100, 20);
            this.txtCashPaid.TabIndex = 7;
            this.txtCashPaid.Text = "0.00";
            this.txtCashPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashPaid.TextChanged += new System.EventHandler(this.txtCashPaid_TextChanged);
            // 
            // lblShortageOrExcess
            // 
            this.lblShortageOrExcess.AutoSize = true;
            this.lblShortageOrExcess.Location = new System.Drawing.Point(24, 471);
            this.lblShortageOrExcess.Name = "lblShortageOrExcess";
            this.lblShortageOrExcess.Size = new System.Drawing.Size(89, 13);
            this.lblShortageOrExcess.TabIndex = 8;
            this.lblShortageOrExcess.Text = "Shortage/Excess";
            // 
            // txtShortageOrExcess
            // 
            this.txtShortageOrExcess.Location = new System.Drawing.Point(135, 468);
            this.txtShortageOrExcess.Name = "txtShortageOrExcess";
            this.txtShortageOrExcess.ReadOnly = true;
            this.txtShortageOrExcess.Size = new System.Drawing.Size(100, 20);
            this.txtShortageOrExcess.TabIndex = 9;
            this.txtShortageOrExcess.TabStop = false;
            this.txtShortageOrExcess.Text = "0.00";
            this.txtShortageOrExcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(444, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddBill
            // 
            this.btnAddBill.Location = new System.Drawing.Point(413, 8);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(75, 23);
            this.btnAddBill.TabIndex = 12;
            this.btnAddBill.Text = "&Add Bill";
            this.btnAddBill.UseVisualStyleBackColor = true;
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click);
            // 
            // btnRemoveBill
            // 
            this.btnRemoveBill.Location = new System.Drawing.Point(413, 37);
            this.btnRemoveBill.Name = "btnRemoveBill";
            this.btnRemoveBill.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveBill.TabIndex = 13;
            this.btnRemoveBill.Text = "&Remove Bill";
            this.btnRemoveBill.UseVisualStyleBackColor = true;
            this.btnRemoveBill.Click += new System.EventHandler(this.btnRemoveBill_Click);
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(293, 23);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(100, 20);
            this.txtBillNo.TabIndex = 14;
            // 
            // grdExpences
            // 
            this.grdExpences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExpences.Location = new System.Drawing.Point(16, 228);
            this.grdExpences.Name = "grdExpences";
            this.grdExpences.Size = new System.Drawing.Size(499, 122);
            this.grdExpences.TabIndex = 15;
            this.grdExpences.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdExpences_CellEndEdit);
            // 
            // txtTotalExpences
            // 
            this.txtTotalExpences.Location = new System.Drawing.Point(245, 361);
            this.txtTotalExpences.Name = "txtTotalExpences";
            this.txtTotalExpences.ReadOnly = true;
            this.txtTotalExpences.Size = new System.Drawing.Size(100, 20);
            this.txtTotalExpences.TabIndex = 17;
            this.txtTotalExpences.TabStop = false;
            this.txtTotalExpences.Text = "0.00";
            this.txtTotalExpences.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalExpences
            // 
            this.lblTotalExpences.AutoSize = true;
            this.lblTotalExpences.Location = new System.Drawing.Point(133, 364);
            this.lblTotalExpences.Name = "lblTotalExpences";
            this.lblTotalExpences.Size = new System.Drawing.Size(81, 13);
            this.lblTotalExpences.TabIndex = 16;
            this.lblTotalExpences.Text = "Total Expences";
            // 
            // lblExpences
            // 
            this.lblExpences.AutoSize = true;
            this.lblExpences.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpences.Location = new System.Drawing.Point(13, 205);
            this.lblExpences.Name = "lblExpences";
            this.lblExpences.Size = new System.Drawing.Size(76, 16);
            this.lblExpences.TabIndex = 18;
            this.lblExpences.Text = "Expences";
            // 
            // btnAddCash
            // 
            this.btnAddCash.Location = new System.Drawing.Point(245, 434);
            this.btnAddCash.Name = "btnAddCash";
            this.btnAddCash.Size = new System.Drawing.Size(75, 23);
            this.btnAddCash.TabIndex = 19;
            this.btnAddCash.Text = "Add Cash";
            this.btnAddCash.UseVisualStyleBackColor = true;
            this.btnAddCash.Click += new System.EventHandler(this.btnAddCash_Click);
            // 
            // btnCashPaid
            // 
            this.btnCashPaid.Location = new System.Drawing.Point(326, 434);
            this.btnCashPaid.Name = "btnCashPaid";
            this.btnCashPaid.Size = new System.Drawing.Size(104, 23);
            this.btnCashPaid.TabIndex = 20;
            this.btnCashPaid.Text = "View Cash Paid";
            this.btnCashPaid.UseVisualStyleBackColor = true;
            this.btnCashPaid.Click += new System.EventHandler(this.btnCashPaid_Click);
            // 
            // ShiftSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 543);
            this.Controls.Add(this.btnCashPaid);
            this.Controls.Add(this.btnAddCash);
            this.Controls.Add(this.lblExpences);
            this.Controls.Add(this.txtTotalExpences);
            this.Controls.Add(this.lblTotalExpences);
            this.Controls.Add(this.grdExpences);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.btnRemoveBill);
            this.Controls.Add(this.btnAddBill);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtShortageOrExcess);
            this.Controls.Add(this.lblShortageOrExcess);
            this.Controls.Add(this.txtCashPaid);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.txtTotalSalesAmount);
            this.Controls.Add(this.lblSalesAmount);
            this.Controls.Add(this.txtTotalCreditSales);
            this.Controls.Add(this.lblCreditTotal);
            this.Controls.Add(this.grdBills);
            this.Controls.Add(this.lblEmployeeName);
            this.Name = "ShiftSummary";
            this.Text = "Shift Summary";
            this.Load += new System.EventHandler(this.ShiftSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExpences)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.DataGridView grdBills;
        private System.Windows.Forms.Label lblCreditTotal;
        private System.Windows.Forms.TextBox txtTotalCreditSales;
        private System.Windows.Forms.Label lblSalesAmount;
        private System.Windows.Forms.TextBox txtTotalSalesAmount;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.TextBox txtCashPaid;
        private System.Windows.Forms.Label lblShortageOrExcess;
        private System.Windows.Forms.TextBox txtShortageOrExcess;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.Button btnRemoveBill;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.DataGridView grdExpences;
        private System.Windows.Forms.TextBox txtTotalExpences;
        private System.Windows.Forms.Label lblTotalExpences;
        private System.Windows.Forms.Label lblExpences;
        private System.Windows.Forms.Button btnAddCash;
        private System.Windows.Forms.Button btnCashPaid;
    }
}