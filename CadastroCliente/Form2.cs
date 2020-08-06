using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace CadastroCliente
{
    public partial class Form2 : Form
    {
        

        Thread nt1;
        Thread login;

        public Form2()
        {
            InitializeComponent();
        }


        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Close();
            nt1 = new Thread(formAdd);
            nt1.SetApartmentState(ApartmentState.STA);
            nt1.Start();
        }

        private void formAdd()
        {
            Application.Run(new add());
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.Close();
            nt1 = new Thread(formEditar);
            nt1.SetApartmentState(ApartmentState.STA);
            nt1.Start();
        }

        private void formEditar()
        {
            Application.Run(new editar());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.Close();
            nt1 = new Thread(formExcluir);
            nt1.SetApartmentState(ApartmentState.STA);
            nt1.Start();
        }

        private void formExcluir()
        {
            Application.Run(new excluir());
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.Close();
            nt1 = new Thread(formConsulta);
            nt1.SetApartmentState(ApartmentState.STA);
            nt1.Start();
        }

        private void formConsulta()
        {
            Application.Run(new consulta());
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            login = new Thread(FormLogin);
            login.SetApartmentState(ApartmentState.STA);
            login.Start();
        }

        private void FormLogin()
        {
            Application.Run(new Form1());
        }
    }
}
