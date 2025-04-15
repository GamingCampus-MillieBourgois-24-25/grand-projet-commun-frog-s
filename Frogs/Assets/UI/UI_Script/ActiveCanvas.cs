using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasActivator : MonoBehaviour
{
    public GameObject canvasToActivate; 

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
