
using System.Reflection;

namespace ToDo.Infrasturcture;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
