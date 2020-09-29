using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LolNexusDLL;
using Newtonsoft.Json;

namespace LoLNexusAndroid
{
    [Activity(Label = "LoLNexus",Theme = "@style/AppTheme",NoHistory = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GameDataFastActivity : Activity
    {
        protected AdView GameDataFastBanner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GameDataFast);

        
            GameDataFastBanner = FindViewById<AdView>(Resource.Id.adView1);
            var adRequest = new Android.Gms.Ads.AdRequest.Builder().Build();
            GameDataFastBanner.LoadAd(adRequest);

            List<Team> data = JsonConvert.DeserializeObject<List<Team>>(Intent.GetStringExtra("data"));

   
            TextView Player1Name = FindViewById<TextView>(Resource.Id.Player1Name);
            Player1Name.Text = data[0].Players[0].Name;

            TextView Player1Division = FindViewById<TextView>(Resource.Id.Player1Division);
            Player1Division.Text = data[0].Players[0].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[0].Players[0].Devision;


            TextView Player1WinPercantage = FindViewById<TextView>(Resource.Id.Player1WinPercantage);
            Player1WinPercantage.Text = data[0].Players[0].WinPercentage;

            TextView Player1Wins = FindViewById<TextView>(Resource.Id.Player1Wins);
            Player1Wins.Text = data[0].Players[0].Wins;

            TextView Player1Looses = FindViewById<TextView>(Resource.Id.Player1Looses);
            Player1Looses.Text = data[0].Players[0].Looses;




     
            TextView Player2Name = FindViewById<TextView>(Resource.Id.Player2Name);
            Player2Name.Text = data[0].Players[1].Name;

            

            TextView Player2Division = FindViewById<TextView>(Resource.Id.Player2Division);
            Player2Division.Text = data[0].Players[1].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[0].Players[1].Devision;

            TextView Player2WinPercantage = FindViewById<TextView>(Resource.Id.Player2WinPercantage);
            Player2WinPercantage.Text = data[0].Players[1].WinPercentage;

            TextView Player2Wins = FindViewById<TextView>(Resource.Id.Player2Wins);
            Player2Wins.Text = data[0].Players[1].Wins;

            TextView Player2Looses = FindViewById<TextView>(Resource.Id.Player2Looses);
            Player2Looses.Text = data[0].Players[1].Looses;





            TextView Player3Name = FindViewById<TextView>(Resource.Id.Player3Name);
            Player3Name.Text = data[0].Players[2].Name;

           
            TextView Player3Division = FindViewById<TextView>(Resource.Id.Player3Division);
            Player3Division.Text = data[0].Players[2].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[0].Players[2].Devision;

            TextView Player3WinPercantage = FindViewById<TextView>(Resource.Id.Player3WinPercantage);
            Player3WinPercantage.Text = data[0].Players[2].WinPercentage;

            TextView Player3Wins = FindViewById<TextView>(Resource.Id.Player3Wins);
            Player3Wins.Text = data[0].Players[2].Wins;

            TextView Player3Looses = FindViewById<TextView>(Resource.Id.Player3Looses);
            Player3Looses.Text = data[0].Players[2].Looses;




            TextView Player4Name = FindViewById<TextView>(Resource.Id.Player4Name);
            Player4Name.Text = data[0].Players[3].Name;


            TextView Player4Division = FindViewById<TextView>(Resource.Id.Player4Division);
            Player4Division.Text = data[0].Players[3].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[0].Players[3].Devision;

            TextView Player4WinPercantage = FindViewById<TextView>(Resource.Id.Player4WinPercantage);
            Player4WinPercantage.Text = data[0].Players[3].WinPercentage;

            TextView Player4Wins = FindViewById<TextView>(Resource.Id.Player4Wins);
            Player4Wins.Text = data[0].Players[3].Wins;

            TextView Player4Looses = FindViewById<TextView>(Resource.Id.Player4Looses);
            Player4Looses.Text = data[0].Players[3].Looses;




            TextView Player5Name = FindViewById<TextView>(Resource.Id.Player5Name);
            Player5Name.Text = data[0].Players[4].Name;

         

            TextView Player5Division = FindViewById<TextView>(Resource.Id.Player5Division);
            Player5Division.Text = data[0].Players[4].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[0].Players[4].Devision;

            TextView Player5WinPercantage = FindViewById<TextView>(Resource.Id.Player5WinPercantage);
            Player5WinPercantage.Text = data[0].Players[4].WinPercentage;

            TextView Player5Wins = FindViewById<TextView>(Resource.Id.Player5Wins);
            Player5Wins.Text = data[0].Players[4].Wins;

            TextView Player5Looses = FindViewById<TextView>(Resource.Id.Player5Looses);
            Player5Looses.Text = data[0].Players[4].Looses;

            //TEAM2

       

            TextView Player6Name = FindViewById<TextView>(Resource.Id.Player6Name);
            Player6Name.Text = data[1].Players[0].Name;

          

            TextView Player6Division = FindViewById<TextView>(Resource.Id.Player6Division);
            Player6Division.Text = data[1].Players[0].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[1].Players[0].Devision;

            TextView Player6WinPercantage = FindViewById<TextView>(Resource.Id.Player6WinPercantage);
            Player6WinPercantage.Text = data[1].Players[0].WinPercentage;

            TextView Player6Wins = FindViewById<TextView>(Resource.Id.Player6Wins);
            Player6Wins.Text = data[1].Players[0].Wins;

            TextView Player6Looses = FindViewById<TextView>(Resource.Id.Player6Looses);
            Player6Looses.Text = data[1].Players[0].Looses;


       

            TextView Player7Name = FindViewById<TextView>(Resource.Id.Player7Name);
            Player7Name.Text = data[1].Players[1].Name;

        

            TextView Player7Division = FindViewById<TextView>(Resource.Id.Player7Division);
            Player7Division.Text = data[1].Players[1].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[1].Players[1].Devision;

            TextView Player7WinPercantage = FindViewById<TextView>(Resource.Id.Player7WinPercantage);
            Player7WinPercantage.Text = data[1].Players[1].WinPercentage;

            TextView Player7Wins = FindViewById<TextView>(Resource.Id.Player7Wins);
            Player7Wins.Text = data[1].Players[1].Wins;

            TextView Player7Looses = FindViewById<TextView>(Resource.Id.Player7Looses);
            Player7Looses.Text = data[1].Players[1].Looses;



            TextView Player8Name = FindViewById<TextView>(Resource.Id.Player8Name);
            Player8Name.Text = data[1].Players[2].Name;


            TextView Player8Division = FindViewById<TextView>(Resource.Id.Player8Division);
            Player8Division.Text = data[1].Players[2].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[1].Players[2].Devision;

            TextView Player8WinPercantage = FindViewById<TextView>(Resource.Id.Player8WinPercantage);
            Player8WinPercantage.Text = data[1].Players[2].WinPercentage;

            TextView Player8Wins = FindViewById<TextView>(Resource.Id.Player8Wins);
            Player8Wins.Text = data[1].Players[2].Wins;

            TextView Player8Looses = FindViewById<TextView>(Resource.Id.Player8Looses);
            Player8Looses.Text = data[1].Players[2].Looses;



     

            TextView Player9Name = FindViewById<TextView>(Resource.Id.Player9Name);
            Player9Name.Text = data[1].Players[3].Name;

         

            TextView Player9Division = FindViewById<TextView>(Resource.Id.Player9Division);
            Player9Division.Text = data[1].Players[3].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[1].Players[3].Devision;

            TextView Player9WinPercantage = FindViewById<TextView>(Resource.Id.Player9WinPercantage);
            Player9WinPercantage.Text = data[1].Players[3].WinPercentage;

            TextView Player9Wins = FindViewById<TextView>(Resource.Id.Player9Wins);
            Player9Wins.Text = data[1].Players[3].Wins;

            TextView Player9Looses = FindViewById<TextView>(Resource.Id.Player9Looses);
            Player9Looses.Text = data[1].Players[3].Looses;


            TextView Player10Name = FindViewById<TextView>(Resource.Id.Player10Name);
            Player10Name.Text = data[1].Players[4].Name;


            TextView Player10Division = FindViewById<TextView>(Resource.Id.Player10Division);
            Player10Division.Text = data[1].Players[4].DevisionImageUrl.Replace("//static.lolskill.net/img/tiers/64/", "").Replace(".png", "") + " " + data[1].Players[4].Devision;

            TextView Player10WinPercantage = FindViewById<TextView>(Resource.Id.Player10WinPercantage);
            Player10WinPercantage.Text = data[1].Players[4].WinPercentage;

            TextView Player10Wins = FindViewById<TextView>(Resource.Id.Player10Wins);
            Player10Wins.Text = data[1].Players[4].Wins;

            TextView Player10Looses = FindViewById<TextView>(Resource.Id.Player10Looses);
            Player10Looses.Text = data[1].Players[4].Looses;


            LinearLayout body = FindViewById<LinearLayout>(Resource.Id.MainBody);
            Space sp = new Space(this);
            sp.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 140);
            body.AddView(sp);

            MainActivity.progress.Visibility = ViewStates.Invisible;
        }
    }
    }
