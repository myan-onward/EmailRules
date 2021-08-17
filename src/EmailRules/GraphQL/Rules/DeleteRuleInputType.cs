using HotChocolate.Types;

namespace EmailRules.GraphQL.Rules
{
    public class DeleteRuleInputType : InputObjectType<DeleteRuleInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DeleteRuleInput> descriptor)
        {
            descriptor.Description("Represents the input to delete a Rule.");

            descriptor
                .Field(c => c.RuleId)
                .Description("Represents the unique ID of the Rule to remove.");

            base.Configure(descriptor);
        }
    }
}