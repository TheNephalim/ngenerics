/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class AbsoluteMaximumIndex
    {
        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(1, vector1.AbsoluteMaximumIndex());
        }
    }
}