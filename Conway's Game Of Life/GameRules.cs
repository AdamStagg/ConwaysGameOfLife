using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_Of_Life
{
    public static class GameRules
    {

        public static bool isToroidol = false;

        public static int CountNeighbors(ref bool[,] universe, int x, int y)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try // TODO look at this later
                    {
                        
                        if (universe[x + i, y + j])
                        {
                            if (i == 0 && j == 0)
                            {
                            }
                            else
                            {
                                count++;
                            }
                        }
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }   

            return count;
        }

        public static int CountNeighborsToroidol(ref bool[,] universe, int x, int y)
        {
            int count = 0;
            
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int xPos = (x + i) % universe.GetLength(0);
                    int yPos = (y + j) % universe.GetLength(1);
                    if (universe[xPos, yPos])
                    {
                        if (i == 0 && j == 0)
                        {

                        }
                        else
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public static bool CalculateRules(ref bool[,] universe, int x, int y)
        {
            int temp = 0;
            if (isToroidol)
            {
                temp = CountNeighborsToroidol(ref universe, x, y);
            } else
            {
                temp = CountNeighbors(ref universe, x, y);
            }

            if (universe[x, y])
            {
                if (temp < 2 || temp > 3)
                {
                    return false;
                } else
                {
                    return true;
                }
            } else
            {
                if (temp == 3)
                {
                    return true;
                }
            }
            throw new ArgumentException();
            return false;
        }
    }
}
