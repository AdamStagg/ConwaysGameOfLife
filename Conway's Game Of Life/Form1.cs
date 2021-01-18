using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conway_s_Game_Of_Life
{
    public partial class Form1 : Form
    {
        static int xCellCount = 50;
        static int yCellCount = 50;

        // The universe array
        bool[,] universe = new bool[xCellCount, yCellCount];

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;


        int seed = 0;
        private int randomizeMaxValue = 50;

        public Form1()
        {
            InitializeComponent();
            UpdateBottomText();

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {

            //creates a list to hold the cells that need to be toggled
            List<CellPoint> cellsToToggle = new List<CellPoint>();
            //clears the lsit, then adds to it
            GameRules.CalculateRules(ref universe, cellsToToggle);

            //iterates through all cells to be toggled
            for (int i = 0; i < cellsToToggle.Count; i++)
            {
                universe[cellsToToggle[i].cellX, cellsToToggle[i].cellY] = cellsToToggle[i].cellState;
            }



            // Increment generation count
            generations++;

            // Update status strip generations
            UpdateBottomText();

            graphicsPanel1.Invalidate();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();

           
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
                UpdateBottomText();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            //turns every cell off
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    universe[i, j] = false;
                }
            }

            //resets the settings
            generations = 0;

            GameRules.isToroidal = false;

            timer.Interval = 100;


            UpdateBottomText();

            //turns off the timer if its on
            timer.Enabled = false;

            //resets the screen
            graphicsPanel1.Invalidate();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void NextGenerationButton_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }


        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e) //Displays the randomize menu
        {
            RandomizeForm dlg = new RandomizeForm();

            dlg.SetSeed(seed);
            dlg.SetDensity(randomizeMaxValue);

            if (DialogResult.OK == dlg.ShowDialog())
            {
                seed = dlg.GetSeed();
                randomizeMaxValue = dlg.GetDensity();
            }
        }

        private void randomizeCellsToolStripMenuItem_Click(object sender, EventArgs e) //randomizes all cells
        {
            Random randy = new Random(seed);

            for (int i = 0; i < universe.GetLength(0); i++) //loops through all x
            {
                for (int j = 0; j < universe.GetLength(1); j++) //loops through all y
                {
                    if (randy.Next(0, 100) <= randomizeMaxValue)
                    {
                        universe[i, j] = true;
                    }
                    else
                    {
                        universe[i, j] = false;
                    }

                    
                }
            }
            graphicsPanel1.Invalidate();
            UpdateBottomText();
            
        }

        private void randomizeSeedCellsToolStripMenuItem_Click(object sender, EventArgs e) //randomizes the settings
        {
            Random randy = new Random((int)DateTime.Now.Ticks);

            seed = randy.Next(0, 1073741824);
            randomizeMaxValue = randy.Next(0, 101);
        }

        private void UpdateBottomText()
        {
            string generationText = "";
            generationText = "Generations = " + generations.ToString() + "     ";


            string modeText = "";
            if (GameRules.isToroidal)
            {
                modeText = "Mode: Toroidal     ";
            } else
            {
                modeText = "Mode: Finite     ";
            }

            string cellsText = "";
            int aliveCells = 0;
            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    if (universe[x,y])
                    {
                        aliveCells++;
                    }
                }
            }
            cellsText = "Cells Alive: " + aliveCells + "     ";

            string timerText = "";
            timerText = "Interval: " + timer.Interval.ToString();


            toolStripStatusLabelGenerations.Text = generationText + modeText + cellsText + timerText;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm dlg = new SettingsForm();

            dlg.SetInterval(timer.Interval);
            dlg.SetXCells(xCellCount);
            dlg.SetYCells(yCellCount);

            if (DialogResult.OK == dlg.ShowDialog())
            {
                timer.Interval = dlg.GetInterval();
                xCellCount = dlg.GetXCells();
                yCellCount = dlg.GetYCells();
                universe = new bool[xCellCount, yCellCount];

                graphicsPanel1.Invalidate();
                UpdateBottomText();
            }

        }
    }
}
