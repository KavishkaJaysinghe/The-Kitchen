using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using programing_project_EE3254.Views;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System.Windows.Markup;

namespace programing_project_EE3254.View
{
	/// <summary>
	/// Interaction logic for LoginView.xaml
	/// </summary>
	public partial class LoginView : Window
	{
		public LoginView()
		{
			InitializeComponent();
		}
		

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
				DragMove();
		}

		private void btnMinimize_Click(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}
		private void btnFull_Click(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				WindowState = WindowState.Normal;
			}
			else
			{
				WindowState = WindowState.Maximized;
			}
		}
		private void btnClose_Click(object sender, RoutedEventArgs e)
		{

			Application.Current.Shutdown();

		}
		private bool ValidateCredentials(string enteredUsername, string enteredPassword)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False"))
				{
					con.Open();

					using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM login WHERE User_Name = @Username AND Password = @Password", con))
					{
						cmd.Parameters.AddWithValue("@Username", enteredUsername);
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

		

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			string enteredUsername = txtUser.Text;
			string enteredPassword = txtPassword.Password;

			if (ValidateCredentials(enteredUsername, enteredPassword))
			{
				// Navigate to Page1 if credentials are valid
				var newForm = new MainView(); //create your new form.
				newForm.Show();
				this.Close();
			}
			else
			{
				MessageBox.Show("Invalid username or password");

				// Clear username and password fields
				txtUser.Clear();
				txtPassword.Clear();
			}
		}


		private void reset_Click(object sender, RoutedEventArgs e)
		{

			MainFrame.Content = new Page1();



		}

		private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
		{

		}
	}
}
