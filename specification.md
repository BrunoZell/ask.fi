# SemanticSwap Specification

To understand how to read this, take [this brief explainer of IEML syntax](./ieml.md) as a reference.

A paranode describing something that could happen, phrased so that a `#subject` is doing an `#action`. Inevitable, it will use concepts from a world model. It refers to the physical, immeasurable, objective truth triangulated by the world model. For this it's recommened to understand how IEML deals with referential semantics. You can read about it [here](https://intlekt.io/theoretical-principles/).

```ieml
@paranode
args: ($Actor, $Action of #action)
en: happening
(
0 ~verb #is doing,
1 <$Actor>,
2 <$Action>
)
```

An action describes a causal interaction that _could_ be done. The important constraint here that the subject _can decide_ on whether to do it or not. And depending on that decision, actually do it or not. And doing it results in causal effects on the world model. And that action must be in the future, although no requirements on when exactly it will take place are required. But can be specified in useful.

```ieml
@paranode
args: ($Process)
en: action
(
0 ~noun $Process,
1 <$Actor>,
2 <$Action>
5 #in the future
)
```

Link to concrete actions:

- Driving a car towards a location
- Sending Ethereum to a wallet address
- Withdrawing Ethereum from an exchange to a wallet address

## Value Statement

In reference to a (stateless) world model, specify arbitrary user defined values. As a sort-order function that orders all possible situations according to user-defined preferences.

```fsharp
type Preference = Better | Worse | Indifferent
type Prefer<^WorldModel> = (a:WorldState, b:WorldState) -> Preference
```

Those value statements can be used by market makers to come up with offers that precisely target user values, thus increasing service quality.

## Ask

$ask = $asker wants (evidence of) $happening, where
- $asker is: the participant requsting the $happening (and thus signing the message and is receiver of all offers pointing to that ask)
- $happening is: a predicate on world observations, in reference to required domain models

Example asks (_"I want #happening to happen"_):

- (I want someone to) send 1 ETH to address 0x0 within 50 blocks after $deal.timestamp
  ```fsharp
  $referenceBlock = Ethereum.latestAt $deal.timestamp
  Ethereum.Blocks
    |> where (b -> $referenceBlock.Number - b.Number < 50)
    |> flatMap (b -> b.Transactions)
    |> any (t -> t is Transfer && t.to == 0x0)
  // (references domain model: Ethereum)
  ```
- (I want someone to) pick me up, at address Moeckernbruecke, using a car, until $ask.timestamp+30min, to then drive me to Tempelhofer feld, arriving no later than now+1h.
  ```
  // references domain model: Berlin Map, ride sharing(car navigation)
  ```

## Offer

$offer = 

Todo: Standalone vs situational

Example offers (_"I can do something for you"_):

- (I can) pick you up, at `$pickup=(address Moeckernbruecke)`, using `[ref:MyCar]`, in 18±3 minutes, to then drive you to `$destination`, with an ETA of: `estimateTravelTime($pickup, $destination)`.
  With order form of:
  `$destination <: #address in Tempelhofer feld-area`

## Order

```fsharp
type OrderService = {
    offer: Offer
}
```

Example orders:
- ride share
- buy bitcoin
- bet on power market

## Deal

For a service provider to acknowledge an order, it signs it into a _Deal_.

```fsharp=
type SignDeal = {
    order: OrderService
    serviceProviderSignature: 
}
```

```ieml
subject: I, the $serviceProvider = #ServiceProvider<$order.offer.provider>
verb: #acknowledge
referent: the $order = #OrderService<ref=CID>

#acknowledge = (import text from below into IEML)
```

Achknowldinging and committing to a deal means taking on the #responsibility of coordinating the settlement so that $deal.offer.serviceDescription evaluates to 'SuccessfulDelivery' given all observed world states after $deal.timestamp.

Such #ServiceDescriptor might depend on observations relating to specifically the related $deal, therefore the data might not be available. But as long as everybody is fine with what happened, no more data is needed because settlement happens in reality. Only on a 'FailedDelivery' an additional settlement action is executed onchain.

Open design question: [Enforce deal delivery deadline](/K3zbY57zSXOsrFtKXDexXQ)


## Delivery

After a deal is signed, all participants can post evidence for a given deals delivery (whether evidence for failure of success), although the $deal-definition has it's own (deal-specific) validation rules attached to it.

## Settlement

On optimal coordination, no participant should need to submit any delivery observations (although they are probably still recorded just in case). When delivery was successful in the eyes of anybod interested, 

Open design question: [Make each deal specify an evidence filter](/kkHl6drJSS2eynSU2gPkwg)

Only when the $deal.offer.serviceDescription evaluates to 'FailedDelivery' on any observation that pass the `$deal.evidenceFilter()`, then initiate a settlement. [Alternative: Settlement could also only be initiated after a deals delivery deadline, whichs eval-function is defined before the deal is signed (purely from the $deal.order) so that counter-evidence can still be recorded and submitted].

When settlement is initiated, according corrective actions will be initiated according to the responsibilities defined in the $deal.

Todo: Specifiy how responsibilities are defined and analyed and how these corrective actions are executed and how they will be a good thing.

```fsharp
/// hgt in [ontology in IEML]
type Perspective = {
  // member functions are availale semantic queries from a Situation<^Perspective>
  // referenced types on those functions are implicitly public domain model types.
  // In the implementation of these member functions, analyze all references to Perception-types (analyze all possible calls to strongly-typed observations from WorldEventStream/WorldState.latest, since, during ect..)
}

type Query<^Perspective, 'Query, 'Result> = 'Query -> Situation<^Perspective> -> 'Result


type ActionTrigger =
  | Query of Query
  | Composition of Query list

type Decision =
  | Inaction
  | Initiate of Action

type Situation<^Perspective> = // position in Agents WorldEventStream

/// Instantiated every time an agent decides to initiate an action. Used to reflect on actions even if no causal effects are observed yet.
type ActionInitiation = {
  Trigger: AgentReflection * Situation<^Perspective> // Todo: Merge ActionReflection into the Situation. And just have well-defined queries for the action domain?
  Action: ActionSet
}

/// The history of all initiated actions of the agent. To reflect on decisions made, because it may not be evident from available observations in the latest Situation
type AgentReflection = ActionInitiation list

/// A function that maps any given situation an agent can be in to a decision, from his Perspective (WorldStateOntology).
type Plan = (AgentReflection, Situation<^Perspective>) -> Decision
// Todo: Write F# analyzer that extracts references to Perspective-queries and the logic between them and the construction of the action into a semantically interoperable model. Or at least generate:
// - the list of domain-queries used
// - the list of actions that can *possibly* be initiated
//    -> vnext: constrain to a subtype of those actions, by backtracing the decision function similar to typescripts type checker
// - the list of actions the decision can *possibly* reflect on.


// Probes an agents observations 
type ActionTriggerProbe<^Perspective> = (Situation<^Perspective>) -> ActionIntiation option // Only references queries and concepts from a perspective

type AlternativePlanProposal = {
  Proposer: AgentId
  Proposal: subject:AgentId * alternative:Plan
}

/// Sent in response to `AlternativePlanProposal` when Proposal.subject == $me
/// Evaluation process is outsourced to the agent so it reflects his true values because there are no constraints on that decision.
type Evaluation = Accept | Reject

type AlternativeProposalResponse = AlternativePlanProposal * Evaluation

let expectedAction = (Situation<^Perspective>, ProposedAction: Action, Probe: Query<^Perspective, Evaluation>) -> Possible | Impossible
// Probes are basically the agents values to probe for. Basicalt
// "I can do $action" where $action is constrained via Lattice (Cue). Like "I can send an ETH-Transfer that expectedly succeeds up to my balance of 1 ETH, minus whatever gas costs I'd have to pay.

```
  