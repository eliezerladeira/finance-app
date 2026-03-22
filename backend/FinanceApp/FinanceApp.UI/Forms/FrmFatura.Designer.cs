namespace FinanceApp.UI
{
    partial class FrmFatura
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
            treeViewFatura = new TreeView();
            SuspendLayout();
            // 
            // treeViewFatura
            // 
            treeViewFatura.Dock = DockStyle.Fill;
            treeViewFatura.Location = new Point(0, 0);
            treeViewFatura.Name = "treeViewFatura";
            treeViewFatura.Size = new Size(800, 450);
            treeViewFatura.TabIndex = 0;
            // 
            // FrmFatura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(treeViewFatura);
            Name = "FrmFatura";
            Text = "FrmFatura";
            Load += FrmFatura_Load;
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeViewFatura;
    }
}