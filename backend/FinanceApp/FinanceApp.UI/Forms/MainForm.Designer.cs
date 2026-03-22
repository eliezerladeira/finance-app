namespace FinanceApp.UI.Forms
{
    partial class MainForm
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
            menuTop = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            fornecedoresToolStripMenuItem = new ToolStripMenuItem();
            contasToolStripMenuItem = new ToolStripMenuItem();
            cartõesToolStripMenuItem = new ToolStripMenuItem();
            menuTop.SuspendLayout();
            SuspendLayout();
            // 
            // menuTop
            // 
            menuTop.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem });
            menuTop.Location = new Point(0, 0);
            menuTop.Name = "menuTop";
            menuTop.Size = new Size(800, 24);
            menuTop.TabIndex = 0;
            menuTop.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fornecedoresToolStripMenuItem, contasToolStripMenuItem, cartõesToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // fornecedoresToolStripMenuItem
            // 
            fornecedoresToolStripMenuItem.Name = "fornecedoresToolStripMenuItem";
            fornecedoresToolStripMenuItem.Size = new Size(180, 22);
            fornecedoresToolStripMenuItem.Text = "Fornecedores";
            fornecedoresToolStripMenuItem.Click += fornecedoresToolStripMenuItem_Click;
            // 
            // contasToolStripMenuItem
            // 
            contasToolStripMenuItem.Name = "contasToolStripMenuItem";
            contasToolStripMenuItem.Size = new Size(180, 22);
            contasToolStripMenuItem.Text = "Contas";
            // 
            // cartõesToolStripMenuItem
            // 
            cartõesToolStripMenuItem.Name = "cartõesToolStripMenuItem";
            cartõesToolStripMenuItem.Size = new Size(180, 22);
            cartõesToolStripMenuItem.Text = "Cartões";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuTop);
            MainMenuStrip = menuTop;
            Name = "MainForm";
            Text = "FinanceApp - Controle Financeiro Pessoal";
            menuTop.ResumeLayout(false);
            menuTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuTop;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem fornecedoresToolStripMenuItem;
        private ToolStripMenuItem contasToolStripMenuItem;
        private ToolStripMenuItem cartõesToolStripMenuItem;
    }
}