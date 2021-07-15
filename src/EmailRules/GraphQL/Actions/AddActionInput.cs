using EmailRules.Models;

namespace EmailRules.GraphQL.Actions
{
    public record AddActionInput(SpecificAction specificAction, string DirectObject, int RuleId);
}