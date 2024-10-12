using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _321445ProjeroFinal.Models
{
    internal class Banco
    {
        //Criando as variáveis publicas para a conexão e consulta serão usadas em todo o projeto
        //Connection responsável pela conexão com o MySQL
        public static MySqlConnection Conexao;
        //command responsável pekas instruções SQL a serem executados 
        public static MySqlCommand Comando;
        //adapter responsável por inserir dados em um dataTable
        public static MySqlDataAdapter Adaptador;
        //Database responsável por ligar o banco em controles com a propriedade DataSource
        public static DataTable datTabela;

        public static void Abrirconexao()
        {
            try
            {
                //Estabelece os parâmetros para a conexão com o banco
                Conexao = new MySqlConnection("server=localhost;port=3307;uid=root;pwd=etecjau");

                //Abre a conexão com o banco de dados 
                Conexao.Open();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static void Fechar_Conexao()
        {
            try
            {
                //Fecha a conexão com o banco de dados 
                Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void CriarBanco()
        {
            try
            {


                //Abrindo a conexão
                Abrirconexao();

                //Informa a instrução SQL
                Comando = new MySqlCommand("CREATE DATABASE IF NOT EXISTS vendas; USE vendas;", Conexao);
                //Executa a query no MySQL (é o raínho do banco)
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand("CREATE TABLE IF NOT EXISTS Cidades " +
                    "(id integer auto_increment primary key, " +
                    "nome char(40), " +
                    "uf char(02))", Conexao);
                Comando.ExecuteNonQuery();

                //Chama a função para fechar a conexão com o banco
                Fechar_Conexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmMenu_Load(Object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }
    }
}
