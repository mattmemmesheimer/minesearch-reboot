﻿using System;
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
        public IGameSettings GameSettings
        {
            get { return _gameSettings; }
            set
            {
                _gameSettings = new GameSettings(value);
            }
        }

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
        }

        private void Save()
        {
            Saved = true;
            FinishInteraction();
        }

        private void Cancel()
        {
            Saved = false;
            FinishInteraction();
        }

        #region Fields

        private IGameSettings _gameSettings;

        #endregion
    }
}
