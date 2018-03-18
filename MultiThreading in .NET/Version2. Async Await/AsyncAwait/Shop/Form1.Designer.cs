namespace Shop
{
	partial class Form1
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
			this.labelControlSelected = new DevExpress.XtraEditors.LabelControl();
			this.labelControlAllProducts = new DevExpress.XtraEditors.LabelControl();
			this.lookUpEditAllProducts = new DevExpress.XtraEditors.LookUpEdit();
			this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.labelControlTotalCaption = new DevExpress.XtraEditors.LabelControl();
			this.simpleButtonRemove = new DevExpress.XtraEditors.SimpleButton();
			this.textEditTotal = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.lookUpEditAllProducts.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditTotal.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControlSelected
			// 
			this.labelControlSelected.Location = new System.Drawing.Point(12, 35);
			this.labelControlSelected.Name = "labelControlSelected";
			this.labelControlSelected.Size = new System.Drawing.Size(45, 13);
			this.labelControlSelected.TabIndex = 0;
			this.labelControlSelected.Text = "Selected:";
			// 
			// labelControlAllProducts
			// 
			this.labelControlAllProducts.Location = new System.Drawing.Point(12, 12);
			this.labelControlAllProducts.Name = "labelControlAllProducts";
			this.labelControlAllProducts.Size = new System.Drawing.Size(42, 13);
			this.labelControlAllProducts.TabIndex = 1;
			this.labelControlAllProducts.Text = "Products";
			// 
			// lookUpEditAllProducts
			// 
			this.lookUpEditAllProducts.Location = new System.Drawing.Point(58, 9);
			this.lookUpEditAllProducts.Name = "lookUpEditAllProducts";
			this.lookUpEditAllProducts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.lookUpEditAllProducts.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
			this.lookUpEditAllProducts.Properties.DisplayMember = "Name";
			this.lookUpEditAllProducts.Properties.ValueMember = "Id";
			this.lookUpEditAllProducts.Size = new System.Drawing.Size(280, 20);
			this.lookUpEditAllProducts.TabIndex = 2;
			// 
			// simpleButtonAdd
			// 
			this.simpleButtonAdd.Location = new System.Drawing.Point(344, 7);
			this.simpleButtonAdd.Name = "simpleButtonAdd";
			this.simpleButtonAdd.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonAdd.TabIndex = 3;
			this.simpleButtonAdd.Text = "Add";
			this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
			// 
			// gridControl1
			// 
			this.gridControl1.Location = new System.Drawing.Point(12, 54);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(407, 200);
			this.gridControl1.TabIndex = 4;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			// 
			// labelControlTotalCaption
			// 
			this.labelControlTotalCaption.Location = new System.Drawing.Point(12, 260);
			this.labelControlTotalCaption.Name = "labelControlTotalCaption";
			this.labelControlTotalCaption.Size = new System.Drawing.Size(28, 13);
			this.labelControlTotalCaption.TabIndex = 0;
			this.labelControlTotalCaption.Text = "Total:";
			// 
			// simpleButtonRemove
			// 
			this.simpleButtonRemove.Location = new System.Drawing.Point(12, 279);
			this.simpleButtonRemove.Name = "simpleButtonRemove";
			this.simpleButtonRemove.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonRemove.TabIndex = 3;
			this.simpleButtonRemove.Text = "Remove";
			this.simpleButtonRemove.Click += new System.EventHandler(this.simpleButtonRemove_Click);
			// 
			// textEditTotal
			// 
			this.textEditTotal.Location = new System.Drawing.Point(319, 257);
			this.textEditTotal.Name = "textEditTotal";
			this.textEditTotal.Size = new System.Drawing.Size(100, 20);
			this.textEditTotal.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 313);
			this.Controls.Add(this.textEditTotal);
			this.Controls.Add(this.gridControl1);
			this.Controls.Add(this.simpleButtonRemove);
			this.Controls.Add(this.simpleButtonAdd);
			this.Controls.Add(this.lookUpEditAllProducts);
			this.Controls.Add(this.labelControlAllProducts);
			this.Controls.Add(this.labelControlTotalCaption);
			this.Controls.Add(this.labelControlSelected);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.lookUpEditAllProducts.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditTotal.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControlSelected;
		private DevExpress.XtraEditors.LabelControl labelControlAllProducts;
		private DevExpress.XtraEditors.LookUpEdit lookUpEditAllProducts;
		private DevExpress.XtraEditors.SimpleButton simpleButtonAdd;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.LabelControl labelControlTotalCaption;
		private DevExpress.XtraEditors.SimpleButton simpleButtonRemove;
		private DevExpress.XtraEditors.TextEdit textEditTotal;
	}
}

