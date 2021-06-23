using GdeVse.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GdeVse.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}