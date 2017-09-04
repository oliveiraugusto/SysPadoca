using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysPadoca.Forms;

namespace SysPadoca.Forms
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMDI_Load(object sender, EventArgs e)
        {
            string login = frmLogin.LoginUsuario;
            tslBemVindo.Text = "Bem Vindo ao SysPadoca | Versão 2.0 | Usuario: "+login.ToUpper()+" | ";
            DateTime data = DateTime.Now;
            tslHoraCerta.Text = Convert.ToString(data);
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios fUsuarios = new frmUsuarios();
            fUsuarios.Show();
        }

        private void frmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //Esse metodo irá fazer a troca de usuario do sistema
        private void trocarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //primeiro passo uma caixa que avisa que todas as telas serão fechadas
            DialogResult resultadoTroca = MessageBox.Show("Deseja mesmo trocar de usuário?\nTODAS AS JANELAS SERÃO FECHADAS", "Confirmação: Troca de Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            //Se o usuario clicar em YES
            if (resultadoTroca == DialogResult.Yes)
            {

                //Forço todos os forms a serem fechados (menos o meu o que eu estou e o de login que é a base do sistema)
                for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 2; intIndex--)
                {
                    if (Application.OpenForms[intIndex] != this)
                        Application.OpenForms[intIndex].Close();
                }

                //Instancio o Form de Login
                frmLogin fLogin = new frmLogin();
                //Exibo ele
                fLogin.Show();

                //E escondo a MDI
                this.Hide();
            }

        }
    }
}
