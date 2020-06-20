using GraphQLStarter.GraphQL.Resolvers;
using GraphQLStarter.Model;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.GraphiQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLStarter.GraphQL
{
    public static class Configuration
    {

        public static IServiceCollection AddStarterGraphQL(this IServiceCollection services)
        {
            var schema = SchemaBuilder.New()
                .AddDocumentFromString(LoadSchemaFromFile())
                .BindResolver<QueryResolver>(configuration => configuration.To("Query"))
                .BindComplexType<Aluno>(configuration => configuration.To("Aluno"))
                .BindComplexType<Curso>(configuration => configuration.To("Curso"))
                .BindResolver<MutationResolver>(configuration => configuration.To("Mutation"))
                .BindComplexType<ResultadoInscricao>(configuration => configuration.To("ResultadoInscricao"))
                .BindResolver<CursoResolver>(configuration => configuration.To("Curso"));

            services.AddGraphQL(schema);

            return services;
        }

        public static string LoadSchemaFromFile()
        {
            using var stream = typeof(Configuration).Assembly.GetManifestResourceStream("GraphQLStarter.GraphQL.schema.graphql");
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static IApplicationBuilder UseStarterGraphQL(this IApplicationBuilder app)
        {
            app.UseGraphQL(new QueryMiddlewareOptions
            {
                Path = "/graphql"
            });

            app.UseGraphiQL(new GraphiQLOptions
            {
                Path = "/ui",
                QueryPath = "/graphql",
                EnableSubscription = false
            });

            return app;
        }


    }
}
