using HotChocolate.Types;

namespace EmailRules.GraphQL.Conditions
{
    public class AddConditionPayloadType : ObjectType<AddConditionPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddConditionPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Condition.");

            descriptor
                .Field(c => c.condition)
                .Description("Represents the added Condition.");

            base.Configure(descriptor);
        }
    }
}