using BenchmarkDotNet.Attributes;
using System.Formats.Cbor;

[MemoryDiagnoser]
public class CborBenchmarks : BenchmarkBase
{
    private byte[] _data;

    [GlobalSetup]
    public void Setup()
    {
        var writer = new CborWriter();
        writer.WriteStartMap(4);
        writer.WriteTextString("Id"); writer.WriteInt32(_user.Id);
        writer.WriteTextString("Name"); writer.WriteTextString(_user.Name);
        writer.WriteTextString("IsActive"); writer.WriteBoolean(_user.IsActive);
        writer.WriteTextString("CreatedAt"); writer.WriteDateTimeOffset(_user.CreatedAt);
        writer.WriteEndMap();
        _data = writer.Encode();
    }

    [Benchmark]
    public byte[] Serialize()
    {
        var writer = new CborWriter();
        writer.WriteStartMap(4);
        writer.WriteTextString("Id"); writer.WriteInt32(_user.Id);
        writer.WriteTextString("Name"); writer.WriteTextString(_user.Name);
        writer.WriteTextString("IsActive"); writer.WriteBoolean(_user.IsActive);
        writer.WriteTextString("CreatedAt"); writer.WriteDateTimeOffset(_user.CreatedAt);
        writer.WriteEndMap();
        return writer.Encode();
    }

    [Benchmark]
    public void Deserialize()
    {
        var reader = new CborReader(_data);
        reader.ReadStartMap();
        while (reader.PeekState() != CborReaderState.EndMap)
        {
            var key = reader.ReadTextString();
            _ = key switch
            {
                "Id" => (object)reader.ReadInt32(),
                "Name" => reader.ReadTextString(),
                "IsActive" => reader.ReadBoolean(),
                "CreatedAt" => reader.ReadDateTimeOffset(),
                _ => null
            };
        }
        reader.ReadEndMap();
    }
}
