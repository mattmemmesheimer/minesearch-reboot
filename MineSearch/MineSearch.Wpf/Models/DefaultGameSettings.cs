using System.Collections.Generic;
using MineSearch.Common;

namespace MineSearch.Wpf.Models
{
    /// <summary>
    /// Default game settings.
    /// </summary>
    public class DefaultGameSettings : GameSettingsCollection
    {
        #region Constants

        private static readonly IPointGenerator DefaultGenerator = new RandomPointGenerator();

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultGameSettings"/> class.
        /// </summary>
        public DefaultGameSettings() : base(GetDefaults())
        {
        }

        private static List<GameSetting> GetDefaults()
        {
            // Create a list of the default game settings.
            return new List<GameSetting>
            {
                new GameSetting(9, 9, 10, DefaultGenerator)
                {
                    Name = "Beginner"
                },
                new GameSetting(16, 16, 40, DefaultGenerator)
                {
                    Name = "Intermediate"
                },
                new GameSetting(16, 30, 99, DefaultGenerator)
                {
                    Name = "Expert"
                }
            };
        }
    }
}
