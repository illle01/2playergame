using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace _2playergame
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        TextView counter, turn;
        Button btn1, btn2, btn3;
        bool isplayer1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            isplayer1 = true;

            turn = FindViewById<TextView>(Resource.Id.textView2);
            counter = FindViewById<TextView>(Resource.Id.textView1);
            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn3 = FindViewById<Button>(Resource.Id.button3);
            

            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
        }

        public void checkwinner()
        {
            if (int.Parse(counter.Text)>= 21)
            {
                if (isplayer1)
                {
                    turn.Text = "Spelare ett förlorar";
                }
                else
                {
                    turn.Text = "Spelare två förlorar";
                }
            }
            if (isplayer1)
            {
                isplayer1 = false;
                turn.Text = "Spelare två";
            }
            else
            {
                isplayer1 = true;
                turn.Text = "Spelare ett";
            }
        }

        private void Btn3_Click(object sender, System.EventArgs e)
        {
            counter.Text = (int.Parse(counter.Text) + 3).ToString();
            checkwinner();
        }

        private void Btn2_Click(object sender, System.EventArgs e)
        {
            counter.Text = (int.Parse(counter.Text) + 2).ToString();
            checkwinner();
        }

        private void Btn1_Click(object sender, System.EventArgs e)
        {
            counter.Text = (int.Parse(counter.Text) + 1).ToString();
            checkwinner();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}