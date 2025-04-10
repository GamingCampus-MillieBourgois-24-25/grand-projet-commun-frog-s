using UnityEngine;

namespace MiniGames
{
    public class MinerMiniGame : BaseMiniGames
    {
        private new void Start()
        {
            GoldMultiplier = 3f;
            base.Start();
        }

        private new void Update()
        {
            base.Update();
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("G Key Pressed Miner");
                HasWin = true;
            }
        }
    }
}
