using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hamburger
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainAppFrame.Navigate(typeof(Views.Page1));
        }

        private void Hmburger_Click(object sender, RoutedEventArgs e)
        {
            mySplit.IsPaneOpen = !mySplit.IsPaneOpen;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainAppFrame.CanGoBack) MainAppFrame.GoBack();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainAppFrame.CanGoForward) MainAppFrame.GoForward();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            switch (listBox.SelectedIndex)
            {
                case (0):
                    MainAppFrame.Navigate(typeof(Views.Page1));

                    break;
                case (1):
                    MainAppFrame.Navigate(typeof(Views.Page2));

                    break;
                case (2):
                    MainAppFrame.Navigate(typeof(Views.Page3));
                    break;
                case (3):
                    MainAppFrame.Navigate(typeof(Views.Page4));
                    break;
                default:
                    break;
            }
        }

        private async void MessageDialogAsync()
        {
            MessageDialog mess = new MessageDialog("Are you sure you want to close?", " Exit Confirmation");

            IUICommand com1 = new UICommand() { Id = 0, Label = "Yes" }; 
            mess.Commands.Add(com1);

            IUICommand com2 = new UICommand() { Id = 1, Label = "No" };
            mess.Commands.Add(com2);

            IUICommand result = await mess.ShowAsync();
            if ((int)result.Id == 0) Application.Current.Exit();


        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageDialogAsync();
        }
    }
}
