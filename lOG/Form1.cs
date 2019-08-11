using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lOG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSEARCH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtSEARCH.Text))
                {
                    this.empTableAdapter.Fill(this.appData.Emp);
                    empBindingSource.DataSource = this.appData.Emp;
                    //dataGridView1.DataSource = empBindingSource;
                }
                 
                else
                {
                    object txtsearch = null;
                    var query = from o in this.appData.Emp
                                
                               
                                select o;
                    
                }

            }

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("", "Messege", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    empBindingSource.RemoveCurrent();
            }

        }

        private void btnBROWSE_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNEW_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = true;
                txtNAME.Focus();
                this.appData.Emp.AddEmpRow(this.appData.Emp.NewEmpRow());
                empBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                empBindingSource.ResetBindings(false);
            }
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            txtNAME.Focus();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                empBindingSource.EndEdit();
                empTableAdapter.Update(this.appData.Emp);
                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                empBindingSource.ResetBindings(false);
            }

        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            empBindingSource.ResetBindings(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'appData.Emp' table. You can move, or remove it, as needed.
            this.empTableAdapter.Fill(this.appData.Emp);
            this.empTableAdapter.Fill(this.appData.Emp);
            empBindingSource.DataSource = this.appData.Emp;
        }
    }
}
