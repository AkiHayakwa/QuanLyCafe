namespace GUI
{
    partial class GiaoDienChuyenDoiBan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.ComboBoxTable2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxInvoiceId = new System.Windows.Forms.TextBox();
            this.textBoxInvoiceId2 = new System.Windows.Forms.TextBox();
            this.dgv_Order1 = new System.Windows.Forms.DataGridView();
            this.dgv_Order2 = new System.Windows.Forms.DataGridView();
            this.btnswitchright = new System.Windows.Forms.Button();
            this.btnswitchallright = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bàn :";
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.FormattingEnabled = true;
            this.comboBoxTable.Location = new System.Drawing.Point(165, 65);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(151, 21);
            this.comboBoxTable.TabIndex = 2;
            this.comboBoxTable.SelectedIndexChanged += new System.EventHandler(this.comboBoxTable_SelectedIndexChanged);
            // 
            // ComboBoxTable2
            // 
            this.ComboBoxTable2.FormattingEnabled = true;
            this.ComboBoxTable2.Location = new System.Drawing.Point(811, 68);
            this.ComboBoxTable2.Name = "ComboBoxTable2";
            this.ComboBoxTable2.Size = new System.Drawing.Size(151, 21);
            this.ComboBoxTable2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(685, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã hóa đơn :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(747, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bàn :";
            // 
            // textBoxInvoiceId
            // 
            this.textBoxInvoiceId.Location = new System.Drawing.Point(165, 35);
            this.textBoxInvoiceId.Name = "textBoxInvoiceId";
            this.textBoxInvoiceId.ReadOnly = true;
            this.textBoxInvoiceId.Size = new System.Drawing.Size(151, 20);
            this.textBoxInvoiceId.TabIndex = 6;
            // 
            // textBoxInvoiceId2
            // 
            this.textBoxInvoiceId2.Location = new System.Drawing.Point(811, 38);
            this.textBoxInvoiceId2.Name = "textBoxInvoiceId2";
            this.textBoxInvoiceId2.ReadOnly = true;
            this.textBoxInvoiceId2.Size = new System.Drawing.Size(151, 20);
            this.textBoxInvoiceId2.TabIndex = 7;
            // 
            // dgv_Order1
            // 
            this.dgv_Order1.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Order1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Order1.Location = new System.Drawing.Point(12, 137);
            this.dgv_Order1.Name = "dgv_Order1";
            this.dgv_Order1.Size = new System.Drawing.Size(450, 347);
            this.dgv_Order1.TabIndex = 8;
            // 
            // dgv_Order2
            // 
            this.dgv_Order2.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Order2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Order2.Location = new System.Drawing.Point(628, 137);
            this.dgv_Order2.Name = "dgv_Order2";
            this.dgv_Order2.Size = new System.Drawing.Size(460, 347);
            this.dgv_Order2.TabIndex = 9;
            // 
            // btnswitchright
            // 
            this.btnswitchright.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnswitchright.Location = new System.Drawing.Point(495, 245);
            this.btnswitchright.Name = "btnswitchright";
            this.btnswitchright.Size = new System.Drawing.Size(99, 36);
            this.btnswitchright.TabIndex = 14;
            this.btnswitchright.Text = ">";
            this.btnswitchright.UseVisualStyleBackColor = true;
            this.btnswitchright.Click += new System.EventHandler(this.btnswitchright_Click);
            // 
            // btnswitchallright
            // 
            this.btnswitchallright.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnswitchallright.Location = new System.Drawing.Point(495, 307);
            this.btnswitchallright.Name = "btnswitchallright";
            this.btnswitchallright.Size = new System.Drawing.Size(99, 36);
            this.btnswitchallright.TabIndex = 15;
            this.btnswitchallright.Text = ">>";
            this.btnswitchallright.UseVisualStyleBackColor = true;
            this.btnswitchallright.Click += new System.EventHandler(this.btnswitchallright_Click);
            // 
            // GiaoDienChuyenDoiBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 496);
            this.Controls.Add(this.btnswitchallright);
            this.Controls.Add(this.btnswitchright);
            this.Controls.Add(this.dgv_Order2);
            this.Controls.Add(this.dgv_Order1);
            this.Controls.Add(this.textBoxInvoiceId2);
            this.Controls.Add(this.textBoxInvoiceId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboBoxTable2);
            this.Controls.Add(this.comboBoxTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GiaoDienChuyenDoiBan";
            this.Text = "GiaoDienChuyenDoiBan";
            this.Load += new System.EventHandler(this.GiaoDienChuyenDoiBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTable;
        private System.Windows.Forms.ComboBox ComboBoxTable2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxInvoiceId;
        private System.Windows.Forms.TextBox textBoxInvoiceId2;
        private System.Windows.Forms.DataGridView dgv_Order1;
        private System.Windows.Forms.DataGridView dgv_Order2;
        private System.Windows.Forms.Button btnswitchright;
        private System.Windows.Forms.Button btnswitchallright;
    }
}