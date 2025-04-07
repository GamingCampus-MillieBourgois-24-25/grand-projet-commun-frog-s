using UnityEngine;

namespace MiniGames
{
    public class BlacksmithMiniGame : BaseMiniGames
    {
        private new void Start()
        {
            goldMultiplier = 1.5f;
            base.Start();
        }

        private new void Update()
        {
            base.Update();
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                hasWin = true;
            }
        }
        
    }
}
