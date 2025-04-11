using UnityEngine;

public class CanvasDesactivator : MonoBehaviour
{
    [SerializeField] private GameObject canvasToDesactivate;

    public void DesactivateCanvas()
    {
        if (canvasToDesactivate != null)
        {
            canvasToDesactivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Canvas non assigné !");
        }
    }
}
