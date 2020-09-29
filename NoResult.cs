using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LoLNexusAndroid
{
    [Activity(Label = "No Result", NoHistory = true,Theme ="@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class NoResult : Activity
    {
        public static InterstitialAd InterNoResult;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NoResult);

            //InterNoResult = new InterstitialAd(this);
            //InterNoResult.AdUnitId = @"ca-app-pub-8723045763935491/1078923743";
            //var adRequest = new Android.Gms.Ads.AdRequest.Builder().Build();
            //InterNoResult.LoadAd(adRequest);

        
            TextView errorMsg = FindViewById<TextView>(Resource.Id.ErrorText);
            errorMsg.Text = Intent.GetStringExtra("errorMsg");
            Button BackBtn = FindViewById<Button>(Resource.Id.BackBtn);
            BackBtn.Click += delegate
            {
                StartActivity(typeof(MainActivity));
                FinishAffinity();

            };

            

        }
      
    }
}