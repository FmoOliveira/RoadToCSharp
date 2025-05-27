```

BenchmarkDotNet v0.15.0, Windows 11 (10.0.26100.4061/24H2/2024Update/HudsonValley)
11th Gen Intel Core i5-1140G7 1.10GHz (Max: 1.80GHz), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.410
  [Host]     : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.16 (8.0.1625.21506), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method      | Mean     | Error   | StdDev   | Median   | Gen0   | Allocated |
|------------ |---------:|--------:|---------:|---------:|-------:|----------:|
| Serialize   | 314.4 ns | 8.68 ns | 24.76 ns | 303.2 ns | 1.0939 |    4576 B |
| Deserialize | 155.7 ns | 3.49 ns | 10.30 ns | 153.1 ns | 0.0687 |     288 B |
