namespace DownloadManager
{
	partial class AddResourceForm
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
			this.labelControlAddress = new DevExpress.XtraEditors.LabelControl();
			this.textEditAddress = new DevExpress.XtraEditors.TextEdit();
			this.labelControlFileName = new DevExpress.XtraEditors.LabelControl();
			this.labelControlCaption = new DevExpress.XtraEditors.LabelControl();
			this.textEditCaption = new DevExpress.XtraEditors.TextEdit();
			this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
			this.textEditFileName = new DevExpress.XtraEditors.TextEdit();
			((System.ComponentModel.ISupportInitialize)(this.textEditAddress.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditCaption.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditFileName.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControlAddress
			// 
			this.labelControlAddress.Location = new System.Drawing.Point(12, 12);
			this.labelControlAddress.Name = "labelControlAddress";
			this.labelControlAddress.Size = new System.Drawing.Size(39, 13);
			this.labelControlAddress.TabIndex = 0;
			this.labelControlAddress.Text = "Address";
			// 
			// textEditAddress
			// 
			this.textEditAddress.EditValue = "http://";
			this.textEditAddress.Location = new System.Drawing.Point(57, 9);
			this.textEditAddress.Name = "textEditAddress";
			this.textEditAddress.Size = new System.Drawing.Size(428, 20);
			this.textEditAddress.TabIndex = 0;
			// 
			// labelControlFileName
			// 
			this.labelControlFileName.Location = new System.Drawing.Point(12, 38);
			this.labelControlFileName.Name = "labelControlFileName";
			this.labelControlFileName.Size = new System.Drawing.Size(16, 13);
			this.labelControlFileName.TabIndex = 0;
			this.labelControlFileName.Text = "File";
			// 
			// labelControlCaption
			// 
			this.labelControlCaption.Location = new System.Drawing.Point(12, 64);
			this.labelControlCaption.Name = "labelControlCaption";
			this.labelControlCaption.Size = new System.Drawing.Size(37, 13);
			this.labelControlCaption.TabIndex = 0;
			this.labelControlCaption.Text = "Caption";
			// 
			// textEditCaption
			// 
			this.textEditCaption.Location = new System.Drawing.Point(57, 61);
			this.textEditCaption.Name = "textEditCaption";
			this.textEditCaption.Size = new System.Drawing.Size(428, 20);
			this.textEditCaption.TabIndex = 2;
			// 
			// simpleButtonAdd
			// 
			this.simpleButtonAdd.Location = new System.Drawing.Point(410, 87);
			this.simpleButtonAdd.Name = "simpleButtonAdd";
			this.simpleButtonAdd.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonAdd.TabIndex = 3;
			this.simpleButtonAdd.Text = "Add";
			this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
			// 
			// textEditFileName
			// 
			this.textEditFileName.Location = new System.Drawing.Point(57, 35);
			this.textEditFileName.Name = "textEditFileName";
			this.textEditFileName.Size = new System.Drawing.Size(428, 20);
			this.textEditFileName.TabIndex = 1;
			// 
			// AddResourceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(497, 118);
			this.Controls.Add(this.simpleButtonAdd);
			this.Controls.Add(this.textEditCaption);
			this.Controls.Add(this.textEditFileName);
			this.Controls.Add(this.textEditAddress);
			this.Controls.Add(this.labelControlCaption);
			this.Controls.Add(this.labelControlFileName);
			this.Controls.Add(this.labelControlAddress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddResourceForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add download";
			((System.ComponentModel.ISupportInitialize)(this.textEditAddress.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditCaption.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditFileName.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControlAddress;
		private DevExpress.XtraEditors.TextEdit textEditAddress;
		private DevExpress.XtraEditors.LabelControl labelControlFileName;
		private DevExpress.XtraEditors.LabelControl labelControlCaption;
		private DevExpress.XtraEditors.TextEdit textEditCaption;
		private DevExpress.XtraEditors.SimpleButton simpleButtonAdd;
		private DevExpress.XtraEditors.TextEdit textEditFileName;
	}
}