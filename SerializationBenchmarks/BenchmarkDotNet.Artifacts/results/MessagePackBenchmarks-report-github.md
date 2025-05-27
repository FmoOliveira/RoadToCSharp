```

BenchmarkDotNet v0.15.0, Windows 11 (10.0.26100.4061/24H2/2024Update/HudsonValley)
11th Gen Intel Core i5-1140G7 1.10GHz (Max: 1.80GHz), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.410
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method      | Mean     | Error   | StdDev   | Gen0   | Allocated |
|------------ |---------:|--------:|---------:|-------:|----------:|
| Serialize   | 141.0 ns | 5.85 ns | 16.78 ns | 0.0114 |      48 B |
| Deserialize | 161.0 ns | 6.35 ns | 18.61 ns | 0.0172 |      72 B |
