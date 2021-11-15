using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinNotifications.Interfaces;

namespace XamarinNotifications
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
            NotificationCenter.Current.NotificationTapped += Current_NotificationTapped;
            NotificationCenter.Current.NotificationReceived += Current_NotificationReceived;
        }

        private void Current_NotificationReceived(Plugin.LocalNotification.NotificationEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert(e.Request.Title, e.Request.Description+ " Received", "ok");
            });
        }

        private void Current_NotificationTapped(Plugin.LocalNotification.NotificationEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert(e.Request.Title, e.Request.Description+ " tapped", "ok");
            });
        }
        // not working
        private void Current_NotificationActionTapped(NotificationActionEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DisplayAlert(e.Request.Title, e.Request.Description, "ok");
            });
        }
        int id = 0;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                Subtitle = "mohaemd fawzy subtitle",
                Image = new NotificationImage() { ResourceName = "xamagonBlue.png" },
                BadgeNumber= 1,
                NotificationId = id,
                Title = "Test, id: " + id,
                Description = "Test Description",
                ReturningData = "Dummy data", // Returning data when tapped on notification.
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(5) // Used for Scheduling local notification, if not specified notification will show immediately.
                },
                Android =
                {
                     IconSmallName = new AndroidIcon("xamagonBlue","png"),
                }
            };
            await NotificationCenter.Current.Show(notification);
            id++;
        }
    }
}
