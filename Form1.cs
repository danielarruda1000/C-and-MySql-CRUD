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

            model.Name = textBox1.Text;
            model.Id = Convert.ToInt32(textBox2.Text);
            model.Balance =Convert.ToDouble(textBox3.Text);

            modelDAO.insertUser(model);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            userLoad();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            userLoad();
        }
    }
}
