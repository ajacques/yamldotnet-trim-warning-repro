using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

public class Config
{
}

[YamlStaticContext]
[YamlSerializable(typeof(Config))]
partial class YamlStaticContext;


public class Program
{
    public static async Task Main(string[] args)
    {
        // Read and parse config.yml
        var configYaml = await File.ReadAllTextAsync("config.yml");

        var deserializer = new StaticDeserializerBuilder(new YamlStaticContext())
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
        var config = deserializer.Deserialize<Config>(configYaml);

        Console.WriteLine(config);
    }
}