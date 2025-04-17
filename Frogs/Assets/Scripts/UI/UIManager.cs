using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text moneyText; // Drag & Drop le Text dans l'inspector
    public GameManager gameManager; // Drag & Drop le GameManager

    void Update()
    {
        moneyText.text = gameManager.GetGolds().ToString();
    }
}
