using Auto.Core.Options;

namespace Auto.Options;

[AutoOptions(Node = "SystemRoot")]
public class Root
{
    public Redis Redis { get; set; }
}