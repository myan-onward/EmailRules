using HotChocolate.Types;

namespace EmailRules.GraphQL.Rules
{
    public class AddRulePayloadType : ObjectType<AddRulePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddRulePayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added Rule.");

            descriptor
                .Field(p => p.rule)
                .Description("Represents the added Rule.");

            base.Configure(descriptor);
        }
    }
}