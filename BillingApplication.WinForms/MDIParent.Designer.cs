namespace BillingApplication.WinForms
{
    partial class MDIParent
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offLineBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeReadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dipEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unloadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.billingToolStripMenuItem,
            this.shiftToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.unloadingToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBillToolStripMenuItem,
            this.offLineBillToolStripMenuItem});
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.billingToolStripMenuItem.Text = "&Billing";
            // 
            // newBillToolStripMenuItem
            // 
            this.newBillToolStripMenuItem.Name = "newBillToolStripMenuItem";
            this.newBillToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newBillToolStripMenuItem.Text = "&New Bill";
            this.newBillToolStripMenuItem.Click += new System.EventHandler(this.newBillToolStripMenuItem_Click);
            // 
            // offLineBillToolStripMenuItem
            // 
            this.offLineBillToolStripMenuItem.Name = "offLineBillToolStripMenuItem";
            this.offLineBillToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.offLineBillToolStripMenuItem.Text = "&Off Line Bill";
            this.offLineBillToolStripMenuItem.Click += new System.EventHandler(this.offLineBillToolStripMenuItem_Click);
            // 
            // shiftToolStripMenuItem
            // 
            this.shiftToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeReadingToolStripMenuItem,
            this.addProductsToolStripMenuItem,
            this.checkBillsToolStripMenuItem,
            this.cashReceiptToolStripMenuItem,
            this.dipEntryToolStripMenuItem});
            this.shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
            this.shiftToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.shiftToolStripMenuItem.Text = "&Shift";
            // 
            // closeReadingToolStripMenuItem
            // 
            this.closeReadingToolStripMenuItem.Name = "closeReadingToolStripMenuItem";
            this.closeReadingToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.closeReadingToolStripMenuItem.Text = "Shift &Close";
            this.closeReadingToolStripMenuItem.Click += new System.EventHandler(this.closeReadingToolStripMenuItem_Click);
            // 
            // addProductsToolStripMenuItem
            // 
            this.addProductsToolStripMenuItem.Name = "addProductsToolStripMenuItem";
            this.addProductsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addProductsToolStripMenuItem.Text = "Add Products";
            this.addProductsToolStripMenuItem.Click += new System.EventHandler(this.addProductsToolStripMenuItem_Click);
            // 
            // checkBillsToolStripMenuItem
            // 
            this.checkBillsToolStripMenuItem.Name = "checkBillsToolStripMenuItem";
            this.checkBillsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.checkBillsToolStripMenuItem.Text = "Check Bills";
            this.checkBillsToolStripMenuItem.Click += new System.EventHandler(this.checkBillsToolStripMenuItem_Click);
            // 
            // cashReceiptToolStripMenuItem
            // 
            this.cashReceiptToolStripMenuItem.Name = "cashReceiptToolStripMenuItem";
            this.cashReceiptToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.cashReceiptToolStripMenuItem.Text = "Cash Receipt";
            this.cashReceiptToolStripMenuItem.Click += new System.EventHandler(this.cashReceiptToolStripMenuItem_Click);
            // 
            // dipEntryToolStripMenuItem
            // 
            this.dipEntryToolStripMenuItem.Name = "dipEntryToolStripMenuItem";
            this.dipEntryToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.dipEntryToolStripMenuItem.Text = "Dip Entry";
            this.dipEntryToolStripMenuItem.Click += new System.EventHandler(this.dipEntryToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProductToolStripMenuItem,
            this.changePriceToolStripMenuItem});
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // addProductToolStripMenuItem
            // 
            this.addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            this.addProductToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addProductToolStripMenuItem.Text = "Add New Product";
            this.addProductToolStripMenuItem.Click += new System.EventHandler(this.addProductToolStripMenuItem_Click);
            // 
            // changePriceToolStripMenuItem
            // 
            this.changePriceToolStripMenuItem.Name = "changePriceToolStripMenuItem";
            this.changePriceToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePriceToolStripMenuItem.Text = "Change Price";
            this.changePriceToolStripMenuItem.Click += new System.EventHandler(this.changePriceToolStripMenuItem_Click);
            // 
            // unloadingToolStripMenuItem
            // 
            this.unloadingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleTagToolStripMenuItem});
            this.unloadingToolStripMenuItem.Name = "unloadingToolStripMenuItem";
            this.unloadingToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.unloadingToolStripMenuItem.Text = "Unloading ";
            // 
            // sampleTagToolStripMenuItem
            // 
            this.sampleTagToolStripMenuItem.Name = "sampleTagToolStripMenuItem";
            this.sampleTagToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.sampleTagToolStripMenuItem.Text = "Sample Tag";
            this.sampleTagToolStripMenuItem.Click += new System.EventHandler(this.sampleTagToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent";
            this.Text = "Petroleum Retail Outlet Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem billingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeReadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addProductsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkBillsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offLineBillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unloadingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sampleTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dipEntryToolStripMenuItem;
    }
}



