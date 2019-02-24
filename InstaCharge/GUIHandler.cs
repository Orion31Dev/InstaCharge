using System;
using System.Collections.Generic;
using UnityEngine;

namespace InstaCharge
{
    class GUIHandler : MonoBehaviour
    {
        public void Awake()
        {
            ErrorMessage.AddDebug("InstaCharge Loaded: charge | chargeto [amount]");
        }
    }
}
