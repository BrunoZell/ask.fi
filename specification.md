# Ask Finance Specification

Ask Finance defines a conversational structure as an alternative solution to social coordination. We expect this to be more efficient, effective, and humane than money or every other political system humanity tried out yet.

## Protocol

Users follow these guiding principles:

1. _"Do whatever you want, as long as everybody is fine with it"_
2. _"Feel free to ask, but don't expect an answer"_

While these principles seem very basic and have surely been around for a while, the critical difference now is that we can implement computing infrastructure that help us living by these principles.

The system is a structured conversation, a protocol. While the overall structure is kept very simple, it is designed to accomodate arbitrary perspectives and arbitrary values. So the core protool can cope with a radically changing world ad will never have to change.

User-defined concepts in the conversation are expressed in [IEML (Information Economy MetaLanguage)](https://intlekt.io/ieml). This allows arbitrary concepts to be communicated without syncing up on them upfront, enabling _true_ counterparty discovery.

To verify the conversation, valid sequences of messages are encoded as a state channel on [HGTP (Hypergraph Transfer Protocol)](https://docs.constellationnetwork.io/core-concepts/). Due to it's great flexibility, it's possible to encode user-defined validation rules for everything that is not part of the core protocol but still essential for successful coordination.

## Messages

### `change-of-plan`

- References the users previous `change-of-plan`
- List of `commitment` added to the users canonical plan
- List of `commitment` in users previous canonical plan to be removed from it

### `commitment`

- IEML phrase "I do $action if I observe $trigger"
where $trigger is a predicate on HGTP state snapshots,
and $action is an arbitrary expression of the plan.
- proof validation: specifies how the user can proof an actions execution.

### `proposal`

- Recipient (addres who's plan is to be changed)
- `change-of-plan` (the alternative)

Proposals tend to come with commitments on whether that proposal is accepted by the recipient or not, to then further build coordination schemes around it.

### `ask`

| IEML phrase "I like to observe $predicate" + invalidation condition
| IEML phrase "I don't like to observe $predicate" + invalidation condition

Asks help market makers to find high quality proposals, and enable automatic negotiations.
