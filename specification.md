# Ask Finance Specification

Messages are expressed in IEML (Information Economy MetaLanguage) and the conversation is validated via HGTP (Hypergraph Transfer Protocol).

## `change-of-plan`

- References the users previous `change-of-plan`
- List of `commitment` added to the users canonical plan
- List of `commitment` in users previous canonical plan to be removed from it

## `commitment`

- IEML phrase "I do $action if I observe $trigger"
where $trigger is a predicate on HGTP state snapshots,
and $action is an arbitrary expression of the plan.
- proof validation: specifies how the user can proof an actions execution.

## `proposal`

- Recipient (addres who's plan is to be changed)
- `change-of-plan` (the alternative)

Proposals tend to come with commitments on whether that proposal is accepted by the recipient or not, to then further build coordination schemes around it.

## `ask`

| IEML phrase "I like to observe $predicate" + invalidation condition
| IEML phrase "I don't like to observe $predicate" + invalidation condition

Asks help market makers to find high quality proposals, and enable automatic negotiations.
