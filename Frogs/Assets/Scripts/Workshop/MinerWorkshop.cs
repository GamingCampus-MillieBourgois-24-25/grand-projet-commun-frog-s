using UnityEngine;

namespace Workshop
{
    public class MinerWorkshop : BaseWorkshop
    {
        [Header("Miner Workshop Settings")]
        [SerializeField] private GameObject MinerFrogPrefab;
        [SerializeField] private GameObject MinerWorkshopPrefab;
        [SerializeField] private GameObject MinerWorkshopUI;
        
        [Header("Miner Workshop Information")]
        [SerializeField] private string workshopName = "Miner";
        [SerializeField] private string workshopDescription = "A place to chop wood and gather resources.";

        private new void Start()
        {
            SetGoldCycle(2);

            base.Start();
        }

        private new void Update()
        {
            base.Update();
        }
    }
}
