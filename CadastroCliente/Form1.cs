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
using System.Security.Principal;
using MySql.Data.MySqlClient;
using System.CodeDom.Compiler;

namespace CadastroCliente
{

    public partial class Form1 : Form
    {
        Thread nt;
        Thread usuario;
        MySqlConnection conexao;
        MySqlDataReader dr;
        MySqlCommand comando;
        String strSql;

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Conexão com MySQL
                conexao = new MySqlConnection("Server=localhost;Database=cadastro_cliente;Uid=root;Pwd=null;");

                strSql = "SELECT * FROM USUARIOS WHERE NOME = @NOME AND SENHA = @SENHA";

                comando = new MySqlCommand(strSql, conexao);

                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@SENHA", txtSenha.Text);

                //abrindo conexão 
                conexao.Open();

                dr = comando.ExecuteReader();

                //verificando se está no banco 
                if (dr.HasRows)
                {
                  
                    this.Close();
                    nt = new Thread(novoForm);
                    nt.SetApartmentState(ApartmentState.STA);
                    nt.Start();
                }
                else { MessageBox.Show("Erro!"); }

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

        private void novoForm()
        {
            Application.Run(new Form2());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            usuario = new Thread(FormUsuario);
            usuario.SetApartmentState(ApartmentState.STA);
            usuario.Start();
        }

        private void FormUsuario()
        {
            Application.Run(new addUsuario());
        }
    }
}
