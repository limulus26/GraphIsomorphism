using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphIsomorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize first graph
            int[] aVertices = new int[] { 1, 2, 3, 4, 5 };
            Dictionary<int, int[]> aEdges = new Dictionary<int, int[]>
            {
                { 1, new int[] { 2, 3, 4, 5 } },
                { 2, new int[] { 1, 3, 4, 5 } },
                { 3, new int[] { 1, 2, 4, 5 } },
                { 4, new int[] { 1, 2, 3, 5 } },
                { 5, new int[] { 1, 2, 3, 4 } }
            };

            Graph aGraph = new Graph(aVertices, aEdges);

            // Initialize second graph
            int[] bVertices = new int[] { 1, 2, 3, 4, 5 };
            Dictionary<int, int[]> bEdges = new Dictionary<int, int[]>
            {
                { 1, new int[] { 2, 3, 4, 5 } },
                { 2, new int[] { 1, 3, 4, 5 } },
                { 3, new int[] { 1, 2, 4, 5 } },
                { 4, new int[] { 1, 2, 3 } },
                { 5, new int[] { 1, 2, 3 } }
            };

            Graph bGraph = new Graph(bVertices, bEdges);

            Isomorphism graphPair = new Isomorphism(aGraph, bGraph);

            // Print true if the graphs are isomorphic
            Console.Write(graphPair.WLTest());
            Console.ReadKey();
        }
    }
}
