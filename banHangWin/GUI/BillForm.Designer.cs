namespace banHangWin.GUI
{
    partial class BillForm
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
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnAddComboBill = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCombo = new System.Windows.Forms.Button();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.mainGridView = new System.Windows.Forms.DataGridView();
            this.subGridView = new System.Windows.Forms.DataGridView();
            this.btnDelivery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(12, 12);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(101, 51);
            this.btnProduct.TabIndex = 22;
            this.btnProduct.Text = "SẢN PHẨM";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnAddComboBill
            // 
            this.btnAddComboBill.Location = new System.Drawing.Point(736, 323);
            this.btnAddComboBill.Name = "btnAddComboBill";
            this.btnAddComboBill.Size = new System.Drawing.Size(102, 44);
            this.btnAddComboBill.TabIndex = 25;
            this.btnAddComboBill.Text = "Lập hóa đơn Combo";
            this.btnAddComboBill.UseVisualStyleBackColor = true;
            this.btnAddComboBill.Click += new System.EventHandler(this.btnAddComboBill_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(736, 480);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(102, 44);
            this.btnXoa.TabIndex = 27;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnCombo
            // 
            this.btnCombo.Location = new System.Drawing.Point(12, 126);
            this.btnCombo.Name = "btnCombo";
            this.btnCombo.Size = new System.Drawing.Size(101, 51);
            this.btnCombo.TabIndex = 28;
            this.btnCombo.Text = "COMBO";
            this.btnCombo.UseVisualStyleBackColor = true;
            this.btnCombo.Click += new System.EventHandler(this.btnCombo_Click);
            // 
            // btnAddBill
            // 
            this.btnAddBill.Location = new System.Drawing.Point(736, 397);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(102, 44);
            this.btnAddBill.TabIndex = 29;
            this.btnAddBill.Text = "Lập hóa đơn";
            this.btnAddBill.UseVisualStyleBackColor = true;
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click);
            // 
            // mainGridView
            // 
            this.mainGridView.AllowUserToAddRows = false;
            this.mainGridView.AllowUserToDeleteRows = false;
            this.mainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.mainGridView.Location = new System.Drawing.Point(119, 12);
            this.mainGridView.MultiSelect = false;
            this.mainGridView.Name = "mainGridView";
            this.mainGridView.ReadOnly = true;
            this.mainGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.mainGridView.RowTemplate.Height = 25;
            this.mainGridView.RowTemplate.ReadOnly = true;
            this.mainGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mainGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainGridView.ShowCellErrors = false;
            this.mainGridView.ShowCellToolTips = false;
            this.mainGridView.ShowEditingIcon = false;
            this.mainGridView.ShowRowErrors = false;
            this.mainGridView.Size = new System.Drawing.Size(719, 248);
            this.mainGridView.TabIndex = 30;
            this.mainGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainGridView_CellClick);
            this.mainGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.mainGridView_DataBindingComplete);
            // 
            // subGridView
            // 
            this.subGridView.AllowUserToAddRows = false;
            this.subGridView.AllowUserToDeleteRows = false;
            this.subGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.subGridView.Location = new System.Drawing.Point(119, 296);
            this.subGridView.MultiSelect = false;
            this.subGridView.Name = "subGridView";
            this.subGridView.ReadOnly = true;
            this.subGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.subGridView.RowTemplate.Height = 25;
            this.subGridView.RowTemplate.ReadOnly = true;
            this.subGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.subGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.subGridView.ShowCellErrors = false;
            this.subGridView.ShowCellToolTips = false;
            this.subGridView.ShowEditingIcon = false;
            this.subGridView.ShowRowErrors = false;
            this.subGridView.Size = new System.Drawing.Size(582, 248);
            this.subGridView.TabIndex = 31;
            // 
            // btnDelivery
            // 
            this.btnDelivery.Location = new System.Drawing.Point(12, 69);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(101, 51);
            this.btnDelivery.TabIndex = 32;
            this.btnDelivery.Text = "GIAO HÀNG";
            this.btnDelivery.UseVisualStyleBackColor = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 579);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.subGridView);
            this.Controls.Add(this.mainGridView);
            this.Controls.Add(this.btnAddBill);
            this.Controls.Add(this.btnCombo);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnAddComboBill);
            this.Controls.Add(this.btnProduct);
            this.Name = "BillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BillForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnAddComboBill;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCombo;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.DataGridView mainGridView;
        private System.Windows.Forms.DataGridView subGridView;
        private System.Windows.Forms.Button btnDelivery;
    }
}