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
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using programing_project_EE3254.View;
using System.Windows.Markup;

namespace programing_project_EE3254.Views
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : Window
	{
		public MainView()
		{
			InitializeComponent();
			if (WindowState == WindowState.Maximized)
			{
				WindowState = WindowState.Normal;
			}
			else
			{
				WindowState = WindowState.Maximized;
			}
			RadioButtonHome(null, null);
		}

		
		SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Admin;Integrated Security=True;Encrypt=False");
		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			if (MainFrame1 != null)
			{
				MainFrame1.Content = new Page3();
			}
		}
		private void RadioButton_Logout(object sender, RoutedEventArgs e)
		{
			if (MainFrame1 != null)
			{
				MainFrame1.Content = new Page2();
			}
		}
		private void btnLogout_Click(object sender, RoutedEventArgs e)
		{
			var newForm = new LoginView(); //create your new form.
			newForm.Show();
			this.Close();
		}
		
		private void RadioButton_item_Checked(object sender, RoutedEventArgs e)
		{
			try
			{
				if (MainFrame1 != null)
				{
					MainFrame1.Content = new Page6();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error navigating to Page4: " + ex.Message);
			}
		}
		private void RadioButtonHome(object sender, RoutedEventArgs e)
		{
			try
			{
				if (MainFrame1 != null)
				{
					// Create a DataTable object or get it from somewhere
					DataTable dataTable = new DataTable(); // This is just an example, replace it with your actual DataTable

					// Navigate to Page4 and pass the DataTable object
					MainFrame1.Content = new Page4(dataTable);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error navigating to Page4: " + ex.Message);
			}
		}
		private void RadioButtonAboth(object sender, RoutedEventArgs e)
		{
			try
			{
				if (MainFrame1 != null)
				{
					MainFrame1.Content = new Page7();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error navigating to Page4: " + ex.Message);
			}
		}



			private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void MainFrame1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
		{

		}
	}
}
