using System;
using System.Diagnostics;

namespace _8puzzle
{
    public class program
    {

        //the puzzles are stored as 2D arrays 3x3
        //0 denotes the empty space 
        int[,] initpuzz = {{1, 2, 3},
                           {0, 8, 4},
                           {7, 6, 5}};

      
        int[,] goalpuzz = {{1, 2, 3},
                           {8, 0, 4},
                           {7, 6, 5}};

        //f(n) = g(n) + h(n)
        //g(n) distance from current node to root node
        //h(n) number of misplaced tiles by comparing the current state and goal state

        //when a tile is moved 0 swaps places with the tile moved
        //in code this means that 0 can swap with tiles above, under, left and right of it
        //this means that physically, the number it was swapped with is moved in the opposite direction
        //ex 0 swaps with the 1 to the right = 1 is moved to the empty tile left of it

        public static void Main(string[] args)
        {
            
        }
        public static int[,] Hfunct(int[,] arr)
        {
            int sum = 0;
            int[,] goalpuzz = {{1, 2, 3},
                               {8, 0, 4},
                               {7, 6, 5}};
            int[,] test = new int[3, 3];
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    test[i, j] = arr[i, j];
                }
            }

            return test;
        }

    }
}
