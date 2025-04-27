using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HookCollector : MonoBehaviour
{
    [Tooltip("Le texte UI pour afficher le nombre de pièces.")]
    public TMP_Text coinCounterText;

    private int coinCount = 0;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager introuvable dans la scène !");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameManager == null)
            return;

        if (other.CompareTag("Coin"))
        {
            gameManager.AddMoney(1);
            coinCount++;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trash"))
        {
            gameManager.RemoveGolds(1);
            coinCount = Mathf.Max(0, coinCount - 1);
            Destroy(other.gameObject);
        }
        else
        {
            return;
        }

        // Mise à jour du texte
        if (coinCounterText != null)
            coinCounterText.text = coinCount.ToString();
    }
}