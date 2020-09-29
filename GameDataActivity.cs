using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LolNexusDLL;
using Newtonsoft.Json;

namespace LoLNexusAndroid
{
    [Activity(Label = "LoLNexus", Theme ="@style/GameLayout" ,ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class GameDataActivity : Activity
    {
        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                try
                {
                    var link = @"http:" + url;
                    var imageBytes = webClient.DownloadData(link);

                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
                catch
                {
       
                }
            }

            return imageBitmap;
        }
        public static Bitmap Player1ChampionLargeImage;
        public static Bitmap Player2ChampionLargeImage;
        public static Bitmap Player3ChampionLargeImage;
        public static Bitmap Player4ChampionLargeImage;
        public static Bitmap Player5ChampionLargeImage;
        public static Bitmap Player6ChampionLargeImage;
        public static Bitmap Player7ChampionLargeImage;
        public static Bitmap Player8ChampionLargeImage;
        public static Bitmap Player9ChampionLargeImage;
        public static Bitmap Player10ChampionLargeImage;
        protected AdView GameDataBanner;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GameData);

            
            GameDataBanner = FindViewById<AdView>(Resource.Id.adView1);
            var adRequest = new Android.Gms.Ads.AdRequest.Builder().Build();
            GameDataBanner.LoadAd(adRequest);

            List<Team> data = JsonConvert.DeserializeObject<List<Team>>(Intent.GetStringExtra("data"));

            LinearLayout Player1Background = FindViewById<LinearLayout>(Resource.Id.Player1Background);
            //Player1Background.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[0].Players[0].ChampionImageLargeUrl));
            Player1Background.Background = new BitmapDrawable(Player1ChampionLargeImage);

            TextView Player1Name = FindViewById<TextView>(Resource.Id.Player1Name);
            Player1Name.Text = data[0].Players[0].Name;

            //ImageView Player1Champ = FindViewById<ImageView>(Resource.Id.Player1Champ);
           // Player1Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[0].ChampionImageUrl));



            TextView Player1SoloText = FindViewById<TextView>(Resource.Id.Player1SoloText);
            Player1SoloText.Text = data[0].Players[0].Solo;

            ImageView Player1DivisionImage = FindViewById<ImageView>(Resource.Id.Player1DivisionImage);
            Player1DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[0].DevisionImageUrl));

            TextView Player1Division = FindViewById<TextView>(Resource.Id.Player1Division);
            Player1Division.Text = data[0].Players[0].Devision;

            TextView Player1WinPercantage = FindViewById<TextView>(Resource.Id.Player1WinPercantage);
            Player1WinPercantage.Text = data[0].Players[0].WinPercentage;

            TextView Player1Wins = FindViewById<TextView>(Resource.Id.Player1Wins);
            Player1Wins.Text = data[0].Players[0].Wins;

            TextView Player1Looses = FindViewById<TextView>(Resource.Id.Player1Looses);
            Player1Looses.Text = data[0].Players[0].Looses;



         
            LinearLayout Player2 = FindViewById<LinearLayout>(Resource.Id.Player2Background);
            // Player2.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[0].Players[1].ChampionImageLargeUrl));
            Player2.Background = new BitmapDrawable(Player2ChampionLargeImage);

            TextView Player2Name = FindViewById<TextView>(Resource.Id.Player2Name);
            Player2Name.Text = data[0].Players[1].Name;

            //ImageView Player2Champ = FindViewById<ImageView>(Resource.Id.Player2Champ);
            //Player2Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[1].ChampionImageLargeUrl));



            TextView Player2SoloText = FindViewById<TextView>(Resource.Id.Player1SoloText);
            Player1SoloText.Text = data[0].Players[1].Solo;

            ImageView Player2DivisionImage = FindViewById<ImageView>(Resource.Id.Player2DivisionImage);
            Player2DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[1].DevisionImageUrl));

            TextView Player2Division = FindViewById<TextView>(Resource.Id.Player2Division);
            Player2Division.Text = data[0].Players[1].Devision;

            TextView Player2WinPercantage = FindViewById<TextView>(Resource.Id.Player2WinPercantage);
            Player2WinPercantage.Text = data[0].Players[1].WinPercentage;

            TextView Player2Wins = FindViewById<TextView>(Resource.Id.Player2Wins);
            Player2Wins.Text = data[0].Players[1].Wins;

            TextView Player2Looses = FindViewById<TextView>(Resource.Id.Player2Looses);
            Player2Looses.Text = data[0].Players[1].Looses;




            LinearLayout Player3Background = FindViewById<LinearLayout>(Resource.Id.Player3Background);
            //Player3Background.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[0].Players[2].ChampionImageLargeUrl));
            Player3Background.Background = new BitmapDrawable(Player3ChampionLargeImage);

            TextView Player3Name = FindViewById<TextView>(Resource.Id.Player3Name);
            Player3Name.Text = data[0].Players[2].Name;

            //ImageView Player3Champ = FindViewById<ImageView>(Resource.Id.Player3Champ);
            //Player3Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[2].ChampionImageUrl));


            TextView Player3SoloText = FindViewById<TextView>(Resource.Id.Player3SoloText);
            Player3SoloText.Text = data[0].Players[2].Solo;

            ImageView Player3DivisionImage = FindViewById<ImageView>(Resource.Id.Player3DivisionImage);
            Player3DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[2].DevisionImageUrl));

            TextView Player3Division = FindViewById<TextView>(Resource.Id.Player3Division);
            Player3Division.Text = data[0].Players[2].Devision;

            TextView Player3WinPercantage = FindViewById<TextView>(Resource.Id.Player3WinPercantage);
            Player3WinPercantage.Text = data[0].Players[2].WinPercentage;

            TextView Player3Wins = FindViewById<TextView>(Resource.Id.Player3Wins);
            Player3Wins.Text = data[0].Players[2].Wins;

            TextView Player3Looses = FindViewById<TextView>(Resource.Id.Player3Looses);
            Player3Looses.Text = data[0].Players[2].Looses;



            LinearLayout Player4Background = FindViewById<LinearLayout>(Resource.Id.Player4Background);
            //Player4Background.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[0].Players[3].ChampionImageLargeUrl));
            Player4Background.Background = new BitmapDrawable(Player4ChampionLargeImage);

            TextView Player4Name = FindViewById<TextView>(Resource.Id.Player4Name);
            Player4Name.Text = data[0].Players[3].Name;

           // ImageView Player4Champ = FindViewById<ImageView>(Resource.Id.Player4Champ);
           // Player4Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[3].ChampionImageUrl));


            TextView Player4SoloText = FindViewById<TextView>(Resource.Id.Player4SoloText);
            Player4SoloText.Text = data[0].Players[3].Solo;

            ImageView Player4DivisionImage = FindViewById<ImageView>(Resource.Id.Player4DivisionImage);
            Player4DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[3].DevisionImageUrl));

            TextView Player4Division = FindViewById<TextView>(Resource.Id.Player4Division);
            Player4Division.Text = data[0].Players[3].Devision;

            TextView Player4WinPercantage = FindViewById<TextView>(Resource.Id.Player4WinPercantage);
            Player4WinPercantage.Text = data[0].Players[3].WinPercentage;

            TextView Player4Wins = FindViewById<TextView>(Resource.Id.Player4Wins);
            Player4Wins.Text = data[0].Players[3].Wins;

            TextView Player4Looses = FindViewById<TextView>(Resource.Id.Player4Looses);
            Player4Looses.Text = data[0].Players[3].Looses;



            LinearLayout Player5Background = FindViewById<LinearLayout>(Resource.Id.Player5Background);
            //Player5Background.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[0].Players[4].ChampionImageLargeUrl));
            Player5Background.Background = new BitmapDrawable(Player5ChampionLargeImage);

            TextView Player5Name = FindViewById<TextView>(Resource.Id.Player5Name);
            Player5Name.Text = data[0].Players[4].Name;

           // ImageView Player5Champ = FindViewById<ImageView>(Resource.Id.Player5Champ);
           // Player5Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[4].ChampionImageUrl));


            TextView Player5SoloText = FindViewById<TextView>(Resource.Id.Player5SoloText);
            Player5SoloText.Text = data[0].Players[4].Solo;

            ImageView Player5DivisionImage = FindViewById<ImageView>(Resource.Id.Player5DivisionImage);
            Player5DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[4].DevisionImageUrl));

            TextView Player5Division = FindViewById<TextView>(Resource.Id.Player5Division);
            Player5Division.Text = data[0].Players[4].Devision;

            TextView Player5WinPercantage = FindViewById<TextView>(Resource.Id.Player5WinPercantage);
            Player5WinPercantage.Text = data[0].Players[4].WinPercentage;

            TextView Player5Wins = FindViewById<TextView>(Resource.Id.Player5Wins);
            Player5Wins.Text = data[0].Players[4].Wins;

            TextView Player5Looses = FindViewById<TextView>(Resource.Id.Player5Looses);
            Player5Looses.Text = data[0].Players[4].Looses;

            //TEAM2

            LinearLayout Player6Background = FindViewById<LinearLayout>(Resource.Id.Player6Background);
            // Player6Background.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[1].Players[0].ChampionImageLargeUrl));
            Player6Background.Background = new BitmapDrawable(Player6ChampionLargeImage);

            TextView Player6Name = FindViewById<TextView>(Resource.Id.Player6Name);
            Player6Name.Text = data[1].Players[0].Name;

            //ImageView Player1Champ = FindViewById<ImageView>(Resource.Id.Player1Champ);
            // Player1Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[0].ChampionImageUrl));



            TextView Player6SoloText = FindViewById<TextView>(Resource.Id.Player6SoloText);
            Player6SoloText.Text = data[1].Players[0].Solo;

            ImageView Player6DivisionImage = FindViewById<ImageView>(Resource.Id.Player6DivisionImage);
            Player6DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[1].Players[0].DevisionImageUrl));

            TextView Player6Division = FindViewById<TextView>(Resource.Id.Player6Division);
            Player6Division.Text = data[1].Players[0].Devision;

            TextView Player6WinPercantage = FindViewById<TextView>(Resource.Id.Player6WinPercantage);
            Player6WinPercantage.Text = data[1].Players[0].WinPercentage;

            TextView Player6Wins = FindViewById<TextView>(Resource.Id.Player6Wins);
            Player6Wins.Text = data[1].Players[0].Wins;

            TextView Player6Looses = FindViewById<TextView>(Resource.Id.Player6Looses);
            Player6Looses.Text = data[1].Players[0].Looses;


            LinearLayout Player7Background = FindViewById<LinearLayout>(Resource.Id.Player7Background);
            //Player7Background.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[1].Players[1].ChampionImageLargeUrl));
            Player7Background.Background = new BitmapDrawable(Player7ChampionLargeImage);


            TextView Player7Name = FindViewById<TextView>(Resource.Id.Player7Name);
            Player7Name.Text = data[1].Players[1].Name;

            //ImageView Player1Champ = FindViewById<ImageView>(Resource.Id.Player1Champ);
            // Player1Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[0].ChampionImageUrl));


            TextView Player7SoloText = FindViewById<TextView>(Resource.Id.Player7SoloText);
            Player7SoloText.Text = data[1].Players[1].Solo;

            ImageView Player7DivisionImage = FindViewById<ImageView>(Resource.Id.Player7DivisionImage);
            Player7DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[1].Players[1].DevisionImageUrl));

            TextView Player7Division = FindViewById<TextView>(Resource.Id.Player7Division);
            Player7Division.Text = data[1].Players[1].Devision;

            TextView Player7WinPercantage = FindViewById<TextView>(Resource.Id.Player7WinPercantage);
            Player7WinPercantage.Text = data[1].Players[1].WinPercentage;

            TextView Player7Wins = FindViewById<TextView>(Resource.Id.Player7Wins);
            Player7Wins.Text = data[1].Players[1].Wins;

            TextView Player7Looses = FindViewById<TextView>(Resource.Id.Player7Looses);
            Player7Looses.Text = data[1].Players[1].Looses;



            LinearLayout Player8Background = FindViewById<LinearLayout>(Resource.Id.Player8Background);
            //Player8Background.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[1].Players[2].ChampionImageLargeUrl));
            Player8Background.Background = new BitmapDrawable(Player8ChampionLargeImage);

            TextView Player8Name = FindViewById<TextView>(Resource.Id.Player8Name);
            Player8Name.Text = data[1].Players[2].Name;

            //ImageView Player1Champ = FindViewById<ImageView>(Resource.Id.Player1Champ);
            // Player1Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[0].ChampionImageUrl));


            TextView Player8SoloText = FindViewById<TextView>(Resource.Id.Player8SoloText);
            Player8SoloText.Text = data[1].Players[2].Solo;

            ImageView Player8DivisionImage = FindViewById<ImageView>(Resource.Id.Player8DivisionImage);
            Player8DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[1].Players[2].DevisionImageUrl));

            TextView Player8Division = FindViewById<TextView>(Resource.Id.Player8Division);
            Player8Division.Text = data[1].Players[2].Devision;

            TextView Player8WinPercantage = FindViewById<TextView>(Resource.Id.Player8WinPercantage);
            Player8WinPercantage.Text = data[1].Players[2].WinPercentage;

            TextView Player8Wins = FindViewById<TextView>(Resource.Id.Player8Wins);
            Player8Wins.Text = data[1].Players[2].Wins;

            TextView Player8Looses = FindViewById<TextView>(Resource.Id.Player8Looses);
            Player8Looses.Text = data[1].Players[2].Looses;



            LinearLayout Player9Background = FindViewById<LinearLayout>(Resource.Id.Player9Background);
            //Player9Background.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[1].Players[3].ChampionImageLargeUrl));
            Player9Background.Background = new BitmapDrawable(Player9ChampionLargeImage);

            TextView Player9Name = FindViewById<TextView>(Resource.Id.Player9Name);
            Player9Name.Text = data[1].Players[3].Name;

            //ImageView Player1Champ = FindViewById<ImageView>(Resource.Id.Player1Champ);
            // Player1Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[0].ChampionImageUrl));


            TextView Player9SoloText = FindViewById<TextView>(Resource.Id.Player9SoloText);
            Player9SoloText.Text = data[1].Players[3].Solo;

            ImageView Player9DivisionImage = FindViewById<ImageView>(Resource.Id.Player9DivisionImage);
            Player9DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[1].Players[3].DevisionImageUrl));

            TextView Player9Division = FindViewById<TextView>(Resource.Id.Player9Division);
            Player9Division.Text = data[1].Players[3].Devision;

            TextView Player9WinPercantage = FindViewById<TextView>(Resource.Id.Player9WinPercantage);
            Player9WinPercantage.Text = data[1].Players[3].WinPercentage;

            TextView Player9Wins = FindViewById<TextView>(Resource.Id.Player9Wins);
            Player9Wins.Text = data[1].Players[3].Wins;

            TextView Player9Looses = FindViewById<TextView>(Resource.Id.Player9Looses);
            Player9Looses.Text = data[1].Players[3].Looses;



            LinearLayout Player10Background = FindViewById<LinearLayout>(Resource.Id.Player10Background);
            // Player10Background.Background = new BitmapDrawable(GetImageBitmapFromUrl(data[1].Players[4].ChampionImageLargeUrl));
            Player10Background.Background = new BitmapDrawable(Player10ChampionLargeImage);

            TextView Player10Name = FindViewById<TextView>(Resource.Id.Player10Name);
            Player10Name.Text = data[1].Players[4].Name;

            //ImageView Player1Champ = FindViewById<ImageView>(Resource.Id.Player1Champ);
            // Player1Champ.SetImageBitmap(GetImageBitmapFromUrl(data[0].Players[0].ChampionImageUrl));


            TextView Player10SoloText = FindViewById<TextView>(Resource.Id.Player10SoloText);
            Player10SoloText.Text = data[1].Players[4].Solo;

            ImageView Player10DivisionImage = FindViewById<ImageView>(Resource.Id.Player10DivisionImage);
            Player10DivisionImage.SetImageBitmap(GetImageBitmapFromUrl(data[1].Players[4].DevisionImageUrl));

            TextView Player10Division = FindViewById<TextView>(Resource.Id.Player10Division);
            Player10Division.Text = data[1].Players[4].Devision;

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