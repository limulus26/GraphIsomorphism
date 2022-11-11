# Graph Isomorphism

It's runtime is probably disasterous.

It probably doesn't work for every kind of graph.

It probably isn't even best practice.


But you know what?


It works for the given example.

I'll take my participation medal and wear it proudly thank you very much.
_______________________________________________________________________________________________________________________________________________________________________________
Prints true if the input graphs are isomorphic, false otherwise.


This is a topology based approach to graph isomorphism.

Essentially, we pick a vertex on graph A and try to find a vertex on graph B with the same topology... Kinda.
Once we have our vertex, V, in graph A, we perform a breadth-first-search over the graph and track the order size of each 'layer' as we search through the graph.

Next, we look for vertices on graph B with the same order as V. For each of these candidate vertices we do the same breadth-first-search over the graph and track the layers built from each candidate vertex. If the size of one of the layers does not match up with the size of that layer for V, then we rule out that candidate as being a matching vertex. 

If we are able to get all the way through the graph and still have one or more candidate vertices, then I'm calling it a win. I'm not 100% certain of the definition of isomorphism, but if the size of the topology layers is the same (i.e. at every layer, you have the same number of edges available to travel along) then the two graphs are pretty functionally close to being isomorphic. I'm gonna have to look into it more before i say its true isomorphism, but at least for now it satisfies some conditions, which is enough for my uni assignment.

peace out.
