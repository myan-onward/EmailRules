using HotChocolate.Types;

namespace EmailRules.GraphQL.Conditions
{
    public class DeleteConditionPayloadType : ObjectType<DeleteConditionPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteConditionPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for a deleted Condition.");

            descriptor
                .Field(c => c.ConditionId)
                .Description("Represents the deleted Condition.");

            base.Configure(descriptor);
        }
    }
}