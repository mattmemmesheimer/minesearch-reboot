using System.Collections.Generic;
using System.Collections.ObjectModel;
using MineSearch.Common.Annotations;

namespace MineSearch.Wpf.Models
{
    /// <summary>
    /// Collection of <see cref="GameSetting"/>.
    /// </summary>
    public class GameSettingsCollection : ReadOnlyCollection<GameSetting>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameSettingsCollection"/> class that 
        /// is a read-only wrapper around the specified list.
        /// </summary>
        /// <param name="list">The list to wrap.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="list"/> is null.
        /// </exception>
        public GameSettingsCollection([NotNull] IList<GameSetting> list) : base(list)
        {
        }
    }
}
