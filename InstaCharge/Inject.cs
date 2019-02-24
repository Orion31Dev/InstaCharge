using Harmony;
using UnityEngine;

namespace InstaCharge
{
    [HarmonyPatch(typeof(Player))]
    [HarmonyPatch("Awake")]
    public class Inject : MonoBehaviour
    {
        [HarmonyPrefix]
        public static void Load()
        {
            new GameObject().AddComponent<InstaChargeCommand>();
            new GameObject().AddComponent<Messenger>();
        }
    }
}
