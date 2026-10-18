using System.Text.Json;
using CapabilityEvaluator.Experiments;

var experiment = new DummyExperiment();
var runId = Guid.NewGuid().ToString("N");
using var cancellationTokenSource = new CancellationTokenSource();

var result = await experiment.RunAsync(
    runId,
    cancellationTokenSource.Token
);

Console.WriteLine($"Experiment: {result.ExperimentId}");
Console.WriteLine($"Run ID: {result.RunId}");
Console.WriteLine($"Operation outcome: {result.OperationOutcome}");
Console.WriteLine($"Property outcome: {result.PropertyOutcome}");
Console.WriteLine($"Evidence quality: {result.EvidenceQuality}");

// saving the result to the JSONL file.
var resultsDirectory = Path.Combine(
    Directory.GetCurrentDirectory(),
    "results"
);

Directory.CreateDirectory(resultsDirectory);

var resultsFile = Path.Combine(
    resultsDirectory,
    "experiment-results.jsonl"
);

var json = JsonSerializer.Serialize(result);

await File.AppendAllTextAsync(
    resultsFile,
    json + Environment.NewLine
);

Console.WriteLine($"Result saved to: {resultsFile}");