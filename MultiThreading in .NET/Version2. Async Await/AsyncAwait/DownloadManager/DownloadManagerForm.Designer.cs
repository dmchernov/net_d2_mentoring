namespace DownloadManager
{
	partial class DownloadManagerForm
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
			this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
			this.gridControlDownloads = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonRun = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.gridControlDownloads)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// simpleButtonDelete
			// 
			this.simpleButtonDelete.Location = new System.Drawing.Point(713, 292);
			this.simpleButtonDelete.Name = "simpleButtonDelete";
			this.simpleButtonDelete.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonDelete.TabIndex = 0;
			this.simpleButtonDelete.Text = "Delete";
			this.simpleButtonDelete.Click += new System.EventHandler(this.simpleButtonDelete_Click);
			// 
			// gridControlDownloads
			// 
			this.gridControlDownloads.Location = new System.Drawing.Point(12, 12);
			this.gridControlDownloads.MainView = this.gridView1;
			this.gridControlDownloads.Name = "gridControlDownloads";
			this.gridControlDownloads.Size = new System.Drawing.Size(776, 274);
			this.gridControlDownloads.TabIndex = 1;
			this.gridControlDownloads.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.ActiveFilterEnabled = false;
			this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
			this.gridView1.GridControl = this.gridControlDownloads;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
			this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this.gridView1.OptionsBehavior.Editable = false;
			// 
			// simpleButtonCancel
			// 
			this.simpleButtonCancel.Location = new System.Drawing.Point(632, 292);
			this.simpleButtonCancel.Name = "simpleButtonCancel";
			this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonCancel.TabIndex = 0;
			this.simpleButtonCancel.Text = "Cancel";
			this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
			// 
			// simpleButtonAdd
			// 
			this.simpleButtonAdd.Location = new System.Drawing.Point(470, 292);
			this.simpleButtonAdd.Name = "simpleButtonAdd";
			this.simpleButtonAdd.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonAdd.TabIndex = 0;
			this.simpleButtonAdd.Text = "Add";
			this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
			// 
			// simpleButtonRun
			// 
			this.simpleButtonRun.Location = new System.Drawing.Point(551, 292);
			this.simpleButtonRun.Name = "simpleButtonRun";
			this.simpleButtonRun.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonRun.TabIndex = 0;
			this.simpleButtonRun.Text = "Run";
			this.simpleButtonRun.Click += new System.EventHandler(this.simpleButtonRun_Click);
			// 
			// DownloadManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 327);
			this.Controls.Add(this.gridControlDownloads);
			this.Controls.Add(this.simpleButtonRun);
			this.Controls.Add(this.simpleButtonAdd);
			this.Controls.Add(this.simpleButtonCancel);
			this.Controls.Add(this.simpleButtonDelete);
			this.Name = "DownloadManagerForm";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.gridControlDownloads)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton simpleButtonDelete;
		private DevExpress.XtraGrid.GridControl gridControlDownloads;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
		private DevExpress.XtraEditors.SimpleButton simpleButtonAdd;
		private DevExpress.XtraEditors.SimpleButton simpleButtonRun;
	}
}

