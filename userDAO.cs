using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dataBaseCRUD
{
    public class userDAO 
    {

        private MySqlConnection connection;

        private string dbWay = "SERVER=localhost;DATABASE=bank;UID=root;PASSWORD=root;";
      
        public void insertUser(userModel u)
        {
            try
            {
                connection = new MySqlConnection(dbWay);
                connection.Open();

                string insert = "INSERT INTO users(userName,id,saldo) VALUES('" + u.Name + "','" + u.Id + "','" + u.Balance + "')";

                MySqlCommand cmd = new MySqlCommand(insert, connection);
                cmd.ExecuteNonQuery();

                connection.Close();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void updateUser(userModel u)
        {
            try
            {
                connection = new MySqlConnection(dbWay);
                connection.Open();

                //string updade = "UPDATE users SET userName=" +"'"+u.Name+"'"+ ",saldo = "+" ' "+u.Balance+".0' WHERE id = "+u.Id;
                string update = "UPDATE users SET userName='"+u.Name+"',saldo="+u.Balance+" WHERE id="+u.Id+"";
                


                MySqlCommand cmd = new MySqlCommand(update, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteUser(int userId)
        {
            try
            {
                connection = new MySqlConnection(dbWay);
                connection.Open();

                string delete = "DELETE FROM users WHERE id="+userId+"";

                var cmd = new MySqlCommand(delete, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<userModel> loadAll()
        {
            List<userModel> users = new List<userModel>();

            connection = new MySqlConnection(dbWay);
            connection.Open();
            string query = "SELECT * FROM users";

            MySqlCommand cmd = new MySqlCommand(query, connection);
                    
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string username = reader["userName"].ToString();
                double balance = Convert.ToDouble(reader["saldo"]);

                userModel currentUser = new userModel(username,id,balance);

                users.Add(currentUser);
            }

            connection.Close();

            return users;
        }

    }
}
