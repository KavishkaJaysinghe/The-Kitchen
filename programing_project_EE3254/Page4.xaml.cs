using MySqlX.XDevAPI.Common;
using programing_project_EE3254.Views;
using ServiceStack;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace programing_project_EE3254
{
	public partial class Page4 : Page
	{
		private int currentImageIndex = 0;
		private string[] imagePaths = { "/Images/1.png", "/Images/2.png", "/Images/3.png" };
		private DispatcherTimer timer;
		private DataTable data;

		private DependencyPropertyChangedEventArgs nameof(string totalSales)
		{
			throw new NotImplementedException();
		}

		public Page4(DataTable data)
		{
			InitializeComponent();
			LoadDestinationData(data);
			DataContext = this;
			LoadSum();
			Button_Appetizers(null, null);

			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(6); // Change image every 3 seconds
			timer.Tick += Timer_Tick;
			timer.Start();

			// Display the initial image
			DisplayImage();
		}
		private void Timer_Tick(object sender, EventArgs e)
		{
			// Change the current image index
			currentImageIndex = (currentImageIndex + 1) % imagePaths.Length;

			// Display the new image
			DisplayImage();
		}
		private void DisplayImage()
		{
			string imagePath = imagePaths[currentImageIndex];
			BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Relative));
			imageControl.Source = bitmapImage;
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
		private void LoadDestinationData(DataTable data)
		{
			try
			{
				// Connection string to your SQL Server database
				string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";

				// Query to select data from your SQL database
				string query = "SELECT * FROM NewBill";

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
					datagr.ItemsSource = dataTable.DefaultView;
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions that occur during data loading
				MessageBox.Show("Error loading data: " + ex.Message);
			}
		}
		private void Bill_txt1_GotFocus(object sender, RoutedEventArgs e)
		{
			// Hide the hint text when the TextBox gets focus
			CatagoryTextBlock.Visibility = Visibility.Collapsed;
		}

		private void Bill_txt1_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(CatagoryTextBox.Text))
			{
				// Show the hint text if the TextBox is empty and loses focus
				CatagoryTextBlock.Visibility = Visibility.Visible;
			}
		}
		private void LoadDestinationData()
		{
			try
			{
				// Connection string to your SQL Server database
				string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";
				string Bill_No = CatagoryTextBox.Text;
				// Query to select data from your SQL database
				string query = "SELECT Name, Price, Bill_No FROM sale where Bill_No = '" + Bill_No + "'";

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
					datagr.ItemsSource = dataTable.DefaultView;
				}
			}
			catch (Exception ex)
			{
				// Handle any exceptions that occur during data loading
				MessageBox.Show("Error loading data: " + ex.Message);
			}
		}

		private void LoadSum()
		{
			string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";
			string query = "SELECT SUM(Price) FROM NewBill";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				connection.Open();

				// ExecuteScalar is used to get the single value result (in this case, the sum)
				object result = command.ExecuteScalar();

				if (result != null && result != DBNull.Value)
				{
					UpdateSumText("   TOTLE = Rs." + result.ToString());
				}
				else
				{
					UpdateSumText("   TOTEL = Rs.0.00");
				}
			}
		}
		
		private void Add_discount(object sender, RoutedEventArgs e)
		{
			LoadDestinationData();


		}


		private void UpdateSumText(string text)
		{
			// Make sure to invoke on UI thread
			Dispatcher.Invoke(() => { sumTextBlock.Text = text; });
		}

		// Button1_Click can be used to refresh the sum on button click
		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			LoadSum(); // Reload the sum value
		}




		private void Button_Appetizers(object sender, RoutedEventArgs e)
		{
			MainFrame3.Content = new pages.appetizer();
		}

		private void ButtonEntrees_Click(object sender, RoutedEventArgs e)
		{
			MainFrame3.Content = new pages.Entress();
		}
		private void btnadd_Click(object sender, RoutedEventArgs e)
		{
			LoadDestinationData(data);
			LoadSum();
		}
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{

			if (datagr.SelectedItem != null)
			{
				LoadSum();
				// Assuming you have established a connection to your SQL database
				using (SqlConnection connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False"))
				{
					connection.Open();

					// Retrieve selected row data from the DataGrid
					DataRowView selectedRow = (DataRowView)datagr.SelectedItem;

					// Check if the "ID" column exists and is not null
					if (selectedRow.Row.Table.Columns.Contains("ID") && selectedRow["ID"] != DBNull.Value)
					{
						int primaryKeyValue = (int)selectedRow["ID"];

						string deleteQuery = "DELETE FROM NewBill WHERE ID = @PrimaryKeyValue";
						SqlCommand command = new SqlCommand(deleteQuery, connection);
						command.Parameters.AddWithValue("@PrimaryKeyValue", primaryKeyValue);

						try
						{
							int rowsAffected = command.ExecuteNonQuery();
							if (rowsAffected > 0)
							{
								LoadDestinationData(data);
								// Optionally, refresh the DataGrid to reflect the changes
								// datagr.ItemsSource = GetData(); // You need to implement GetData() to fetch data again
							}
							else
							{
								MessageBox.Show("Record not found or unable to delete.");
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error deleting record: " + ex.Message);
						}
					}

				}
				LoadSum();
			}

		}

		

		public void MoveDataFromBillToSale()
		{
			string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";
			string sql = "INSERT INTO sale (Name, Custermer_ID, Price, Bill_No) SELECT Name, Cus_ID, Price, Bill_NO FROM NewBill;";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(sql, connection);
				try
				{
					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();
					Console.WriteLine($"{rowsAffected} row(s) inserted.");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error: " + ex.Message);
				}
			}
		}

		public void UpdateNewBillWithLastBillNo()
		{
			string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";
			string selectLastBillNoQuery = "SELECT MAX(Bill_No) FROM sale";
			string updateNewBillQuery = "UPDATE NewBill SET Bill_No = @BillNo WHERE Bill_No IS NULL";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand selectLastBillNoCommand = new SqlCommand(selectLastBillNoQuery, connection);
				SqlCommand updateNewBillCommand = new SqlCommand(updateNewBillQuery, connection);

				try
				{
					connection.Open();

					// Execute the query to retrieve the last Bill_No from the sale table
					object result = selectLastBillNoCommand.ExecuteScalar();

					// Increment the lastBillNo by 1
					int lastBillNo = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1;

					// Set the parameter value for the update query
					updateNewBillCommand.Parameters.AddWithValue("@BillNo", lastBillNo);

					// Execute the update query
					int rowsAffected = updateNewBillCommand.ExecuteNonQuery();

					Console.WriteLine($"{rowsAffected} row(s) updated with the last Bill_No + 1: {lastBillNo}");
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error: " + ex.Message);
				}
			}
		}


		private void ButtonDesserts_Click(object sender, RoutedEventArgs e)
		{
			MainFrame3.Content = new pages.Desserts();
		}

		private void ButtonSide_Dishes_Click(object sender, RoutedEventArgs e)
		{
			MainFrame3.Content = new pages.Side_Dishes();
		}

		private void ButtonSalads_Click(object sender, RoutedEventArgs e)
		{
			MainFrame3.Content = new pages.Salads();
		}

		private void ButtonDrink_Click(object sender, RoutedEventArgs e)
		{
			MainFrame3.Content = new pages.Drink();
		}

		private void ButtonAdd_item_Click(object sender, RoutedEventArgs e)
		{
			MainFrame3.Content = new pages.Add_item();
		}
		
		private void ButtonContityIncres_Click(object sender, RoutedEventArgs e)
		{
			MainFrame3.Content = new pages.Add_item();
		}
		private void ButtonContityDicres_Click(object sender, RoutedEventArgs e)
		{
			MainFrame3.Content = new pages.Add_item();
		}

		private void DeleteDataFromTable(string tableName)
		{
			
			string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					// Construct the SQL DELETE command to delete all rows from the table
					string deleteCommandText = $"DELETE FROM {tableName}";

					using (SqlCommand command = new SqlCommand(deleteCommandText, connection))
					{
						// Execute the DELETE command
						int rowsAffected = command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
		private void RetrieveCustomerIdByPhoneNumber(string phoneNumber)
		{
			string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";
			string query = "SELECT ID FROM Customerdet WHERE PhoneNo = @PhoneNumber";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

				try
				{
					connection.Open();
					object result = command.ExecuteScalar();
					if (result != null)
					{
						int customerId = Convert.ToInt32(result);
						InsertCustomerIdIntoBill(customerId); // Call the method to insert customerId into the bill table
					}
					else
					{
						// Handle case where no customer with the given phone number is found
					}
				}
				catch (Exception ex)
				{
					// Handle any exceptions
					Console.WriteLine(ex.Message);
				}
			}
		}

		private void InsertCustomerIdIntoBill(int customerId)
		{
			string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";
			string query = "UPDATE NewBill SET Cus_ID = @CustomerId WHERE Cus_ID IS NULL";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand command = new SqlCommand(query, connection);
				command.Parameters.AddWithValue("@CustomerId", customerId);

				try
				{
					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();
					Console.WriteLine(rowsAffected + " rows updated."); // Optional: Print the number of rows updated
				}
				catch (Exception ex)
				{
					// Handle any exceptions
					Console.WriteLine(ex.Message);
				}
			}
		}

		private void RetrieveCustomerId()
		{
			string phoneNumber = search_txt2.Text;
			RetrieveCustomerIdByPhoneNumber(phoneNumber);
		}

		private void DeleteAllButton_Click(object sender, RoutedEventArgs e)
		{
			UpdateNewBillWithLastBillNo();
			RetrieveCustomerId();
			MoveDataFromBillToSale();
			DeleteDataFromTable("NewBill");
			LoadDestinationData(data);
			LoadSum();
			MessageBox.Show("Receipt Print!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}

