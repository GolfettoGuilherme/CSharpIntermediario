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
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CarregarDataGridView();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //o valor da linha celecionada, na posição 0, convertido para int
            int id = (int) dgvAgenda.CurrentRow.Cells[0].Value;
            ContatoDAO contatoDao = new ContatoDAO();
            contatoDao.Excluir(id);
            CarregarDataGridView();
        }

        private void CarregarDataGridView()
        {
            ContatoDAO contatoDao = new ContatoDAO();
            DataTable dataTable = contatoDao.GetContatos();
            dgvAgenda.DataSource = dataTable;
            dgvAgenda.Refresh();
            //usando dataSet
            /*DataSet ds = contatoDao.GetContatos();
            dgvAgenda.DataSource = ds.Tables["CONTATOS"];
            */
            CarregarStatusStrip();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmIncluirAlterarContato form = new frmIncluirAlterarContato();
            form.ShowDialog(); //formulário ficará em foco e não podera voltar enquanto não clicar
            CarregarDataGridView();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Contato contatoEditar = new Contato
            {
                Id = (int)dgvAgenda.CurrentRow.Cells[0].Value,
                Nome = dgvAgenda.CurrentRow.Cells[1].Value.ToString(),
                Email = dgvAgenda.CurrentRow.Cells[2].Value.ToString(),
                Telefone = (int)dgvAgenda.CurrentRow.Cells[3].Value
            };
            frmIncluirAlterarContato form = new frmIncluirAlterarContato(contatoEditar);
            form.ShowDialog();
            CarregarDataGridView();
        }

        private void CarregarStatusStrip()
        {
            ContatoDAO contatoDao = new ContatoDAO();
            string quantidadeContatos = contatoDao.ContarUsuarios();
            stsInfoUsuarios.Items[0].Text = quantidadeContatos.ToString() + "usuário(s)";
        }
    }
}
