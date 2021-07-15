using EmailRules.Models;

namespace EmailRules.GraphQL.Conditions
{
    public record AddConditionInput(SpecificCondition specificCondition, string onThis, int RuleId);
}