namespace banHangWin.GUI
{
    partial class ComboForm
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
            this.btnBill = new System.Windows.Forms.Button();
            this.mainGridView = new System.Windows.Forms.DataGridView();
            this.subGridView = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
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
            this.btnProduct.TabIndex = 23;
            this.btnProduct.Text = "SẢN PHẨM";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnBill
            // 
            this.btnBill.Location = new System.Drawing.Point(12, 69);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(101, 51);
            this.btnBill.TabIndex = 24;
            this.btnBill.Text = "HÓA ĐƠN";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // mainGridView
            // 
            this.mainGridView.AllowUserToAddRows = false;
            this.mainGridView.AllowUserToDeleteRows = false;
            this.mainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.mainGridView.Location = new System.Drawing.Point(131, 12);
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
            this.mainGridView.Size = new System.Drawing.Size(417, 185);
            this.mainGridView.TabIndex = 25;
            this.mainGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainGridView_CellClick);
            this.mainGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.mainGridView_DataBindingComplete);
            // 
            // subGridView
            // 
            this.subGridView.AllowUserToAddRows = false;
            this.subGridView.AllowUserToDeleteRows = false;
            this.subGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.subGridView.Location = new System.Drawing.Point(131, 236);
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
            this.subGridView.Size = new System.Drawing.Size(305, 156);
            this.subGridView.TabIndex = 26;
            this.subGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.subGridView_DataBindingComplete);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(460, 236);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 41);
            this.btnThem.TabIndex = 27;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(460, 292);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 41);
            this.btnSua.TabIndex = 28;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(460, 351);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 41);
            this.btnXoa.TabIndex = 29;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.Location = new System.Drawing.Point(12, 126);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(101, 51);
            this.btnDelivery.TabIndex = 30;
            this.btnDelivery.Text = "GIAO HÀNG";
            this.btnDelivery.UseVisualStyleBackColor = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // ComboForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 406);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.subGridView);
            this.Controls.Add(this.mainGridView);
            this.Controls.Add(this.btnBill);
            this.Controls.Add(this.btnProduct);
            this.Name = "ComboForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Combo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ComboForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.mainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.DataGridView mainGridView;
        private System.Windows.Forms.DataGridView subGridView;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDelivery;
    }
}