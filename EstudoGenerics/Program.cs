using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa
            {
                Id = 1,
                Nome = "Guilherme"
            };

            Animal animal = new Animal
            {
                Id = 1,
                Especie = "Cachorro"
            };

            RepositorioGenerico<Pessoa> rP = new RepositorioGenerico<Pessoa>();
            RepositorioGenerico<Animal> rA = new RepositorioGenerico<Animal>();

            rP.Insert(pessoa);
            rA.Insert(animal);

            foreach (Pessoa p in rP.Get())
            {
                Console.WriteLine("Id Pessoa: {0}, Nome pessoa: {1}", p.Id, p.Nome);
            }

            foreach (Animal a in rA.Get())
            {
                Console.WriteLine("Id Animal: {0}, Especie Animal: {1}", a.Id, a.Especie);
            }

            Console.ReadKey();


        }
    }
}
