# SmenaticSwap User Stories

This documens shows the exact message exchange of some use cases to illustrate what role SemanitcSwap plays in social coordination. These examples are fousing on the end user experience.

## Crypto asset swap

This example illustrates the use case of cross-chain swaps for crypto assets and offers eagerly posted by market makers.

- show ask to buy a spot asset.
- show market maker offer inclundig guarantees of delivery
- show onchain transactions for all affected chains
- how an order refers to an existing blockchain, and an account on it

## Ride sharing (via market maker proxy)

This example illustrates a real world use case that works in web2, but can be further enhanced by aggregation through market making.

Outline UI-flow of ordering a ride via a special-purpose user interface for rideshare aggregation. Such UIs are built around typical user values and abstracting away unnecessary details like the name of specifc service providers. White those UIs are not neccessary on a technical level, they are important to enable non-technical every-day use of SemanticSwap for certain use cases.

- from initial ask
- how market makers would query Uber, Lift, Bolt, or own riders and post (private) offers targeted to specifically that asker
- through selection of offers by mapping the preferences of the user to all available offers
- ordering one ride share by filling out the according order formular (by assigning constants to the offers variables)
- wait for a signed deal (from the service providerm within the TTL)
- through delivery (pickup)
- to final settlement (service provider posts evidence of delivery; customer posts evidence of delivery failure; delta-settlement is executed according to terms specified in the $deal).

## Ride sharing (via exchange-native employment)

This example illsutrates how you would work as a driver for a market maker that coordinates ride shares.

First [read about the accoridng coordination scheme](./market-making.md) the market maker might use.

## Crypto derivative (via external index price)

As a prediction market on future bid/ask on all well-known exchanges. Or altern

## Crypto derivative (as future with exhange-native physical delivery)

Use SemanticSwap-native orders to acquire spot crypto assets and define a coordination scheme around it that facilitates a betting market.

## DAG 99/100 ask

Buying a very unique physical coin. Illustrates how the exchange is able to accept any possible ask regarless how detailed or unique they are.

Put an ask to swap the DAG 98/100 coin for the DAG 99/100 coin

Todo: Find an IEML sentence that sufficently describes the act of asking for the 99/100 DAG coin and offer a swap for the 98/100 coin.
Todo: What is a sufficently trustless mechanism
