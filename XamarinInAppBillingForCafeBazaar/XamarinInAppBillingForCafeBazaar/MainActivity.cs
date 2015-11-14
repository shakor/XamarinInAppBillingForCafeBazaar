using System;

using Android.App;
using Android.Content;
using Android.Views;
using Android.Util;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;

namespace XamarinInAppBillingForCafeBazaar
{
    [Activity(Label = "XamarinInAppBillingForCafeBazaar", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        IInAppBillingHelper _billingHelper;
        InAppBillingServiceConnection _serviceConnection;
        ListView _lvPurchsedItems;
        PurchaseAdapter _purchasesAdapter;


        protected override void OnCreate(Bundle bundle)
        {
            StartSetup();

            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _lvPurchsedItems = FindViewById<ListView>(Resource.Id.purchasedItemsList);

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;

            Button btnLoadPurchasedItems = FindViewById<Button>(Resource.Id.btnLoadPurchasedItems);
            btnLoadPurchasedItems.Click += BtnLoadPurchasedItems_Click;

            Button btnConsumePurchase = FindViewById<Button>(Resource.Id.btnConsumePurchase);
            btnConsumePurchase.Click += BtnConsumePurchase_Click;

        }

        private void BtnConsumePurchase_Click(object sender, EventArgs e)
        {
            try
            {
                var purchases = _billingHelper.GetPurchases("inapp");
                var purchasedItem = purchases.First();
                bool result = _billingHelper.ConsumePurchase(purchasedItem);

                if (result)
                {
                    _purchasesAdapter.Items.Remove(purchasedItem);
                    _purchasesAdapter.NotifyDataSetChanged();
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void BtnLoadPurchasedItems_Click(object sender, EventArgs e)
        {
            var purchases = _billingHelper.GetPurchases("inapp");

            _purchasesAdapter = new PurchaseAdapter(this, purchases);
            _lvPurchsedItems.Adapter = _purchasesAdapter;
            Toast.MakeText(this, purchases.Count.ToString(), ToastLength.Short).Show();

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            _billingHelper.LaunchPurchaseFlow("goleverestekhdam", "inapp", "payload");

        }

        public void StartSetup()
        {
            string publicKey = "MIHNMA0GCSqGSIb3DQEBAQUAA4G7ADCBtwKBrwDMj+fU1e54eAcRZeU0R1GXO4HnVd+YXkPtWfdlujPWRAifXs+4bKsTqQ9hRsPYOcHgWQR6PDMJPIxsi+U/TCSVSxYjWCu1wc5/UIggALFSpFKZ77BEi7xbMbp2g6j9kdDurarDOSWbIr0kRBKMbhgq/T6sXjzZdRYfQGeTwzHWAMz8TuTpMZYy/O62yHSiOSz/4uGZNwQ6UIsHuEFnx9+I1NazfYjsx3UUzEV1MPECAwEAAQ==";

            _serviceConnection = new InAppBillingServiceConnection(this, publicKey);
            _serviceConnection.OnConnected += HandleOnConnected;
            _serviceConnection.Connect();
        }

        void HandleOnConnected(object sender, EventArgs e)
        {
            _billingHelper = _serviceConnection.BillingHelper;

        }


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            _billingHelper.HandleActivityResult(requestCode, resultCode, data);

            if (resultCode.ToString() == "Ok")
            {
                Toast.MakeText(this, "پرداخت با موفقیت انجام شد", ToastLength.Short).Show();
            }

            else
            {
                Toast.MakeText(this, "خطا در هنگام پرداخت", ToastLength.Short).Show();
            }


        }


        protected override void OnDestroy()
        {
            if (_serviceConnection != null)
            {
                _serviceConnection.Disconnected();
            }

            base.OnDestroy();
        }


    }
}

