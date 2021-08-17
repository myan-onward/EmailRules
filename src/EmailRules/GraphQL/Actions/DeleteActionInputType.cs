using HotChocolate.Types;

namespace EmailRules.GraphQL.Actions
{
    public class DeleteActionInputType : InputObjectType<DeleteActionInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DeleteActionInput> descriptor)
        {
            descriptor.Description("Represents the input to delete an Action.");

            descriptor
                .Field(c => c.ActionId)
                .Description("Represents the unique ID of the Action to remove.");

            base.Configure(descriptor);
        }
    }
}