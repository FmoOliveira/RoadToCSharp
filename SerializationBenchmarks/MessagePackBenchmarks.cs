using BenchmarkDotNet.Attributes;
using MessagePack;

[MemoryDiagnoser]
public class MessagePackBenchmarks : BenchmarkBase
{
    private byte[] _data;

    [GlobalSetup]
    public void Setup() => _data = MessagePackSerializer.Serialize(_user);

    [Benchmark] public byte[] Serialize() => MessagePackSerializer.Serialize(_user);
    [Benchmark] public UserModel Deserialize() => MessagePackSerializer.Deserialize<UserModel>(_data);
}
