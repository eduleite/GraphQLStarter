using GraphQLStarter.Model;
using GraphQLStarter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLStarter.GraphQL.Resolvers
{
    public class CursoResolver
    {

        private readonly Database database;

        public CursoResolver(Database database)
        {
            this.database = database;
        }

        public IList<Aluno> Inscritos(Curso source)
        {
            return database.Inscricoes
                .Where(inscricao => inscricao.curso.Id == source.Id)
                .Select(inscricao => inscricao.aluno)
                .ToList();
        }

    }
}
