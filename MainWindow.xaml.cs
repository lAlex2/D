using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionStr = "Data Source=DESKTOP-B7DNMAF; Initial Catalog=Shop; User ID=Alex; Password=1; TrustServerCertificate=True";
                string cmd = "INSERT INTO Users (Login, TypeUsers, Phone, Password) VALUES (@D1, @D2, @D3, @D4)";
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    SqlCommand command = new SqlCommand(cmd, connection);
                    command.Parameters.AddWithValue("@D1", D1.Text);
                    command.Parameters.AddWithValue("@D2", D2.Text);
                    command.Parameters.AddWithValue("@D3", int.Parse(D3.Text));
                    command.Parameters.AddWithValue("@D4", int.Parse(D4.Text));
                    connection.Open();
                    MessageBox.Show("Успешно");
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
            // Public репозиторий не Private
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionStr1 = "Data Source=DESKTOP-B7DNMAF; Initial Catalog=Shop; User ID=Alex; Password=1; TrustServerCertificate=True";
            string cmd = "SELECT * FROM Users";
            SqlConnection connection1 = new SqlConnection(connectionStr1);
            SqlCommand command1 = new SqlCommand(cmd, connection1);
            command1.ExecuteNonQueryAsync();
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable("Users");
            adapter.Fill(dt);
            Test1.ItemsSource = dt.DefaultView;
            connection1.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (A4.Text == "1" && A5.Text == "1")
            {
                MessageBox.Show("True");
            }
            if (A4.Text == "2" && A5.Text == "2")
            {
                MessageBox.Show("True1");
            }
            string labelText = d3.Content.ToString().Trim();
            string textboxText = A5.Text.Trim();
                if (labelText == textboxText)
                {
                    MessageBox.Show("Текст совпадает с текстом в Label!", "Результат");
                }
                else
                {
                    MessageBox.Show("Текст не совпадает.", "Результат");
                }
            
            }
    }
}
