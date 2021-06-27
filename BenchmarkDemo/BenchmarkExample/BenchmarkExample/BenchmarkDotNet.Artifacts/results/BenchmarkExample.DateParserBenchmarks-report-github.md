``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-8665U CPU 1.90GHz (Coffee Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.100
  [Host]     : .NET 5.0.0 (5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET 5.0.0 (5.0.20.51904), X64 RyuJIT


```
|                              Method |      Mean |    Error |    StdDev |    Median | Ratio | RatioSD | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |----------:|---------:|----------:|----------:|------:|--------:|-----:|-------:|------:|------:|----------:|
| GetYearFromSpanWithManualConversion |  13.29 ns | 0.294 ns |  0.315 ns |  13.24 ns |  0.03 |    0.00 |    1 |      - |     - |     - |         - |
|                     GetYearFromSpan |  30.68 ns | 0.648 ns |  1.233 ns |  30.56 ns |  0.07 |    0.00 |    2 |      - |     - |     - |         - |
|                GetYearFromSubstring |  51.09 ns | 2.204 ns |  6.463 ns |  49.11 ns |  0.12 |    0.02 |    3 | 0.0076 |     - |     - |      32 B |
|                    GetYearFromSplit | 125.34 ns | 2.557 ns |  4.610 ns | 124.68 ns |  0.28 |    0.02 |    4 | 0.0381 |     - |     - |     160 B |
|                 GetYearFromDateTime | 435.25 ns | 8.373 ns | 22.920 ns | 429.20 ns |  1.00 |    0.00 |    5 |      - |     - |     - |         - |
