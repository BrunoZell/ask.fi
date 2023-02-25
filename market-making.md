# SemanticSwap Market Making

Some notes and examples on how to run market making bots within the SemanticSwap network.

## Default Market Making Behavior

Specify all types and processes described in the whitepapers "Market Makers" section where a typical market maker process is described.

## Examples

### Rideshare (as a proxy)

A ride share market maker: Proxy Uber, Lyft, Bolt ect and put quote as offers on the hypergraph.

Market maker scans for ask in the scheme of:

`I want to get picked up at #pickup and be lifted to #destination [within #delivery-window]`

If the market maker is able to serve #pickup and #destination within the asked time window, it builds an according offer.

The market maker will proxy the service to existing rideshare providers like Lyft, Uber, Bolt & co.

The market maker will request quotes for the requested ride from those services APIs. It records the full TLS session to prove that the quote is actually coming from those service providers. This ensures the market maker is fully trustless and can reasonably stay anonymous. The only trust-requirements are those of the existing services.

### Rideshare (as exchange-native coordination scheme)

To futher improve the quality of service, rideshare market makers may opt to hire their own drivers.

Todo: Show how drivers are hired, compensated, and coordinated

How evidence is collected: Using GPS of user and driver: Driver is required to post his reasnable GPS historiy (outlining where he drive) and commits to locally pair with the customer. If the customer refuses to do that, the driver is free to not give him a lift and cancel. If paired, where both driver and user sign a message that they are rady to start the ride.

In practice, there probably will be different market maker organizations focussing on different local regions or cities. This is to tailor their offers to the specific needs of the area.

### Crpyot asset spot delivery [via centralized exchange withdrawal]

Required domain models:

- Prooving TLS sessions for withdrawals of well-known exchanges

### Crypto asset spot delivery [via decentralized consensus topology]

Required domain models:

- Consensus topology of referenced chains, to form consensus about onchain state (using HGTP and PRO)
