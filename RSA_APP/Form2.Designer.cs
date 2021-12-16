namespace RSA_APP
{
    partial class Form2
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
            this.txtE = new System.Windows.Forms.TextBox();
            this.txtN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBanRo = new System.Windows.Forms.TextBox();
            this.txtBanMa = new System.Windows.Forms.TextBox();
            this.rdUnicode = new System.Windows.Forms.RadioButton();
            this.rdZ26 = new System.Windows.Forms.RadioButton();
            this.rdSo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.btnThamMa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(509, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(507, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "N";
            // 
            // txtE
            // 
            this.txtE.Location = new System.Drawing.Point(568, 89);
            this.txtE.Name = "txtE";
            this.txtE.Size = new System.Drawing.Size(153, 20);
            this.txtE.TabIndex = 1;
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(568, 131);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(153, 20);
            this.txtN.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Q";
            // 
            // txtQ
            // 
            this.txtQ.Enabled = false;
            this.txtQ.Location = new System.Drawing.Point(568, 217);
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(153, 20);
            this.txtQ.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(34, 271);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 16);
            this.label18.TabIndex = 13;
            this.label18.Text = "Bản rõ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(27, 143);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 16);
            this.label17.TabIndex = 14;
            this.label17.Text = "Bản mã";
            // 
            // txtBanRo
            // 
            this.txtBanRo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanRo.ForeColor = System.Drawing.Color.Red;
            this.txtBanRo.Location = new System.Drawing.Point(93, 233);
            this.txtBanRo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBanRo.Multiline = true;
            this.txtBanRo.Name = "txtBanRo";
            this.txtBanRo.Size = new System.Drawing.Size(347, 104);
            this.txtBanRo.TabIndex = 12;
            // 
            // txtBanMa
            // 
            this.txtBanMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBanMa.Location = new System.Drawing.Point(93, 89);
            this.txtBanMa.Margin = new System.Windows.Forms.Padding(4);
            this.txtBanMa.Multiline = true;
            this.txtBanMa.Name = "txtBanMa";
            this.txtBanMa.Size = new System.Drawing.Size(347, 104);
            this.txtBanMa.TabIndex = 11;
            // 
            // rdUnicode
            // 
            this.rdUnicode.AutoSize = true;
            this.rdUnicode.Location = new System.Drawing.Point(12, 64);
            this.rdUnicode.Name = "rdUnicode";
            this.rdUnicode.Size = new System.Drawing.Size(65, 17);
            this.rdUnicode.TabIndex = 17;
            this.rdUnicode.Text = "Unicode";
            this.rdUnicode.UseVisualStyleBackColor = true;
            this.rdUnicode.CheckedChanged += new System.EventHandler(this.rdUnicode_CheckedChanged);
            // 
            // rdZ26
            // 
            this.rdZ26.AutoSize = true;
            this.rdZ26.Location = new System.Drawing.Point(12, 38);
            this.rdZ26.Name = "rdZ26";
            this.rdZ26.Size = new System.Drawing.Size(44, 17);
            this.rdZ26.TabIndex = 16;
            this.rdZ26.Text = "Z26";
            this.rdZ26.UseVisualStyleBackColor = true;
            this.rdZ26.CheckedChanged += new System.EventHandler(this.rdZ26_CheckedChanged);
            // 
            // rdSo
            // 
            this.rdSo.AutoSize = true;
            this.rdSo.Checked = true;
            this.rdSo.Location = new System.Drawing.Point(12, 12);
            this.rdSo.Name = "rdSo";
            this.rdSo.Size = new System.Drawing.Size(38, 17);
            this.rdSo.TabIndex = 15;
            this.rdSo.TabStop = true;
            this.rdSo.Text = "Số";
            this.rdSo.UseVisualStyleBackColor = true;
            this.rdSo.CheckedChanged += new System.EventHandler(this.rdSo_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "P";
            // 
            // txtP
            // 
            this.txtP.Enabled = false;
            this.txtP.Location = new System.Drawing.Point(568, 171);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(153, 20);
            this.txtP.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(508, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "D";
            // 
            // txtD
            // 
            this.txtD.ForeColor = System.Drawing.Color.Red;
            this.txtD.Location = new System.Drawing.Point(569, 259);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(153, 20);
            this.txtD.TabIndex = 5;
            // 
            // btnThamMa
            // 
            this.btnThamMa.Location = new System.Drawing.Point(607, 314);
            this.btnThamMa.Name = "btnThamMa";
            this.btnThamMa.Size = new System.Drawing.Size(75, 23);
            this.btnThamMa.TabIndex = 18;
            this.btnThamMa.Text = "Thám Mã";
            this.btnThamMa.UseVisualStyleBackColor = true;
            this.btnThamMa.Click += new System.EventHandler(this.btnThamMa_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 419);
            this.Controls.Add(this.btnThamMa);
            this.Controls.Add(this.rdUnicode);
            this.Controls.Add(this.rdZ26);
            this.Controls.Add(this.rdSo);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtBanRo);
            this.Controls.Add(this.txtBanMa);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.txtE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thám Mã RSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBanRo;
        private System.Windows.Forms.TextBox txtBanMa;
        private System.Windows.Forms.RadioButton rdUnicode;
        private System.Windows.Forms.RadioButton rdZ26;
        private System.Windows.Forms.RadioButton rdSo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Button btnThamMa;
    }
}