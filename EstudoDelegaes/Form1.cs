using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudoDelegaes
{
    public partial class frmCalculadora : Form
    {
        //ponteiro de metodos.
        private delegate int ExecutarOperacao(int num1, int num2);
        //objeto do delegate
        private ExecutarOperacao minhaOperacao;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {

        }

        private int Calcular()
        {
            int num1 = Convert.ToInt32(txbNumero1.Text);
            int num2 = Convert.ToInt32(txbNumero2.Text);
            return minhaOperacao(num1, num2);
        }

        private int Somar(int a, int b)
        {
            return a + b;
        }

        private int Subtrair(int a, int b)
        {
            return a - b;
        }

        private int Multiplicar(int a, int b)
        {
            return a * b;
        }

        private int Dividir(int a, int b)
        {
            return a / b;
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Somar);
            txbResultado.Text = Calcular().ToString();
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Subtrair);
            txbResultado.Text = Calcular().ToString();
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Multiplicar);
            txbResultado.Text = Calcular().ToString();
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            //é interessante porque se for necessário trocar o metodo que será executado,
            //só alterar o delegate no final
            minhaOperacao = new ExecutarOperacao(Dividir);
            txbResultado.Text = Calcular().ToString();
        }
    }
}
