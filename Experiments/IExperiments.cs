using CapabilityEvaluator.Models;

namespace CapabilityEvaluator.Experiments;

public interface IExperiment{
    string ExperimentId {
        get;
    }

    Task<ExperimentResult> RunAsync(
        string runId,
        CancellationToken cancellationToken
    );
}