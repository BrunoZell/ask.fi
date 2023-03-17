# Message Types

## Coordination Plan

Every users todo list virtually being the cannonical social coordination plan.

### Commitment

```ieml
@paranode
args: ($DagAddress, $Action)
en:"I do $action if I observe $observation"
(
0 ~verb #"i.", // #to do
1 #"B." <$DagAddress>, // user
2 #action <$Action>, // Must be decidable by subject
5 #after #observation
)
```

### Propsal

I [~definite User] propose you [~definite User] commit to **commitment**

### Commitment (by accepting a proposal)

I commit to **commitment**, in reference to **proposal**

## Coordination Optimization

Every user states what they want and don't want in order for the economy to align the coordination with the users values.

- **attraction declaration**: I like to observe $observationPredicate
- **aversion declaration**: I like not to observe $observationPredicate

## Coordination Schemes

Certain (stateless) structures of coordination that can be reused, given they result in useful coordination results.

It's basically a group of **commitment** messages that are specialized to a specific use case.

### Ride Sharing

### Crypto Swap
