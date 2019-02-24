using System;
using Harmony;
using UnityEngine;

namespace InstaCharge
{
    // Token: 0x02000004 RID: 4
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("Awake")]
    public class Inject : MonoBehaviour
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002149 File Offset: 0x00000349
        [HarmonyPrefix]
        public static void Load()
        {
            new GameObject().AddComponent<InstaChargeCommand>();
            new GameObject().AddComponent<GUIHandler>();
        }
    }
}
