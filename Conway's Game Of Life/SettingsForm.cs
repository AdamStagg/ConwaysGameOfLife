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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }


        public void SetInterval(int interval)
        {
            intervalSlider.Value = interval;
        }

        public int GetInterval()
        {
            return (int)intervalSlider.Value;
        }

        public void SetXCells(int cells)
        {
            xCellSlider.Value = cells;
        }

        public int GetXCells()
        {
            return (int)xCellSlider.Value;
        }

        public void SetYCells(int cells)
        {
            yCellsSlider.Value = cells;
        }

        public int GetYCells()
        {
            return (int)yCellsSlider.Value;
        }

    }
}
