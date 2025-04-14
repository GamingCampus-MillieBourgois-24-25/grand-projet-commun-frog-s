using UnityEngine;

namespace Workshop
{
    public class LumberjackWorkshop : BaseWorkshop
    {
        [Header("Lumberjack Workshop Settings")]
        [SerializeField] private GameObject lumberjackFrogPrefab;
        [SerializeField] private GameObject lumberjackWorkshopPrefab;
        [SerializeField] private GameObject lumberjackWorkshopUI;
        
        [Header("Lumberjack Workshop Information")]
        [SerializeField] private string workshopName = "Lumberjack";
        [SerializeField] private string workshopDescription = "A place to chop wood and gather resources.";

        private new void Start()
        {
            SetGoldCycle(3);
            workshopType = WorkshopType.Lumberjack;

            base.Start();
        }

        private new void Update()
        {
            base.Update();
        }
    }
}
