using System;
using System.Threading.Tasks;
using EmailRules.Data;
using EmailRules.GraphQL;
using EmailRules.GraphQL.Actions;
using EmailRules.GraphQL.Conditions;
using EmailRules.GraphQL.Rules;
using EmailRules.Models;
using HotChocolate;
using HotChocolate.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EmailRules.Tests
{
    public class UnitTest1
    {
        private const string TESTDB_CONN_STR = @"Server=localhost,1433;Database=EmailRulesDB;User ID=sa;Password=CHANGE_PLZ";
        [Fact]
        public async Task Schema_Query()
        {
            // arrange
            ISchema schema =
            await new ServiceCollection()
                .AddGraphQL()
                .AddQueryType<Query>()
                .AddFiltering()
                .AddSorting()
                .BuildSchemaAsync();

            // act
            var schemaSDL = schema.Print();

            // assert
            Console.WriteLine(schemaSDL);
            // schemaSDL.MatchSnapshot();
        }

        [Fact]
        public async Task Schema_Query_EFDB()
        {
            // arrange
            // act
            ISchema schema = await new ServiceCollection()
                .AddPooledDbContextFactory<AppDbContext>(
                    // options => options.UseInMemoryDatabase("Data Source=conferences.db")
                    options => options.UseSqlServer(TESTDB_CONN_STR)
                )
                .AddGraphQL()
                .AddQueryType<Query>()
                .AddType<RuleType>()
                .AddType<ConditionType>()
                .AddType<SpecificConditionType>()
                .AddType<ActionType>()
                .AddType<SpecificActionType>()
                .AddFiltering()
                .AddSorting()
                .BuildSchemaAsync();

            // assert
            var schemaSDL = schema.Print();
            Console.WriteLine(schemaSDL);
            // schema.Print().MatchSnapshot();
        }

        [Fact]
        public async Task Query_RulesIsReturned()
        {
            // arrange
            IRequestExecutor executor =
                await new ServiceCollection()
                .AddPooledDbContextFactory<AppDbContext>(
                    // options => options.UseInMemoryDatabase("Data Source=conferences.db")
                    options => options.UseSqlServer(TESTDB_CONN_STR)
                )
                .AddGraphQL()
                .AddQueryType<Query>()
                .AddType<RuleType>()
                .AddType<ConditionType>()
                .AddType<SpecificConditionType>()
                .AddType<ActionType>()
                .AddType<SpecificActionType>()
                .AddFiltering()
                .AddSorting()
                .BuildRequestExecutorAsync();

            //act
            IExecutionResult result =
                await executor.ExecuteAsync("{ rules { name } }");

            //assert
            var resp = result.ToJson();
            Console.WriteLine(resp.ToString());
            // result.ToJson().MatchSnapshot();
        }

        [Fact]
        public async Task Mutation_AddRule()
        {
            // arrange
            IRequestExecutor executor = await new ServiceCollection()
                .AddPooledDbContextFactory<AppDbContext>(
                    // options => options.UseInMemoryDatabase("Data Source=conferences.db")
                    options => options.UseSqlServer(TESTDB_CONN_STR)
                )
                .AddGraphQL()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddType<RuleType>()
                .AddType<AddRuleInputType>()
                .AddType<AddRulePayloadType>()
                .AddType<ConditionType>()
                .AddType<AddConditionInputType>()
                .AddType<AddConditionPayloadType>()
                .AddType<SpecificConditionType>()
                .AddType<ActionType>()
                .AddType<AddActionInputType>()
                .AddType<AddActionPayloadType>()
                .AddType<SpecificActionType>()
                .AddInMemorySubscriptions()
                .AddFiltering()
                .AddSorting()
                .BuildRequestExecutorAsync();

            // act
            IExecutionResult result = await executor.ExecuteAsync(@"
            mutation addRule {
                addRule(input: {name: ""TEST""}) {
                    rule {
                        id
                        name
                    }
                }
            }");

            // assert
            var mutated = result.ToJson();
            Console.WriteLine(mutated);
            // result.ToJson().MatchSnapshot();
        }

    }
}
