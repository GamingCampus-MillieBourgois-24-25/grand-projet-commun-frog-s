using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MiniGames
{
    public class TypingMiniGame : BaseMiniGames
    {
        [Header("Typing Mini Game Settings")]
        [SerializeField] private TMP_Text phraseToTypeText;
        [SerializeField] private TMP_InputField userInputField;
        [SerializeField] private Button submitButton;

        private string targetPhrase;

        protected new void Start()
        {
            base.Start();
            SetupNewPhrase();
            submitButton.onClick.AddListener(CheckUserInput);
        }

        private void SetupNewPhrase()
        {
            // Tu peux remplacer par un système plus évolué plus tard
            targetPhrase = "Vives les grenouilles !";
            phraseToTypeText.text = targetPhrase;
        }

        private void CheckUserInput()
        {
            if (userInputField.text == targetPhrase)
            {
                SetHasWin(true);
                Debug.Log("Gagné !");
                CloseMiniGame();
            }
            else
            {
                Debug.Log("Mauvais texte, réessaie !");
            }
        }
    }
}
