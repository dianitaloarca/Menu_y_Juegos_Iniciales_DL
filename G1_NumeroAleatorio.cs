using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumeroAleatorio_DL_5toB
{

    public partial class G1_NumeroAleatorio : Form
    {
        int intentos = 0; //Inicializar la variable
        Random rand = new Random(); //Crea objeto que genere el número aleatorio 
        int aleatorio = 0;

        public G1_NumeroAleatorio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            intentos = 5;
            txtIntentos.Text = intentos.ToString();
            aleatorio = rand.Next(1, 100); //Aleatorio =número entre 1 y 100
            MessageBox.Show($"{aleatorio}");
        }

        private void txtIntentos_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumero.Text, out int num))
            {
                if (num == aleatorio)
                {
                    MessageBox.Show($"Ganó el juego. El número es {aleatorio}");
                    DialogResult resultado = MessageBox.Show("¿Quiere volver a jugar?", "Resultado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.No)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        intentos = 5;
                        txtIntentos.Text = intentos.ToString();
                        aleatorio = rand.Next(1, 100);
                    }
                }
                if (num > aleatorio)
                {
                    MessageBox.Show($"{num} es mayor al número aleatorio");
                    intentos = intentos - 1;
                    txtIntentos.Text = intentos.ToString();
                }
                if (num < aleatorio)
                {
                    MessageBox.Show($"{num} es menor al número aleatorio");
                    intentos--; //Es lo mismo que poner "intentos = intentos - 1;"
                    txtIntentos.Text = intentos.ToString();
                }
                if (intentos == 0)
                {
                    DialogResult resultado = MessageBox.Show("Se acabaron los intentos :( ¿Quiere volver a intentarlo?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (resultado == DialogResult.No)
                    {
                        MessageBox.Show("¡Suerte para la próxima!");
                        Application.Exit();
                    }
                    else
                    {
                        intentos = 5;
                        txtIntentos.Text = intentos.ToString();
                        aleatorio = rand.Next(1, 100);
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Ingrese un número válido");
            }
        }
    }
}
