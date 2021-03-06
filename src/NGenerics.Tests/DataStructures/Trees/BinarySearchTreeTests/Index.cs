/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Index : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();

            var dictionary = new Dictionary<int, string>();

            var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            for (var i = 0; i < 50; i++)
            {
                var gen = rand.Next(2000);

                while (dictionary.ContainsKey(gen))
                {
                    gen = rand.Next(2000);
                }

                dictionary.Add(gen, null);

                tree.Add(gen, gen.ToString());

                Assert.IsTrue(tree.ContainsKey(gen));
                Assert.AreEqual(tree[gen], gen.ToString());
            }
        }

        [Test]
        public void Set()
        {
            var tree = new BinarySearchTree<int, string>();

            for (var i = 20; i > 10; i--)
            {
                tree.Add(i, i.ToString());
            }

            for (var i = 0; i < 10; i++)
            {
                tree.Add(i, i.ToString());
            }

            Assert.AreEqual(tree[0], "0");
            tree[0] = "1";
            Assert.AreEqual(tree[0], "1");

            tree[1] = "4";
            Assert.AreEqual(tree[1], "4");
        }

        [Test]
        public void ExceptionGetInvalidKey()
        {
            var tree = new BinarySearchTree<int, string>();
            string s;
            Assert.Throws<KeyNotFoundException>(() => s = tree[4]);
        }

        [Test]
        public void ExceptionSetInvalidKey()
        {
            var tree = new BinarySearchTree<int, string>();
            Assert.Throws<KeyNotFoundException>(() => tree[4] = "testString");
        }
    }
}