using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
using System.Xml.Linq;

namespace programing_project_EE3254
{
	/// <summary>
	/// Interaction logic for Page1.xaml
	/// </summary>
	public partial class Page1 : Page
	{
		public Page1()
		{
			InitializeComponent();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
		private bool ValidateCredentials(string enteredPassword)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False"))
				{
					con.Open();

					using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Admin WHERE  Admin_Password = @Password", con))
					{
						cmd.Parameters.AddWithValue("@Password", enteredPassword);

						int count = (int)cmd.ExecuteScalar();

						return count > 0;
					}
				}
			}
			catch (SqlException)
			{
				MessageBox.Show("An error occurred during login. Please try again later.");
				return false;
			}
		}
		private void save_Click(object sender, RoutedEventArgs e)
		{
			{
				string name = txtUsername.Text;
				string Password = txtPassword.Text;
				string Admin_Password = txtAdminpass.Password;
				string connectionString = @"Data Source=LAPTOP-NBUFH9LE\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";

				if (ValidateCredentials(Admin_Password))
				{
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						string query = "INSERT INTO login (User_Name, Password) VALUES (@User_Name,@Password)";
						SqlCommand command = new SqlCommand(query, connection);

						command.Parameters.AddWithValue("@User_Name", name);
						command.Parameters.AddWithValue("@Password", Password);

						try
						{
							connection.Open();
							int rowsAffected = command.ExecuteNonQuery();
							MessageBox.Show($"{rowsAffected} row(s) inserted successfully.");
						}
						catch (SqlException ex)
						{
							MessageBox.Show($"Error: {ex.Message}");
						}

					}
				}
				else
				{
					MessageBox.Show("An error occurred during login.Access only in the administrator");
				}
			}
		}
		private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
		{

		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			this.NavigationService.Navigate(new Uri("Page5.xaml", UriKind.Relative));
		}
    }
}
