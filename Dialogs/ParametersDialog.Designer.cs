namespace RemoteDataManager
{
    partial class ParametersDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ParametersDataGrid = new System.Windows.Forms.DataGridView();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.TableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.PublishButton = new System.Windows.Forms.Button();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LinkLabel = new System.Windows.Forms.Label();
            this.LinkDropDown = new System.Windows.Forms.ComboBox();
            this.FamilyDropDown = new System.Windows.Forms.ComboBox();
            this.FamilyLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TypeDropDown = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersDataGrid)).BeginInit();
            this.TableLayoutMain.SuspendLayout();
            this.TableButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParametersDataGrid
            // 
            this.ParametersDataGrid.AllowUserToAddRows = false;
            this.ParametersDataGrid.AllowUserToDeleteRows = false;
            this.ParametersDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            this.ParametersDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ParametersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ParametersDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.ParametersDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParametersDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ParametersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParametersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColumn,
            this.EditColumn,
            this.TypeColumn,
            this.ParameterColumn,
            this.ValueColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ParametersDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.ParametersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParametersDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.ParametersDataGrid.Location = new System.Drawing.Point(8, 103);
            this.ParametersDataGrid.MultiSelect = false;
            this.ParametersDataGrid.Name = "ParametersDataGrid";
            this.ParametersDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ParametersDataGrid.RowHeadersVisible = false;
            this.ParametersDataGrid.Size = new System.Drawing.Size(323, 297);
            this.ParametersDataGrid.TabIndex = 0;
            // 
            // IdColumn
            // 
            this.IdColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IdColumn.HeaderText = "Id";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Visible = false;
            // 
            // EditColumn
            // 
            this.EditColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EditColumn.FillWeight = 25.64103F;
            this.EditColumn.HeaderText = "Edit";
            this.EditColumn.MinimumWidth = 15;
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EditColumn.Width = 50;
            // 
            // TypeColumn
            // 
            this.TypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Gray;
            this.TypeColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            this.TypeColumn.Width = 56;
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.MaxInputLength = 250;
            this.ParameterColumn.Name = "ParameterColumn";
            this.ParameterColumn.ReadOnly = true;
            this.ParameterColumn.Width = 80;
            // 
            // ValueColumn
            // 
            this.ValueColumn.FillWeight = 174.359F;
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.MaxInputLength = 250;
            this.ValueColumn.Name = "ValueColumn";
            // 
            // TableLayoutMain
            // 
            this.TableLayoutMain.ColumnCount = 3;
            this.TableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.TableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.TableLayoutMain.Controls.Add(this.ParametersDataGrid, 1, 1);
            this.TableLayoutMain.Controls.Add(this.TableButtons, 1, 2);
            this.TableLayoutMain.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.TableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutMain.Name = "TableLayoutMain";
            this.TableLayoutMain.RowCount = 4;
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.TableLayoutMain.Size = new System.Drawing.Size(339, 441);
            this.TableLayoutMain.TabIndex = 1;
            // 
            // TableButtons
            // 
            this.TableButtons.ColumnCount = 2;
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableButtons.Controls.Add(this.PublishButton, 0, 0);
            this.TableButtons.Controls.Add(this.CancelEditButton, 1, 0);
            this.TableButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableButtons.Location = new System.Drawing.Point(8, 406);
            this.TableButtons.Name = "TableButtons";
            this.TableButtons.RowCount = 1;
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableButtons.Size = new System.Drawing.Size(323, 29);
            this.TableButtons.TabIndex = 2;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LinkLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LinkDropDown, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.FamilyDropDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.FamilyLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TypeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TypeDropDown, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 94);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // LinkLabel
            // 
            this.LinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LinkLabel.AutoSize = true;
            this.LinkLabel.Location = new System.Drawing.Point(3, 62);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(30, 32);
            this.LinkLabel.TabIndex = 4;
            this.LinkLabel.Text = "Link:";
            this.LinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LinkDropDown
            // 
            this.LinkDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LinkDropDown.FormattingEnabled = true;
            this.LinkDropDown.Location = new System.Drawing.Point(53, 68);
            this.LinkDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.LinkDropDown.Name = "LinkDropDown";
            this.LinkDropDown.Size = new System.Drawing.Size(267, 21);
            this.LinkDropDown.TabIndex = 5;
            // 
            // FamilyDropDown
            // 
            this.FamilyDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FamilyDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamilyDropDown.FormattingEnabled = true;
            this.FamilyDropDown.Location = new System.Drawing.Point(53, 6);
            this.FamilyDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.FamilyDropDown.Name = "FamilyDropDown";
            this.FamilyDropDown.Size = new System.Drawing.Size(267, 21);
            this.FamilyDropDown.TabIndex = 2;
            // 
            // FamilyLabel
            // 
            this.FamilyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FamilyLabel.AutoSize = true;
            this.FamilyLabel.Location = new System.Drawing.Point(3, 0);
            this.FamilyLabel.Name = "FamilyLabel";
            this.FamilyLabel.Size = new System.Drawing.Size(39, 31);
            this.FamilyLabel.TabIndex = 0;
            this.FamilyLabel.Text = "Family:";
            this.FamilyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypeLabel
            // 
            this.TypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(3, 31);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(34, 31);
            this.TypeLabel.TabIndex = 1;
            this.TypeLabel.Text = "Type:";
            this.TypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypeDropDown
            // 
            this.TypeDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeDropDown.FormattingEnabled = true;
            this.TypeDropDown.Location = new System.Drawing.Point(53, 37);
            this.TypeDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TypeDropDown.Name = "TypeDropDown";
            this.TypeDropDown.Size = new System.Drawing.Size(267, 21);
            this.TypeDropDown.TabIndex = 3;
            // 
            // ParametersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 441);
            this.Controls.Add(this.TableLayoutMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(355, 480);
            this.Name = "ParametersDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Remote Type Properties";
            ((System.ComponentModel.ISupportInitialize)(this.ParametersDataGrid)).EndInit();
            this.TableLayoutMain.ResumeLayout(false);
            this.TableButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView ParametersDataGrid;
        private System.Windows.Forms.TableLayoutPanel TableLayoutMain;
        private System.Windows.Forms.Button PublishButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.TableLayoutPanel TableButtons;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label FamilyLabel;
        private System.Windows.Forms.Label TypeLabel;
        public System.Windows.Forms.ComboBox FamilyDropDown;
        public System.Windows.Forms.ComboBox TypeDropDown;
        private System.Windows.Forms.Label LinkLabel;
        public System.Windows.Forms.ComboBox LinkDropDown;
    }
}