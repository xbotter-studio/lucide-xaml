using LucideIcons.MAUI.Sample.Models;
using LucideIcons.MAUI.Sample.PageModels;

namespace LucideIcons.MAUI.Sample.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}