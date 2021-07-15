using HotChocolate.Types;

namespace EmailRules.GraphQL.Actions
{
    public class AddActionPayloadType : ObjectType<AddActionPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddActionPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Action.");

            descriptor
                .Field(c => c.action)
                .Description("Represents the added Action.");

            base.Configure(descriptor);
        }
    }
}