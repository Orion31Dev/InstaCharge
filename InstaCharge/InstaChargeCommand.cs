using System;
using UnityEngine;

namespace InstaCharge
{
    class InstaChargeCommand : MonoBehaviour
    {
        public void Awake()
        {
            DevConsole.RegisterConsoleCommand(this, "charge");
            DevConsole.RegisterConsoleCommand(this, "chargeto");
        }


        public void OnConsoleCommand_charge()
        {
            PlayerTool item = Inventory.main.GetHeldTool();
            EnergyMixin energyMixin = item.GetComponent<EnergyMixin>();

            ErrorMessage.AddMessage("Charged.");
            energyMixin.ModifyCharge(energyMixin.capacity);
        }

        public void OnConsoleCommand_chargeto(NotificationCenter.Notification n)
        {
            PlayerTool item = Inventory.main.GetHeldTool();
            EnergyMixin energyMixin = item.GetComponent<EnergyMixin>();

            if (n.data.Count != 1)
            {
                ErrorMessage.AddMessage("Usage: chargeto [amount]");
                return;
            }

            if ((float.TryParse((string)n.data[0], out float newCharge)))
            {
                ErrorMessage.AddMessage("Charged from " + energyMixin.charge + " to " + ((newCharge > energyMixin.capacity) ? energyMixin.capacity : newCharge) + ".");
                energyMixin.ModifyCharge(newCharge - energyMixin.charge);
                return;
            } else
            {
                ErrorMessage.AddMessage("Amount must be number.");
            }
        }

    }
}
