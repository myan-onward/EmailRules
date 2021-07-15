using HotChocolate.Types;

namespace EmailRules.GraphQL.Actions
{
    public class AddActionInputType : InputObjectType<AddActionInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddActionInput> descriptor)
        {
            descriptor.Description("Represents the input to add for an Action.");

            descriptor
                .Field(c => c.specificAction)
                .Description("Represents the specific action to look for.");
            descriptor
                .Field(c => c.DirectObject)
                .Description("Represents the action value to check.");
            descriptor
                .Field(c => c.RuleId)
                .Description("Represents the unique ID of the email Rule which the Action belongs.");

            base.Configure(descriptor);
        }
    }
}