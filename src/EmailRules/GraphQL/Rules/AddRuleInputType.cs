using HotChocolate.Types;

namespace EmailRules.GraphQL.Rules
{
    public class AddRuleInputType : InputObjectType<AddRuleInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddRuleInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a Rule.");

            descriptor
                .Field(p => p.Name)
                .Description("Represents the name for the Rule.");

            base.Configure(descriptor);
        }
    }
}