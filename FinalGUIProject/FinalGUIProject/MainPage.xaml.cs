using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalGUIProject
{
	
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

			this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;

			initMonth();
			initDay();
			initYear();
		}

		public List<string> months;

		public List<string> days;

		public List<string> years;

		public void initMonth() {
			months = new List<string>();
			months.Add("January");
			months.Add("February");
			months.Add("March");
			months.Add("April");
			months.Add("May");
			months.Add("June");
			months.Add("July");
			months.Add("August");
			months.Add("September");
			months.Add("October");
			months.Add("November");
			months.Add("December");

			Month.DataContext = months;
			Month.SelectedIndex = 0;
		}

		public void initDay() {
			int ndays;
			int month = Month.SelectedIndex;

			//get number of days in that month
			if (month == 3 || month == 5 || month == 8 || month == 10) ndays = 30;
			else if (month == 1) {
				ndays = 28;
				//TODO: leap year case
			}
			else ndays = 31;

			//populate the combobox
			List<string> list = new List<string>();
			for (int i = 1; i <= ndays; i++) {
				list.Add(i.ToString());
			}
			days = list;
			Day.DataContext = days;
			Day.SelectedIndex = 0;
		}

		public void initYear() {
			int minDate = 1950;
			int maxDate = 2013;

			//populate the combo box
			List<string> list = new List<string>();
			for (int i = minDate; i <= maxDate; i++) {
				list.Add(i.ToString());
			}
			years = list;
			Year.DataContext = years;
			Year.SelectedIndex = 0;
		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.  The Parameter
		/// property is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			Input.Visibility = Visibility.Visible;
			LoadingPanel.Visibility = Visibility.Collapsed;
		}

		private void SillyButton_Click(object sender, RoutedEventArgs e) {
			(Application.Current as App).selectDictionary(1);
		}

		private void ManlyButton_Click(object sender, RoutedEventArgs e) {
			(Application.Current as App).selectDictionary(2);
		}

		private void Submit_Click(object sender, RoutedEventArgs e) {
			Input.Visibility = Visibility.Collapsed;
			LoadingPanel.Visibility = Visibility.Visible;
			
			this.Frame.Navigate(typeof(ResultsPage), (Application.Current as App).submit());
		}

		private void UpdateDayCount(object sender, SelectionChangedEventArgs e) {
			initDay();
		}

		private void AboutButton_Click(object sender, RoutedEventArgs e) {
			this.Frame.Navigate(typeof(AboutPage));
		}
	}
}
