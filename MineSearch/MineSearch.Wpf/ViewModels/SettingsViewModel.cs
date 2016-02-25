using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using MineSearch.Common.ViewModels;
using MineSearch.Game;
using MineSearch.Wpf.Models;
using Prism.Interactivity.InteractionRequest;

namespace MineSearch.Wpf.ViewModels
{
    public class SettingsViewModel : ViewModelBase, INotification, IInteractionRequestAware
    {
        #region Commands

        /// <summary>
        /// Select game setting command.
        /// </summary>
        public ICommand SelectGameSettingCommand { get; private set; }

        /// <summary>
        /// Save command.
        /// </summary>
        public ICommand SaveCommand { get; private set; }

        /// <summary>
        /// Cancel command.
        /// </summary>
        public ICommand CancelCommand { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the title to use for the notification.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the content of the notification.
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// The <see cref="T:Prism.Interactivity.InteractionRequest.INotification"/> 
        /// passed when the interaction request was raised.
        /// </summary>
        public INotification Notification { get; set; }

        /// <summary>
        /// Game settings.
        /// </summary>
        public IGameSettings SelectedGameSetting { get; private set; }

        /// <summary>
        /// An <see cref="T:System.Action"/> that can be invoked to finish the interaction.
        /// </summary>
        public Action FinishInteraction { get; set; }

        /// <summary>
        /// Whether or not the settings were saved.
        /// </summary>
        public bool Saved { get; set; }

        /// <summary>
        /// Default game settings.
        /// </summary>
        public DefaultGameSettings DefaultGameSettings { get; private set; } 

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
        /// </summary>
        /// <param name="defaultGameSettings">Default game settings.</param>
        public SettingsViewModel(DefaultGameSettings defaultGameSettings)
        {
            Content = Title = "";

            DefaultGameSettings = defaultGameSettings;

            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
            SelectGameSettingCommand = new DelegateCommand<GameSetting>(SelectGameSetting);
        }

        private void Save()
        {
            SelectedGameSetting = DefaultGameSettings.First(s => s.Selected);
            Saved = true;
            FinishInteraction();
        }

        private void Cancel()
        {
            Saved = false;
            FinishInteraction();
        }

        private void SelectGameSetting(GameSetting setting)
        {
            foreach (var gameSetting in DefaultGameSettings)
            {
                gameSetting.Selected = false;
            }
            setting.Selected = true;
            SelectedGameSetting = setting;
        }
    }
}
