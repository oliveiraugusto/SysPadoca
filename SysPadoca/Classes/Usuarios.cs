using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SysPadoca.Classes
{
    public class Usuarios : Conexao
    {
        public void InsertUsuario(string nome, string email, string login, string senha, bool admin)
        {
            SqlConnection conn = new SqlConnection(strConn); //instancio a classe de conexao com banco, passando a string de conexao como parametro

            SqlCommand cmd = new SqlCommand("SELECT count(*) FROM dbo.usuarios WHERE login = @login",conn);
            cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
            conn.Open();
            int resultSQL = (int)cmd.ExecuteScalar();

            if (resultSQL == 1)
            {
                System.Windows.Forms.MessageBox.Show("O usuario "+ login.ToUpper() + " já existe, por favor escolha outro" );
                conn.Close();
                return;
            }
            else
            {
                //instancio a classe comando sql, e passo meu script SQL por parametro
                SqlCommand cmd2 = new SqlCommand("INSERT INTO dbo.usuarios (nome, email, login, senha, administrador) VALUES (@nome, @email, @login, @senha, @admin)", conn);

                //Parametrizo minha query
                cmd2.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                cmd2.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd2.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                cmd2.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
                cmd2.Parameters.Add("@admin", SqlDbType.Bit).Value = admin;

                try
                {
                    cmd2.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("Dados gravados com sucesso!");
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("ERRO!\nNão foi possivel inserir os dados no Sistema\nPor Favor Contate o Suporte do sistema!");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void UpdateUsuario(int id, string nome, string email, string login, string senha, bool admin)
        {
            SqlConnection conn = new SqlConnection(strConn);

            //instancio a classe comando sql, e passo meu script SQL por parametro
            SqlCommand cmd2 = new SqlCommand("UPDATE dbo.usuarios SET nome = @nome, login = @login, senha = @senha, administrador = @admin, email = @email WHERE pk_id = @id", conn);

            //Parametrizo minha query
            cmd2.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd2.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
            cmd2.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd2.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
            cmd2.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
            cmd2.Parameters.Add("@admin", SqlDbType.Bit).Value = admin;

            conn.Open();

            try
            {
                cmd2.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Dados atualizados com sucesso!");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("ERRO!\nNão foi possivel atualizar os dados no Sistema\nPor Favor Contate o Suporte do sistema!");
            }
            finally
            {
                conn.Close();
            }

        }

        public void DeleteUsuario(int id)
        {
            SqlConnection conn = new SqlConnection(strConn);

            //instancio a classe comando sql, e passo meu script SQL por parametro
            SqlCommand cmd2 = new SqlCommand("DELETE FROM dbo.usuarios WHERE pk_id = @id;", conn);

            //Parametrizo minha query
            cmd2.Parameters.Add("@id", SqlDbType.Int).Value = id;
            conn.Open();

            try
            {
                cmd2.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Usuário removido");
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("ERRO!\nNão foi possivel alterar os dados no Sistema\nPor Favor Contate o Suporte do sistema!");
            }
            finally
            {
                conn.Close();
            }
        }

        //public int PesquisarUsuario(string pesquisa, string parametro)
        //{
        //    SqlConnection conn = new SqlConnection(strConn);
        //    string sql = "SELECT pk_id FROM dbo.usuarios WHERE " + parametro + " LIKE '%" + pesquisa + "%'";
        //    //System.Windows.Forms.MessageBox.Show(sql);

        //    //instancio a classe comando sql, e passo meu script SQL por parametro
        //    SqlCommand cmd2 = new SqlCommand(sql , conn);

        //    //Parametrizo minha query
        //    //cmd2.Parameters.Add("@pesquisa", SqlDbType.Int).Value = pesquisa;
        //    //cmd2.Parameters.Add("@parametro", SqlDbType.).Value = parametro;
        //    conn.Open();

        //    try
        //    {
        //        cmd2.ExecuteNonQuery();
        //        int resultadoSQL = (int)cmd2.ExecuteScalar();
        //        conn.Close();
        //        //System.Windows.Forms.MessageBox.Show(Convert.ToString(resultadoSQL));
        //        return resultadoSQL;
        //    }
        //    catch
        //    {
        //        conn.Close();
        //        System.Windows.Forms.MessageBox.Show("ERRO!\nNão foi possivel realizar essa pesquisa no sistema\nPor Favor Contate o Suporte do sistema!");
        //        return 0;
        //    }
        //}

    }
}
