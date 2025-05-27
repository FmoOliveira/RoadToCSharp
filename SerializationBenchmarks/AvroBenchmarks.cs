using BenchmarkDotNet.Attributes;
using Avro;
using Avro.Generic;
using Avro.IO;

[MemoryDiagnoser]
public class AvroBenchmarks : BenchmarkBase
{
    private byte[] _data;
    private Schema _schema;
    private GenericRecord _record;

    [GlobalSetup]
    public void Setup()
    {
        string schemaJson = @"{
            ""type"": ""record"",
            ""name"": ""User"",
            ""fields"": [
                {""name"": ""Id"", ""type"": ""int""},
                {""name"": ""Name"", ""type"": ""string""},
                {""name"": ""IsActive"", ""type"": ""boolean""},
                {""name"": ""CreatedAt"", ""type"": ""string""}
            ]
        }";
        _schema = Schema.Parse(schemaJson);
        _record = new GenericRecord((RecordSchema)_schema);
        _record.Add("Id", _user.Id);
        _record.Add("Name", _user.Name);
        _record.Add("IsActive", _user.IsActive);
        _record.Add("CreatedAt", _user.CreatedAt.ToString("o"));

        using var ms = new MemoryStream();
        new GenericWriter<GenericRecord>(_schema).Write(_record, new BinaryEncoder(ms));
        _data = ms.ToArray();
    }

    [Benchmark]
    public byte[] Serialize()
    {
        using var ms = new MemoryStream();
        new GenericWriter<GenericRecord>(_schema).Write(_record, new BinaryEncoder(ms));
        return ms.ToArray();
    }

    [Benchmark]
    public void Deserialize()
    {
        using var ms = new MemoryStream(_data);
        var decoder = new BinaryDecoder(ms);
        var reader = new GenericReader<GenericRecord>(_schema, _schema);
        reader.Read(null, decoder);
    }
}
