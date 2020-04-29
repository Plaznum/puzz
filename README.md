# puzz
8 Puzzle A* A.I algorithm

Built with C# in Visual Studio 2019, Tested with NUnit  
This program was made to be an Artificial Intelegence program that utilized A* search to find and return a solution to a sliding 8 tile puzzle.  
![alt text](https://puu.sh/FE4Ff/d3aab2a8ca.png)

Algorithm is based on the f(n) = g(n) + h(n) function where  
g(n) is the distance from current node to root node AKA number of moves from initial  
h(n) is the number of misplaced tiles by comparing the current state and goal state  
The puzzle is handled by a 2D array and contains values 0-9  
Tile movement is handled by 'swap' method that swaps the coords of a number with 0's coordinates  
Movement is looped until the inital puzzle matches the goal puzzle.  
