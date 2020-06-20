using GraphQLStarter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLStarter.GraphQL.Resolvers
{
    public class MutationResolver
    {

        private readonly Database database;

        public MutationResolver(Database database)
        {
            this.database = database;
        }

        public bool CadastrarAluno(int id, string nome, int idade)
        {
            if (database.Alunos.Where(aluno => aluno.Id == id).Any())
            {
                return false;
            }
            database.Alunos.Add(new Model.Aluno
            {
                Id = id,
                Nome = nome,
                Idade = idade
            });
            return true;
        }

    }
}
