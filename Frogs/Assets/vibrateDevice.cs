using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateDevice : MonoBehaviour
{
    public void OnClickVibrate()
    {
        if (SettingsManager.isVibrate)
        {
            Handheld.Vibrate();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
