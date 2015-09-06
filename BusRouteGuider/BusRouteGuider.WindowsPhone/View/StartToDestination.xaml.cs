using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using System.Diagnostics;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using System.Windows;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace BusRouteGuider
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartToDestination : Page
    {
        Dictionary<String, Location> dic;
        BusRouteGuider.ViewModel.Algorithm process;
        int option = 0;

        public StartToDestination()
        {
            //Navigation achieved
            Debug.WriteLine("Start to destination reached");
            //Create the GUI
            this.InitializeComponent();
            //Set functionality for the phone's back buttons
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            //Create an object from Algorithm Class
            process = new ViewModel.Algorithm();
        }

        

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Dictionary<String, Location> dic = e.Parameter as Dictionary<String, Location>;
            Debug.WriteLine("**********************on navigated to got called");
            this.dic = dic;
        }

        //Set the functionality for the phone's back button to move one page back
        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null && rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                e.Handled = true;
            }
        }

        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            //return to main page
            this.Frame.Navigate(typeof(MainPage));
        }

       
        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            //return to main page
            this.Frame.Navigate(typeof(MainPage));
        }

        
        private void Map_ItemClick(object sender, ItemClickEventArgs e)
        {
            //return to map
            this.Frame.Navigate(typeof(Map));
        }

        private async void AllRoutesBtn_Click(object sender, RoutedEventArgs e)
        {
            Boolean start = false;
            Boolean end = false;

            //Validating if start location user input town is available in the data file
            foreach (String key in dic.Keys) {
                //Check if start location user input is correct
                if (key.Equals(textStart.Text)) {
                    start = true;
                    break;
                }
            }

            //Validating if destination user input town is available in the data file
            foreach (String key in dic.Keys)
            {
                //Check if start location user input is correct
                if (key.Equals(textEnd.Text))
                {
                    end = true;
                    break;
                }
            }

            //Warn the user
            if (start == false && end == false){
                MessageDialog msgbox = new MessageDialog("Sorry the start location and destination are not available.", "ERROR");
                await msgbox.ShowAsync();
                return;
            }
            if (start == false){
                MessageDialog msgbox = new MessageDialog("Sorry this start location is not available.", "ERROR");
                await msgbox.ShowAsync();
                return;
            }
            if (end == false) {
                MessageDialog msgbox = new MessageDialog("Sorry this destination is not available.", "ERROR");
                await msgbox.ShowAsync();
                return;
            }
            

            //Validating if text boxes are not empty
            if (textStart.Text == null || textEnd.Text == null)
            {
                MessageDialog msgbox = new MessageDialog("Please fill all the fields.","ERROR");
                await msgbox.ShowAsync();
                return;
            }

            //Validating if two locations on the two text boxes are the same
            else if ((textStart.Text.ToString()).Equals(textEnd.Text.ToString()))
            {
                MessageDialog msgbox = new MessageDialog("Enter different locations for Start and Destination", "ERROR");
                await msgbox.ShowAsync();
                return;
            }  

            //Validations are OK
            else
            {
                process.getRoutes(textStart.Text.ToString(), textEnd.Text.ToString(), dic, true);
            }
        }

        private async void BestRoutesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (textStart.Text == null || textEnd.Text == null)
            {
                MessageDialog msgbox = new MessageDialog("Please fill all the fields.", "ERROR");
                await msgbox.ShowAsync();
                return;
            }
            else if ((textStart.Text.ToString()).Equals(textEnd.Text.ToString()))
            {

                MessageDialog msgbox = new MessageDialog("Enter different locations for Start and Destination", "ERROR");
                await msgbox.ShowAsync();
                return;
            }
            else
            {
                process.getRoutes(textStart.Text.ToString(), textEnd.Text.ToString(), dic, false);
            }
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                // Set a threshold when to start looking for suggestions
                if (sender.Text.Length >= 1)
                {
                    sender.ItemsSource = getSuggestions(sender.Text);
                }
                else
                {
                    sender.ItemsSource = new List<String> { };
                }
            }
        }

        private object getSuggestions(string p)
        {
            //The list of suggestions to display on text box
            List<String> suggestions = new List<string>();
            
            //The list of the combo box should appear in alphabetical order
            SortedSet<string> keySet = new SortedSet<string>();

            //Add elements from dictionary into the sorted set which conains elements in alphebetical order
            foreach (String key in dic.Keys)
            {
                keySet.Add(key);
            }

            //Add elements from dictionary into the sorted set which conains elements in alphebetical order
            foreach (String key in keySet)
            {
                //Both user entered string and string to be suggested are converted to lowecase for comparison
                String entered = p.ToLower();
                String suggested = key.ToLower();

                //check if user entered text is availble in the suggestions List
                if (suggested.StartsWith(entered))
                {
                    suggestions.Add(key);
                }
            }          

            return suggestions;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();

        }

        private void direct_Click(object sender, RoutedEventArgs e)
        {
            if (option == 0)
            {
                textStart.Focus(FocusState.Keyboard);
                //option = 1;
            }
            else if (option == 1)
            {
                textEnd.Focus(FocusState.Keyboard);
               // option = 2;
            }
            else
            {
                option = 0;
            }
            
        }

        private void textStartOnFocus(object sender, RoutedEventArgs e)
        {
            option = 1;
        }

        private void textEndOnFocus(object sender, RoutedEventArgs e)
        {
            option = 2;
        }

        private void Help_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(Help));
        }

        
    }
}
