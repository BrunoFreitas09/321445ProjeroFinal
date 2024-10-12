using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using _321445ProjeroFinal.Models;


namespace _321445ProjeroFinal.Views
{
    internal class Cidades
    {

        public int id { get; set; }
        public string nome { get; set; }

        public string uf { get; set; }




        public void Incluir()
        {
            try
            {
                //abrindo a conexão com o banco
                Banco.Abrirconexao();
                //Alimentando o método Command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("INSERT INTO cidades (nome, uf) VALUES (@nome, @uf)", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@nome", nome);//Parâmetro string 
                Banco.Comando.Parameters.AddWithValue("@uf", uf);
                //execura o Comando, no MYSQL, tem afunção do raio do Workbench
                Banco.Comando.ExecuteNonQuery();
                //Fecha a conexão
                Banco.Fechar_Conexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Alterar()
        {
            try
            {
                //abrindo a conexão com o banco
                Banco.Abrirconexao();
                //Alimentando o método Command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("Update cidades set nome = @nome, uf = @uf where id = @id", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@nome", nome);//Parâmetro string 
                Banco.Comando.Parameters.AddWithValue("@uf", uf);
                Banco.Comando.Parameters.AddWithValue("@id", id);
                //execura o Comando, no MYSQL, tem afunção do raio do Workbench
                Banco.Comando.ExecuteNonQuery();
                //Fecha a conexão
                Banco.Fechar_Conexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Excluir()
        {
            try
            {
                //abrindo a conexão com o banco
                Banco.Abrirconexao();
                //Alimentando o método Command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("delete from cidades where id = @id", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@id", id);
                //execura o Comando, no MYSQL, tem afunção do raio do Workbench
                Banco.Comando.ExecuteNonQuery();
                //Fecha a conexão
                Banco.Fechar_Conexao();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Consultar()
        {
            try
            {
                //abrindo a conexão com o banco
                Banco.Abrirconexao();
                //Alimentando o método Command com a instrução desejada e indica a conexão utilizada
                Banco.Comando = new MySqlCommand("SELECT * FROM Cidades where nome like @Nome " +   //Esse N maiúsculo é bem sus
                                                                       "order by nome", Banco.Conexao);
                //Cria os parâmetros utilizados na instrução SQL com seu respectivo conteúdo 
                Banco.Comando.Parameters.AddWithValue("@Nome", nome + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                Banco.Fechar_Conexao();
                return Banco.datTabela;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
