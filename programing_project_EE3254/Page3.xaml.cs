using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace programing_project_EE3254
{
	/// <summary>
	/// Interaction logic for Page3.xaml
	/// </summary>

	public partial class Page3 : Page
	{
		public Page3()
		{
			InitializeComponent();
			DataContext = new YourViewModel();
			

		}

		SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False");

		private void cb_Checked(object sender, RoutedEventArgs e)
		{




		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			
		}
		
		private void search_txt2_GotFocus(object sender, RoutedEventArgs e)
		{
			// Hide the hint text when the TextBox gets focus
			hintTextBlock.Visibility = Visibility.Collapsed;
		}

		private void search_txt2_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(search_txt2.Text))
			{
				// Show the hint text if the TextBox is empty and loses focus
				hintTextBlock.Visibility = Visibility.Visible;
			}
		}


		public void LoadGrid4()
		{
			string query = "SELECT Name, Email, PhoneNo, Addres FROM Customerdet WHERE PhoneNo = @SearchValue1";

			



			SqlCommand cmd = new SqlCommand(query, con);

			// Add a parameter to avoid SQL injection
			cmd.Parameters.AddWithValue("@SearchValue1", search_txt2.Text);

			DataTable dt = new DataTable();
			con.Open();
			SqlDataReader sdr = cmd.ExecuteReader();
			dt.Load(sdr);
			con.Close();


			datagr.ItemsSource = dt.DefaultView;


		}

		private void Search(object sender, RoutedEventArgs e)
		{
			LoadGrid4();
		}
		public class Module
		{
			public string Name { get; set; }
			public string Address { get; set; }
			public string Email { get; set; }
			public string Phone_Number { get; set; }

		}

		public class YourViewModel
		{

			public ObservableCollection<Module> M { get; set; }

			public YourViewModel()
			{
				M = new ObservableCollection<Module>();

				// Connection string to your SQL Server database
				string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";

				// SQL query to retrieve data from the database
				string query = "SELECT Name, Addres,Email,PhoneNo FROM Customerdet";

				// Create a SqlConnection object
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					// Create a SqlCommand object with the query and connection
					SqlCommand command = new SqlCommand(query, connection);

					try
					{
						// Open the connection
						connection.Open();

						// Execute the query and get a SqlDataReader
						SqlDataReader reader = command.ExecuteReader();

						// Read the data and add it to the ObservableCollection
						while (reader.Read())
						{
							Module module = new Module();
							module.Name = reader["Name"].ToString();
							module.Address = reader["Addres"].ToString();
							module.Email = reader["Email"].ToString();
							module.Phone_Number = reader["PhoneNo"].ToString();
							;
							M.Add(module);
						}

						// Close the reader
						reader.Close();
					}
					catch (Exception ex)
					{
						// Handle any exceptions
						Console.WriteLine(ex.Message);
					}
				}

			}
		}


		private void MainFrame1_Navigated(object sender, NavigationEventArgs e)
		{

		}
	}


}