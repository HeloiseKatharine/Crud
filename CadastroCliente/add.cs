using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace CadastroCliente
{
    public partial class add : Form
    {
        Thread menu;

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlCommand comando2;
        String strSql;
        String strSql2;


        public add()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Conexão com MySQL
                conexao = new MySqlConnection("Server=localhost;Database=cadastro_cliente;Uid=root;Pwd=null;");

                strSql = "INSERT INTO CLIENTES ( NOME, ENDERECO, TELEFONE, EMAIL) VALUES (@NOME, @ENDERECO, @TELEFONE, @EMAIL)";
                strSql2 = "SELECT count(CODIGO) FROM CLIENTES";

                comando = new MySqlCommand(strSql, conexao);
                comando2 = new MySqlCommand(strSql2, conexao);

                //abrindo conexão 
                conexao.Open();

                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@ENDERECO", txtEndereco.Text);
                comando.Parameters.AddWithValue("@TELEFONE", txtTel.Text);
                comando.Parameters.AddWithValue("@EMAIL", txtEmail.Text);

                comando.ExecuteNonQuery();

                var quantCliente = comando2.ExecuteScalar();

                txtNum.Text = quantCliente.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //fechando conexão

                conexao.Close();
                conexao = null;
                comando = null;
                comando2 = null;
            }


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            menu = new Thread(Formmenu);
            menu.SetApartmentState(ApartmentState.STA);
            menu.Start();
        }

        private void Formmenu()
        {
            Application.Run(new Form2());
        }

        private void add_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}