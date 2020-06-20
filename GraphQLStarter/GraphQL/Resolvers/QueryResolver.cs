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

        public IList<Aluno> Alunos()
        {
            return database.Alunos;
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
