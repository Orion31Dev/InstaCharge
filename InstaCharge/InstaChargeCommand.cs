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
            EnergyMixin energyMixin = Inventory.main.GetHeldTool().GetComponent<EnergyMixin>();
            energyMixin.ModifyCharge(energyMixin.capacity);
            ErrorMessage.AddMessage("Charged.");
        }

        public void OnConsoleCommand_chargeto(NotificationCenter.Notification n)
        {
            EnergyMixin energyMixin = Inventory.main.GetHeldTool().GetComponent<EnergyMixin>();
            if (n.data.Count != 1 || n.data == null)
            {
                ErrorMessage.AddMessage("Usage: chargeto [amount]");
                return;
            }

            if (float.TryParse((string)n.data[0], out float newCharge))
            {
                float oldCharge = energyMixin.charge;
                energyMixin.ModifyCharge(newCharge - oldCharge);
                Messenger.AddMessage("Charged to " + ((newCharge > energyMixin.capacity) ? energyMixin.capacity : newCharge) + ".");
            }
            else
            {
                Messenger.AddMessage("Amount must be number.");
            }
        }

    }
}
