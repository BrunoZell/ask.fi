# SemanticSwap Specification

## Value Set

In reference to a (stateless) world model, specify arbitrary user defined values. As a sort-order function that orders all possible situations according to user-defined preferences.

```fsharp
type Preference = Better | Worse | Indifferent
type Prefer<^WorldModel> = (a:WorldState, b:WorldState) -> Preference
```

## Ask

$ask = $asker wants (evidence of) $happening, where
- $asker is: the participant requsting the $happening (and thus signing the message and is receiver of all offers pointing to that ask)
- $happening is: a predicate on world observations, in reference to required domain models

Todo: Put examples into previous ask scheme

Example asks (_"I want something to get done"_):

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

## Default Market Making Behavior

Specify all types and processes described in the whitepapers "Market Makers" section where a typical market maker process is described.

Then add example implementations of how certain market makers could operate:
- a ride share market maker: Proxy Uber, Lyft, Bolt ect and put quote as offers on the hypergraph
- a crypto asset spot purchaser

## User Stories

State exact message exchange for each user story described in the white paper.

### Crypto asset swap

- onchain transactions for all affected chains
- how an order refers to an existing blockchain, and an account on it

### Ride sharing proxy

- Market maker algo of a ride sharing market maker
- special-purpose user interface for ride haul aggregation, considerung typical user values and abstracting specifc service providers away
- How evidence is collected: Using GPS of user and driver: Driver is required to post his reasnable GPS historiy (outlining where he drive) and commits to locally pair with the customer. If the customer refuses to do that, the driver is free to not give him a lift and cancel. If paired, where both driver and user sign a message that they are rady to start the ride.

### DAG 99/100 ask

Find an IEML sentence that sufficently describes the act of asking for the 99/100 DAG coin and offer a swap for the 98/100 coin.

## [maybe] Specifications of early domain models

### Onchain power markes

Cash-settled, on-chain prediction markets on physical intraday power contract closing prices, as retrieved from power exchanges like EPEX and NordPool.

### Ride sharing

### L0 prediction markets
