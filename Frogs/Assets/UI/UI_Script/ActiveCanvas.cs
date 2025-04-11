using UnityEngine;

public class CanvasActivator : MonoBehaviour
{
    [SerializeField] private GameObject canvasToActivate; 

    public void ActivateCanvas()
    {
        if (canvasToActivate != null)
        {
            canvasToActivate.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Canvas non assigné !");
        }
    }
}
