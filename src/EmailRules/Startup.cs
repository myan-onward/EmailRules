using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailRules.Data;
using EmailRules.GraphQL;
using EmailRules.GraphQL.Rules;
using EmailRules.GraphQL.Conditions;
using EmailRules.GraphQL.Actions;
using EmailRules.Models;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oracle.ManagedDataAccess.Client;


namespace EmailRules
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Set the active provider via configuration
            var provider = Configuration.GetValue("Provider", "SqlServer");
            // Console.WriteLine($"Provider = {provider}");

            // Set TnsAdmin value to directory location of tnsnames.ora and sqlnet.ora files
            OracleConfiguration.TnsAdmin = @"<DIRECTORY LOCATION>";

            // Set WalletLocation value to directory location of the ADB wallet (i.e. cwallet.sso)
            OracleConfiguration.WalletLocation = @"<DIRECTORY LOCATION>";

            services.AddPooledDbContextFactory<AppDbContext>(opt => _ = provider switch
            {
                // "Sqlite" => opt.UseSqlite(
                //     Configuration.GetConnectionString("SqliteConnection"),
                //     x => x.MigrationsAssembly("SqliteMigrations")),

                "SqlServer" => opt.UseSqlServer(
                    Configuration.GetConnectionString("SqlServerConnection"),
                    x => x.MigrationsAssembly("SqlServerMigrations")),

                // Configure ODP.NET connection string
                // optionsBuilder.UseOracle(@"User Id=<USER>;Password=<PASSWORD>;Data Source=<TNS NAME>");

                "Oracle" => opt.UseOracle(
                    Configuration.GetConnectionString("OracleConnection"),
                    x => x.MigrationsAssembly("OracleMigrations")),

                _ => throw new Exception($"Unsupported provider: {provider}")
            });

            services
            .AddGraphQLServer()
            .AddProjections()
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
            .AddSorting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql"
            },
            "/ui/voyager");
        }

        // private static void InitializeDatabase(IApplicationBuilder app)
        // {
        //     using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        //     {
        //         var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        //         if (context.Database.EnsureCreated())
        //         {
        //             var aarule = new EmailRule
        //             {
        //                 Name = "American Airlines",
        //                 Condition = new EmailCondition
        //                 {
        //                     Condition = Conditions.PeopleFrom,
        //                     OnThis = "aairlines@promo.aa.com"
        //                 },
        //                 Action = new EmailAction
        //                 {
        //                     ActionType = ActionTypes.OrganizeMoveTo,
        //                     DirectObject = "AA_Folder"
        //                 }
        //             };

        //             context.Rules.Add(aarule);

        //             var deltarule = new EmailRule
        //             {
        //                 Name = "Delta Airlines",
        //                 Condition = new EmailCondition
        //                 {
        //                     Condition = Conditions.PeopleFrom,
        //                     OnThis = "promos@deltaair.com"
        //                 },
        //                 Action = new EmailAction
        //                 {
        //                     ActionType = ActionTypes.OrganizeMoveTo,
        //                     DirectObject = "DeltaAir_folder"
        //                 }
        //             };

        //             context.Rules.Add(deltarule);

        //             var unitedrule = new EmailRule
        //             {
        //                 Name = "United Airlines",
        //                 Condition = new EmailCondition
        //                 {
        //                     Condition = Conditions.PeopleFrom,
        //                     OnThis = "flyunited@donotreply.united.com"
        //                 },
        //                 Action = new EmailAction
        //                 {
        //                     ActionType = ActionTypes.OrganizeMoveTo,
        //                     DirectObject = "United_Airlines_Folder"
        //                 }
        //             };

        //             context.Add(unitedrule);

        //             context.SaveChangesAsync();
        //         }
        //     }
        // }

    }
}
