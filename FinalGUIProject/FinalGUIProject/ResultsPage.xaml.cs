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
using System.Net;
using System.Threading;
using System.Text;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalGUIProject {
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ResultsPage : Page 
    {
		public ResultsPage() 
        {
            this.InitializeComponent();
            APIGetResponseDate(((Application.Current as App).selectedMonth + 1).ToString() + "/" + ((Application.Current as App).selectedDay + 1).ToString());
            APIGetResponseYear(((Application.Current as App).selectedYear + 1950).ToString());
		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.  The Parameter
		/// property is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e) {
			NameTextBlock.Text = e.Parameter.ToString();
		}

		private void GoBackButton_Click(object sender, RoutedEventArgs e) {
			if (this.Frame.CanGoBack) {
				this.Frame.GoBack();
			}
			else {
				this.Frame.Navigate(typeof(MainPage));
			}
		}

        private async void APIGetResponseDate(string date)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://numbersapi.com/" + date + "/date");

            HttpWebResponse res = (HttpWebResponse)(await req.GetResponseAsync());
            Stream streamResponse = res.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = await streamRead.ReadToEndAsync();

            APIDate.Text = responseString;
        }

        private async void APIGetResponseYear(string year)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://numbersapi.com/" + year + "/year");

            HttpWebResponse res = (HttpWebResponse)(await req.GetResponseAsync());
            Stream streamResponse = res.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = await streamRead.ReadToEndAsync();

            APIYear.Text = responseString;
        }

	}
}
