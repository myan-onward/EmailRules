using System.Linq;
using EmailRules.Data;
using EmailRules.Models;
using HotChocolate;
using HotChocolate.Types;

namespace EmailRules.GraphQL.Conditions
{
    public class ConditionType : ObjectType<EmailCondition>
    {
        protected override void Configure(IObjectTypeDescriptor<EmailCondition> descriptor)
        {
            descriptor.Description("Represents criteria of an email.");

            descriptor.Field(c => c.Rule)
            .ResolveWith<Resolvers>(c => c.GetRule(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is the rule to which the condition belongs.");
        }

        private class Resolvers
        {
                public EmailRule GetRule(EmailCondition condition, [ScopedService] AppDbContext context)
                {
                    return context.Rules.FirstOrDefault(r => r.Id == condition.RuleId);
                }
        }
    }
}