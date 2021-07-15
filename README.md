# EmailRules
GraphQL service for managing email rules

The service is expected to be used by a management client (or by user) to create Email Rules.
Ideally, Conditions and Actions are created independently from the Rules so they can be mixed and matched, similar to presets or templates.
Combined with the AdEmails service, the Email Rules would be run on an email box and filter out old advertisements.

## GraphQL Touchpoints
* Query, Mutation, and Subscription
* HotChocolate v11 Enum types
* HotChocolate v11 Propagation replaced with Resolvers
* HotChocolate v11 migrated Unit / Integration tests

## Default Endpoint
The endpoint is set by default to /graphql for ease.

## Query
* rules - an email rule that includes a collection of Conditions (such as From someone) and Actions (like Move to Folder 'Junk')

## Mutation
* addRule - Add an Email Rule first to build it up.  It needs only a name.
* addCondition - Add a Condition or criteria to categorize an email.
* addAction - Add an Action to take on an email when it has met a Condition.

## Subscription
* There is a single subscribable event on the addRule mutation.

## GraphQL Voyager
You may use the GraphQL UI Voyager once built and running to inspect the schema.  (/ui/voyager)
For example, a sample deployment can be reached at: https://emailrules.azurewebsites.net/ui/voyager

Otherwise, personally recommending the use of the Insomnia tool for testing the GraphQL services.
