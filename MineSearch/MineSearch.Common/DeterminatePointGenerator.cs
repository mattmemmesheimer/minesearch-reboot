﻿using System.Collections.Generic;

namespace MineSearch.Common
{
    /// <summary>
    /// Concrete implementation of <see cref="IPointGenerator"/>.
    /// The points generated by this class are provided in the constructor.
    /// </summary>
    public class DeterminatePointGenerator : BasePointGenerator
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DeterminatePointGenerator"/>.
        /// </summary>
        /// <param name="points">List of points to be generated.</param>
        public DeterminatePointGenerator(IList<Point> points)
        {
            _points = points;
            _currentIndex = 0;
        }

        /// <summary>
        /// Generates a point.
        /// </summary>
        /// <param name="maxRow">Maximum row.</param>
        /// <param name="maxColumn">Maximum column.</param>
        /// <returns>Point.</returns>
        public override Point Generate(int maxRow, int maxColumn)
        {
            if (_currentIndex == _points.Count)
            {
                _currentIndex = 0;
            }
            return _points[_currentIndex++];
        }

        #region Fields

        private readonly IList<Point> _points;
        private int _currentIndex;

        #endregion
    }
}
