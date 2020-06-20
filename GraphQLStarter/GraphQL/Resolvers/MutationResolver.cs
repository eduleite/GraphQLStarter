using GraphQLStarter.Model;
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

        public ResultadoInscricao InscreverAlunoEmCurso(int idAluno, int idCurso)
        {
            //Verifica se aluno existe
            var aluno = database.Alunos.Where(aluno => aluno.Id == idAluno).FirstOrDefault();
            if (aluno == null)
            {
                return new ResultadoInscricao
                {
                    Sucesso = false,
                    MensagemErro = $"aluno com id {idAluno} não encontrado"
                };
            }
            //Verifica se curso existe
            var curso = database.Cursos.Where(curso => curso.Id == idCurso).FirstOrDefault();
            if (curso == null)
            {
                return new ResultadoInscricao
                {
                    Sucesso = false,
                    MensagemErro = $"curso com id {idCurso} não encontrado"
                };
            }
            //Verifica se aluno ja esta inscrito no curso
            if (database.Inscricoes.Where(inscricao => inscricao.curso.Id == idCurso && inscricao.aluno.Id == idAluno).Any())
            {
                return new ResultadoInscricao
                {
                    Sucesso = false,
                    MensagemErro = "Aluno ja matriculado no curso"
                };
            }
            //Inscrevendo aluno
            database.Inscricoes.Add((curso, aluno));
            return new ResultadoInscricao
            {
                Sucesso = true
            };
        }

    }
}
