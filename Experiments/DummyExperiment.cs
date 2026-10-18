using CapabilityEvaluator.Models;

namespace CapabilityEvaluator.Experiments;

public sealed class DummyExperiment : IExperiment
{
    public string ExperimentId => "SMOKE-001";

    public Task<ExperimentResult> RunAsync(
        string runId,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var result = new ExperimentResult(
            ExperimentId: ExperimentId,
            RunId: runId,
            Capability: "A1 (simulated)",
            TargetProperty: "Harness smoke test; no security property evaluated",
            OperationOutcome: OperationOutcome.Allowed,
            PropertyOutcome: PropertyOutcome.Inconclusive,
            EvidenceQuality: EvidenceQuality.Insufficient,
            Observation: "Dummy result generated successfully; no protected operation was attempted.",
            Limitations: "Synthetic result only; provides no evidence about Chrome ABE or DBSC."
        );

        return Task.FromResult(result);
    }
}