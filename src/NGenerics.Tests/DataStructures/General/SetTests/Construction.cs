/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void UpperBound()
        {
            var pascalSet = new PascalSet(50);
            Assert.AreEqual(pascalSet.LowerBound, 0);
            Assert.AreEqual(pascalSet.UpperBound, 50);
            Assert.AreEqual(pascalSet.Count, 0);

            for (var i = 0; i <= 50; i++)
            {
                Assert.IsFalse(pascalSet[i]);
            }
        }

        [Test]
        public void LowerBoundUpperBound()
        {
            var pascalSet = new PascalSet(10, 50);

            Assert.AreEqual(pascalSet.LowerBound, 10);
            Assert.AreEqual(pascalSet.UpperBound, 50);
            Assert.AreEqual(pascalSet.Count, 0);

            for (var i = 10; i <= 50; i++)
            {
                Assert.IsFalse(pascalSet[i]);
            }
        }

        [Test]
        public void UpperBoundInitial()
        {
            var values = new[] { 20, 30, 40 };

            var pascalSet = new PascalSet(50, values);

            Assert.AreEqual(pascalSet.LowerBound, 0);
            Assert.AreEqual(pascalSet.UpperBound, 50);
            Assert.AreEqual(pascalSet.Count, 3);

            for (var i = 0; i <= 50; i++)
            {
                if ((i == 20) || (i == 30) || (i == 40))
                {
                    Assert.IsTrue(pascalSet[i]);
                }
                else
                {
                    Assert.IsFalse(pascalSet[i]);
                }
            }
        }

        [Test]
        public void LowerBoundUpperBoundInitialValues()
        {
            var values = new[] { 20, 30, 40 };

            var pascalSet = new PascalSet(10, 50, values);

            Assert.AreEqual(pascalSet.LowerBound, 10);
            Assert.AreEqual(pascalSet.UpperBound, 50);
            Assert.AreEqual(pascalSet.Count, 3);

            for (var i = 10; i <= 50; i++)
            {
                if ((i == 20) || (i == 30) || (i == 40))
                {
                    Assert.IsTrue(pascalSet[i]);
                }
                else
                {
                    Assert.IsFalse(pascalSet[i]);
                }
            }
        }

        [Test]
        public void ExceptionInvalidLowerBounds1()
        {
            Assert.Throws<ArgumentException>(() => new PascalSet(-1, 10));
        }

        [Test]
        public void ExceptionInvalidLowerBounds2()
        {
            Assert.Throws<ArgumentException>(() => new PascalSet(-1, 10, new[] { 3, 4 }));
        }

        [Test]
        public void ExceptionUpperBoundSmallerThanLowerBound1()
        {
            Assert.Throws<ArgumentException>(() => new PascalSet(12, 10));
        }

        [Test]
        public void ExceptionUpperBoundSmallerThanLowerBound2()
        {
            Assert.Throws<ArgumentException>(() => new PascalSet(12, 10, new[] { 3, 4 }));
        }

        [Test]
        public void ExceptionNullValues()
        {
            Assert.Throws<ArgumentNullException>(() => new PascalSet(5, 10, null));
        }

        [Test]
        public void ExceptionUpperBoundNull()
        {
            Assert.Throws<ArgumentNullException>(() => new PascalSet(10, null));
        }

        [Test]
        public void ExceptionInvalidInitialValues1()
        {
            Assert.Throws<ArgumentException>(() => new PascalSet(10, 20, new[] { 3, 4, 15, 16 }));
        }

        [Test]
        public void ExceptionInvalidInitialValues2()
        {
            Assert.Throws<ArgumentException>(() => new PascalSet(10, 20, new[] { 22, 12, 15, 16 }));
        }
    }
}