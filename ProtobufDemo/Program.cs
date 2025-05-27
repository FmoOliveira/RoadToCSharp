using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Google.Protobuf;
using ProtobufDemo.Protos;

[MemoryDiagnoser]
public class ProtobufBenchmark
{
    private Person person;
    private byte[] serializedData;
    private string filePath;

    [GlobalSetup]
    public void Setup()
    {
        person = new Person
        {
            Id = 12345,
            Name = "Alice Smith",
            Email = "alice.smith@example.com",
            Phones = {
                new PhoneNumber { Number = "555-1111", Type = PhoneType.Home },
                new PhoneNumber { Number = "555-2222", Type = PhoneType.Mobile }
            }
        };

        // Pre-serialize for use in deserialization benchmarks
        serializedData = person.ToByteArray();

        // Setup temp file for file I/O benchmarks
        filePath = Path.Combine(Path.GetTempPath(), "person_data_benchmark.bin");
        File.WriteAllBytes(filePath, serializedData);
    }

    [Benchmark]
    public byte[] SerializeToByteArray() => person.ToByteArray();

    [Benchmark]
    public byte[] SerializeToStream()
    {
        using (var stream = new MemoryStream())
        {
            person.WriteTo(stream);
            return stream.ToArray();
        }
    }

    [Benchmark]
    public Person DeserializeFromByteArray() => Person.Parser.ParseFrom(serializedData);

    [Benchmark]
    public Person DeserializeFromStream()
    {
        using (var stream = new MemoryStream(serializedData))
        {
            return Person.Parser.ParseFrom(stream);
        }
    }

    [Benchmark]
    public void SerializeToFile()
    {
        using (var fs = File.Create(filePath))
        {
            person.WriteTo(fs);
        }
    }

    [Benchmark]
    public Person DeserializeFromFile()
    {
        using (var fs = File.OpenRead(filePath))
        {
            return Person.Parser.ParseFrom(fs);
        }
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ProtobufBenchmark>();
    }
}
