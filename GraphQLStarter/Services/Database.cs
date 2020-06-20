using GraphQLStarter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace GraphQLStarter.Services
{
    public class Database
    {

        public IList<Aluno> Alunos { get; set; } = new List<Aluno>
        {
            new Aluno
            {
                Id = 1,
                Nome = "Eduardo Leite",
                Idade = 41
            },
            new Aluno
            {
                Id = 2,
                Nome = "Pedro Leite",
                Idade = 11
            }
        };

        public IList<Curso> Cursos { get; set; } = new List<Curso>
        {
            new Curso
            {
                Id = 1,
                Nome = "GraphQL para iniciantes",
                Descricao = "Curso inicial que todos podem cursar"
            },
            new Curso
            {
                Id = 2,
                Nome = "GraphQL avançado",
                Descricao = "Curso avançado para pessoas safas em GraphQL"
            }
        };

    }
}
