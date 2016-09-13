using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabajoPracticoCalculadora
{
    public partial class Form1 : Form
    {
        public numero num1;
        public numero num2;
        public string operarando;
        public double resultado;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            this.num1 = new numero(txtNumero1.Text);
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            this.num2 = new numero(txtNumero2.Text);
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.operarando = cmbOperacion.Text;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            operar();
            lblResultado.Text = resultado.ToString();
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void limpiar()
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            cmbOperacion.Text = "0";
        }

        private void operar()
        {
            calculadora calcu;
            calcu = new calculadora();
            resultado = calcu.operar(this.num1, this.num2, this.operarando);
        }
    }
}
