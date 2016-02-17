using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using MineSearch.Common.ViewModels;
using MineSearch.Wpf.Models;
using Prism.Interactivity.InteractionRequest;

namespace MineSearch.Wpf.ViewModels
{
    /// <summary>
    /// Main window view model.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region Commands

        /// <summary>
        /// Settings command.
        /// </summary>
        public ICommand SettingsCommand { get; private set; }

        /// <summary>
        /// Exit command.
        /// </summary>
        public ICommand ExitCommand { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// Game view model.
        /// </summary>
        public IMineSearchGameViewModel GameViewModel { get; private set; }

        /// <summary>
        /// Settings dialog request.
        /// </summary>
        public InteractionRequest<SettingsViewModel> SettingsRequest { get; private set; }

        // ReSharper disable once CollectionNeverUpdated.Global
        public DefaultGameSettings DefaultGameSettings { get; private set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            // Create the default game settings
            DefaultGameSettings = new DefaultGameSettings();
            var defaultGameSetting = DefaultGameSettings.First();
            defaultGameSetting.Selected = true;
            // Use the first game setting
            GameViewModel = new MineSearchGameViewModel(defaultGameSetting);

            SettingsRequest = new InteractionRequest<SettingsViewModel>();
            SettingsCommand = new DelegateCommand(RaiseSettingsRequest);
            ExitCommand = new DelegateCommand<IBaseWindow>(CloseWindow);
        }

        private void RaiseSettingsRequest()
        {
            var settingsViewModel = new SettingsViewModel(DefaultGameSettings);
            SettingsRequest.Raise(settingsViewModel, result =>
            {
                if (result.Saved)
                {
                    // Start a new game with the new settings
                    GameViewModel.NewGameCommand.Execute(result.SelectedGameSetting);
                }
            });
        }

        private void CloseWindow(IBaseWindow window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
