using BenchmarkDotNet.Attributes;
using Amazon.IonDotnet;
using Amazon.IonDotnet.Builders;
using Amazon.IonDotnet.Tree;
using Amazon.IonDotnet.Tree.Impl;

[MemoryDiagnoser]
public class IonBenchmarks : BenchmarkBase
{
    private byte[] _data;

    [GlobalSetup]
    public void Setup()
    {
        var stream = new MemoryStream();
        var writer = IonBinaryWriterBuilder.Build(stream);
        writer.StepIn(IonType.Struct);
        writer.SetFieldName("Id"); writer.WriteInt(_user.Id);
        writer.SetFieldName("Name"); writer.WriteString(_user.Name);
        writer.SetFieldName("IsActive"); writer.WriteBool(_user.IsActive);
        writer.SetFieldName("CreatedAt"); writer.WriteTimestamp(new Timestamp(_user.CreatedAt));
        writer.StepOut();
        writer.Finish();
        _data = stream.ToArray();
    }

    [Benchmark]
    public byte[] Serialize()
    {
        var stream = new MemoryStream();
        var writer = IonBinaryWriterBuilder.Build(stream);
        writer.StepIn(IonType.Struct);
        writer.SetFieldName("Id"); writer.WriteInt(_user.Id);
        writer.SetFieldName("Name"); writer.WriteString(_user.Name);
        writer.SetFieldName("IsActive"); writer.WriteBool(_user.IsActive);
        writer.SetFieldName("CreatedAt"); writer.WriteTimestamp(new Timestamp(_user.CreatedAt));
        writer.StepOut();
        writer.Finish();
        return stream.ToArray();
    }

    [Benchmark]
    public UserModel Deserialize()
    {
        var user = new UserModel();
        var reader = IonReaderBuilder.Build(_data);
        while (reader.MoveNext() != IonType.None)
        {
            reader.StepIn();
            while (reader.MoveNext() != IonType.None)
            {
                var fieldName = reader.CurrentFieldName;
                switch (fieldName)
                {
                    case "Id":
                        user.Id = reader.IntValue();
                        break;
                    case "Name":
                        user.Name = reader.StringValue();
                        break;
                    case "IsActive":
                        user.IsActive = reader.BoolValue();
                        break;
                    case "CreatedAt":
                        user.CreatedAt = reader.TimestampValue().DateTimeValue;
                        break;
                }
            }
            reader.StepOut();
        }
        return user;
    }
}
