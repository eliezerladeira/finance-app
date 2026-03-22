using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SuppliersForm();
            form.ShowDialog();
        }
    }
}
