using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphIsomorphism
{
    public class Isomorphism
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

        public bool WLTest()
        {
            List<Graph> graphList = new List<Graph>
            {
                AGraph,
                BGraph
            };

            // generate canonical forms for each graph
            foreach(Graph graph in graphList)
            {
                // holds the partition ID of each vertex
                Dictionary<int, int> ID = new Dictionary<int, int> { };

                // holds the partition set of each vertex
                Dictionary<int, List<int>> set = new Dictionary<int, List<int>> { };

                // initialize partitions to 1
                foreach (int vertex in graph.Vertices)
                {
                    ID.Add(vertex, 1);
                    set.Add(vertex, new List<int> { });
                }
                List<List<int>> lastPartitions = new List<List<int>> {
                    { graph.Vertices.ToList() }
                };

                int nextPID = 2;
                bool partitionsEqual = false;

                while (!partitionsEqual)
                {
                    graph.Partitions = new List<List<int>> { };

                    // generate new partition set for each vertex
                    foreach (int vertex in graph.Vertices)
                    {
                        foreach (int edge in graph.Edges[vertex])
                        {
                            set[vertex].Add(ID[edge]);
                        }
                    }

                    // update partition IDs
                    List<int> notUpdated = graph.Vertices.ToList();
                    while (notUpdated.Count != 0)
                    {
                        int vertex = notUpdated.Last();
                        ID[vertex] = nextPID;
                        notUpdated.Remove(vertex);
                        List<int> newPartition = new List<int> { vertex };
                        // check the partition set of each other vertex
                        foreach (int eachOtherVertex in notUpdated)
                        {
                            if (set[eachOtherVertex].All(set[vertex].Contains) && set[eachOtherVertex].Count == set[vertex].Count)
                            {
                                ID[eachOtherVertex] = ID[vertex];
                                newPartition.Add(eachOtherVertex);
                            }
                        }
                        foreach(int otherVertices in newPartition)
                        {
                            notUpdated.Remove(otherVertices);
                        }
                        graph.Partitions.Add(newPartition);
                        nextPID += 1;
                    }

                    // checks for final canonical form
                    partitionsEqual = true;
                    foreach (List<int> eachPartition in graph.Partitions)
                    {
                        bool foundPartition = false;
                        foreach (List<int> oldPartition in lastPartitions)
                        {
                            if ((eachPartition.All(oldPartition.Contains) && eachPartition.Count == oldPartition.Count))
                            {
                                foundPartition = true;
                            }
                        }
                        if (foundPartition == false)
                        {
                            partitionsEqual = false;
                        }
                    }
                    lastPartitions = graph.Partitions;
                }
            }            
            
            // Compare canonical forms for each graph
            foreach(List<int> eachPartition in AGraph.Partitions)
            {
                bool foundPartition = false;
                foreach (List<int> oldPartition in BGraph.Partitions)
                {
                    if ((eachPartition.All(oldPartition.Contains) && eachPartition.Count == oldPartition.Count))
                    {
                        foundPartition = true;
                    }
                }
                if (foundPartition == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
