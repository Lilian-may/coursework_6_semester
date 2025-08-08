namespace IAT_Test
{
    partial class DatabaseForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(12, 12);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(300, 40);
            this.comboBoxTables.TabIndex = 0;
            this.comboBoxTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxTables_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = true;
            this.dataGridView.AllowUserToDeleteRows = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 70);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 82;
            this.dataGridView.RowTemplate.Height = 41;
            this.dataGridView.Size = new System.Drawing.Size(960, 500);
            this.dataGridView.TabIndex = 1;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(330, 12);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(150, 40);
            this.BtnRefresh.TabIndex = 2;
            this.BtnRefresh.Text = "Обновить";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(490, 12);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(200, 40);
            this.BtnEdit.TabIndex = 3;
            this.BtnEdit.Text = "Сохранить изменения";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(700, 12);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(150, 40);
            this.BtnDelete.TabIndex = 4;
            this.BtnDelete.Text = "Удалить";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 591);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.comboBoxTables);
            this.Name = "DatabaseForm";
            this.Text = "База данных";
            this.Load += new System.EventHandler(this.DatabasseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
