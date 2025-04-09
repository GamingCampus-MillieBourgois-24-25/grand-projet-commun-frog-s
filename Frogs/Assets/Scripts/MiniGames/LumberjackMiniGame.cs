using UnityEngine;

namespace MiniGames
{
    public class LumberjackMiniGame : BaseMiniGames
    {
        private new void Start()
        {
            goldMultiplier = 2f;
            base.Start();
        }

        private new void Update()
        {
            base.Update();
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("G Key Pressed Lumberjack");
                hasWin = true;
            }
        }
    }
}
