using Fody;
using Mono.Cecil.Cil;
using System.Collections.Generic;
using System.Linq;

namespace Weavers
{
    public class UnsafeWeaver : BaseModuleWeaver
    {
        public override void Execute()
        {
            var enumInfoType = ModuleDefinition.GetType("Genumerics.Unsafe");
            foreach (var method in enumInfoType.Methods)
            {
                if (method.Name == "As")
                {
                    var processor = method.Body.GetILProcessor();
                    processor.Emit(OpCodes.Ldarg_0);
                    processor.Emit(OpCodes.Ret);
                    LogInfo($"Set implementation of {method.Name}");
                }
            }
        }

        public override IEnumerable<string> GetAssembliesForScanning() => Enumerable.Empty<string>();
    }
}