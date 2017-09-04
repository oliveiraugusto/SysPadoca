using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SysPadoca.Classes
{
    public class Conexao
    {
        public static string strConn = @"Data Source=BOT0500897W10-1\SQLEXPRESS;Initial Catalog=syspadoca;Persist Security Info=True;User ID=sa;Password=sasenac"; //string de conexao

        //Metodo para testar a conexao com o banco de Dados no momento de abrir o sistema
        public static SqlConnection TestaConexao()
        {
            try // tenta realizar a conexao com o banco de dados
            {
                SqlConnection conn = new SqlConnection(strConn); // crio uma nova instancia do SqlConnection (passando a string de conexao por parametro)
                return conn; // retorna a propria conexao aberta
            }
            catch //Mas se a conexão falhar
            {
                System.Windows.Forms.MessageBox.Show("Houve um erro na conexão com o Banco de Dados!\nContate o Suporte do sistema!");
                System.Windows.Forms.Application.Exit();
                throw new Exception(""); //Alteração qualquer no codigo
            }
        }
        
    }
}
