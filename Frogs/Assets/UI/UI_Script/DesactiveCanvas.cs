using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasDesactivator : MonoBehaviour
{
    public GameObject canvasToDesactivate;

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
