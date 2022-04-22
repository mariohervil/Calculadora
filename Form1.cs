using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



/*
 raiz de -1
log de numeros negativos
divisiones por 0
 
 
 */
namespace PCalculadora
{
    public partial class Form1 : Form
    {   
        int widthForm, widthTextBoxResult;
        double operador1, operador2;
        bool suma = false, resta = false, mult = false, div = false, ex = false, per = false;
        double result;
        
        public Form1()
        {
            InitializeComponent();
            InitConfig();
            
        }
        private void sound(string s)
        {
            try
            {

                string CurrentDirectory = Directory.GetCurrentDirectory();
                string path = CurrentDirectory + "\\sounds\\" + s + ".m4a";
                SoundPlayer soundPlayer = new SoundPlayer();
                soundPlayer.SoundLocation = path;
                soundPlayer.Play();
            }
            
            catch(FileNotFoundException e)
            {
                
            }

        }

        private void InitConfig()
        {
            widthForm = this.panel1.Width;
            widthTextBoxResult = this.textBoxResult.Width;
        }
         private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ClearScreen()
        {

            textBoxResult.Text = "0";

        }
       



        private void ClickNumber(object sender, EventArgs e)
        {
            
            Button bt = (Button)sender;
            if(textBoxResult.Text == "0")
            {
                textBoxResult.Clear();
            }

            textBoxResult.Text += bt.Text;

            sound(bt.Text);
            
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            try
            {
                operador1 = Convert.ToDouble(textBoxResult.Text);
                resta = true;
                textBoxResult.Clear();
                sound(bt.Text);
            }
            catch (FormatException a)
            {
            }
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            try
            {
                operador1 = Convert.ToDouble(textBoxResult.Text);
                mult = true;
                textBoxResult.Clear();
                sound(bt.Text);
            }
            catch (FormatException a) { 
            }
        }

        private void buttonTan_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            
            operador1 = Convert.ToDouble(textBoxResult.Text);
            result = Math.Tan(operador1 / 360 * 2 * Math.PI);
            textBoxResult.Text = Convert.ToString(result);
            operador1 = 0;
            sound(bt.Text);
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            operador1 = Convert.ToDouble(textBoxResult.Text);
            result = Math.Sqrt(operador1);
            textBoxResult.Text = Convert.ToString(result);
            operador1 = 0;
            sound(bt.Text);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            ClearScreen();
            operador1 = 0;
            operador2 = 0;
            Button bt = (Button)sender;
            sound(bt.Text);
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            operador1 = Convert.ToDouble(textBoxResult.Text);
            per = true;
            textBoxResult.Clear();
            Button bt = (Button)sender;
            sound(bt.Text);
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {
            operador1 = Convert.ToDouble(textBoxResult.Text);
            result = Math.Cos(operador1 / 360 * 2 * Math.PI);
            textBoxResult.Text = Convert.ToString(result);
            operador1 = 0;
            Button bt = (Button)sender;
            sound(bt.Text);
        }

        private void buttonSin_Click(object sender, EventArgs e)
        {
            operador1 = Convert.ToDouble(textBoxResult.Text);
            result = Math.Sin(operador1 * 360 * 2 * Math.PI);
            textBoxResult.Text = Convert.ToString(result);
            operador1 = 0;
            Button bt = (Button)sender;
            sound(bt.Text);
        }

        private void buttonLn_Click(object sender, EventArgs e)
        {
            operador1 = Convert.ToDouble(textBoxResult.Text);
            result = Math.Log(operador1);
            textBoxResult.Text = Convert.ToString(result);
            Button bt = (Button)sender;
            sound(bt.Text);
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            try { 
            operador1 = Convert.ToDouble(textBoxResult.Text);
            div = true;
            textBoxResult.Clear();
                Button bt = (Button)sender;
                sound(bt.Text);
            }
            catch(FormatException a)
            {

            }
        }

        private void buttonInversa_Click(object sender, EventArgs e)
        {
            try
            {
                operador1 = Convert.ToDouble(textBoxResult.Text);
                result = 1 / operador1;
                textBoxResult.Text = Convert.ToString(result);
                Button bt = (Button)sender;
                sound("inversa");
            }
            catch (FormatException a)
            {

            }
        }


        private void checkBoxScientific_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxScientific.Checked)
            {
                this.panel1.Width = widthForm * 180/100;
                textBoxResult.Width = widthTextBoxResult * 180 / 100;
            }
            else
            {
                this.panel1.Width = widthForm;
                textBoxResult.Width = widthTextBoxResult;
            }
        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            try { 
            operador1 = Convert.ToDouble(textBoxResult.Text);
            result = Math.Log10(operador1);
            ClearScreen();
            Button bt = (Button)sender;
            sound(bt.Text);
            }
            catch (ArithmeticException a)
            {
                textBoxResult.Text = "Error";
            }
        }

        private void buttonExp_Click(object sender, EventArgs e)
        {
            operador1 = Convert.ToDouble(textBoxResult.Text);
            ex = true;
            textBoxResult.Clear();
            Button bt = (Button)sender;
            sound(bt.Text);
        }

        private void buttonComa_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            sound(bt.Text);

            if (!textBoxResult.Text.Contains(',') && (!string.IsNullOrWhiteSpace(textBoxResult.Text)))
            {
                textBoxResult.Text += ",";
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            ClearScreen();
            
            sound(bt.Text);
        }

        private void buttonEqual_Click(object sender, EventArgs e) {
            Button bt = (Button)sender;
            sound(bt.Text);
            if (suma == true)
            {
                operador2  = Convert.ToDouble(textBoxResult.Text);
                result = operador1 + operador2;
                textBoxResult.Text = Convert.ToString(result);
                suma = false;
                
            }
            if (resta == true)
            {
                operador2 = Convert.ToDouble(textBoxResult.Text);
                result = operador1 - operador2;
                textBoxResult.Text = Convert.ToString(result);
                resta = false;
                
            }
            if (mult == true)
            {
                operador2 = Convert.ToDouble(textBoxResult.Text);
                result = operador1 * operador2;
                textBoxResult.Text = Convert.ToString(result);
                mult = false;
                
            }
            if (div == true)
            {
                try { 
                operador2 = Convert.ToDouble(textBoxResult.Text);
                result = operador1 / operador2;
                textBoxResult.Text = Convert.ToString(result);
                div = false;}
                catch (ArithmeticException a)
                {
                    textBoxResult.Text = "Error";
                }
            }
            if (ex == true)
            {
                operador2 = Convert.ToDouble(textBoxResult.Text);
                result = Math.Pow(operador1, operador2);
                textBoxResult.Text = Convert.ToString(result);
                ex = false;
            }
            
            if (per == true)
            {
                operador2 = Convert.ToDouble(textBoxResult.Text);
                result = (operador1 / operador2) * 100;
                textBoxResult.Text = Convert.ToString(result);
                per = false;

            }

            operador1 = 0;
            operador2 = 0;

        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            try
            {
                Button bt = (Button)sender;
                sound(bt.Text);
                operador1 = Convert.ToDouble(textBoxResult.Text);
                suma = true;
                textBoxResult.Clear();
            }
            catch (FormatException a)
            {
            }

        }





    }

} 



