using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HookCollector : MonoBehaviour
{
    [Tooltip("Le texte UI pour afficher le nombre de pièces.")]
    public TMP_Text coinCounterText;

    private int coinCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trash"))
        {
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
