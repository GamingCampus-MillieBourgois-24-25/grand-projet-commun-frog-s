using UnityEngine;

namespace Workshop
{
    public class BlacksmithWorkshop : BaseWorkshop
    {
        
        [Header("Blacksmith Workshop Settings")]
        [SerializeField] private GameObject blacksmithFrogPrefab;
        [SerializeField] private GameObject blacksmithWorkshopPrefab;
        [SerializeField] private GameObject blacksmithWorkshopUI;
        
        [Header("Blacksmith Workshop Information")]
        [SerializeField] private string workshopName = "Blacksmith";
        [SerializeField] private string workshopDescription = "A place to forge weapons and armor.";

        new void Start()
        {
            goldPerCycle = 2;
            base.Start();
        }

        void Update()
        {
            base.Update();
        }
    }
}
