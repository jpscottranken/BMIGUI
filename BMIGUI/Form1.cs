using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMIGUI
{
    public partial class FormBMI : Form
    {
        public FormBMI()
        {
            InitializeComponent();
        }

        //  Declare and initialize global HEIGHT constants
        const int MINHEIGHT = 12;   //  Minimum allowed height
        const int MAXHEIGHT = 96;   //  Maximum allowed height
        const int DEFHEIGHT = 72;   //  Default height

        //  Declare and initialize global WEIGHT constants
        const int MINWEIGHT = 1;    //  Minimum allowed weight
        const int MAXWEIGHT = 777;  //  Maximum allowed wheight
        const int DEFWEIGHT = 175;  //  Default weight

        //  Declare and initialize global BMI constants
        const double MINOPT = 18.5; //  Minimum optimal weight BMI
        const double MINOVR = 30.0; //  Minimum overweight BMI
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            //  Declare and initialize global variables
            int height = InputHeight();                 //  Set the height
            int weight = InputWeight();                 //  Set the weight
            double bmi = CalculateBMI(height, weight);  //   Calculate BMI
            string bmiStatus = CalculateBMIStatus(bmi); //   Calculate BMI status
            DisplayAll(height, weight,
                       bmi, bmiStatus);                 //  Display all I/O values
        }

        private int InputHeight()
        {
            //  IsNumeric test variable
            bool test = IsNumeric(textBoxHeight.Text);

            //  Numeric test returned false, set to default height
            if (!test)
            {
                return DEFHEIGHT;
            }

            //  Number entered for height.  Validate number
            int h = Convert.ToInt32(textBoxHeight.Text);

            //  Valid range check
            if ((h < MINHEIGHT) || (h > MAXHEIGHT))
            {
                h = DEFHEIGHT;
            }

            return h;
        }

        private int InputWeight()
        {
            //  IsNumeric test variable
            bool test = IsNumeric(textBoxWeight.Text);

            //  Numeric test returned false, set to default weight
            if (!test)
            {
                return DEFWEIGHT;
            }

            //  Number entered for height.  Validate number
            int w = Convert.ToInt32(textBoxWeight.Text);

            //  Valid range check
            if ((w < MINWEIGHT) || (w > MAXWEIGHT))
            {
                w = DEFWEIGHT;
            }

            return w;
        }

        private bool IsNumeric(string input)
        {
            int test = 0;

            return int.TryParse(input, out test);
        }

        private double CalculateBMI(int height, int weight)
        {
            return ((weight / (Math.Pow(height, 2))) * 703.0);
        }

        private string CalculateBMIStatus(double bmi)
        {
            string weightStr = "";

            if ((bmi >= 0 ) && (bmi < MINOPT))
            {
                weightStr = "Underweight";
            }
            else if ((bmi >= MINOPT) && (bmi < MINOVR))
            {
                weightStr = "Optimal weight";
            }
            else if (bmi >= MINOVR)
            {
                weightStr = "Overweight";
            }
            else
            {
                weightStr = "Error Occurred During Processing";
            }

            return weightStr;
        }

        private void DisplayAll(int height, int weight, 
                                double bmi,
                                string bmiStatus)
        {
            textBoxHeight.Text      = height.ToString("n2");
            textBoxWeight.Text      = weight.ToString("n2");
            textBoxBMI.Text         = bmi.ToString("n2");
            textBoxBMIStatus.Text   = bmiStatus;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxHeight.Text      = "";
            textBoxWeight.Text      = "";
            textBoxBMI.Text         = "";
            textBoxBMIStatus.Text   = "";
            textBoxHeight.Focus();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Program Now?!?!?",
                "EXIT PROGRAM???",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
