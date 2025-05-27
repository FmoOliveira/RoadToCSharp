using BenchmarkDotNet.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

[MemoryDiagnoser]
public class BsonBenchmarks : BenchmarkBase
{
    private byte[] _data;

    [GlobalSetup]
    public void Setup()
    {
        var doc = new BsonDocument
        {
            { "Id", _user.Id },
            { "Name", _user.Name },
            { "IsActive", _user.IsActive },
            { "CreatedAt", _user.CreatedAt }
        };
        _data = doc.ToBson();
    }

    [Benchmark]
    public byte[] Serialize() =>
        new BsonDocument {
            { "Id", _user.Id },
            { "Name", _user.Name },
            { "IsActive", _user.IsActive },
            { "CreatedAt", _user.CreatedAt }
        }.ToBson();
    [Benchmark]
    public BsonDocument Deserialize() =>
        BsonSerializer.Deserialize<BsonDocument>(new MemoryStream(_data));
}
