using UnityEngine;

namespace InstaCharge
{
    class Messenger : MonoBehaviour
    {
        private readonly static string Tag = "[InstaCharge]: ";
        public void Awake()
        {
            ErrorMessage.AddDebug("InstaCharge Loaded: charge | chargeto [amount]");
        }

        public static void AddMessage(object message)
        {
            ErrorMessage.AddMessage(Tag + message.ToString());
        }

    }
}
