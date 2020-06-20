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

        public IList<Aluno> Alunos { get; set; }

        public IList<Curso> Cursos { get; set; }

        public IList<(Curso curso, Aluno aluno)> Inscricoes { get; set; }

    }
}
