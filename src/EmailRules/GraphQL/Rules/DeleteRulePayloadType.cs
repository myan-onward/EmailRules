using HotChocolate.Types;

namespace EmailRules.GraphQL.Rules
{
    public class DeleteRulePayloadType : ObjectType<DeleteRulePayload>
    {
        protected override void Configure(IObjectTypeDescriptor<DeleteRulePayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for a deleted Rule.");

            descriptor
                .Field(c => c.RuleId)
                .Description("Represents the deleted Rule.");

            base.Configure(descriptor);
        }
    }
}