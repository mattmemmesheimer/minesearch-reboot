using MineSearch.Wpf.ViewModels;

namespace MineSearch.Wpf.Views.UserControls
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView
    {
        public SettingsViewModel ViewModel { get { return DataContext as SettingsViewModel; } }

        public SettingsView()
        {
            InitializeComponent();
        }
    }
}
