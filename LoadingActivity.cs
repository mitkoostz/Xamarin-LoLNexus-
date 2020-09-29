using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LoLNexusAndroid
{
    [Activity(Label = "LoLNexus", Icon = "@drawable/GameIco" ,Theme = "@style/LoadingActivity", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, MainLauncher = true, NoHistory =true)]
    public class LoadingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Intent act = new Intent(this, typeof(MainActivity));
            StartActivity(act);
        }
    }
}