namespace AsyncRepository
{
	partial class FormCustomers
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.labelControlId = new DevExpress.XtraEditors.LabelControl();
			this.textEditId = new DevExpress.XtraEditors.TextEdit();
			this.labelControlFirstName = new DevExpress.XtraEditors.LabelControl();
			this.textEditFirstName = new DevExpress.XtraEditors.TextEdit();
			this.labelControlLastName = new DevExpress.XtraEditors.LabelControl();
			this.textEditLastName = new DevExpress.XtraEditors.TextEdit();
			this.labelControlAge = new DevExpress.XtraEditors.LabelControl();
			this.spinEditAge = new DevExpress.XtraEditors.SpinEdit();
			this.memoEditLog = new DevExpress.XtraEditors.MemoEdit();
			this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonUpdate = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButtonGet = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditFirstName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditLastName.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spinEditAge.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEditLog.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(396, 426);
			this.dataGridView1.TabIndex = 0;
			// 
			// labelControlId
			// 
			this.labelControlId.Location = new System.Drawing.Point(414, 15);
			this.labelControlId.Name = "labelControlId";
			this.labelControlId.Size = new System.Drawing.Size(10, 13);
			this.labelControlId.TabIndex = 1;
			this.labelControlId.Text = "Id";
			// 
			// textEditId
			// 
			this.textEditId.Location = new System.Drawing.Point(470, 12);
			this.textEditId.Name = "textEditId";
			this.textEditId.Properties.ReadOnly = true;
			this.textEditId.Size = new System.Drawing.Size(318, 20);
			this.textEditId.TabIndex = 2;
			// 
			// labelControlFirstName
			// 
			this.labelControlFirstName.Location = new System.Drawing.Point(414, 41);
			this.labelControlFirstName.Name = "labelControlFirstName";
			this.labelControlFirstName.Size = new System.Drawing.Size(50, 13);
			this.labelControlFirstName.TabIndex = 1;
			this.labelControlFirstName.Text = "First name";
			// 
			// textEditFirstName
			// 
			this.textEditFirstName.Location = new System.Drawing.Point(470, 38);
			this.textEditFirstName.Name = "textEditFirstName";
			this.textEditFirstName.Size = new System.Drawing.Size(318, 20);
			this.textEditFirstName.TabIndex = 2;
			// 
			// labelControlLastName
			// 
			this.labelControlLastName.Location = new System.Drawing.Point(415, 67);
			this.labelControlLastName.Name = "labelControlLastName";
			this.labelControlLastName.Size = new System.Drawing.Size(49, 13);
			this.labelControlLastName.TabIndex = 1;
			this.labelControlLastName.Text = "Last name";
			// 
			// textEditLastName
			// 
			this.textEditLastName.Location = new System.Drawing.Point(470, 64);
			this.textEditLastName.Name = "textEditLastName";
			this.textEditLastName.Size = new System.Drawing.Size(318, 20);
			this.textEditLastName.TabIndex = 2;
			// 
			// labelControlAge
			// 
			this.labelControlAge.Location = new System.Drawing.Point(414, 93);
			this.labelControlAge.Name = "labelControlAge";
			this.labelControlAge.Size = new System.Drawing.Size(19, 13);
			this.labelControlAge.TabIndex = 1;
			this.labelControlAge.Text = "Age";
			// 
			// spinEditAge
			// 
			this.spinEditAge.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.spinEditAge.Location = new System.Drawing.Point(470, 90);
			this.spinEditAge.Name = "spinEditAge";
			this.spinEditAge.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			this.spinEditAge.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.spinEditAge.Properties.IsFloatValue = false;
			this.spinEditAge.Properties.Mask.EditMask = "N00";
			this.spinEditAge.Properties.MaxLength = 2;
			this.spinEditAge.Properties.MaxValue = new decimal(new int[] {
            90,
            0,
            0,
            0});
			this.spinEditAge.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.spinEditAge.Size = new System.Drawing.Size(318, 20);
			this.spinEditAge.TabIndex = 3;
			// 
			// memoEdit1
			// 
			this.memoEditLog.Location = new System.Drawing.Point(414, 145);
			this.memoEditLog.Name = "memoEdit1";
			this.memoEditLog.Properties.ReadOnly = true;
			this.memoEditLog.Size = new System.Drawing.Size(374, 293);
			this.memoEditLog.TabIndex = 4;
			// 
			// simpleButtonAdd
			// 
			this.simpleButtonAdd.Location = new System.Drawing.Point(470, 116);
			this.simpleButtonAdd.Name = "simpleButtonAdd";
			this.simpleButtonAdd.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonAdd.TabIndex = 5;
			this.simpleButtonAdd.Text = "Add";
			this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
			// 
			// simpleButtonUpdate
			// 
			this.simpleButtonUpdate.Location = new System.Drawing.Point(551, 116);
			this.simpleButtonUpdate.Name = "simpleButtonUpdate";
			this.simpleButtonUpdate.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonUpdate.TabIndex = 5;
			this.simpleButtonUpdate.Text = "Update";
			// 
			// simpleButtonDelete
			// 
			this.simpleButtonDelete.Location = new System.Drawing.Point(632, 116);
			this.simpleButtonDelete.Name = "simpleButtonDelete";
			this.simpleButtonDelete.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonDelete.TabIndex = 5;
			this.simpleButtonDelete.Text = "Delete";
			// 
			// simpleButtonGet
			// 
			this.simpleButtonGet.Location = new System.Drawing.Point(713, 116);
			this.simpleButtonGet.Name = "simpleButtonGet";
			this.simpleButtonGet.Size = new System.Drawing.Size(75, 23);
			this.simpleButtonGet.TabIndex = 5;
			this.simpleButtonGet.Text = "Get";
			// 
			// FormCustomers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.simpleButtonGet);
			this.Controls.Add(this.simpleButtonDelete);
			this.Controls.Add(this.simpleButtonUpdate);
			this.Controls.Add(this.simpleButtonAdd);
			this.Controls.Add(this.memoEditLog);
			this.Controls.Add(this.spinEditAge);
			this.Controls.Add(this.textEditLastName);
			this.Controls.Add(this.labelControlAge);
			this.Controls.Add(this.textEditFirstName);
			this.Controls.Add(this.labelControlLastName);
			this.Controls.Add(this.textEditId);
			this.Controls.Add(this.labelControlFirstName);
			this.Controls.Add(this.labelControlId);
			this.Controls.Add(this.dataGridView1);
			this.Name = "FormCustomers";
			this.Text = "Customers";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditFirstName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.textEditLastName.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spinEditAge.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoEditLog.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private DevExpress.XtraEditors.LabelControl labelControlId;
		private DevExpress.XtraEditors.TextEdit textEditId;
		private DevExpress.XtraEditors.LabelControl labelControlFirstName;
		private DevExpress.XtraEditors.TextEdit textEditFirstName;
		private DevExpress.XtraEditors.LabelControl labelControlLastName;
		private DevExpress.XtraEditors.TextEdit textEditLastName;
		private DevExpress.XtraEditors.LabelControl labelControlAge;
		private DevExpress.XtraEditors.SpinEdit spinEditAge;
		private DevExpress.XtraEditors.MemoEdit memoEditLog;
		private DevExpress.XtraEditors.SimpleButton simpleButtonAdd;
		private DevExpress.XtraEditors.SimpleButton simpleButtonUpdate;
		private DevExpress.XtraEditors.SimpleButton simpleButtonDelete;
		private DevExpress.XtraEditors.SimpleButton simpleButtonGet;
	}
}

