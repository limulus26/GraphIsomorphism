using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphIsomorphism;

namespace GraphIsomorphismTests
{
    [TestClass]
    public class IsomorphismTests
    {
        [TestMethod]
        public void GraphIsIsometricTest()
        {
            // Initialize first graph
            int[] aVertices = new int[] { 1, 2, 3, 4, 5 };
            Dictionary<int, int[]> aEdges = new Dictionary<int, int[]>
            {
                { 1, new int[] { 2, 3 } },
                { 2, new int[] { 1, 3, 4, 5 } },
                { 3, new int[] { 1, 2, 4 } },
                { 4, new int[] { 2, 3 } },
                { 5, new int[] { 2} }
            }; 
            Graph aGraph = new Graph(aVertices, aEdges);

            // Initialize second graph
            int[] bVertices = new int[] { 1, 2, 3, 4, 5 };
            Dictionary<int, int[]> bEdges = new Dictionary<int, int[]>
            {
                { 1, new int[] { 2, 3, 4, 5 } },
                { 2, new int[] { 1, 5 } },
                { 3, new int[] { 1, 5 } },
                { 4, new int[] { 1 } },
                { 5, new int[] { 1, 2, 3 } }
            };
            Graph bGraph = new Graph(bVertices, bEdges);

            Isomorphism graphPair = new Isomorphism(aGraph, bGraph);

            bool isomorphic = graphPair.Check();

            Assert.AreEqual(true, isomorphic, "Isomorphic graphs labelled as not isomorphic.");
        }

        [TestMethod]
        public void GraphsNotIsometricTest()
        {
            // Initialize first graph
            int[] aVertices = new int[] { 1, 2, 3, 4, 5 };
            Dictionary<int, int[]> aEdges = new Dictionary<int, int[]>
            {
                { 1, new int[] { 2, 3 } },
                { 2, new int[] { 1, 3, 4, 5 } },
                { 3, new int[] { 1, 2, 4 } },
                { 4, new int[] { 2, 3 } },
                { 5, new int[] { 2} }
            };
            Graph aGraph = new Graph(aVertices, aEdges);

            // Initialize second graph
            int[] bVertices = new int[] { 1, 2, 3, 4, 5 };
            Dictionary<int, int[]> bEdges = new Dictionary<int, int[]>
            {
                { 1, new int[] { 2, 3, 4, 5 } },
                { 2, new int[] { 1 } },
                { 3, new int[] { 1, 5 } },
                { 4, new int[] { 1 } },
                { 5, new int[] { 1, 3 } }
            };
            Graph bGraph = new Graph(bVertices, bEdges);

            Isomorphism graphPair = new Isomorphism(aGraph, bGraph);

            bool isomorphic = graphPair.Check();

            Assert.AreEqual(false, isomorphic, "Isomorphic graphs labelled as not isomorphic.");
        }
    }
}
