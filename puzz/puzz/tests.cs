using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace puzz
{
    class tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestHfunct()
        {
            int[,] testpuzz = {{1, 0, 2},
                               {8, 6, 3},
                               {7, 5, 4}};
            int outtest = 0;
            int arr = program.Hfunct(testpuzz);
            Assert.AreEqual(outtest, arr);
        }

        [Test]
        public void Testpuzzle()
        {
            int[,] initpuzz = {{1, 2, 3},
                               {7, 8, 4},
                               {6, 5, 0}};
            int[,] goalpuzz = {{1, 2, 3},
                               {8, 0, 4},
                               {7, 6, 5}};
            int[,] test = program.Puzzle(initpuzz);
            Assert.AreEqual(goalpuzz, test);

        }

        [Test]
        public void Testswap()
        {
            int[,] initpuzz = {{1, 2, 3},
                               {0, 8, 4},
                               {7, 6, 5}};
            int[,] goalpuzz = {{1, 2, 3},
                               {8, 0, 4},
                               {7, 6, 5}};
            int[,] test = program.swap(initpuzz, 1, 1);
            Assert.AreEqual(goalpuzz, test);
        }

        [Test]
        public void Testswap2()
        {
            int zi = -1;
            int zj = -1;
            int[,] initpuzz = {{1, 2, 3},
                               {0, 8, 4},
                               {7, 6, 5}};
            int[,] goalpuzz = {{1, 2, 3},
                               {8, 0, 4},
                               {7, 6, 5}};
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
            int[,] test = program.swap(initpuzz, zi, zj + 1);
            Assert.AreEqual(goalpuzz, test);
        }

        [Test]
        public void otherTest()
        {
            int gcounter = 0;
            int fup = 100;
            int fdown = 100;
            int fleft = 100;
            int fright = 100;
            int min = 100;
            int[,] initpuzz = {{1, 2, 3},
                               {0, 8, 4},
                               {7, 6, 5}};
            int[,] initpuzz2 = initpuzz;
            int[,] goalpuzz = {{1, 2, 3},
                               {8, 0, 4},
                               {7, 6, 5}};
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
                up = program.swap(initpuzz, zi - 1, zj);
                fup = gcounter + program.Hfunct(up);
            }
            else
            {
                fup = 100;
            }
            initpuzz = initpuzz2;
            //move 0 down
            if (zi + 1 < 3)
            {
                down = program.swap(initpuzz, zi + 1, zj);
                fdown = gcounter + program.Hfunct(down);
            }
            else
            {
                fdown = 100;
            }
            initpuzz = initpuzz2;
            //move 0 left
            if (zj - 1 >= 0)
            {
                left = program.swap(initpuzz, zi, zj - 1);
                fleft = gcounter + program.Hfunct(left);
            }
            else
            {
                fleft = 100;
            }
            initpuzz = initpuzz2;
            //move 0 right
            if (zj + 1 < 3)
            {
                right = program.swap(initpuzz, zi, zj + 1);
                fright = gcounter + program.Hfunct(right);
            }
            else
            {
                fright = 100;
            }
            initpuzz = initpuzz2;

            min = program.fmin(fup, fdown, fleft, fright);

            //replacing the puzzle with the lowest f value move
            /*
            if (min == fup)
            {
                initpuzz = up;
            }
            else if (min == fdown)
            {
                initpuzz = down;
            }
            else if (min == fleft)
            {
                initpuzz = left;
            }
            else if (min == fright)
            {
                initpuzz = right;
            }
            Assert.AreEqual(goalpuzz, up);
            */
            Assert.AreEqual(min, fright);
        }
        [Test]
        public void Testarray()
        {
            int[,] initpuzz = {{1, 2, 3},
                               {0, 8, 4},
                               {7, 6, 5}};
            int[,] goalpuzz = {{1, 2, 3},
                               {8, 0, 4},
                               {7, 6, 5}};
            Array.Copy(initpuzz, goalpuzz, 9);
            int[,] test = {{0, 0, 0},
                            {0, 0, 0},
                            {0, 0, 0}};
            Array.Copy(program.swap(initpuzz, 1, 1), test, 9);

            Assert.AreEqual(initpuzz, goalpuzz);
        }
    }
}
