Android.App.Activity activity = Platform.CurrentActivity;
        Android.Views.Window window;
        public Environment()
        {
            window = activity.Window;
        }

        public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                return;
            window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.SetStatusBarColor(color.ToPlatformColor());
        }

        public void SetNavigationBarColor(System.Drawing.Color color)
        {
            window.SetNavigationBarColor(color.ToPlatformColor());
        }
