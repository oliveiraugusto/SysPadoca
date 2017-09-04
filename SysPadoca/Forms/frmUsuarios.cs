using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SysPadoca.Classes;

namespace SysPadoca.Forms
{
    public partial class frmUsuarios : Form
    {
        //Dentro desse form, vou criar um variavel global para receber o valor digitado na barra de pesquisa
        string valorComboPesquisa = null; // setando sempre como null para não receber lixo

        public frmUsuarios()
        {
            InitializeComponent();
        }

        //Botão Cadastrar
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Passando os dados para variaveis
            string nomeCompleto = txtNome1.Text;
            string email = txtEmail1.Text;
            string login = txtLogin1.Text;
            string senha = txtSenha1.Text;
            bool admin = chkAdministrador.Checked;

            //MessageBox.Show(nomeCompleto + email + login + senha);

            //Antes de fazer a inserção dos dados no banco, precisamos validar os campos
            if (txtNome1.Text == "" || txtEmail1.Text == "" || LabelSenha.Text == "") // Nenhum campo pode ficar vazio (somente o Administrador)
            {
                MessageBox.Show("Os Campos não podem ficar em Branco");
            }
            else //se os campos não estiverem vazios, faz a inserção no Sistema/Banco
            {
                //Instancio a classe usuarios
                Usuarios u = new Usuarios();

                //Chamo o metodo InsertUsuario e passo os dados por parametro (que serão tratados dentro do metodo)
                u.InsertUsuario(nomeCompleto, email, login.ToLower(), senha, admin);

                //Depois da inserção do usuario no Sistema/Banco
                //Limpo os TextBox do Form
                txtNome1.Text = "";
                txtEmail1.Text = "";
                txtLogin1.Text = "";
                txtSenha1.Text = "";
                chkAdministrador.Checked = false;

                //Faço um Focus no TextBox nome
                txtNome1.Focus();

                //Recarrego o Grid
                this.usuariosTableAdapter.Fill(this.sysPadocaDataSet.usuarios);
            }
        }

        //Ao carregar o form, esses comandos serão executados
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // A linha abaixo carrega os dados da tabela usuario no DataSet e os Distribui dentro do DataGridView
            this.usuariosTableAdapter.Fill(this.sysPadocaDataSet.usuarios);

            //Seto o ComboBox para aparecer o pesquisar ao abrir o form
            cboxPesquisar.Text = "Nome";

            //Focus no TextBox Nome
            txtNome1.Focus();
        }

        //Esse Metodo será executado todas as vezes que selectionar uma linha do Grid
        private void dataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //O metodo funciona da segunte forma:
            //Toda vez que eu clico na linha do grid, ele passa para os TextBoxs o valor de cada coluna
            int id = Convert.ToInt16(this.dataGridViewUsuarios.CurrentRow.Cells[0].Value);
            txtNome1.Text = this.dataGridViewUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtLogin1.Text = this.dataGridViewUsuarios.CurrentRow.Cells[2].Value.ToString();
            txtEmail1.Text = this.dataGridViewUsuarios.CurrentRow.Cells[5].Value.ToString();

            //Inclusive da senha que esta oculta para o usuario
            txtSenha1.Text = this.dataGridViewUsuarios.CurrentRow.Cells[3].Value.ToString();
            chkAdministrador.Checked = Convert.ToBoolean(this.dataGridViewUsuarios.CurrentRow.Cells[4].Value);
        }

        //Botão Alterar
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //Para fazer a alteração, eu crio alguma variaveis e passo os valores dos TextBox para elas
            int id = Convert.ToInt16(this.dataGridViewUsuarios.CurrentRow.Cells[0].Value);
            string nome = txtNome1.Text;
            string login = txtLogin1.Text;
            string email = txtEmail1.Text;
            string senha = txtSenha1.Text;
            bool admin = chkAdministrador.Checked;

            //Depois Instancio o a classe Usuarios
            Usuarios u = new Usuarios();

            //Chamo o metodo Updateusuario e passo por parametro todos os dados necessarios para o update (que serão tratados dentro do metodo)
            u.UpdateUsuario(id, nome, email, login, senha, admin);

            // E Recarrego os dados do DataSet após a alteração
            this.usuariosTableAdapter.Fill(this.sysPadocaDataSet.usuarios);
        }

        //Botão Deletar
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            //Crio uma variavel para receber o ID do usuário que será excluido do Banco/Sistema
            int id = Convert.ToInt16(this.dataGridViewUsuarios.CurrentRow.Cells[0].Value);

            //Crio uma variavel que vai receber o login do usuário que será excluido do Banco/Sistema
            string login = txtLogin1.Text;

            //Como essa é uma modificação que não pode ser desfeita, é melhor mostrar uma caixa de Sim/Não para o Usuário
            DialogResult resultadoExclusao = MessageBox.Show("O usuário " + login.ToUpper() + " será excluido do sistema \nTem Certeza? \n(Essa operação não pode ser desfeita)", "Confirmação: Exclusão de Usuário", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            //Se o usuario clicar em YES
            if (resultadoExclusao == DialogResult.Yes)
            {
                //instancio a classe usuarios  e chamo o metodo DeleteUsuario, passando o id por parametro (que sera tratado dentro do metodo)
                Usuarios u = new Usuarios();
                u.DeleteUsuario(id);

                //Depois da Exclusão, limpo os dados do usuario deletado dos TextBox
                txtNome1.Text = "";
                txtEmail1.Text = "";
                txtLogin1.Text = "";
                txtPesquisar.Text = "";
                txtSenha1.Text = "";
                chkAdministrador.Checked = false;

                // E Recarrego os dados do DataSet após a exclusão
                this.usuariosTableAdapter.Fill(this.sysPadocaDataSet.usuarios);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            string pesquisa = txtPesquisar.Text;
            string parametro = valorComboPesquisa.ToLower();
            


        }

        //Esse metodo é usado para passar o valor do ComboBox da pesquisa para uma variavel
        private void cboxPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            valorComboPesquisa = cboxPesquisar.Text;
        }
    }
}