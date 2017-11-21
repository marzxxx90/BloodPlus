using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BloodPlus
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
        }

        private void Sample_Load(object sender, EventArgs e)
        {

        }

        private static double[] Get_N_DaysMovingAverage(int frameSize, int[] data)
        {
            double sum = 0;
            double[] avgPoints = new double[data.Length - frameSize + 1];
            for (int counter = 0; counter <= data.Length - frameSize; counter++)
            {
                int innerLoopCounter = 0;
                int index = counter;
                while (innerLoopCounter < frameSize)
                {
                    sum = sum + data[index];

                    innerLoopCounter += 1;

                    index += 1;

                }

                avgPoints[counter] = sum / frameSize;

                sum = 0;

            }
            return avgPoints;

        }
    }
}
