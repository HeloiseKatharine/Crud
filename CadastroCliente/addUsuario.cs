using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace CadastroCliente
{
    public partial class addUsuario : Form
    {
        Thread login;

        MySqlConnection conexao;
        MySqlCommand comando;
        String strSql;

        public addUsuario()
        {
            InitializeComponent();
        }

        private void addUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String senha1 = txtSenha.Text.ToString();
            String senha2 = txtSenhaCon.Text.ToString();

            if (senha1.Equals(senha2))
            {
                try
                {
                    //Conexão com MySQL
                    conexao = new MySqlConnection("Server=localhost;Database=cadastro_cliente;Uid=root;Pwd=null;");

                    strSql = "INSERT INTO USUARIOS ( NOME, SENHA) VALUES (@NOME, @SENHA)";

                    comando = new MySqlCommand(strSql, conexao);

                    //abrindo conexão 
                    conexao.Open();

                    comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                    comando.Parameters.AddWithValue("@SENHA", txtSenha.Text);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Cadastrado com sucesso!");

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
                }
            }
            else
            {
                MessageBox.Show("Erro!");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
