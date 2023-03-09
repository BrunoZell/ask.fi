module AskFi

type Decision = Action | Inaction

/// Translates into IEML phrase "$user do $action when $trigger matches $user.perspective"
type Commitment = {
    /// Arbitrary IEML verb-phrase, with related user as subject.
    Action: unit

    // Predicate on users perspective
    Trigger: (UserReflection, WorldState) -> Decision
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

// In reference to a perspective, given a situation, evaluates to either a match or not
type ObservationPredicate = struct end
type InvalidationCondition = struct end

// The declaration of valuing certain happenings
type Ask =
    | Attraction of ObservationPredicate * InvalidationCondition
    | Aversion of ObservationPredicate * InvalidationCondition

// Groups all users asks into a set that is atomically updated
type ValueSet = ValueSet of Ask list // v> All asks must come from the same user to form a value set

type DagAddress = DagAddress of byte list
type User = {
    Address: DagAddress
} with
    /// User proposes an alternative plan for another user
    member Propose(p: Proposal)

    /// User commits to an updated plan
    member Commit(latest: ChangeOfPlan)
    
    /// User declares a new value set
    member Declare(value: ValueSet)

type UserStateSnapshot = {
    Values: ValueSet
    Commitments: Commitment list
    Situation: Situation
}

type NetworkStateSnapshot = {
    Users: Map<DagAddress, UserStateSnapshot>
}
