using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZbiorPotegowy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            string inputString = textBoxInput.Text;
            string [] splittedInput = inputString.Split(',');
            int[] input = Array.ConvertAll(splittedInput, s => int.Parse(s));

            string[] output = new string[(int)Math.Pow(2, Convert.ToDouble(input.Count()))];

            output[0] = input[0].ToString();
            output[1] = input[1].ToString();
            output[2] = input[0].ToString()+","+ input[1].ToString();

            int temp = 0;
            int notEmpty;
            int i=0;
 
            for(int x = 2; x < input.Count(); x++)
            {
                notEmpty = output.Count(s => s != null);
                for (i = notEmpty; i < notEmpty * 2; i++)
                {
                    output[i] = input[x].ToString() + "," + output[temp++];
                }
                output[i] = input[x].ToString();
                temp = 0;
            }
            output[++i] = "∅";

            string toDisplay = string.Join(Environment.NewLine, output);
            MessageBox.Show(toDisplay);
        }
    }
}
