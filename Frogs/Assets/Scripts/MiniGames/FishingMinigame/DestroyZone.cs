using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // D�s qu�un Coin ou un Trash entre dans la zone, on le d�truit
        if (other.CompareTag("Coin") || other.CompareTag("Trash"))
            Destroy(other.gameObject);
    }
}
