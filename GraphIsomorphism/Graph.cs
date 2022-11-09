using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphIsomorphism
{
    class Graph
    {
        int[] vertices;
        Dictionary<int, int[]> edges;

        public Graph() {}

        public Graph(int[] vertices, Dictionary<int, int[]> edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public int[] Vertices { get => vertices; set => vertices = value; }
        public Dictionary<int, int[]> Edges { get => edges; set => edges = value; }
    }
}
