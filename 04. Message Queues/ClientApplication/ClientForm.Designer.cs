namespace ClientApplication
{
	partial class ClientForm
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
			this.labelControlFile = new DevExpress.XtraEditors.LabelControl();
			this.buttonEditFile = new DevExpress.XtraEditors.ButtonEdit();
			this.simpleButtonSend = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.buttonEditFile.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControlFile
			// 
			this.labelControlFile.Location = new System.Drawing.Point(12, 15);
			this.labelControlFile.Name = "labelControlFile";
			this.labelControlFile.Size = new System.Drawing.Size(16, 13);
			this.labelControlFile.TabIndex = 0;
			this.labelControlFile.Text = "File";
			// 
			// buttonEditFile
			// 
			this.buttonEditFile.Location = new System.Drawing.Point(34, 12);
			this.buttonEditFile.Name = "buttonEditFile";
			this.buttonEditFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.buttonEditFile.Size = new System.Drawing.Size(582, 20);
			this.buttonEditFile.TabIndex = 1;
			this.buttonEditFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditFile_ButtonClick);
			// 
			// simpleButtonSend
			// 
			this.simpleButtonSend.Location = new System.Drawing.Point(541, 38);
			this.simpleButtonSend.Name = "simpleButtonSend";
			this.simpleButtonSend.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonSend.TabIndex = 2;
			this.simpleButtonSend.Text = "Send";
			this.simpleButtonSend.Click += new System.EventHandler(this.simpleButtonSend_Click);
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(628, 72);
			this.Controls.Add(this.simpleButtonSend);
			this.Controls.Add(this.buttonEditFile);
			this.Controls.Add(this.labelControlFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ClientForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Client form";
			((System.ComponentModel.ISupportInitialize)(this.buttonEditFile.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControlFile;
		private DevExpress.XtraEditors.ButtonEdit buttonEditFile;
		private DevExpress.XtraEditors.SimpleButton simpleButtonSend;
	}
}

