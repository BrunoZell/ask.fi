# SemanticSwap Specification

To understand how to read this, take [this brief explainer of IEML syntax](./ieml.md) as a reference.

A paranode describing something that could happen, phrased so that a `#subject` is doing an `#action`. Inevitable, it will use concepts from a world model. It refers to the physical, immeasurable, objective truth triangulated by the world model. For this it's recommened to understand how IEML deals with referential semantics. You can read about it [here](https://intlekt.io/theoretical-principles/).

```ieml
#happening = (
0: is doing
#subject
#action
)

@link
	args:($A)
	en:happening
	template-en:$A indicates a position in relation to a horizontal axis
	phraseWordInflection: ~noun 
	
	(
	0 #to indicate the place,
	1 #word <$A>,
	2 #orientation or position in space,
	6 *in #horizontal axis
	).

```

```ieml
#action = 
```

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

- (I can) send 1 ETH to address 0x0
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
