namespace RemoteDataManager
{
    partial class CompareParametersDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.PublishButton = new System.Windows.Forms.Button();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.TypeDropDown = new System.Windows.Forms.ComboBox();
            this.FamilyDropDown = new System.Windows.Forms.ComboBox();
            this.CategoryDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TypesDatagrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.TableButtons.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TypesDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Controls.Add(this.TableButtons, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TypesDatagrid, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 551);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TableButtons
            // 
            this.TableButtons.ColumnCount = 2;
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableButtons.Controls.Add(this.PublishButton, 0, 0);
            this.TableButtons.Controls.Add(this.CancelEditButton, 1, 0);
            this.TableButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.TableButtons.Location = new System.Drawing.Point(8, 516);
            this.TableButtons.Name = "TableButtons";
            this.TableButtons.RowCount = 1;
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableButtons.Size = new System.Drawing.Size(323, 29);
            this.TableButtons.TabIndex = 6;
            // 
            // PublishButton
            // 
            this.PublishButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PublishButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PublishButton.Location = new System.Drawing.Point(3, 3);
            this.PublishButton.Name = "PublishButton";
            this.PublishButton.Size = new System.Drawing.Size(155, 23);
            this.PublishButton.TabIndex = 1;
            this.PublishButton.Text = "Publish";
            this.PublishButton.UseVisualStyleBackColor = true;
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelEditButton.Location = new System.Drawing.Point(164, 3);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(156, 23);
            this.CancelEditButton.TabIndex = 3;
            this.CancelEditButton.Text = "Cancel";
            this.CancelEditButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 323F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.TypeDropDown, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.FamilyDropDown, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.CategoryDropDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(428, 114);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypeDropDown
            // 
            this.TypeDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeDropDown.FormattingEnabled = true;
            this.TypeDropDown.Location = new System.Drawing.Point(103, 82);
            this.TypeDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TypeDropDown.Name = "TypeDropDown";
            this.TypeDropDown.Size = new System.Drawing.Size(317, 21);
            this.TypeDropDown.TabIndex = 5;
            this.TypeDropDown.SelectedIndexChanged += new System.EventHandler(this.TypeDropDown_SelectedIndexChanged);
            // 
            // FamilyDropDown
            // 
            this.FamilyDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FamilyDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamilyDropDown.FormattingEnabled = true;
            this.FamilyDropDown.Location = new System.Drawing.Point(103, 44);
            this.FamilyDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.FamilyDropDown.Name = "FamilyDropDown";
            this.FamilyDropDown.Size = new System.Drawing.Size(317, 21);
            this.FamilyDropDown.TabIndex = 4;
            this.FamilyDropDown.SelectedIndexChanged += new System.EventHandler(this.FamilyDropDown_SelectedIndexChanged);
            // 
            // CategoryDropDown
            // 
            this.CategoryDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryDropDown.FormattingEnabled = true;
            this.CategoryDropDown.Location = new System.Drawing.Point(103, 6);
            this.CategoryDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.CategoryDropDown.Name = "CategoryDropDown";
            this.CategoryDropDown.Size = new System.Drawing.Size(317, 21);
            this.CategoryDropDown.TabIndex = 2;
            this.CategoryDropDown.SelectedIndexChanged += new System.EventHandler(this.CategoryDropDown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "Family:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypesDatagrid
            // 
            this.TypesDatagrid.BackgroundColor = System.Drawing.Color.White;
            this.TypesDatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TypesDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TypesDatagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypesDatagrid.Location = new System.Drawing.Point(8, 123);
            this.TypesDatagrid.Name = "TypesDatagrid";
            this.TypesDatagrid.Size = new System.Drawing.Size(428, 387);
            this.TypesDatagrid.TabIndex = 5;
            // 
            // CompareParametersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(444, 551);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 590);
            this.Name = "CompareParametersDialog";
            this.ShowIcon = false;
            this.Text = "Compare Parameters";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TableButtons.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TypesDatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.ComboBox FamilyDropDown;
        public System.Windows.Forms.ComboBox CategoryDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel TableButtons;
        private System.Windows.Forms.Button PublishButton;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox TypeDropDown;
        public System.Windows.Forms.DataGridView TypesDatagrid;
    }
}