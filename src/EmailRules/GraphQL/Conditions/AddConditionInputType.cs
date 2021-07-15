using EmailRules.GraphQL.Rules;
using HotChocolate.Types;

namespace EmailRules.GraphQL.Conditions
{
    public class AddConditionInputType : InputObjectType<AddConditionInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddConditionInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a Condition.");

            descriptor
                .Field(c => c.specificCondition)
                .Description("Represents the specific condition to look for.");
            descriptor
                .Field(c => c.onThis)
                .Description("Represents the condition value to check.");
            descriptor
                .Field(c => c.RuleId)
                .Description("Represents the unique ID of the email Rule which the Condition belongs.");

            base.Configure(descriptor);
        }
    }
}