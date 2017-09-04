using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysPadoca.Classes;
using SysPadoca.Forms;

namespace SysPadoca
{
    public partial class frmLogin : Form
    {
        static string loginUsuario;

        public static string LoginUsuario
        {
            get { return loginUsuario; }
            set { loginUsuario = value;}
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            txtLogin.Focus();
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtLogin.Focus();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Conexao.TestaConexao();
            //Passo os valores digitados para as variaveis
            string login = txtLogin.Text;
            string senha = txtSenha.Text;
            
            Login l = new Login();//Instancio minha classe de Conexao

            bool verifica = l.Logar(login, senha); // crio uma variavel que vai receber a verificação do metodo Logar


            //Ai fazemos aquela verificação de sempre...
            if (login == "" || senha == "") // Se o usuario deixar os campos login OU senha em branco
            {
                MessageBox.Show("Não deixe os campos login/senha em branco"); // Abro um aviso na tela
            }
            else if (verifica == true) // se o retorno do metodo Logar foi true
            {
                LoginUsuario = txtLogin.Text;
                frmMDI fMDI = new frmMDI(); // Instancio o Form Principal (frmMDI)
                fMDI.Show(); // mostro ele 
                this.Hide(); // e escondo o Form de Login (frmLogin)
            }
            else // Se cair no senão, a verificação na classe logar nao deu certo
            {
                MessageBox.Show("Login/Senha incorretos"); // exibo pro usuario que o login/senha esta incorreto
            }
        }
    }
}
