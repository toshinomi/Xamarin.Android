using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Views;

namespace WebView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const string m_strUri = "https://www.bing.com/";
        
        private Button m_btnBack;
        private Button m_btnForward;
        private Button m_btnReload;
        private EditText m_textUri;
        private Android.Webkit.WebView m_webView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            InitLayout();

            HomeWebView();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void OnClick_Back(object sender, EventArgs e)
        {
            BackWebView();

            return;
        }

        private void OnClick_Foward(object sender, EventArgs e)
        {
            FowardWebView();

            return;
        }

        private void OnClick_Reload(object sender, EventArgs e)
        {
            ReloadWebView();

            return;
        }

        private void OnKeyPress_textUri(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                m_webView.LoadUrl(m_textUri.Text);
                e.Handled = true;
            }
        }

        public void InitLayout()
        {
            m_btnBack = (Button)FindViewById(Resource.Id.buttonBack);
            m_btnBack.Click += OnClick_Back;

            m_btnForward = (Button)FindViewById(Resource.Id.buttonForward);
            m_btnForward.Click += OnClick_Foward;

            m_btnReload = (Button)FindViewById(Resource.Id.buttonReload);
            m_btnReload.Click += OnClick_Reload;

            m_textUri = (EditText)FindViewById(Resource.Id.edittextUri);
            m_textUri.KeyPress += OnKeyPress_textUri;

            m_webView = (Android.Webkit.WebView)FindViewById(Resource.Id.webView1);

            return;
        }

        public bool BackWebView()
        {
            bool bRst = true;
            try
            {
                m_webView.GoBack();
            }
            catch (Exception)
            {
                bRst = false;
            }

            return bRst;
        }

        public bool FowardWebView()
        {
            bool bRst = true;
            try
            {
                m_webView.GoForward();
            }
            catch (Exception)
            {
                bRst = false;
            }

            return bRst;
        }

        public bool ReloadWebView()
        {
            bool bRst = true;
            try
            {
                m_webView.Reload();
            }
            catch (Exception)
            {
                bRst = false;
            }

            return bRst;
        }

        public bool HomeWebView()
        {
            m_textUri.Text = m_strUri;
            string strUri = m_strUri;
            return ShowWebView(ref strUri);
        }

        public bool ShowWebView(ref String _strUri)
        {
            bool bRst = true;
            try
            {
                m_webView.LoadUrl(_strUri);
                m_textUri.Text = _strUri;
            }
            catch (Exception)
            {
                bRst = false;
            }

            return bRst;
        }
    }
}