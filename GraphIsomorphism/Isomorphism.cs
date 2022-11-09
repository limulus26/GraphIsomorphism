using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphIsomorphism
{
    class Isomorphism
    {
        Graph aGraph;
        Graph bGraph;

        public Isomorphism() { }

        public Isomorphism(Graph aGraph, Graph bGraph)
        {
            AGraph = aGraph;
            BGraph = bGraph;
        }

        internal Graph AGraph { get => aGraph; set => aGraph = value; }
        internal Graph BGraph { get => bGraph; set => bGraph = value; }

        public bool Check()
        {
            // Find the vertex, maxV, with the most edges in graph A, this is our starting point in Graph A
            int maxEdgeLength = 0;
            int maxV = 0;
            foreach(int vertex in AGraph.Vertices)
            {
                if(AGraph.Edges[vertex].Length > maxEdgeLength)
                {
                    maxEdgeLength = AGraph.Edges[vertex].Length;
                    maxV = vertex;
                }
            }

            // Tracking the layers of graph A
            List<List<int>> graphALayers = new List<List<int>> { };
            graphALayers.Add(AGraph.Edges[maxV].ToList());

            // Tracking the layers from multiple vertices in graph B
            Dictionary<int, List<List<int>>> matchingVertices = new Dictionary<int, List<List<int>>> { };

            // Add matching vertex candidates from graph B
            foreach (int vertex in BGraph.Vertices)
            {
                // check the number of edges for the vertex
                if(BGraph.Edges[vertex].Length == maxEdgeLength)
                {
                    // Add the vertex as a candidate
                    matchingVertices.Add(vertex, new List<List<int>> { });
                    // Add the vertex's edges as the first layer
                    matchingVertices[vertex].Add(BGraph.Edges[vertex].ToList());
                }
            }

            // Tracking for each vertex in graph A
            int[] notVisited = AGraph.Vertices;
            notVisited = notVisited.Where(val => val != maxV).ToArray();

            // Tracking for each vertex for each candidate in graph B
            Dictionary<int, int[]> notVisitedB = new Dictionary<int, int[]> { };
            foreach(int vertex in matchingVertices.Keys)
            {
                notVisitedB.Add(vertex, BGraph.Vertices);
            }

            // Lists to assist with the construction of each new topological layer
            List<int> nextLayerAVertices = new List<int> { };
            List<int> nextLayerBVertices = new List<int> { };

            // Repeat until all vertices have been visited
            while (notVisited.Length > 0)
            {
                // Constructs the topological order for graph A
                foreach(int layerVertex in graphALayers.Last())
                {
                    // Only visit new Vertices
                    if (notVisited.Contains(layerVertex))
                    {
                        // Mark next vertex as visited
                        notVisited = notVisited.Where(val => val != layerVertex).ToArray();

                        // Track all of a vertex's edges
                        foreach (int nextVertex in AGraph.Edges[layerVertex])
                        {
                            nextLayerAVertices.Add(nextVertex);
                        }
                    }  
                }
                // Submit new topological layer for graph A
                graphALayers.Add(nextLayerAVertices);

                // Check each candidate
                foreach (int vertex in matchingVertices.Keys.ToList())
                {
                    // Constructs the topological order for the candidate vertex
                    foreach(int layerVertex in matchingVertices[vertex].Last())
                    {
                        // Only visit new Vertices
                        if (notVisitedB[vertex].Contains(layerVertex))
                        {
                            // Mark next vertex as visited
                            notVisitedB[vertex] = notVisitedB[vertex].Where(val => val != layerVertex).ToArray();

                            // Track all of a vertex's edges
                            foreach (int nextVertex in BGraph.Edges[layerVertex])
                            {
                                nextLayerBVertices.Add(nextVertex);
                            }
                        }
                    }
                    // Submit new topological layer for candidate in graph B
                    matchingVertices[vertex].Add(nextLayerBVertices);

                    // Remove candidates with non-matching next-layer size
                    if(matchingVertices[vertex].Last().Count != graphALayers.Last().Count)
                    {
                        matchingVertices.Remove(vertex);
                    }
                }
            }

            // If any candidates remain, they have the same topological order as the vertex from graph A
            if(matchingVertices.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
