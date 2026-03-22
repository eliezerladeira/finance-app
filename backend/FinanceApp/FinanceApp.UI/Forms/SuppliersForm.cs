using FinanceApp.UI.Services;
using FinanceApp.UI.Models;
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
    public partial class SuppliersForm : Form
    {
        // campo
        private readonly SupplierApiService _service = new SupplierApiService();

        public SuppliersForm()
        {
            InitializeComponent();
        }

        private async void SuppliersForm_Load(object sender, EventArgs e)
        {
            await LoadSuppliers();
        }

        private async Task LoadSuppliers()
            // método de carga
        {
            var suppliers = await _service.GetAll();
            dgvSuppliers.DataSource = suppliers;

            if (dgvSuppliers.Columns["Id"] != null)
                dgvSuppliers.Columns["Id"].Visible = false;

            if (dgvSuppliers.Columns["Name"] != null)
                dgvSuppliers.Columns["Name"].HeaderText = "Fornecedor";

            dgvSuppliers.Columns["Balance"].HeaderText = "Saldo";

            // formatação em real
            dgvSuppliers.Columns["Balance"].DefaultCellStyle.Format = "C2";

            // alinhar à direita
            dgvSuppliers.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.ReadOnly = true;
            dgvSuppliers.AllowUserToAddRows = false;

            foreach (DataGridViewRow row in dgvSuppliers.Rows)
            {
                var saldo = Convert.ToDecimal(row.Cells["Balance"].Value);

                if (saldo < 0)
                {
                    row.Cells["Balance"].Style.ForeColor = Color.Red;
                }
                else
                {
                    row.Cells["Balance"].Style.ForeColor = Color.Green;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Informe o nome do fornecedor.");
                return;
            }

            await _service.Create(name);

            txtName.Clear();

            await LoadSuppliers();
        }
    }
}