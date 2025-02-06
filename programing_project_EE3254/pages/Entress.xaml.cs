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
using static programing_project_EE3254.Page4;


namespace programing_project_EE3254.pages
{
	/// <summary>
	/// Interaction logic for Entress.xaml
	/// </summary>
	public partial class Entress : Page
	{
		public Entress()
		{
			InitializeComponent();
			LoadSourceData();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (sourceDataGrid.SelectedItem != null)
			{

				Button button = sender as Button;
				if (button != null)
				{
					// Change the background color of the button
					button.Background = Brushes.Gold; // Change the color as desired
				}
				// Assuming you have established connections to your source and destination databases
				using (SqlConnection Connection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False"))
				{
					Connection.Open();


					// Retrieve selected row data from the source database
					DataRowView selectedRow = (DataRowView)sourceDataGrid.SelectedItem;
					DataTable selectedDataTable = selectedRow.Row.Table.Clone();
					selectedDataTable.ImportRow(selectedRow.Row);

					// Insert the row data into the destination database
					using (SqlBulkCopy bulkCopy = new SqlBulkCopy(Connection))
					{
						bulkCopy.DestinationTableName = "NewBill";

						// Map source columns to destination columns explicitly
						bulkCopy.ColumnMappings.Add("Name", "Name");
						bulkCopy.ColumnMappings.Add("price", "Price");
						bulkCopy.ColumnMappings.Add("ID", "Item_ID");
						try
						{
							bulkCopy.WriteToServer(selectedDataTable);
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error: " + ex.Message);
						}
					}

				}
			}

		}


			private void LoadSourceData()
			{
				try
				{
					// Connection string to your SQL Server database
					string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";

					// Query to select data from your SQL database
					string query = "SELECT Name, Price FROM _item WHERE Catagry = 'Entress'";

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

						// Add an ID column to the DataTable
						DataColumn idColumn = new DataColumn("ID", typeof(int));
						dataTable.Columns.Add(idColumn);

						// Populate the ID column with incremental values starting from 1
						int id = 1;
						foreach (DataRow row in dataTable.Rows)
						{
							row["ID"] = id;
							id++;
						}

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


			/*private void MoveSelectedData_Click(object sender, RoutedEventArgs e)
			{
				if (sourceDataGrid.SelectedItem != null)
				{
					DataRowView selectedRow = (DataRowView)sourceDataGrid.SelectedItem;
					DataTable selectedDataTable = new DataTable();
					selectedDataTable = selectedRow.Row.Table.Clone();
					selectedDataTable.ImportRow(selectedRow.Row);
					// Navigate to the DestinationPage and pass the selected data
					Page4 destinationPage = new Page4(selectedDataTable);
					NavigationService.Navigate(destinationPage);
				}
				else
				{
					MessageBox.Show("Please select a row to move.");
				}
			}*/


			private void sourceDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
			{
				// Handle selection change event if needed
			}
		}
	}


