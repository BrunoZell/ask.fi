module AskFi

module Messages =
    /// Translates into IEML phrase "$user do $action when $trigger matches $user.perspective"
    type Commitment = {
        /// Arbitrary IEML verb-phrase, with related user as subject.
        Action: unit

        // Predicate on users perspective
        Trigger: (UserReflection, WorldState) -> Decision
    }
    and Decision = Initiate | Inaction

    type ChangeOfPlan = {
        /// Users previous 'Change Of Plan', forming a linked list
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
    type ObservationPredicate = UserReflection -> WorldState -> bool
    type InvalidationCondition = UserReflection -> WorldState -> bool

    // The declaration of valuing certain happenings
    type Ask =
        | Attraction of ObservationPredicate * InvalidationCondition
        | Aversion of ObservationPredicate * InvalidationCondition

    // Groups all users asks into a set that is atomically updated
    type ValueSet = ValueSet of Ask list // v> All asks must come from the same user to form a value set

module UserPerspective =
    open AskFi.Messages

    /// Represents a unique user in the network and the protocol messages available to send
    type User = {
        DagAddress: byte list
    } with
        /// User commits to an updated plan
        abstract member Commit : ChangeOfPlan -> unit

        /// User proposes an alternative plan for another user
        abstract member Propose : Proposal -> unit

        /// User declares a new value set
        abstract member Declare : ValueSet -> unit

    type UserStateSnapshot = {
        Values: ValueSet
        Commitments: Commitment list
        Situation: Situation
    }

    /// Groups state snapshots of multiple users
    type NetworkStateSnapshot = {
        Users: Map<DagAddress, UserStateSnapshot>
    }
