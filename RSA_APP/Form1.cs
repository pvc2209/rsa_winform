using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA_APP
{
    public partial class RSAFORM : Form
    {
        private RSA personA;
        private RSA personB;

        public RSAFORM()
        {
            InitializeComponent();

            personA = new RSA();
            personB = new RSA();
        }

        private void ResetColor()
        {
            txtBanRoA.ForeColor = Color.Black;
            txtBanMaA.ForeColor = Color.Black;
            txtBanRoB.ForeColor = Color.Black;
            txtBanMaB.ForeColor = Color.Black;
        }

        private void btnTaoKhoaA_Click(object sender, EventArgs e)
        {
            if (rdSo.Checked)
            {
                personA.TaoKhoaNumber();
            }
            else if (rdZ26.Checked)
            {
                personA.TaoKhoaZ26();
            }
            else if (rdUnicode.Checked)
            {
                personA.TaoKhoaUnicode();
            }

            txtEA.Text = personA.MyE.ToString();
            txtNA.Text = personA.MyN.ToString();
            txtDA.Text = personA.MyD.ToString();
        }

        private void btnTaoKhoaB_Click(object sender, EventArgs e)
        {
            if (rdSo.Checked)
            {
                personB.TaoKhoaNumber();
            }
            else if (rdZ26.Checked)
            {
                personB.TaoKhoaZ26();
            }
            else if (rdUnicode.Checked)
            {
                personB.TaoKhoaUnicode();
            }

            txtEB.Text = personB.MyE.ToString();
            txtNB.Text = personB.MyN.ToString();
            txtDB.Text = personB.MyD.ToString();
        }

        private void btnMaHoaA_Click(object sender, EventArgs e)
        {
            if (!CheckKhoaB())
            {
                MessageBox.Show("Khóa công khai của B không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblEB.Text = personB.MyE.ToString();
            lblNB.Text = personB.MyN.ToString();
            personA.SetPartnerEN(personB.MyE, personB.MyN);

            try
            {
                if (rdSo.Checked)
                {
                    int banRoA = int.Parse(txtBanRoA.Text);
                    if (banRoA >= personA.GetPartnerN)
                    {
                        MessageBox.Show("Bản rõ phải nhỏ hơn n!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtBanMaA.Text = personA.EncodeNumber(banRoA).ToString();
                }
                else if (rdZ26.Checked)
                {
                    string banRoA = txtBanRoA.Text;

                    if (!Regex.IsMatch(banRoA, @"^[a-z]+$"))
                    {
                        MessageBox.Show("Bản rõ A chỉ chứa các ký tự thuộc Z26!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    txtBanMaA.Text = personA.EncodeZ26(banRoA);
                }
                else if (rdUnicode.Checked)
                {
                    string banRoA = txtBanRoA.Text;

                    txtBanMaA.Text = personA.EncodeUnicode(banRoA);
                }


                ResetColor();
                txtBanMaA.ForeColor = Color.Red;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Bản rõ A không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGuiA_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdSo.Checked)
                {
                    int banMaA = int.Parse(txtBanMaA.Text);
                    txtBanRoB.Text = personB.DecodeNumber(banMaA).ToString();
                }
                else if (rdZ26.Checked)
                {
                    string banMaA = txtBanMaA.Text;
                    txtBanRoB.Text = personB.DecodeZ26(banMaA);
                }
                else if (rdUnicode.Checked)
                {
                    string banMaA = txtBanMaA.Text;
                    txtBanRoB.Text = personB.DecodeUnicode(banMaA);
                }


                ResetColor();
                txtBanRoB.ForeColor = Color.Red;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Bản mã A không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnMaHoaB_Click(object sender, EventArgs e)
        {
            if (!CheckKhoaA())
            {
                MessageBox.Show("Khóa công khai của A không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblEA.Text = personA.MyE.ToString();
            lblNA.Text = personA.MyN.ToString();
            personB.SetPartnerEN(personA.MyE, personA.MyN);

            try
            {
                if (rdSo.Checked)
                {
                    int banRoB = int.Parse(txtBanRoB.Text);

                    if (banRoB >= personB.GetPartnerN)
                    {
                        MessageBox.Show("Bản rõ phải nhỏ hơn n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtBanMaB.Text = personB.EncodeNumber(banRoB).ToString();
                }
                else if (rdZ26.Checked)
                {
                    string banRoB = txtBanRoB.Text;

                    if (!Regex.IsMatch(banRoB, @"^[a-z]+$"))
                    {
                        MessageBox.Show("Bản rõ B chỉ chứa các ký tự thuộc Z26!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtBanMaB.Text = personB.EncodeZ26(banRoB);
                }
                else if (rdUnicode.Checked)
                {
                    string banRoB = txtBanRoB.Text;

                    txtBanMaB.Text = personB.EncodeUnicode(banRoB);
                }




                ResetColor();
                txtBanMaB.ForeColor = Color.Red;

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Bản rõ B không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuiB_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdSo.Checked)
                {
                    int banMaB = int.Parse(txtBanMaB.Text);
                    txtBanRoA.Text = personA.DecodeNumber(banMaB).ToString();
                }
                else if (rdZ26.Checked)
                {
                    string banMaB = txtBanMaB.Text;
                    txtBanRoA.Text = personA.DecodeZ26(banMaB);
                }
                else if (rdUnicode.Checked)
                {
                    string banMaB = txtBanMaB.Text;
                    txtBanRoA.Text = personA.DecodeUnicode(banMaB);
                }

                ResetColor();
                txtBanRoA.ForeColor = Color.Red;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Bản mã B không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtEA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                personA.MyE = int.Parse(txtEA.Text);
            }
            catch (OverflowException ex)
            {
                personA.MyE = 0;
                txtEA.Text = "0";

                MessageBox.Show("Error - Số quá lớn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                // Không cho phép nhập chữ vào textbox
                txtEA.Text = "";
            }

            lblEA.Text = txtEA.Text;
        }

        private void txtNA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                personA.MyN = int.Parse(txtNA.Text);
            }
            catch (OverflowException ex)
            {
                personA.MyN = 0;
                txtNA.Text = "0";

                MessageBox.Show("Error - Số quá lớn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                txtNA.Text = "";
            }

            lblNA.Text = txtNA.Text;
        }

        private void txtDA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                personA.MyD = int.Parse(txtDA.Text);
            }
            catch (OverflowException ex)
            {
                personA.MyD = 0;
                txtDA.Text = "0";

                MessageBox.Show("Error - Số quá lớn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                txtDA.Text = "";
            }
        }

        private void txtEB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                personB.MyE = int.Parse(txtEB.Text);
            }
            catch (OverflowException ex)
            {
                personB.MyE = 0;
                txtEB.Text = "0";

                MessageBox.Show("Error - Số quá lớn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                txtEB.Text = "";
            }

            lblEB.Text = txtEB.Text;
        }

        private void txtNB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                personB.MyN = int.Parse(txtNB.Text);
            }
            catch (OverflowException ex)
            {
                personB.MyN = 0;
                txtNB.Text = "0";

                MessageBox.Show("Error - Số quá lớn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                txtNB.Text = "";
            }

            lblNB.Text = txtNB.Text;
        }

        private void txtDB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                personB.MyD = int.Parse(txtDB.Text);
            }
            catch (OverflowException ex)
            {
                personB.MyD = 0;
                txtDB.Text = "0";

                MessageBox.Show("Error - Số quá lớn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                txtDB.Text = "";
            }
        }


        private bool CheckKhoaB()
        {
            bool hopLe = true;
            try
            {
                int e = int.Parse(txtEB.Text);
                int n = int.Parse(txtNB.Text);
                int d = int.Parse(txtDB.Text);

                if (!RSA.KiemTraKhoa(e, n, d))
                {
                    hopLe = false;
                }
            }
            catch (FormatException ex)
            {
                hopLe = false;
            }

            return hopLe;
        }


        private bool CheckKhoaA()
        {
            bool hopLe = true;
            try
            {
                int e = int.Parse(txtEA.Text);
                int n = int.Parse(txtNA.Text);
                int d = int.Parse(txtDA.Text);

                if (!RSA.KiemTraKhoa(e, n, d))
                {
                    hopLe = false;
                }
            }
            catch (FormatException ex)
            {
                hopLe = false;
            }

            return hopLe;
        }

        private void btnKiemTraKhoaA_Click(object sender, EventArgs e)
        {
            if (!CheckKhoaA())
            {
                MessageBox.Show("Khóa không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Khóa hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnKiemTraKhoaB_Click(object sender, EventArgs e)
        {
            if (!CheckKhoaB())
            {
                MessageBox.Show("Khóa không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Khóa hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ResetAll()
        {
            txtBanRoA.Text = "";
            txtBanMaA.Text = "";
            txtEA.Text = "";
            txtNA.Text = "";
            txtDA.Text = "";
            lblEB.Text = "";
            lblNB.Text = "";

            txtBanRoB.Text = "";
            txtBanMaB.Text = "";
            txtEB.Text = "";
            txtNB.Text = "";
            txtDB.Text = "";
            lblEA.Text = "";
            lblNA.Text = "";

            ResetColor();
        }

        private void rdSo_CheckedChanged(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void rdZ26_CheckedChanged(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void rdUnicode_CheckedChanged(object sender, EventArgs e)
        {
            ResetAll();
        }
    }
}
