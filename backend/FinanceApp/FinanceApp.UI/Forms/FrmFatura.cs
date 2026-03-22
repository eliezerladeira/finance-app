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

namespace FinanceApp.UI
{
    public partial class FrmFatura : Form
    {
        private readonly ApiService _apiService = new ApiService();

        public FrmFatura()
        {
            InitializeComponent();
        }

        private async void FrmFatura_Load(object sender, EventArgs e)
        {
            var invoiceId = Guid.Parse("COLOQUE_UM_ID_REAL_AQUI");

            var purchases = await _apiService.GetPurchases(invoiceId);

            CarregarTreeView(purchases);

            /*
            treeViewFatura.Nodes.Clear();

            var notebook = new TreeNode("Notebook (6x - R$1200)");
            notebook.Nodes.Add("1/6 - R$200");
            notebook.Nodes.Add("2/6 - R$200");

            treeViewFatura.Nodes.Add(notebook);

            treeViewFatura.Nodes.Add("Supermercado - R$150");
            treeViewFatura.Nodes.Add("Netflix - R$39");

            notebook.Expand();
            */
        }

        private void CarregarTreeView(List<PurchaseDto> purchases)
        {
            treeViewFatura.Nodes.Clear();

            var grupos = purchases
                .Where(p => p.PurchaseGroupId != null)
                .GroupBy(p => p.PurchaseGroupId);

            foreach (var grupo in grupos)
            {
                var primeira = grupo.First();

                var parentNode = new TreeNode(
                    $"{primeira.Description} ({primeira.TotalInstallments}x)"
                );

                foreach (var item in grupo.OrderBy(p => p.InstallmentNumber))
                {
                    parentNode.Nodes.Add(
                        $"{item.InstallmentNumber}/{item.TotalInstallments} - {item.Amount:C}"
                    );
                }

                treeViewFatura.Nodes.Add(parentNode);
                parentNode.Expand();
            }

            var simples = purchases
                .Where(p => p.PurchaseGroupId == null);

            foreach (var item in simples)
            {
                treeViewFatura.Nodes.Add(
                    $"{item.Description} - {item.Amount:C}"
                );
            }
        }
    }
}