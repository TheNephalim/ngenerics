﻿/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Collections.Generic;

namespace NGenerics.Comparers {
    /// <summary>
    /// A comparer for comparing keys for the KeyValuePair class.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
	/// <typeparam name="TValue">The value type.</typeparam>
    [Serializable]
    public class KeyValuePairComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>> {

        #region Globals

        private readonly IComparer<TKey> _comparer;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValuePairComparer&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        public KeyValuePairComparer() {
            _comparer = Comparer<TKey>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValuePairComparer&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public KeyValuePairComparer(IComparer<TKey> comparer) {
            this._comparer = comparer ?? throw new ArgumentNullException("comparer");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValuePairComparer&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        /// <param name="comparison">The comparison.</param>
        public KeyValuePairComparer(Comparison<TKey> comparison)
        {
            if (comparison == null) {
                throw new ArgumentNullException("comparison");
            }

            _comparer = new ComparisonComparer<TKey>(comparison);
        }

        #endregion

        #region IComparer<KeyValuePairComparer<TKey,TValue>> Members

        /// <inheritdoc />
        public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y) {
            return _comparer.Compare(x.Key, y.Key);
        }

        #endregion

        #region IComparer<TKey> Members

        /// <inheritdoc />
        public int Compare(TKey x, TKey y) {
            return _comparer.Compare(x, y);
        }

        #endregion

    }
}