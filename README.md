# Cutting Stock Problem

Grasshopper Implementation of a C# greedy solution of the *Cutting Stock Problem*

From Wikipedia:
>In operations research, the cutting-stock problem is the problem of cutting standard-sized pieces of stock material, such as paper rolls or sheet metal, into pieces of specified sizes while minimizing material wasted. It is an optimization problem in mathematics that arises from applications in industry. In terms of computational complexity, the problem is an NP-hard problem reducible to the knapsack problem. The problem can be formulated as an integer linear programming problem.

In this particular case, the algorithm was implemented for *'1 dimensional materials'*, such as Planks and Rods.

### Input
1. A list of the desired Plank or Rod lengths to be cut.
2. A list of the available material length from the Suppier.
3. A list of labels for fabrication.

### Output
1. A List of text strings describing the necessary cuts per supplied rod and their corresponding label.

### Pending
Next version will bring full GH compatibility such as:
* Polyline/curve input, automatic labeling if no labels are supplied
* Output DataTree with ordered polylines by cut and another for ordered labels
* ...
