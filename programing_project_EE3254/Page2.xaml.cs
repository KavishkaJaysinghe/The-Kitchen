using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Controls;

namespace programing_project_EE3254
{
	/// <summary>
	/// Interaction logic for Page2.xaml
	/// </summary>
	public partial class Page2 : Page
	{
		public SeriesCollection SeriesCollection { get; set; }
		public string[] Labels { get; set; }
		public Page2()
		{
			InitializeComponent();

			SeriesCollection = new SeriesCollection
			{
				new LineSeries
				{
					Title = "Series 1",
					Values = new ChartValues<double> { 3, 5, 7, 4, 9 }
				},
				new LineSeries
				{
					Title = "Series 2",
					Values = new ChartValues<double> { 5, 2, 8, 6, 7 }
				}
			};

			// Sample labels for the x-axis
			Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };

			// Set the data context
			DataContext = this;
		}
	}
}
