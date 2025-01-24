using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Login
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Data Source=HIRON\HIRON;Initial Catalog=AracGaleri;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string username = textBox1.Text;
            string password_ = textBox2.Text;

            using (SqlConnection connection = new SqlConnection(connectionString)) { 

                try
                {
                connection.Open();

                    string query = "Select COUNT(*) from Kullanicilar where username=@username and password_=@password_";    //COUNT(*) 0 veya 1 döndüreceği için 
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username",username);
                        command.Parameters.AddWithValue("@password_", password_);

                        int sonuc = (int)command.ExecuteScalar();
                        if (sonuc > 0)
                        {
                            Form2 form2 = new Form2();
                            form2.Show();

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre yanlış");
                        }

                    }       

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            

        }
        }

    }
}
