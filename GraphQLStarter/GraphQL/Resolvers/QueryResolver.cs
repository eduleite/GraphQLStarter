using GraphQLStarter.Model;
using GraphQLStarter.Services;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLStarter.GraphQL.Resolvers
{
    public class QueryResolver
    {

        private readonly Database database;

        public QueryResolver(Database database)
        {
            this.database = database;
        }

        public IList<Aluno> Alunos(string contemNome, int? idadeAte, int? idadeAcimaDe)
        {
            var result = database.Alunos;
            if (contemNome != null)
            {
                result = result.Where(aluno => aluno.Nome.Contains(contemNome)).ToList();
            }
            if (idadeAte.HasValue)
            {
                result = result.Where(aluno => aluno.Idade <= idadeAte.Value).ToList();
            }
            if (idadeAcimaDe.HasValue)
            {
                result = result.Where(aluno => aluno.Idade >= idadeAcimaDe.Value).ToList();
            }
            return result;
        }

        public Aluno Aluno(int id)
        {
            return database.Alunos.Where(aluno => aluno.Id == id).FirstOrDefault();
        }

        public IList<Curso> Cursos()
        {
            return database.Cursos;
        }

    }
}
