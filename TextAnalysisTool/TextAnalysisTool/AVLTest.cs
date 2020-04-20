using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AVLTestNUnit
{
    using TextAnalysisTool;


    [TestFixture]
    class AVLTest
    {

        private AVLTree<Word> avl;
        private Word w1, w2, w3, w4, w5, w6, w7;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            w1 = new Word("Star");
            w2 = new Word("Moon");
            w3 = new Word("Sun");
            w4 = new Word("Earth");
            w5 = new Word("Mars");
            w6 = new Word("Venus");
            w7 = new Word("Pluto");
        }

        [SetUp]
        public void SetUp()
        {
            avl = new AVLTree<Word>();
            avl.InsertItem(w1);
            avl.InsertItem(w2);
            avl.InsertItem(w3);
            avl.InsertItem(w4);
            avl.InsertItem(w5);
            avl.InsertItem(w6);
        }
        
        [TestCase] //test retrieval of Book nodes from tree
        public void GetBookNode()
        {
            Assert.AreEqual("Moon", avl.GetNode(w2).Key.TheWord, "Wrong title");
            Assert.AreEqual(0, avl.GetNode(w2).Key.Occurrences, "Wrong occur value");
            Assert.AreEqual(0, avl.GetNode(w2).Key.Locations.Count, "Wrong Location");
        }

        [TestCase] //test retrieval of non-existing Book node from tree
        public void GetNonExistingNode()
        {
            Word nothing = new Word("NOTHING");
            Assert.AreEqual(null, avl.GetNode(nothing), "Node does not exist");
        }

        [TestCase] //test removal Book node from tree
        public void RemoveBookNode()
        {
            avl.RemoveItem(w5);
            Assert.IsNull(avl.GetNode(w5));
        }
        
        [TestCase] //test height of tree
        public void GetTreeHeight()
        {
            Assert.AreEqual(3, avl.Height(), "Wrong tree height");
        }

        [TestCase] //test tree count
        public void GetTreeCount()
        {
            Assert.AreEqual(6, avl.Count(), "Wrong tree count");
        }

        [TestCase] //test tree containing existing node
        public void TreeContains()
        {
            Assert.IsTrue(avl.Contains(w4));
        }

        [TestCase] //test tree containing non-existing node
        public void TreeNonExistingContains()
        {
            Assert.IsFalse(avl.Contains(w7));
        }

        [TestCase] //test tree count
        public void TreeLeastItem()
        {
            Assert.AreEqual(w4, avl.LeastItem(avl.root));
        }


    }
}
