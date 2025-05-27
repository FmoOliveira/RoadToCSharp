using BenchmarkDotNet.Attributes;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

[MemoryDiagnoser]
public class ProtobufBenchmarks : BenchmarkBase
{
    private UserProto _protoUser;
    private byte[] _data;

    [GlobalSetup]
    public void Setup()
    {
        _protoUser = new UserProto
        {
            Id = _user.Id,
            Name = _user.Name,
            IsActive = _user.IsActive,
            CreatedAt = Timestamp.FromDateTime(_user.CreatedAt.ToUniversalTime())
        };
        using var ms = new MemoryStream();
        _protoUser.WriteTo(ms);
        _data = ms.ToArray();
    }

    [Benchmark]
    public byte[] Serialize()
    {
        using var ms = new MemoryStream();
        _protoUser.WriteTo(ms);
        return ms.ToArray();
    }

    [Benchmark]
    public UserProto Deserialize() => UserProto.Parser.ParseFrom(_data);
}
