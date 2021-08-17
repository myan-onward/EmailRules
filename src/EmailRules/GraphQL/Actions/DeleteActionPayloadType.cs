using HotChocolate.Types;

namespace EmailRules.GraphQL.Actions
{
    public class DeleteActionPayloadType : ObjectType<DeleteActionPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteActionPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for a deleted Action.");

            descriptor
                .Field(c => c.ActionId)
                .Description("Represents the deleted Action.");

            base.Configure(descriptor);
        }
    }
}