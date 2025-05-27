using BenchmarkDotNet.Running;

// run all benchmarks in the assembly
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
