namespace CapabilityEvaluator.Models;


// experiment results
public enum OperationOutcome{
    Allowed,
    Denied,
    Inconclusive
}

// experiment's evidence demonstrates violation of a security boundary
public enum PropertyOutcome{
    ViolationDemonstrated,
    ViolationNotDemonstrated,
    Inconclusive
}

public enum EvidenceQuality{
    Sufficient,
    Partial,
    Insufficient
}

public sealed record ExperimentResult(
    string ExperimentId,
    string RunId,
    string Capability,
    string TargetProperty,
    OperationOutcome OperationOutcome,
    PropertyOutcome PropertyOutcome,
    EvidenceQuality EvidenceQuality,
    string Observation,
    string Limitations,
    DateTimeOffset Timestamp
);