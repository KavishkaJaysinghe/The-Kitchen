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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace programing_project_EE3254
{
	/// <summary>
	/// Interaction logic for Page6.xaml
	/// </summary>
	public partial class Page6 : Page
	{
		public Page6()
		{
			InitializeComponent();
			LoadDestinationData();
		}
		private void Search(object sender, RoutedEventArgs e)
		{
			LoadDestinationData1();
		}
		
			private void Search_1(object sender, RoutedEventArgs e)
		{
			LoadDestinationData2();
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
		

		private void search_txt3_GotFocus(object sender, RoutedEventArgs e)
		{
			// Hide the hint text when the TextBox gets focus
			hintTextBlock_1.Visibility = Visibility.Collapsed;
		}

		private void search_txt3_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(search_txt3.Text))
			{
				// Show the hint text if the TextBox is empty and loses focus
				hintTextBlock_1.Visibility = Visibility.Visible;
			}
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{

		}
		private void LoadDestinationData()
		{
			try
			{
				// Connection string to your SQL Server database
				string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";

				// Query to select data from your SQL database
				string query = "SELECT * FROM _item";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					// Open the database connection
					connection.Open();

					// Create a SQL command object with the query and connection
					SqlCommand command = new SqlCommand(query, connection);

					// Create a data adapter to fill a data table with the results of the command
					SqlDataAdapter adapter = new SqlDataAdapter(command);

					// Create a data table to hold the data retrieved from the database
					DataTable dataTable = new DataTable();

					// Fill the data table with the data from the database
					adapter.Fill(dataTable);

					// Bind the data table to the sourceDataGrid
					sourceDataGrid.ItemsSource = dataTable.DefaultView;
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions that occur during data loading
				MessageBox.Show("Error loading data: " + ex.Message);
			}
		}
		private void LoadDestinationData1()
		{
			try
			{
				// Connection string to your SQL Server database
				string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";

				string Name = search_txt2.Text;
				// Query to select data from your SQL database
				string query = "SELECT * FROM _item where Name = '" + Name + "'";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					// Open the database connection
					connection.Open();

					// Create a SQL command object with the query and connection
					SqlCommand command = new SqlCommand(query, connection);

					// Create a data adapter to fill a data table with the results of the command
					SqlDataAdapter adapter = new SqlDataAdapter(command);

					// Create a data table to hold the data retrieved from the database
					DataTable dataTable = new DataTable();

					// Fill the data table with the data from the database
					adapter.Fill(dataTable);

					// Bind the data table to the sourceDataGrid
					sourceDataGrid.ItemsSource = dataTable.DefaultView;
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions that occur during data loading
				MessageBox.Show("Error loading data: " + ex.Message);
			}
		}
		private void LoadDestinationData2()
		{
			try
			{
				// Connection string to your SQL Server database
				string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";

				string Name = search_txt3.Text;
				// Query to select data from your SQL database
				string query = "SELECT * FROM _item where ID = '" + Name + "'";

				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					// Open the database connection
					connection.Open();

					// Create a SQL command object with the query and connection
					SqlCommand command = new SqlCommand(query, connection);

					// Create a data adapter to fill a data table with the results of the command
					SqlDataAdapter adapter = new SqlDataAdapter(command);

					// Create a data table to hold the data retrieved from the database
					DataTable dataTable = new DataTable();

					// Fill the data table with the data from the database
					adapter.Fill(dataTable);

					// Bind the data table to the sourceDataGrid
					sourceDataGrid.ItemsSource = dataTable.DefaultView;
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions that occur during data loading
				MessageBox.Show("Error loading data: " + ex.Message);
			}
		}
		private void price_txt1_GotFocus(object sender, RoutedEventArgs e)
		{
			// Hide the hint text when the TextBox gets focus
			CatagoryTextBlock.Visibility = Visibility.Collapsed;
		}

		private void price_txt1_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(CatagoryTextBox.Text))
			{
				// Show the hint text if the TextBox is empty and loses focus
				CatagoryTextBlock.Visibility = Visibility.Visible;
			}
		}
		private void price_txt2_GotFocus(object sender, RoutedEventArgs e)
		{
			// Hide the hint text when the TextBox gets focus
			NameTextBlock.Visibility = Visibility.Collapsed;
		}

		private void price_txt2_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(NameTextBox.Text))
			{
				// Show the hint text if the TextBox is empty and loses focus
				NameTextBlock.Visibility = Visibility.Visible;
			}
		}
		private void price_txt3_GotFocus(object sender, RoutedEventArgs e)
		{
			// Hide the hint text when the TextBox gets focus
			priceTextBlock.Visibility = Visibility.Collapsed;
		}

		private void price_txt3_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(priceTextBox.Text))
			{
				// Show the hint text if the TextBox is empty and loses focus
				priceTextBlock.Visibility = Visibility.Visible;
			}
		}

		private void CatagoryTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}




		private void ButtonEdit_Click(object sender, RoutedEventArgs e)
		{
			CatagoryTextBlock.Visibility = Visibility.Collapsed;
			NameTextBlock.Visibility = Visibility.Collapsed;
			priceTextBlock.Visibility = Visibility.Collapsed;

			if (sourceDataGrid.SelectedItem != null)
			{
				// Change the background color of the button temporarily
				if (sender is Button button)
				{
					// Store the original background color
					Brush originalBackground = button.Background;

					// Change the background color temporarily
					button.Background = Brushes.Gold;

					// Restore the original background color after a short delay
					DispatcherTimer timer = new DispatcherTimer();
					timer.Interval = TimeSpan.FromSeconds(1); // Change the duration as desired
					timer.Tick += (s, args) =>
					{
						button.Background = originalBackground;
						timer.Stop();
					};
					timer.Start();
				}

				// Retrieve selected item from the DataGrid's ItemsSource
				var selectedItem = sourceDataGrid.SelectedItem;

				// Assuming selectedItem is of type DataRowView
				if (selectedItem is DataRowView)
				{
					DataRowView selectedRow = selectedItem as DataRowView;

					// Extract values from the selected row
					string category = selectedRow["Catagry"].ToString();
					string Name = selectedRow["Name"].ToString();
					decimal Price = Convert.ToDecimal(selectedRow["Price"]);


					// Populate your TextBoxes with the retrieved values
					CatagoryTextBox.Text = category;
					NameTextBox.Text = Name;
					priceTextBox.Text = Price.ToString();

				}
			}
		}

		private void save_Click(object sender, RoutedEventArgs e)
		{
			string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";

			try
			{
				if (!string.IsNullOrEmpty(CatagoryTextBox.Text) &&
			!string.IsNullOrEmpty(NameTextBox.Text) &&
			!string.IsNullOrEmpty(priceTextBox.Text))
				{
					using (SqlConnection connection = new SqlConnection(connectionString))
					{
						connection.Open();

						// Start building the query
						string query = "UPDATE _item SET ";

						// Check each field and add it to the query only if it has a non-null value
						if (!string.IsNullOrEmpty(CatagoryTextBox.Text))
							query += "Catagry = '" + CatagoryTextBox.Text + "', ";

						if (!string.IsNullOrEmpty(NameTextBox.Text))
							query += "Name = '" + NameTextBox.Text + "', ";

						if (!string.IsNullOrEmpty(priceTextBox.Text))
							query += "price = '" + priceTextBox.Text + "', ";

						// Remove the trailing comma
						query = query.TrimEnd(',', ' ');

						DataRowView selectedRow = (DataRowView)sourceDataGrid.SelectedItem;

						int id = (int)selectedRow["ID"];

						// Add the WHERE clause with the ID
						query += " WHERE ID = '" + id + "'";

						// Create SqlCommand object with the dynamic query
						SqlCommand cmd = new SqlCommand(query, connection);

						// Execute the query
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadDestinationData();
							CatagoryTextBox.Text = "";
							NameTextBox.Text = "";
							priceTextBox.Text = "";
							CatagoryTextBlock.Visibility = Visibility.Visible;
							NameTextBlock.Visibility = Visibility.Visible;
							priceTextBlock.Visibility = Visibility.Visible;
						}
						else
						{
							MessageBox.Show("No records updated", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						}
					}

				}
				else
				{
					MessageBox.Show("Please fill in all text boxes", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			catch (SqlException ex)
			{
				MessageBox.Show("SQL Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			
		}

	}
}
