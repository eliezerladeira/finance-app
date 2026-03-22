namespace FinanceApp.UI.Forms
{
    partial class SuppliersForm
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
            lblSupplier = new Label();
            txtName = new TextBox();
            btnAdd = new Button();
            dgvSuppliers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            SuspendLayout();
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(27, 41);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(67, 15);
            lblSupplier.TabIndex = 0;
            lblSupplier.Text = "Fornecedor";
            // 
            // txtName
            // 
            txtName.Location = new Point(100, 38);
            txtName.Name = "txtName";
            txtName.Size = new Size(279, 23);
            txtName.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(385, 37);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Adicionar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(12, 80);
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.Size = new Size(776, 358);
            dgvSuppliers.TabIndex = 3;
            // 
            // SuppliersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvSuppliers);
            Controls.Add(btnAdd);
            Controls.Add(txtName);
            Controls.Add(lblSupplier);
            Name = "SuppliersForm";
            Text = "FinanceApp - Controle Financeiro Pessoal [Fornecedores]";
            Load += SuppliersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSupplier;
        private TextBox txtName;
        private Button btnAdd;
        private DataGridView dgvSuppliers;
    }
}