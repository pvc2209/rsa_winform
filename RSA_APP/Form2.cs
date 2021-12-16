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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnThamMa_Click(object sender, EventArgs e)
        {
            bool hopLe = true;
            try
            {
                int E = int.Parse(txtE.Text);
                int N = int.Parse(txtN.Text);

                var result = Hacker.ThamMaPro(E, N);

                if (result.Item1 > 0)
                {
                    txtD.Text = result.Item1.ToString();
                    txtP.Text = result.Item2.ToString();
                    txtQ.Text = result.Item3.ToString();

                    try
                    {
                        if (rdSo.Checked)
                        {
                            int banMa = int.Parse(txtBanMa.Text);

                            if (banMa >= N)
                            {
                                MessageBox.Show("Bản mã phải nhỏ hơn n", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }


                            txtBanRo.Text = Hacker.DecodeNumber(banMa, result.Item1, N).ToString();
                        }
                        else if (rdZ26.Checked)
                        {
                            string banMa = txtBanMa.Text;

                            if (N != 26)
                            {
                                MessageBox.Show("Với Z26 - N phải bằng 26", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (!Regex.IsMatch(banMa, @"^[a-z]+$"))
                            {
                                MessageBox.Show("Bản mã chỉ chứa các ký tự thuộc Z26!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            txtBanRo.Text = Hacker.DecodeZ26(banMa, result.Item1, N);
                        }
                        else if (rdUnicode.Checked)
                        {
                            string banMa = txtBanMa.Text;
                            txtBanRo.Text = Hacker.DecodeUnicode(banMa, result.Item1, N);
                        }

                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show("Bản mã không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } 
                else
                {
                    hopLe = false;
                }
            }
            catch (FormatException ex)
            {
                hopLe = false;
            }

            if (!hopLe)
            {
                MessageBox.Show("Error - Khóa không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetAll()
        {
            txtBanMa.Clear();
            txtBanRo.Clear();
            txtE.Clear();
            txtN.Clear();
            txtP.Clear();
            txtQ.Clear();
            txtD.Clear();
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
