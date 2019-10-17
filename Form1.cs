using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dataBaseCRUD
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                           
            var model = new userModel();
            var modelDAO = new userDAO();

            try
            {


                model.Name = textBox1.Text;
                model.Id = Convert.ToInt32(textBox2.Text);
                model.Balance = Convert.ToDouble(textBox3.Text);

                modelDAO.insertUser(model);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

                userLoad();
            }catch(Exception ex)
            {
                
                MessageBox.Show("Dados incompletos");
            }
                           
        }

        public void userLoad()
        {
            userDAO cmd = new userDAO();
            List<userModel> users = new List<userModel>();

            users = cmd.loadAll();

            dataGridView1.Rows.Clear();
            foreach(userModel u in users)
            {

                dataGridView1.Rows.Add(u.Name.ToString(), u.Id.ToString(), u.Balance.ToString());

            }
        }

        public void getUserFromGrid(DataGridViewCellEventArgs e)
        {
            try
            {
                int currentIndex = e.RowIndex;
                DataGridViewRow currentCell = dataGridView1.Rows[currentIndex];
                textBox1.Text = currentCell.Cells[0].Value.ToString();
                textBox2.Text = currentCell.Cells[1].Value.ToString();
                textBox3.Text = currentCell.Cells[2].Value.ToString();
                textBox2.Enabled = false;
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.Enabled = true;
            }
        }

        public userModel inputedUser()
        {
            var modelData = new userModel();

            modelData.Name = textBox1.Text;
            modelData.Id = Convert.ToInt32(textBox2.Text);
            modelData.Balance = Convert.ToDouble(textBox3.Text);

            return modelData;
        }

        public void cleanTextBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox2.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e){}

        private void button2_Click(object sender, EventArgs e)
        {
            userLoad();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var model =new userDAO();
            model.updateUser(inputedUser());
            userLoad();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getUserFromGrid(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var model = new userDAO();
            model.deleteUser(inputedUser().Id);
            userLoad();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cleanTextBox();
        }
    }
}
