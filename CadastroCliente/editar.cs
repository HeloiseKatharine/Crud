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
    public partial class editar : Form
    {
        Thread menu;

        MySqlConnection conexao;
        MySqlCommand comando;
        String strSql;

        public editar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Conexão com MySQL
                conexao = new MySqlConnection("Server=localhost;Database=cadastro_cliente;Uid=root;Pwd=null;");

                strSql = "UPDATE CLIENTES SET NOME = @NOME, ENDERECO = @ENDERECO, TELEFONE = @TELEFONE, EMAIL = @EMAIL WHERE CODIGO = @CODIGO";

                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@CODIGO", txtCod.Text);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                comando.Parameters.AddWithValue("@ENDERECO", txtEndereco.Text);
                comando.Parameters.AddWithValue("@TELEFONE", txtTel.Text);
                comando.Parameters.AddWithValue("@EMAIL", txtEmail.Text);

                //abrindo conexão 
                conexao.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Informações editadas com sucesso!");
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

        private void label1_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
