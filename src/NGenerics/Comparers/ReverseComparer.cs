/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Comparers
{
	/// <summary>
	/// A comparer that wraps the IComparable interface to reproduce the opposite comparison result.
	/// </summary>
	/// <typeparam name="T">The type of the objects to compare.</typeparam>
    [Serializable]
    public sealed class ReverseComparer<T> : IComparer<T>
    {
        #region Globals

        private IComparer<T> _comparerToUse;

        #endregion

        #region Construction
        /// <inheritdoc />
        public ReverseComparer()
        {
            _comparerToUse = Comparer<T>.Default;
        }

 
        /// <param name="comparer">The comparer to reverse.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public ReverseComparer(IComparer<T> comparer)
        {

            Guard.ArgumentNotNull(comparer, "comparer");
            _comparerToUse = comparer;
        }

        #endregion

        #region IComparer<T> Members

        /// <inheritdoc />
        public int Compare(T x, T y) => _comparerToUse.Compare(y, x);

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the comparer used in this instance.
        /// </summary>
        /// <value>The comparer.</value>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public IComparer<T> Comparer
        {
            get => _comparerToUse;
            set
            {
                Guard.ArgumentNotNull(value, "value");
                _comparerToUse = value;
            }
        }

        #endregion
    }
}
