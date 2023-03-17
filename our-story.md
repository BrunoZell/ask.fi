# Our Story

We spent a lot of time building a trading system from first principles. In the final design, we successfully abstracted out the perspective of the world, and what the user values in those perspectives. And then have a single algorithm optimizing arbitrary values in an arbitrary world.

While the design is seemingly abstract and simple, this is exactly what gives it its power. After a lot of experiments and validation, we're pretty sure now that this structure can model any auction mechanism, exchange, distributed ledger, or other domain. In a single ontology.

While building it, we figured that money is not the most efficient way to coordinate and there seemingly exist better alternatives.

Initially we traded in European power markets, then expanded into crypto markets, and now create a whole new paradigm of "Coordination Markets".

We'll do this by adding an internal market place to our trading bot. Multiple askbots will communicate via the Ask Finance protocol to cooperate across organizational boundaries and alongside existing financial markets. The protocol allows for more fine grained automatic negotiations than money and thus the network can coordinate on trading strategies none of the individual organizations involved could pull off in their own.

The core innovations that unlock such a protocol are the [Information Economy MetaLanguage (IEML)](https://intlekt.io/ieml) as a metadata system, and the [Hypergraph Transfer Protocol (HGTP)](https://docs.constellationnetwork.io/core-concepts/) as a raw data layer.

Read more about Ask Finance [here](./specification.md), and how to run askbot on your own [here](./askbot.md).
