using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EstudoXML
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            CriarContato();
            lblTitulo.Text = CarregarTitulo();
            CarregarContatos();
        }

        private string CarregarTitulo()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C:\Curso\C#\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml");
            //se tiver mais que um conteudo no nó, o SingleNode vai trazer o primeiro
            XmlNode noTitulo = documentoXml.SelectSingleNode("/agenda/titulo");
            return noTitulo.InnerText;
        }

        private void CarregarContatos()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C:\Curso\C#\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml");
            XmlNodeList contatos = documentoXml.SelectNodes("/agenda/contatos/contato");
            foreach(XmlNode contato in contatos)
            {
                string representacaoContato = "";
                string id = contato.Attributes["id"].Value;
                string nome = contato.Attributes["nome"].Value;
                string idade = contato.Attributes["idade"].Value;
                representacaoContato = nome + ", " + idade + ", " + id;
                lbxContatos.Items.Add(representacaoContato);
            }
        }

        private void CriarContato()
        {
            //carregar o arquivo xml
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C:\Curso\C#\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml");
            //criar attributos
            XmlAttribute attId = documentoXml.CreateAttribute("id");
            attId.Value = "6";
            XmlAttribute attNome = documentoXml.CreateAttribute("nome");
            attNome.Value = "Teste Novo Elemento";
            XmlAttribute attIdade = documentoXml.CreateAttribute("idade");
            attIdade.Value = "50";
            //criar linha no xml
            XmlNode novoContato = documentoXml.CreateElement("contato");
            //linkar attributos
            novoContato.Attributes.Append(attId);
            novoContato.Attributes.Append(attNome);
            novoContato.Attributes.Append(attIdade);
            //pegar o nó principal e adicionar o Child criado acima
            XmlNode contatos = documentoXml.SelectSingleNode("/agenda/contatos");
            contatos.AppendChild(novoContato);

            //salvar no arquivo
            documentoXml.Save(@"C:\Curso\C#\TreinaWeb.CSharpIntermediario\EstudoXML\Agenda.xml");
        }
    }
}
