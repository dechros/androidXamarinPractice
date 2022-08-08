using androidXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace androidXamarin.Views
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