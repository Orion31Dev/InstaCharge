using System;
using System.Reflection;
using Harmony;

namespace InstaCharge
{
    // Token: 0x02000003 RID: 3
    public static class Patcher
    {
        // Token: 0x06000006 RID: 6 RVA: 0x00002124 File Offset: 0x00000324
        public static void Patch()
        {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("com.orion31.instacharge");
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
