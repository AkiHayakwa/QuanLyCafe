namespace GUI
{
    partial class GiaoDienDangki
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GiaoDienDangki));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.Register_loginbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Register_checkpassword = new System.Windows.Forms.CheckBox();
            this.Register_password = new System.Windows.Forms.TextBox();
            this.Register_username = new System.Windows.Forms.TextBox();
            this.Register_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Register_confirmpassword = new System.Windows.Forms.TextBox();
            this.register_close = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "ĐĂNG KÍ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Register_loginbtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 572);
            this.panel1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(67, 476);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Bạn đã có tài khoản ?";
            // 
            // Register_loginbtn
            // 
            this.Register_loginbtn.BackColor = System.Drawing.Color.DarkCyan;
            this.Register_loginbtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_loginbtn.ForeColor = System.Drawing.Color.White;
            this.Register_loginbtn.Location = new System.Drawing.Point(23, 512);
            this.Register_loginbtn.Name = "Register_loginbtn";
            this.Register_loginbtn.Size = new System.Drawing.Size(249, 35);
            this.Register_loginbtn.TabIndex = 4;
            this.Register_loginbtn.Text = "Đăng nhập";
            this.Register_loginbtn.UseVisualStyleBackColor = false;
            this.Register_loginbtn.Click += new System.EventHandler(this.Register_loginbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(86, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(42, 145);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "HỆ THỐNG QUẢN LÝ CAFE";
            // 
            // Register_checkpassword
            // 
            this.Register_checkpassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_checkpassword.Location = new System.Drawing.Point(332, 402);
            this.Register_checkpassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Register_checkpassword.Name = "Register_checkpassword";
            this.Register_checkpassword.Size = new System.Drawing.Size(141, 28);
            this.Register_checkpassword.TabIndex = 9;
            this.Register_checkpassword.Text = "Hiện mật khẩu";
            this.Register_checkpassword.UseVisualStyleBackColor = true;
            this.Register_checkpassword.CheckedChanged += new System.EventHandler(this.Register_checkpassword_CheckedChanged);
            // 
            // Register_password
            // 
            this.Register_password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_password.Location = new System.Drawing.Point(329, 257);
            this.Register_password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Register_password.Name = "Register_password";
            this.Register_password.PasswordChar = '*';
            this.Register_password.Size = new System.Drawing.Size(284, 29);
            this.Register_password.TabIndex = 14;
            // 
            // Register_username
            // 
            this.Register_username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_username.Location = new System.Drawing.Point(328, 169);
            this.Register_username.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Register_username.Name = "Register_username";
            this.Register_username.Size = new System.Drawing.Size(285, 29);
            this.Register_username.TabIndex = 13;
            // 
            // Register_btn
            // 
            this.Register_btn.BackColor = System.Drawing.Color.DarkCyan;
            this.Register_btn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_btn.ForeColor = System.Drawing.Color.White;
            this.Register_btn.Location = new System.Drawing.Point(328, 459);
            this.Register_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Register_btn.Name = "Register_btn";
            this.Register_btn.Size = new System.Drawing.Size(157, 56);
            this.Register_btn.TabIndex = 12;
            this.Register_btn.Text = "Đăng kí";
            this.Register_btn.UseVisualStyleBackColor = false;
            this.Register_btn.Click += new System.EventHandler(this.Register_btn_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 220);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mật khẩu :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(325, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tên người dùng :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(328, 312);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Xác nhận mật khẩu :";
            // 
            // Register_confirmpassword
            // 
            this.Register_confirmpassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_confirmpassword.Location = new System.Drawing.Point(330, 349);
            this.Register_confirmpassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Register_confirmpassword.Name = "Register_confirmpassword";
            this.Register_confirmpassword.PasswordChar = '*';
            this.Register_confirmpassword.Size = new System.Drawing.Size(284, 29);
            this.Register_confirmpassword.TabIndex = 16;
            // 
            // register_close
            // 
            this.register_close.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_close.Location = new System.Drawing.Point(622, 9);
            this.register_close.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.register_close.Name = "register_close";
            this.register_close.Size = new System.Drawing.Size(25, 26);
            this.register_close.TabIndex = 10;
            this.register_close.Text = "X";
            this.register_close.Click += new System.EventHandler(this.register_close_Click);
            // 
            // GiaoDienDangki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 572);
            this.Controls.Add(this.register_close);
            this.Controls.Add(this.Register_confirmpassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Register_checkpassword);
            this.Controls.Add(this.Register_password);
            this.Controls.Add(this.Register_username);
            this.Controls.Add(this.Register_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GiaoDienDangki";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GiaoDienDangki";
            this.Load += new System.EventHandler(this.GiaoDienDangki_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Register_loginbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Register_checkpassword;
        private System.Windows.Forms.TextBox Register_password;
        private System.Windows.Forms.TextBox Register_username;
        private System.Windows.Forms.Button Register_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Register_confirmpassword;
        private System.Windows.Forms.Label register_close;
    }
}