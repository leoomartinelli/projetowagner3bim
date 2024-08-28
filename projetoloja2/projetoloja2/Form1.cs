using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoloja2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
        
        float valorTotal;
        float valorParcela;
        int numeroParcelas;
        DateTime dataCompra;
        float juros = 0.03f;

        
        // textBox1 - inserir o valor da compra
        // textBox2 - inserir o número de parcelas
        // textBox3 - inserir a data da compra
        // textBox4 - multilines para exibir as parcelas e datas de vencimento
        // textBox5 - simular a data de pagamento.
        // label1 - exibir o valor total a pagar
        // Button1 - calcular as parcelas e exibir as datas de vencimento
        // Button2 - simular o pagamento de uma parcela.
        private void button1_Click(object sender, EventArgs e)
        {
            // Coleta e trasforma pro tipo
            float.TryParse(textBox1.Text, out valorTotal);
            int.TryParse(textBox2.Text, out numeroParcelas);          
            DateTime.TryParse(textBox3.Text, out dataCompra);

            valorParcela = valorTotal / numeroParcelas;
            textBox4.Text = "";

            for (int i = 1; i <= numeroParcelas; i++)
            {
                DateTime dataVencimento = dataCompra.AddMonths(i - 1);

                while (dataVencimento.DayOfWeek == DayOfWeek.Saturday || dataVencimento.DayOfWeek == DayOfWeek.Sunday)
                {
                    dataVencimento = dataVencimento.AddDays(1);
                }

                // Formatação
                string linha = "Parcela " + i.ToString() + ": " + dataVencimento.ToString("dd/MM/yyyy") + " - Valor: " + valorParcela.ToString("C2");
                textBox4.AppendText(linha + Environment.NewLine);
            }

            label1.Text = "Total a Pagar: " + valorTotal.ToString("C2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
       

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
