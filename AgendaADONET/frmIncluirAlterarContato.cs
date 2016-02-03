using AgendaADONET.Classes;
using AgendaADONET.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaADONET
{
    public partial class frmIncluirAlterarContato : Form
    {
        private Contato contato;
        
         public frmIncluirAlterarContato(Contato contato = null)
        {
            this.contato = contato;
            InitializeComponent();
        }

        public frmIncluirAlterarContato()
        {
            InitializeComponent();
        }

        private void frmIncluirAlterarContato_Load(object sender, EventArgs e)
        {
            if(this.contato != null)
            {
                //veio contato para o form
                txbNome.Text = this.contato.Nome;
                txbEmail.Text = this.contato.Email;
                txbTelefone.Text = this.contato.Telefone.ToString();
            }
            else
            {
                txbNome.Text = string.Empty; //string vazia;
                txbEmail.Text = string.Empty;
                txbTelefone.Text = string.Empty;
            }

            txbNome.Focus(); //cursor vai ficar neste ponto
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); //fechar a tela
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ContatoDAO contatoDao = new ContatoDAO();
            if(this.contato == null)
            {
                //registro novo
                Contato contato = new Contato
                {
                    Nome = txbNome.Text,
                    Email = txbEmail.Text,
                    Telefone = Convert.ToInt32(txbTelefone.Text)
                };
                contatoDao.Inserir(contato);
            }
            else
            {
                //atualizar registro
                this.contato.Nome = txbNome.Text;
                this.contato.Email = txbEmail.Text;
                this.contato.Telefone = Convert.ToInt32(txbTelefone.Text);
                contatoDao.Atualizar(this.contato);
            }
            this.Close();
        }
    }
}
