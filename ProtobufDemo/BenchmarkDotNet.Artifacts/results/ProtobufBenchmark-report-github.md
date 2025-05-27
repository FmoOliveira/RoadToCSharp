```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3194)
11th Gen Intel Core i5-1140G7 1.10GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.408
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                   | Mean         | Error        | StdDev       | Gen0   | Allocated |
|------------------------- |-------------:|-------------:|-------------:|-------:|----------:|
| SerializeToByteArray     |     373.4 ns |     35.99 ns |    105.00 ns | 0.0381 |     160 B |
| SerializeToStream        |     717.5 ns |     47.61 ns |    138.87 ns | 1.1044 |    4624 B |
| DeserializeFromByteArray |     462.0 ns |     13.97 ns |     39.63 ns | 0.1488 |     624 B |
| DeserializeFromStream    |     853.9 ns |     44.01 ns |    125.55 ns | 1.1492 |    4808 B |
| SerializeToFile          | 330,460.7 ns | 10,465.39 ns | 30,857.44 ns | 1.9531 |    8545 B |
| DeserializeFromFile      | 270,075.9 ns |  9,541.99 ns | 28,134.77 ns | 0.9766 |    4984 B |
