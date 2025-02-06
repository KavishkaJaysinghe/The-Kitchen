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

namespace programing_project_EE3254.pages
{
	/// <summary>
	/// Interaction logic for Add_item.xaml
	/// </summary>
	public partial class Add_item : Page
	{
		public Add_item()
		{
			InitializeComponent();
			categoryComboBox.Items.Add("Appetizers");
			categoryComboBox.Items.Add("Entress");
			categoryComboBox.Items.Add("Side Dishes");
			categoryComboBox.Items.Add("Salads");
			categoryComboBox.Items.Add("Drink");
			categoryComboBox.Items.Add("Desserts");
		}

		private void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False";
			string category = categoryComboBox.Text;
			string name = nameTextBox.Text;
			decimal price;

			if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(name) || !decimal.TryParse(priceTextBox.Text, out price))
			{
				MessageBox.Show("Please fill in all fields with valid data.");
				return;
			}

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					string insertQuery = $"INSERT INTO _item (Catagry, Name, price) VALUES ('{category}', '{name}', {price})";

					using (SqlCommand command = new SqlCommand(insertQuery, connection))
					{
						int rowsAffected = command.ExecuteNonQuery();
						if (rowsAffected > 0)
						{
							MessageBox.Show("Item added successfully!");
						}
						else
						{
							MessageBox.Show("Failed to add item.");
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		}
		private void name_txt2_GotFocus(object sender, RoutedEventArgs e)
		{
			// Hide the hint text when the TextBox gets focus
			nameTextBlock.Visibility = Visibility.Collapsed;
		}

		private void name_txt2_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(nameTextBox.Text))
			{
				// Show the hint text if the TextBox is empty and loses focus
				nameTextBox.Visibility = Visibility.Visible;
			}
		}
		private void price_txt2_GotFocus(object sender, RoutedEventArgs e)
		{
			// Hide the hint text when the TextBox gets focus
			priceTextBlock.Visibility = Visibility.Collapsed;
		}

		private void price_txt2_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(priceTextBox.Text))
			{
				// Show the hint text if the TextBox is empty and loses focus
				nameTextBlock.Visibility = Visibility.Visible;
			}
		}
	}
}
