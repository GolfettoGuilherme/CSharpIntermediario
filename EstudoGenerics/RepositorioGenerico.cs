using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoGenerics
{
    public class RepositorioGenerico<TTipo>
    {
        //essa classe pode lidar com qualquer objeto
        private List<TTipo> listaGenerica;

        public RepositorioGenerico()
        {
            listaGenerica = new List<TTipo>();
        }

        public List<TTipo> Get()
        {
            return listaGenerica;
        }

        public void Insert(TTipo meuObjeto)
        {
            listaGenerica.Add(meuObjeto);
        }

    }
}
