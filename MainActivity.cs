using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using LolNexusDLL;
using System.Collections.Generic;
using Android.Content;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Android.Graphics;
using System.Net;
using Android.Net;
using Android.Preferences;
using Firebase.Analytics;
using Android.Gms.Ads;

namespace LoLNexusAndroid
{
    [Activity(Label = "LoLNexus", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private string Region = "EUNE";
        protected AdView MainAd;
        public static InterstitialAd Inter;
        public static ProgressBar progress;
        FirebaseAnalytics firebaseAnalytics;
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
        public bool HasInternet()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
            bool isOnline = networkInfo != null && networkInfo.IsConnectedOrConnecting;
            return isOnline;

        }
        public static void RequestNewInterstitial()

        {

            var adRequest = new Android.Gms.Ads.AdRequest.Builder().Build();

            Inter.LoadAd(adRequest);

        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            firebaseAnalytics = FirebaseAnalytics.GetInstance(this);


            Inter = new InterstitialAd(this);
            Inter.AdUnitId = @"ca-app-pub-6587288653197033/9171749372";
            RequestNewInterstitial();

            //MobileAds.Initialize(this, @"ca-app-pub-8723045763935491~6083413387");
            MainAd = FindViewById<AdView>(Resource.Id.adView1);
            var adRequest = new Android.Gms.Ads.AdRequest.Builder().Build();
            MainAd.LoadAd(adRequest);

            Button SearchButton = FindViewById<Button>(Resource.Id.SearchButton);
            EditText InputField = FindViewById<EditText>(Resource.Id.SearchInput);
            progress = FindViewById<ProgressBar>(Resource.Id.Progress);
            progress.Visibility = Android.Views.ViewStates.Invisible;


            Spinner RegionSpinner = FindViewById<Spinner>(Resource.Id.RegionSpinner);
            //RegionSpinner.SetPopupBackgroundDrawable(Android.Graphics.Color.Argb(255, 0, 0, 0));

            RegionSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(RegionSpinner_ItemSelected);
            //GenderPicker
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.RegionSpinner, Resource.Layout.spinner);

            adapter.SetDropDownViewResource(Resource.Layout.SpinnerItems);
            RegionSpinner.Adapter = adapter;

            Android.Support.V7.App.AlertDialog.Builder Alert = new Android.Support.V7.App.AlertDialog.Builder(this);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();

            CheckBox Rembember = FindViewById<CheckBox>(Resource.Id.RememberCheckBox);
            CheckBox FastMode = FindViewById<CheckBox>(Resource.Id.FastMode);
            Rembember.CheckedChange += delegate
            {
                var IsCheck = Rembember.Checked;
                editor.PutBoolean("Remember", IsCheck);
                editor.Apply();
            };
            FastMode.CheckedChange += delegate
            {
                var IsCheck = FastMode.Checked;
                editor.PutBoolean("FastMode", IsCheck);
                editor.Apply();
            };

            Rembember.Checked = prefs.GetBoolean("Remember", false);
            FastMode.Checked = prefs.GetBoolean("FastMode", false);

            InputField.Text = prefs.GetString("RememberedUser", "");
            RegionSpinner.SetSelection(prefs.GetInt("RememberedRegionPosition", 0));

          
            
            SearchButton.Click += delegate
            {             
              
                bool IsFastMode = prefs.GetBoolean("FastMode", false);

                Inter.RewardedVideoAdClosed += delegate
                {
                    if (prefs.GetBoolean("Remember", false))
                    {
                        editor.PutString("RememberedUser", InputField.Text);
                        editor.PutInt("RememberedRegionPosition", RegionSpinner.SelectedItemPosition);
                        editor.Apply();
                    }

                    if (IsFastMode)
                    {
                        try
                        {
                            if (!HasInternet())
                            {
                                Alert.SetTitle("Internet connection is required.");
                                //Alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
                                Alert.SetPositiveButton("Ok", (senderAlert, args) => {
                                });
                                Alert.Show();
                                return;
                            };
                            if (InputField.Text == "")
                            {
                                Alert.SetTitle("Please enter player name.");
                                //Alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
                                Alert.SetPositiveButton("Ok", (senderAlert, args) => {
                                });
                                Alert.Show();
                                return;
                            }

                            progress.Visibility = Android.Views.ViewStates.Visible;

                            Task.Run(() =>
                            {
                                string username = InputField.Text;
                                string region = Region;

                                LolNexus nexus = new LolNexus();
                                Tuple<string, List<Team>> tuple = nexus.GetNexusData(username, region);

                                var result = tuple.Item2;

                                if (tuple.Item1 != "success" || result == null)
                                {

                                    Intent erAct = new Intent(this, typeof(NoResult));
                                    erAct.PutExtra("errorMsg", tuple.Item1);
                                    StartActivity(erAct);
                                    progress.Visibility = Android.Views.ViewStates.Invisible;


                                    return;
                                };

                                List<Team> data = tuple.Item2;



                                Intent act = new Intent(this, typeof(GameDataFastActivity));
                                act.PutExtra("data", JsonConvert.SerializeObject(data));
                                StartActivity(act);

                            });



                        }
                        catch
                        {
                            Intent erAct = new Intent(this, typeof(NoResult));
                            erAct.PutExtra("errorMsg", "Please make sure your internet connection is stable.");
                            StartActivity(erAct);
                            progress.Visibility = Android.Views.ViewStates.Invisible;

                        }
                    }
                    else
                    {
                        try
                        {
                            if (!HasInternet())
                            {
                                Alert.SetTitle("Internet connection is required.");
                                //Alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
                                Alert.SetPositiveButton("Ok", (senderAlert, args) => {
                                });
                                Alert.Show();
                                return;
                            };
                            if (InputField.Text == "")
                            {
                                Alert.SetTitle("Please enter player name.");
                                //Alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
                                Alert.SetPositiveButton("Ok", (senderAlert, args) => {
                                });
                                Alert.Show();
                                return;
                            }

                            progress.Visibility = Android.Views.ViewStates.Visible;

                            Task.Run(() =>
                            {
                                string username = InputField.Text;
                                string region = Region;

                                LolNexus nexus = new LolNexus();
                                Tuple<string, List<Team>> tuple = nexus.GetNexusData(username, region);

                                var result = tuple.Item2;

                                if (tuple.Item1 != "success" || result == null)
                                {

                                    Intent erAct = new Intent(this, typeof(NoResult));
                                    erAct.PutExtra("errorMsg", tuple.Item1);
                                    StartActivity(erAct);
                                    progress.Visibility = Android.Views.ViewStates.Invisible;


                                    return;
                                };

                                List<Team> data = tuple.Item2;

                                GameDataActivity.Player1ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[0].ChampionImageLargeUrl);
                                GameDataActivity.Player2ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[1].ChampionImageLargeUrl);
                                GameDataActivity.Player3ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[2].ChampionImageLargeUrl);
                                GameDataActivity.Player4ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[3].ChampionImageLargeUrl);
                                GameDataActivity.Player5ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[4].ChampionImageLargeUrl);

                                GameDataActivity.Player6ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[0].ChampionImageLargeUrl);
                                GameDataActivity.Player7ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[1].ChampionImageLargeUrl);
                                GameDataActivity.Player8ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[2].ChampionImageLargeUrl);
                                GameDataActivity.Player9ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[3].ChampionImageLargeUrl);
                                GameDataActivity.Player10ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[4].ChampionImageLargeUrl);

                                Intent act = new Intent(this, typeof(GameDataActivity));
                                act.PutExtra("data", JsonConvert.SerializeObject(data));
                                StartActivity(act);

                            });



                        }
                        catch
                        {
                            Intent erAct = new Intent(this, typeof(NoResult));
                            erAct.PutExtra("errorMsg", "Please make sure your internet connection is stable.");
                            StartActivity(erAct);
                            progress.Visibility = Android.Views.ViewStates.Invisible;

                        }
                    }
                };

                if (Inter.IsLoaded)
                {
                    Inter.Show();


                }
                else
                {
                    if (prefs.GetBoolean("Remember", false))
                    {
                        editor.PutString("RememberedUser", InputField.Text);
                        editor.PutInt("RememberedRegionPosition", RegionSpinner.SelectedItemPosition);
                        editor.Apply();
                    }

                    if (IsFastMode)
                    {
                        try
                        {
                            if (!HasInternet())
                            {
                                Alert.SetTitle("Internet connection is required.");
                                //Alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
                                Alert.SetPositiveButton("Ok", (senderAlert, args) => {
                                });
                                Alert.Show();
                                return;
                            };
                            if (InputField.Text == "")
                            {
                                Alert.SetTitle("Please enter player name.");
                                //Alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
                                Alert.SetPositiveButton("Ok", (senderAlert, args) => {
                                });
                                Alert.Show();
                                return;
                            }

                            progress.Visibility = Android.Views.ViewStates.Visible;

                            Task.Run(() =>
                            {
                                string username = InputField.Text;
                                string region = Region;

                                LolNexus nexus = new LolNexus();
                                Tuple<string, List<Team>> tuple = nexus.GetNexusData(username, region);

                                var result = tuple.Item2;

                                if (tuple.Item1 != "success" || result == null)
                                {

                                    Intent erAct = new Intent(this, typeof(NoResult));
                                    erAct.PutExtra("errorMsg", tuple.Item1);
                                    StartActivity(erAct);
                                    progress.Visibility = Android.Views.ViewStates.Invisible;


                                    return;
                                };

                                List<Team> data = tuple.Item2;



                                Intent act = new Intent(this, typeof(GameDataFastActivity));
                                act.PutExtra("data", JsonConvert.SerializeObject(data));
                                StartActivity(act);

                            });



                        }
                        catch
                        {
                            Intent erAct = new Intent(this, typeof(NoResult));
                            erAct.PutExtra("errorMsg", "Please make sure your internet connection is stable.");
                            StartActivity(erAct);
                            progress.Visibility = Android.Views.ViewStates.Invisible;

                        }
                    }
                    else
                    {
                        try
                        {
                            if (!HasInternet())
                            {
                                Alert.SetTitle("Internet connection is required.");
                                //Alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
                                Alert.SetPositiveButton("Ok", (senderAlert, args) => {
                                });
                                Alert.Show();
                                return;
                            };
                            if (InputField.Text == "")
                            {
                                Alert.SetTitle("Please enter player name.");
                                //Alert.SetMessage("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.");
                                Alert.SetPositiveButton("Ok", (senderAlert, args) => {
                                });
                                Alert.Show();
                                return;
                            }

                            progress.Visibility = Android.Views.ViewStates.Visible;

                            Task.Run(() =>
                            {
                                string username = InputField.Text;
                                string region = Region;

                                LolNexus nexus = new LolNexus();
                                Tuple<string, List<Team>> tuple = nexus.GetNexusData(username, region);

                                var result = tuple.Item2;

                                if (tuple.Item1 != "success" || result == null)
                                {

                                    Intent erAct = new Intent(this, typeof(NoResult));
                                    erAct.PutExtra("errorMsg", tuple.Item1);
                                    StartActivity(erAct);
                                    progress.Visibility = Android.Views.ViewStates.Invisible;


                                    return;
                                };

                                List<Team> data = tuple.Item2;

                                GameDataActivity.Player1ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[0].ChampionImageLargeUrl);
                                GameDataActivity.Player2ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[1].ChampionImageLargeUrl);
                                GameDataActivity.Player3ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[2].ChampionImageLargeUrl);
                                GameDataActivity.Player4ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[3].ChampionImageLargeUrl);
                                GameDataActivity.Player5ChampionLargeImage =
                                GetImageBitmapFromUrl(data[0].Players[4].ChampionImageLargeUrl);

                                GameDataActivity.Player6ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[0].ChampionImageLargeUrl);
                                GameDataActivity.Player7ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[1].ChampionImageLargeUrl);
                                GameDataActivity.Player8ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[2].ChampionImageLargeUrl);
                                GameDataActivity.Player9ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[3].ChampionImageLargeUrl);
                                GameDataActivity.Player10ChampionLargeImage =
                                GetImageBitmapFromUrl(data[1].Players[4].ChampionImageLargeUrl);

                                Intent act = new Intent(this, typeof(GameDataActivity));
                                act.PutExtra("data", JsonConvert.SerializeObject(data));
                                StartActivity(act);

                            });



                        }
                        catch
                        {
                            Intent erAct = new Intent(this, typeof(NoResult));
                            erAct.PutExtra("errorMsg", "Please make sure your internet connection is stable.");
                            StartActivity(erAct);
                            progress.Visibility = Android.Views.ViewStates.Invisible;

                        }
                    }
                }
               
            
                

                

            };

        }

        public void RegionSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string Picked = spinner.GetItemAtPosition(e.Position).ToString();
            Region = Picked;

        }
  

    }
}



