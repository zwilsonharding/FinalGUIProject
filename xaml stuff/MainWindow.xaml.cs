using System;
using System.Collections.Generic;
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

using System.Collections;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            initMonth();
            initDay();
            initYear();
        }

        public ArrayList months;

        public ArrayList days;

        public ArrayList years;
        
        public void initMonth()
        {
            months = new ArrayList();
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
        
        public void initDay()
        {
            int ndays;
            int month = Month.SelectedIndex;

            //get number of days in that month
            if (month == 3 || month == 5 || month == 8 || month == 10) ndays = 30;
            else if (month == 1)
            {
                ndays = 28;
                //TODO: leap year case
            }
            else ndays = 31;

            //populate the combobox
            ArrayList list = new ArrayList();
            for (int i = 1; i < ndays; i++)
            {
                list.Add(i.ToString());
            }
            days = list;
            Day.DataContext = days;
            Day.SelectedIndex = 0;
        }

        public void initYear()
        {
            int minDate = 1900;
            int maxDate = 2013;

            //populate the combo box
            ArrayList list = new ArrayList();
            for (int i = minDate; i <= maxDate; i++)
            {
                list.Add(i.ToString());
            }
            years = list;
            Year.DataContext = years;
            Year.SelectedIndex = 0;
        }
    }
}
