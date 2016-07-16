using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;

namespace ProgressDialogWithButton
{
    [Activity(Label = "ProgressDialogWithButton", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate {
                ProgressDialog pd = new ProgressDialog(this);
                pd.SetProgressStyle(ProgressDialogStyle.Spinner);
                pd.SetTitle("Title");
                pd.SetMessage("Loading.........");
                pd.Indeterminate = false;
                pd.SetCancelable(false);

                string s = "Stop";
                pd.SetButton( Convert.ToInt32( DialogButtonType.Negative), s ,
                    (object sender, DialogClickEventArgs args) => { pd.Dismiss(); });

                pd.Show();
            };
        }
    }
}

