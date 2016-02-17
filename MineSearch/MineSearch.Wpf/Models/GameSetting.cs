using MineSearch.Common;
using MineSearch.Game;

namespace MineSearch.Wpf.Models
{
    /// <summary>
    /// Wrapper around a <see cref="GameSettings"/> instance.
    /// </summary>
    public class GameSetting : GameSettings
    {
        #region Properties

        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether or not this setting is selected.
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (value != _selected)
                {
                    _selected = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GameSetting"/> class.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="mineCount"></param>
        /// <param name="generator"></param>
        public GameSetting(int rows, int columns, int mineCount, IPointGenerator generator)
            : base(rows, columns, mineCount, generator)
        {
        }

        /// <summary>
        /// Initializes a copy of the <see cref="IGameSettings"/> class.
        /// </summary>
        /// <param name="rhs">Settings to copy.</param>
        public GameSetting(IGameSettings rhs) : base(rhs)
        {
        }

        #region Fields

        private bool _selected;

        #endregion
    }
}
