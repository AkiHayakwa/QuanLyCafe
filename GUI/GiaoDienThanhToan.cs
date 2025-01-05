using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GiaoDienThanhToan : Form
    {
        private int maHoaDon;
        private float tongTien;
        public GiaoDienThanhToan(int maHoaDon , float tongTien)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon; 
            this.tongTien = tongTien;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String s = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            labelTime.Text = s;

            if (!string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.Text.Substring(1) + this.Text[0];
            }
        }

        private void labelInvoiceId_Click(object sender, EventArgs e)
        {

        }

        private void GiaoDienThanhToan_Load(object sender, EventArgs e)
        {
            labelInvoiceId.Text = maHoaDon.ToString();
            textBoxCash.Text = tongTien.ToString("0.00");
            CalculateChange();
        }

        private void textBoxCustomerCash_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            try
            {
                float customerCash = string.IsNullOrEmpty(textBoxCustomerCash.Text) ? 0 : float.Parse(textBoxCustomerCash.Text);
                float totalAmount = string.IsNullOrEmpty(textBoxCash.Text) ? 0 : float.Parse(textBoxCash.Text);
                float discount = string.IsNullOrEmpty(textBoxDiscount.Text) ? 0 : float.Parse(textBoxDiscount.Text);
                float amountAfterDiscount = totalAmount - (totalAmount * (discount / 100));  
                textBoxCash1.Text = amountAfterDiscount.ToString("0.00"); 
                float change = customerCash - amountAfterDiscount;
                textBoxChange.Text = change.ToString("0.00");
            } catch (Exception ex) {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCash_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void textBoxChange_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }
    }
}

