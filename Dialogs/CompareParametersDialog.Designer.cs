﻿namespace RemoteDataManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.ParameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(339, 441);
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
            this.TableButtons.Location = new System.Drawing.Point(8, 404);
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 696F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.TypeDropDown, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.FamilyDropDown, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.CategoryDropDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(323, 94);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypeDropDown
            // 
            this.TypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeDropDown.DropDownWidth = 500;
            this.TypeDropDown.FormattingEnabled = true;
            this.TypeDropDown.Location = new System.Drawing.Point(63, 68);
            this.TypeDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.TypeDropDown.Name = "TypeDropDown";
            this.TypeDropDown.Size = new System.Drawing.Size(257, 21);
            this.TypeDropDown.TabIndex = 5;
            this.TypeDropDown.TabStop = false;
            this.TypeDropDown.SelectedIndexChanged += new System.EventHandler(this.TypeDropDown_SelectedIndexChanged);
            // 
            // FamilyDropDown
            // 
            this.FamilyDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FamilyDropDown.FormattingEnabled = true;
            this.FamilyDropDown.Location = new System.Drawing.Point(63, 37);
            this.FamilyDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.FamilyDropDown.Name = "FamilyDropDown";
            this.FamilyDropDown.Size = new System.Drawing.Size(257, 21);
            this.FamilyDropDown.TabIndex = 4;
            this.FamilyDropDown.TabStop = false;
            this.FamilyDropDown.SelectedIndexChanged += new System.EventHandler(this.FamilyDropDown_SelectedIndexChanged);
            // 
            // CategoryDropDown
            // 
            this.CategoryDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryDropDown.FormattingEnabled = true;
            this.CategoryDropDown.Location = new System.Drawing.Point(63, 6);
            this.CategoryDropDown.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.CategoryDropDown.Name = "CategoryDropDown";
            this.CategoryDropDown.Size = new System.Drawing.Size(257, 21);
            this.CategoryDropDown.TabIndex = 2;
            this.CategoryDropDown.TabStop = false;
            this.CategoryDropDown.SelectedIndexChanged += new System.EventHandler(this.CategoryDropDown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Category:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Family:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypesDatagrid
            // 
            this.TypesDatagrid.AllowUserToAddRows = false;
            this.TypesDatagrid.AllowUserToDeleteRows = false;
            this.TypesDatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TypesDatagrid.BackgroundColor = System.Drawing.Color.White;
            this.TypesDatagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TypesDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TypesDatagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterColumn,
            this.TypeColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TypesDatagrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.TypesDatagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypesDatagrid.Location = new System.Drawing.Point(8, 103);
            this.TypesDatagrid.MultiSelect = false;
            this.TypesDatagrid.Name = "TypesDatagrid";
            this.TypesDatagrid.RowHeadersVisible = false;
            this.TypesDatagrid.Size = new System.Drawing.Size(323, 295);
            this.TypesDatagrid.TabIndex = 5;
            this.TypesDatagrid.TabStop = false;
            this.TypesDatagrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TypesDatagrid_CellClick);
            // 
            // ParameterColumn
            // 
            this.ParameterColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ParameterColumn.FillWeight = 67.42708F;
            this.ParameterColumn.HeaderText = "Parameter";
            this.ParameterColumn.Name = "ParameterColumn";
            this.ParameterColumn.ReadOnly = true;
            this.ParameterColumn.Width = 80;
            // 
            // TypeColumn
            // 
            this.TypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Gray;
            this.TypeColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.TypeColumn.FillWeight = 156.4309F;
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            this.TypeColumn.Width = 56;
            // 
            // CompareParametersDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(339, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(355, 480);
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
        public System.Windows.Forms.DataGridView TypesDatagrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox TypeDropDown;
        public System.Windows.Forms.ComboBox FamilyDropDown;
        public System.Windows.Forms.ComboBox CategoryDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.TableLayoutPanel TableButtons;
        private System.Windows.Forms.Button PublishButton;
        private System.Windows.Forms.Button CancelEditButton;
    }
}