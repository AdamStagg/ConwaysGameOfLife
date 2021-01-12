﻿using System;
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
            for (int i = -1; i <= 1; i++) // iterates x offset
            {
                for (int j = -1; j <= 1; j++) // iterates y offset
                {
                    if (x + i >= 0 && x + i < universe.GetLength(0) && y + j >= 0 && y + j < universe.GetLength(1)) //makes sure its within the grid
                    {
                        if (universe[x + i, y + j]) 
                        {
                            if (!(i == 0 && j == 0))
                            {
                                count++;
                            }
                        }
                    }
                }
            }


            return count;
        }

        public static int CountNeighborsToroidol(ref bool[,] universe, int x, int y)
        {
            int count = 0;

            for (int i = -1; i <= 1; i++) // iterates x offset
            {
                for (int j = -1; j <= 1; j++) // iterates y offset
                {
                    int xPos = (x + i) % universe.GetLength(0);
                    int yPos = (y + j) % universe.GetLength(1);
                    if (universe[xPos, yPos])
                    {
                        if (!(i == 0 && j == 0))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }




        public static void CalculateRules(ref bool[,] universe,  List<CellPoint> cellsToToggle)
        {
            int temp = 0;
            cellsToToggle.Clear();

            for (int i = 0; i < universe.GetLength(0); i++) //iterates x cells
            {
                for (int j = 0; j < universe.GetLength(1); j++) //iterates y cells
                {
                    #region //checks to see if the toroidol mode is on
                    if (isToroidol)
                    {
                        temp = CountNeighborsToroidol(ref universe, i, j);
                    }
                    else
                    {
                        temp = CountNeighbors(ref universe, i, j);
                    }
                    #endregion

                    if (universe[i, j])//cell is alive
                    {
                        if (temp == 2 || temp == 3)
                        {
                            //keeps the cell on
                            cellsToToggle.Add(new CellPoint(i, j, true));
                        }
                        else
                        {
                            //turns the cell off
                            cellsToToggle.Add(new CellPoint(i, j, false));
                        }
                    }
                    else//cell is dead
                    {
                        if (temp == 3)
                        {
                            //turns the cell on
                            cellsToToggle.Add(new CellPoint(i, j, true));
                        }
                    }

                }
            }



        }
    }

    public class CellPoint
    {
        public int cellX = 0;
        //{
        //    get => cellX;
        //    private set => cellX = value;
        //}
        public int cellY = 0;
        //{
        //    get => cellY;
        //    private set => cellY = value;
        //}
        public bool cellState = false;
        //{
        //    get => cellState;
        //    private set => cellState = value;
        //}
        public CellPoint(int x, int y, bool value)
        {
            cellX = x;
            cellY = y;
            cellState = value;
        }
    }
}
