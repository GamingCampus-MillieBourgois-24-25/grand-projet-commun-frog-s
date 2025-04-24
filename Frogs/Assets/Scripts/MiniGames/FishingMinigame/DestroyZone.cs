using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Dès qu’un Coin ou un Trash entre dans la zone, on le détruit
        if (other.CompareTag("Coin") || other.CompareTag("Trash"))
            Destroy(other.gameObject);
    }
}
