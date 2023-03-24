# Ask Finance Specification

Ask Finance defines a conversational structure as an alternative solution to social coordination. We expect this to be more efficient, effective, and humane than money or every other political system humanity tried out yet.

## Protocol

Users follow these guiding principles:

1. _"Do whatever you want, as long as everybody is fine with it"_
2. _"Feel free to ask, but don't expect an answer"_

While these principles seem very basic and have surely been around for a while. The critical difference now is that we can implement computing infrastructure that help us living by these principles.

The system is a structured conversation, a protocol. While the overall structure is kept very simple, it is designed to accomodate arbitrary perspectives and arbitrary values. So the core protocol can cope with a radically changing world and will never have to change.

User-defined concepts in the conversation are expressed in [IEML (Information Economy MetaLanguage)](https://intlekt.io/ieml). This allows arbitrary concepts to be communicated without syncing up on them upfront, enabling _true_ counterparty discovery.

To verify the conversation, valid sequences of messages are encoded as a state channel on [HGTP (Hypergraph Transfer Protocol)](https://docs.constellationnetwork.io/core-concepts/). Due to it's great flexibility, it's possible to encode user-defined validation rules for everything that is not part of the core protocol but still essential for successful coordination.

## Users

New users are identified by their DAG-address. The underlying key is used to sign messages authored by them.

### Messages

There are just three predefined messages each user can sign and submit. These are:

- `Commit`: commiting to an updated personal coordination plan
- `Propose`: proposing changes to the coordination plan of another user
- `Declare`: adjusting the users values which are used by market makers to steer the optimization process towards the disired coordination plans

Those messages are serialized, signed, and sent to the global L0 network. This includes them into the AskFi state channel and are used to coordinate.

### State Snapshot

By aggregating all messages of a user, the users state snapshot is derived. It consists of:

- `Commitments`: All currently commited conditional actions of this user
- `Values`: The users latest declared value set
- `Situation`: The users latest perception of the world used to evaluate triggers of active commitments. This includes proofs of initiated actions or received proposals for alternative coordination.
