using System.Linq;
using EmailRules.Data;
using EmailRules.Models;
using HotChocolate;
using HotChocolate.Types;

namespace EmailRules.GraphQL.Actions
{
    public class ActionType : ObjectType<EmailAction>
    {
        protected override void Configure(IObjectTypeDescriptor<EmailAction> descriptor)
        {
            descriptor.Description("Represents action applied to an email.");

            descriptor.Field(c => c.Rule)
            .ResolveWith<Resolvers>(c => c.GetRule(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the rule to which the action belongs.");
        }

        private class Resolvers
        {
            public EmailRule GetRule(EmailAction action, [ScopedService] AppDbContext context)
            {
                return context.Rules.FirstOrDefault(r => r.Id == action.RuleId);
            }
        }
    }
}