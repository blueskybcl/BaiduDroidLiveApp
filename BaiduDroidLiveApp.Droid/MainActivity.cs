using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using Android.Views;

using Android.Content.PM;

using System.IO;


using Com.Baidu.Recorder;
using Com.Baidu.Recorder.Api;

namespace BaiduDroidLiveApp.Droid
{
    [Activity(Label = "BaiduDroidLiveApp", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //var camera=new Camera.CameraInfo();



            var mLiveSession = new LiveSessionHW(this, 1280, 720, 15, 2048000, 0);

            mLiveSession.PrepareSessionAsync();

            SurfaceView cameraView = FindViewById<SurfaceView>(Resource.Id.camera);
            //cameraView.Holder
            mLiveSession.BindPreviewDisplay(cameraView.Holder);

           // LiveConfig liveConfig = new LiveConfig.Builder();

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { 
                
               var status =   mLiveSession.StartRtmpSession("Your rtmp live url");
                if(status)
                {
                    //var temp1 = 0;
                }
            };
        }
    }
}

