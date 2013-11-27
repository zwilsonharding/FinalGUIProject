using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace FinalGUIProject
{
	/// <summary>
	/// Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App : Application
	{
		/// <summary>
		/// Initializes the singleton application object.  This is the first line of authored code
		/// executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App()
		{
			this.InitializeComponent();
			this.Suspending += new SuspendingEventHandler(App_Suspending);
			this.Resuming += new EventHandler<object>(App_Resuming);
			
			selectedDictionary = SelectedDictionary.sillyDict;

			initializeDictionaries();
		}

		//Dictionaries
		private Dictionary<int, string> sillyMonths;
		private Dictionary<int, string> sillyDays;
		private Dictionary<int, string> sillyYears;
		
		private Dictionary<int, string> manlyMonths;
		private Dictionary<int, string> manlyDays;
		private Dictionary<int, string> manlyYears;

		//Selected Date Variables
		public int selectedMonth;
		public int selectedDay;
		public int selectedYear;

		//Other Private members
		private enum SelectedDictionary {sillyDict, manlyDict};
		SelectedDictionary selectedDictionary;

		public string submit() {
			string generatedName = "";
			
			//figure out ranges to assign month, day, and year to
			//run through dictionaries, assign to output string
			if (selectedDictionary == SelectedDictionary.sillyDict) {
				generatedName += sillyMonths[selectedMonth % 4] + " ";
				generatedName += sillyDays[selectedDay % 10] + " ";
				generatedName += sillyYears[selectedYear % 20];
			}
			else {
				generatedName += manlyMonths[selectedMonth % 4] + " ";
				generatedName += manlyDays[selectedDay % 10] + " ";
				generatedName += manlyYears[selectedYear % 20];
			}

			return generatedName;
		}
		public void selectDictionary(int selection) {
			if (selection == 1) {
				selectedDictionary = SelectedDictionary.sillyDict;
			}
			else {
				selectedDictionary = SelectedDictionary.manlyDict;
			}
		}

		private void initializeDictionaries() {

			//Instantiate the dictionaries
			sillyMonths = new Dictionary<int, string>();
			sillyDays = new Dictionary<int, string>();
			sillyYears = new Dictionary<int, string>();

			manlyMonths = new Dictionary<int, string>();
			manlyDays = new Dictionary<int, string>();
			manlyYears = new Dictionary<int, string>();

			//Fill in the dictionaries
			initializeSillyDicts();
			initializeManlyDics();
		}

		private void initializeSillyDicts() {

			//Silly Months
			sillyMonths[0] = "Big-footed";
			sillyMonths[1] = "Crook-nosed";
			sillyMonths[2] = "Hysterical";
			sillyMonths[3] = "Hyperactive";

			//Silly Days
			sillyDays[0] = "Hooper-toading";
			sillyDays[1] = "Rope-mongering";
			sillyDays[2] = "Thieving";
			sillyDays[3] = "Flannel-eating";
			sillyDays[4] = "Spewing";
			sillyDays[5] = "Hawking";
			sillyDays[6] = "Booger-flicking";
			sillyDays[7] = "Monkey-riding";
			sillyDays[8] = "Mouse-chasing";
			sillyDays[9] = "Chicken-kicking";

			//Silly Years
			sillyYears[0] = "Treehugger";
			sillyYears[1] = "Oak-eater";
			sillyYears[2] = "People-smasher";
			sillyYears[3] = "Boot-licker";
			sillyYears[4] = "Lamp-destroyer";
			sillyYears[5] = "Ant-punisher";
			sillyYears[6] = "Keyboard-masher";
			sillyYears[7] = "Basement-dweller";
			sillyYears[8] = "Clown";
			sillyYears[9] = "Anteater";
			sillyYears[10] = "Bean-ingester";
			sillyYears[11] = "Meal-scarfer";
			sillyYears[12] = "Time-waster";
			sillyYears[13] = "Student";
			sillyYears[14] = "Comp-Sci Major";
			sillyYears[15] = "Leotard Wearing Wrestler";
			sillyYears[16] = "Rat-wrangler";
			sillyYears[17] = "Holiday-ruiner";
			sillyYears[18] = "Forum-lurker";
			sillyYears[19] = "Plague";

		}
		private void initializeManlyDics() {
			
				//Manly Months
			manlyMonths[0] = "Hulking";
			manlyMonths[1] = "Sir";
			manlyMonths[2] = "Bearded";
			manlyMonths[3] = "Knight";

				//Manly Days
			manlyDays[0] = "Jace";
			manlyDays[1] = "Robert";
			manlyDays[2] = "Abbas";
			manlyDays[3] = "Ben";
			manlyDays[4] = "Clint";

			manlyDays[5] = "Ezra";
			manlyDays[6] = "Brutus";
			manlyDays[7] = "Richard";
			manlyDays[8] = "Arthur";
			manlyDays[9] = "Maximus";
			
				//Manly Years
			manlyYears[0] = "The Great";
			manlyYears[1] = "The Powerful";
			manlyYears[2] = "VII";
			manlyYears[3] = "XIV";
			manlyYears[4] = "The Terrible";

			manlyYears[5] = "The Destroyer Of Worlds";
			manlyYears[6] = "The Machine";
			manlyYears[7] = "The Unwavering";
			manlyYears[8] = "The Baron of Biceps";
			manlyYears[9] = "The Big Dog";

			manlyYears[10] = "The Strong";
			manlyYears[11] = "The Invincible";
			manlyYears[12] = "The Undefeated";
			manlyYears[13] = "XVIII";
			manlyYears[14] = "The Man in Tights";

			manlyYears[15] = "The Fierce";
			manlyYears[16] = "Of The Land Of Manly-Men";
			manlyYears[17] = "Who Scorns Pretty Flowers";
			manlyYears[18] = "The Brave";
			manlyYears[19] = "The Fearless";

		}

		/// <summary>
		/// Invoked when the application is launched normally by the end user.  Other entry points
		/// will be used when the application is launched to open a specific file, to display
		/// search results, and so forth.
		/// </summary>
		/// <param name="args">Details about the launch request and process.</param>
		protected override void OnLaunched(LaunchActivatedEventArgs args)
		{
			Frame rootFrame = Window.Current.Content as Frame;
			
			// Do not repeat app initialization when the Window already has content,
			// just ensure that the window is active
			if (rootFrame == null)
			{
				// Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = new Frame();

				if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Load state from previously suspended application
				}

				// Place the frame in the current Window
				Window.Current.Content = rootFrame;
			}

			if (rootFrame.Content == null)
			{
				// When the navigation stack isn't restored navigate to the first page,
				// configuring the new page by passing required information as a navigation
				// parameter
				if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
				{
					throw new Exception("Failed to create initial page");
				}
			}
			// Ensure the current window is active
			Window.Current.Activate();
		}

		async void App_Suspending(Object sender, Windows.ApplicationModel.SuspendingEventArgs e) {
			//nothing to save
		}

		async void App_Resuming(Object sender, Object e) {
			//nothing to load
		}
	}
}
