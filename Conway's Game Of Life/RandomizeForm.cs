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
    public partial class RandomizeForm : Form
    {

        public RandomizeForm()
        {
            InitializeComponent();
        }

        private void RandomizeButton_Click(object sender, EventArgs e)
        {
            Random randy = new Random((int)DateTime.Now.Ticks);

            numericUpDown1.Value = randy.Next(0, 1073741824);

            panel1.Invalidate();
            
        }

        public void SetSeed(int seed)
        {
            numericUpDown1.Value = seed;
        }

        public int GetSeed()
        {
            return (int)numericUpDown1.Value;
        }

        public void SetDensity(int density)
        {
            DensitySlider.Value = density;
        }

        public int GetDensity()
        {
            return (int)DensitySlider.Value;
        }

    }
}
