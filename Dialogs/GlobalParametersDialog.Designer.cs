namespace RemoteDataManager
{
    partial class GlobalParametersDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.ParametersDataGrid = new System.Windows.Forms.DataGridView();
            this.EditColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.PublishButton = new System.Windows.Forms.Button();
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LinkDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TableLayoutMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParametersDataGrid)).BeginInit();
            this.TableButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.TableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.TableLayoutMain.Size = new System.Drawing.Size(339, 441);
            this.TableLayoutMain.TabIndex = 2;
            // 
            // ParametersDataGrid
            // 
            this.ParametersDataGrid.AllowUserToAddRows = false;
            this.ParametersDataGrid.AllowUserToDeleteRows = false;
            this.ParametersDataGrid.AllowUserToResizeRows = false;
            this.ParametersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ParametersDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.ParametersDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ParametersDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ParametersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParametersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EditColumn,
            this.TypeColumn,
            this.ParameterColumn,
            this.ValueColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ParametersDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.ParametersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParametersDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.ParametersDataGrid.Location = new System.Drawing.Point(8, 44);
            this.ParametersDataGrid.MultiSelect = false;
            this.ParametersDataGrid.Name = "ParametersDataGrid";
            this.ParametersDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ParametersDataGrid.RowHeadersVisible = false;
            this.ParametersDataGrid.Size = new System.Drawing.Size(323, 356);
            this.ParametersDataGrid.TabIndex = 0;
            this.ParametersDataGrid.TabStop = false;
            this.ParametersDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ParametersDataGrid_CellClick);
            // 
            // EditColumn
            // 
            this.EditColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EditColumn.HeaderText = "Edit";
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.Width = 31;
            // 
            // TypeColumn
            // 
            this.TypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gray;
            this.TypeColumn.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.MaxInputLength = 250;
            this.ValueColumn.Name = "ValueColumn";
            // 
            // TableButtons
            // 
            this.TableButtons.ColumnCount = 2;
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableButtons.Controls.Add(this.PublishButton, 0, 0);
            this.TableButtons.Controls.Add(this.CancelEditButton, 1, 0);
            this.TableButtons.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.PublishButton.TabStop = false;
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
            this.CancelEditButton.TabStop = false;
            this.CancelEditButton.Text = "Cancel";
            this.CancelEditButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.LinkDropDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 35);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // LinkDropDown
            // 
            this.LinkDropDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LinkDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LinkDropDown.FormattingEnabled = true;
            this.LinkDropDown.Location = new System.Drawing.Point(53, 6);
            this.LinkDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.LinkDropDown.Name = "LinkDropDown";
            this.LinkDropDown.Size = new System.Drawing.Size(267, 21);
            this.LinkDropDown.TabIndex = 2;
            this.LinkDropDown.TabStop = false;
            this.LinkDropDown.SelectedIndexChanged += new System.EventHandler(this.LinkDropDown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Link:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GlobalParametersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 441);
            this.Controls.Add(this.TableLayoutMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(355, 480);
            this.Name = "GlobalParametersDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Remote Global Parameters";
            this.TableLayoutMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ParametersDataGrid)).EndInit();
            this.TableButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TableLayoutMain;
        public System.Windows.Forms.DataGridView ParametersDataGrid;
        private System.Windows.Forms.TableLayoutPanel TableButtons;
        private System.Windows.Forms.Button PublishButton;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.ComboBox LinkDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
    }
}