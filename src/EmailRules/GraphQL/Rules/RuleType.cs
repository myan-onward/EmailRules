using System.Linq;
using EmailRules.Data;
using EmailRules.Models;
using HotChocolate;
using HotChocolate.Types;

namespace EmailRules.GraphQL.Rules
{
    public class RuleType : ObjectType<EmailRule>
    {
        protected override void Configure(IObjectTypeDescriptor<EmailRule> descriptor)
        {
            descriptor.Description("Represents an email rule that handles (Action) an email based on criteria specified (Condition).");

            //descriptor.Field(f => f.).Ignore();

            descriptor.Field(f => f.Conditions)
            .ResolveWith<Resolvers>(r => r.GetConditions(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is what criteria we are looking at in the email.");

            descriptor.Field(f => f.Actions)
            .ResolveWith<Resolvers>(r => r.GetActions(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("This is how we handle the email.");
        }

        private class Resolvers
        {            
            public IQueryable<EmailCondition> GetConditions(EmailRule rule, [ScopedService] AppDbContext context)
            {
                return context.Conditions.Where(c => c.RuleId == rule.Id);
            }

            public IQueryable<EmailAction> GetActions(EmailRule rule, [ScopedService] AppDbContext context)
            {
                return context.Actions.Where(a => a.RuleId == rule.Id);
            }
        }
    }
}