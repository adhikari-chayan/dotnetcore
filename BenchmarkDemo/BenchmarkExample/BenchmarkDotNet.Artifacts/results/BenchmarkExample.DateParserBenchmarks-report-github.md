``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Core i7-8665U CPU 1.90GHz (Coffee Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.100
  [Host]     : .NET 5.0.0 (5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET 5.0.0 (5.0.20.51904), X64 RyuJIT


```
|              Method |     Mean |    Error |   StdDev |   Median | Rank | Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |---------:|---------:|---------:|---------:|-----:|------:|------:|------:|----------:|
| GetYearFromDateTime | 559.5 ns | 11.20 ns | 31.03 ns | 550.8 ns |    1 |     - |     - |     - |         - |
