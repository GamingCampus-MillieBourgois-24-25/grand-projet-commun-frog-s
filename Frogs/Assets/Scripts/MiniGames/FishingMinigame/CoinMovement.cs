using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [Tooltip("Vitesse de chute en pixels/s")]
    public float fallSpeed = 200f;

    private RectTransform rt;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Descente continue
        Vector2 pos = rt.anchoredPosition;
        pos.y -= fallSpeed * Time.deltaTime;
        rt.anchoredPosition = pos;
    }
}
