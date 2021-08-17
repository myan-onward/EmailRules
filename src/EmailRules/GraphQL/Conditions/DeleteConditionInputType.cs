using HotChocolate.Types;

namespace EmailRules.GraphQL.Conditions
{
    public class DeleteConditionInputType : InputObjectType<DeleteConditionInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DeleteConditionInput> descriptor)
        {
            descriptor.Description("Represents the input to delete a Condition.");

            descriptor
                .Field(c => c.ConditionId)
                .Description("Represents the unique ID of the Condition to remove.");

            base.Configure(descriptor);
        }
    }
}