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
    public partial class consulta : Form
    {
        Thread menu;

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dr;
        String strSql;

        public consulta()
        {
            InitializeComponent();
        }

        private void bntExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Conexão com MySQL
                conexao = new MySqlConnection("Server=localhost;Database=cadastro_cliente;Uid=root;Pwd=null;");

                strSql = "SELECT * FROM CLIENTES WHERE  NOME = @NOME";

                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@NOME", txtNome.Text);

                //abrindo conexão 
                conexao.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txtCod.Text = Convert.ToString(dr["codigo"]);
                    txtEndereco.Text = Convert.ToString(dr["Endereco"]);
                    txtTel.Text = Convert.ToString(dr["Telefone"]);
                    txtEmail.Text = Convert.ToString(dr["Email"]);
                }
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
    }
}
