module AskFi

type DagAddress = DagAddress of byte list
type User = DagAddress

type Commitment = {
    Action: unit
    Trigger: unit // Todo: predicate on HGTP state snaphot
}

type ChangeOfPlan = {
    /// Users previous CoP, forming a linked list
    Previous: ChangeOfPlan
    Added: Commitment list
    Removed: Commitment list // v> Must be included in the previous state snapshot
}

/// Send & signed by 'Proposer', proposing an alternative coordination plan
type Proposal = {
    Proposer: User
    Recipient: User
    Alternative: ChangeOfPlan
}

type ObservationPredicate = struct end
type InvalidationCondition = struct end

type Ask =
    | Attraction of ObservationPredicate * InvalidationCondition
    | Aversion of ObservationPredicate * InvalidationCondition
