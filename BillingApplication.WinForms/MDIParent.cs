using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BillingApplication.WinForms
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new BillingForm(false);
            childform.MdiParent = this;
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Maximized;
            childform.Show();
        }

        private void closeReadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new CloseShift();
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Maximized;
            childform.ShowDialog();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new AddPump();
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Normal;
            childform.ShowDialog();
        }

        private void addProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new AddProducts();
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Normal;
            childform.ShowDialog();
        }

        private void changePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new ChangeProductPrice();
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Normal;
            childform.ShowDialog();
        }

        private void checkBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new CheckBills();
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Normal;
            childform.ShowDialog();
        }

        private void cashReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new CashReceiptForm();
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Normal;
            childform.ShowDialog();
        }

        private void offLineBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new BillingForm(true);
            childform.MdiParent = this;
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Maximized;
            childform.Show();
        }

        private void sampleTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new SampleTag();
            childform.MdiParent = this;
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Maximized;
            childform.Show();
        }

        private void dipEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childform = new DipEntry();
            childform.MdiParent = this;
            childform.MinimizeBox = false;
            childform.MaximizeBox = false;
            childform.WindowState = FormWindowState.Maximized;
            childform.Show();
        }

       
    }
}
