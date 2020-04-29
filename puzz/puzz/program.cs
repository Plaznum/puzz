using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace puzz
{
    public class program
    {

        //f(n) = g(n) + h(n)
        //g(n) distance from current node to root node AKA number of moves from initial
        //h(n) number of misplaced tiles by comparing the current state and goal state

        //when a tile is moved 0 swaps places with the tile moved
        //in code this means that 0 can swap with tiles above, under, left and right of it
        //this means that physically, the number it was swapped with is moved in the opposite direction
        //ex 0 swaps with the 1 to the right = 1 is moved to the empty tile left of it

        public static int[,] Puzzle(int[,] initpuzz)
        {
            //the puzzles are stored as 2D arrays 3x3
            //0 denotes the empty space 

            int[,] initpuzz2 = {{0, 0, 0},
                                {0, 0, 0},
                                {0, 0, 0}};
            Array.Copy(initpuzz, initpuzz2, 9);
            int[,] goalpuzz = {{1, 2, 3},
                               {8, 0, 4},
                               {7, 6, 5}};

            //swap with up, example 0 is at [1,1] swaps with [0,1] meaning swapping up is [i,j] swapping with [i-1,j]
            //swap with down, example 0 is at [1,1] swaps with [2,1] meaning swapping up is [i,j] swapping with [i+1,j]
            //swap with left, example 0 is at [1,1] swaps with [1,0] meaning swapping up is [i,j] swapping with [i,j-1]
            //swap with right, example 0 is at [1,1] swaps with [1,2] meaning swapping up is [i,j] swapping with [i,j+1]
            //IF i OR j END UP BEING LESS THAN ZERO, THE SWAP/MOVE CANNOT BE MADE

            int gcounter = 0;
            //f funtion values for each move 
            int fup = 100;
            int fdown = 100;
            int fleft = 100;
            int fright = 100;
            int min = 100;
            int[,] up = {{0, 0, 0},
                         {0, 0, 0},
                         {0, 0, 0}};
            int[,] down = {{0, 0, 0},
                           {0, 0, 0},
                           {0, 0, 0}};
            int[,] left = {{0, 0, 0},
                           {0, 0, 0},
                           {0, 0, 0}};
            int[,] right = {{0, 0, 0},
                            {0, 0, 0},
                            {0, 0, 0}};
            //coords for 0 block
            int zi = -1; 
            int zj = -1;
            
            //loop completes when the goal puzzle is met
            while (!program.arrcompare(initpuzz, goalpuzz))
            {
                Array.Copy(initpuzz, initpuzz2, 9);
                //find 0
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (initpuzz[i, j] == 0)
                        {
                            zi = i;
                            zj = j;
                        }
                    }
                }
                //moves are done and the board state is compared and the board with the lowest f becomes the new initpuzz
                //move 0 up
                if (zi - 1 >= 0)
                {
                    Array.Copy(program.swap(initpuzz, zi - 1, zj), up, 9);
                    Array.Copy(initpuzz2, initpuzz, 9);
                    //up = program.swap(initpuzz, zi - 1, zj);
                    fup = gcounter + program.Hfunct(up);
                } 
                else
                {
                    fup = 100;
                }
                
                //initpuzz = initpuzz2;
                //move 0 down
                if (zi + 1 < 3)
                {
                    Array.Copy(program.swap(initpuzz, zi + 1, zj), down, 9);
                    Array.Copy(initpuzz2, initpuzz, 9);
                    //down = program.swap(initpuzz, zi + 1, zj);
                    fdown = gcounter + program.Hfunct(down);
                }
                else
                {
                    fdown = 100;
                }
                //initpuzz = initpuzz2;
                //move 0 left
                if (zj - 1 >= 0)
                {
                    Array.Copy(program.swap(initpuzz, zi, zj - 1), left, 9);
                    Array.Copy(initpuzz2, initpuzz, 9);
                    //left = program.swap(initpuzz, zi, zj - 1);
                    fleft = gcounter + program.Hfunct(left);
                }
                else
                {
                    fleft = 100;
                }
                //initpuzz = initpuzz2;
                //move 0 right
                if (zj + 1 < 3)
                {
                    Array.Copy(program.swap(initpuzz, zi, zj + 1), right, 9);
                    Array.Copy(initpuzz2, initpuzz, 9);
                    //right = program.swap(initpuzz, zi, zj + 1);
                    fright = gcounter + program.Hfunct(right);
                }
                else
                {
                    fright = 100;
                }
                //initpuzz = initpuzz2;

                min = program.fmin(fup, fdown, fleft, fright);

                //replacing the puzzle with the lowest f value move
                if (min == fup)
                {
                    Console.WriteLine("Moved " + initpuzz2[zi - 1, zj] +" down");
                    Array.Copy(up, initpuzz, 9);
                    //initpuzz = up;
                } 
                if (min == fdown)
                {
                    Console.WriteLine("Moved " + initpuzz2[zi + 1, zj] + " up");
                    Array.Copy(down, initpuzz, 9);
                    //initpuzz = down;
                }
                if (min == fleft)
                {
                    Console.WriteLine("Moved " + initpuzz2[zi, zj - 1] + " left");
                    Array.Copy(left, initpuzz, 9);
                    //initpuzz = left;
                }
                if (min == fright)
                {
                    Console.WriteLine("Moved " + initpuzz2[zi, zj + 1] + " right");
                    Array.Copy(right, initpuzz, 9);
                    //initpuzz = right;
                }

                
                //g(n) increases each itteration/move from start
                gcounter++;
            }
            return initpuzz;
        }

        //method to calculated the h(n) of an array
        public static int Hfunct(int[,] arr)
        {
            int sum = 0;
            int[,] goalpuzz = {{1, 2, 3},
                               {8, 0, 4},
                               {7, 6, 5}};
            for(int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] == goalpuzz[i, j])
                        sum++;
                }
            }
            //loops add up the number of correct tiles
            //subtracting 9 results in the number of missplaced tiles
            sum = 9 - sum;
            return sum;
        }

        //method to handle tile movement. i2 and j2 are the coords for the intended swap tile
        public static int[,] swap(int[,] arr,int i2, int j2)
        {
            //coords for 0 block
            int zi = -1;
            int zj = -1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        zi = i;
                        zj = j;
                    }
                }
            }
            arr[zi, zj] = arr[i2, j2];
            arr[i2, j2] = 0;

            return arr;
        }

        //returns the smallest f function value
        public static int fmin(int fup, int fdown, int fleft, int fright)
        {
            int min = 100;
            min = Math.Min(Math.Min(fup, fdown), Math.Min(fleft, fright));
            return min;
        }

        //compare 2d arrays and return corresponding bool
        public static Boolean arrcompare(int[,] initpuzz, int[,] goalpuzz)
        {
            var equal = initpuzz.Rank == goalpuzz.Rank && 
                Enumerable.Range(0, initpuzz.Rank).All(dimension => initpuzz.GetLength(dimension)
                == goalpuzz.GetLength(dimension)) &&
                initpuzz.Cast<int>().SequenceEqual(goalpuzz.Cast<int>());
            return equal; 
        }

    }
}
