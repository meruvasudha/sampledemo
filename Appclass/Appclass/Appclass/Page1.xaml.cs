using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Appclass
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            rootlayout.Children.Insert(0, new ScrollView
            {
                Content = _wraplayout,
                VerticalOptions = LayoutOptions.FillAndExpand
            }


                     );

        }


        StackLayout _wraplayout = new StackLayout();




        bool isrefreahing;


        void showstatus(string msg, bool active = true)
        {
            txtstatus.Text = msg;
            activity.IsVisible = activity.IsRunning = active;

        }

        async void refreshimage(Object o, EventArgs e)
        {
            if (isrefreahing)
            {
                return;
            }
            isrefreahing = true;
            showstatus("refreshing....", true);

            await updateallimagesasync();
            showstatus("Done....", false);


        }

        async Task updateallimagesasync()
        {
            _wraplayout.Children.Clear();
            var uris = await BlobM.Instance.getallblobasync();
            foreach (var uri in uris)
            {

                var img = new Image
                {
                    Source = ImageSource.FromUri(uri),
                    WidthRequest = 70

                };
                _wraplayout.Children.Add(img);
            }


        }
        public void addimage(Object o, EventArgs e)
        {


        }

    }
}
