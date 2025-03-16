namespace KickNetLib.DesktopFormsTool.Controls
{
    partial class CategoryAPIControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            btnSearchByTerm = new Button();
            lblTermOfSearch = new Label();
            txtTermOfSearch = new TextBox();
            gb1 = new GroupBox();
            gb2 = new GroupBox();
            lblIdCategory = new Label();
            txtIdCategory = new TextBox();
            btnSerachByID = new Button();
            panel = new Panel();
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).BeginInit();
            scBaseAPI.Panel1.SuspendLayout();
            scBaseAPI.SuspendLayout();
            gb1.SuspendLayout();
            gb2.SuspendLayout();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // scBaseAPI
            // 
            // 
            // scBaseAPI.Panel1
            // 
            scBaseAPI.Panel1.Controls.Add(panel);
            scBaseAPI.Size = new Size(967, 496);
            // 
            // btnSearchByTerm
            // 
            btnSearchByTerm.Location = new Point(303, 55);
            btnSearchByTerm.Name = "btnSearchByTerm";
            btnSearchByTerm.Size = new Size(100, 29);
            btnSearchByTerm.TabIndex = 0;
            btnSearchByTerm.Text = "Search";
            btnSearchByTerm.UseVisualStyleBackColor = true;
            btnSearchByTerm.Click += btnSearchByTerm_Click;
            // 
            // lblTermOfSearch
            // 
            lblTermOfSearch.AutoSize = true;
            lblTermOfSearch.Location = new Point(20, 34);
            lblTermOfSearch.Name = "lblTermOfSearch";
            lblTermOfSearch.Size = new Size(106, 20);
            lblTermOfSearch.TabIndex = 1;
            lblTermOfSearch.Text = "Term of search";
            // 
            // txtTermOfSearch
            // 
            txtTermOfSearch.Location = new Point(20, 57);
            txtTermOfSearch.Name = "txtTermOfSearch";
            txtTermOfSearch.Size = new Size(277, 27);
            txtTermOfSearch.TabIndex = 2;
            // 
            // gb1
            // 
            gb1.Controls.Add(lblTermOfSearch);
            gb1.Controls.Add(txtTermOfSearch);
            gb1.Controls.Add(btnSearchByTerm);
            gb1.Location = new Point(3, 12);
            gb1.Name = "gb1";
            gb1.Size = new Size(419, 109);
            gb1.TabIndex = 3;
            gb1.TabStop = false;
            gb1.Text = "GET /public/v1/categories - Get Categories";
            // 
            // gb2
            // 
            gb2.Controls.Add(lblIdCategory);
            gb2.Controls.Add(txtIdCategory);
            gb2.Controls.Add(btnSerachByID);
            gb2.Location = new Point(3, 127);
            gb2.Name = "gb2";
            gb2.Size = new Size(419, 109);
            gb2.TabIndex = 4;
            gb2.TabStop = false;
            gb2.Text = "GET /public/v1/categories/:category_id - Get Category";
            // 
            // lblIdCategory
            // 
            lblIdCategory.AutoSize = true;
            lblIdCategory.Location = new Point(20, 34);
            lblIdCategory.Name = "lblIdCategory";
            lblIdCategory.Size = new Size(104, 20);
            lblIdCategory.TabIndex = 1;
            lblIdCategory.Text = "Id of Category";
            // 
            // txtIdCategory
            // 
            txtIdCategory.Location = new Point(20, 57);
            txtIdCategory.Name = "txtIdCategory";
            txtIdCategory.Size = new Size(277, 27);
            txtIdCategory.TabIndex = 2;
            // 
            // btnSerachByID
            // 
            btnSerachByID.Location = new Point(303, 55);
            btnSerachByID.Name = "btnSerachByID";
            btnSerachByID.Size = new Size(100, 29);
            btnSerachByID.TabIndex = 0;
            btnSerachByID.Text = "Search";
            btnSerachByID.UseVisualStyleBackColor = true;
            btnSerachByID.Click += btnSerachByID_Click;
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(gb1);
            panel.Controls.Add(gb2);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(446, 496);
            panel.TabIndex = 0;
            // 
            // CategoryAPIControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "CategoryAPIControl";
            Size = new Size(967, 496);
            scBaseAPI.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scBaseAPI).EndInit();
            scBaseAPI.ResumeLayout(false);
            gb1.ResumeLayout(false);
            gb1.PerformLayout();
            gb2.ResumeLayout(false);
            gb2.PerformLayout();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnSearchByTerm;
        private Label lblTermOfSearch;
        private TextBox txtTermOfSearch;
        private GroupBox gb1;
        private GroupBox gb2;
        private Label lblIdCategory;
        private TextBox txtIdCategory;
        private Button btnSerachByID;
        private Panel panel;
    }
}
