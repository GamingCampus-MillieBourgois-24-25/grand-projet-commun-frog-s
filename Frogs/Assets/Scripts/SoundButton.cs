using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public AudioClip clickSound;
    public float volume = 1f;

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position, volume);
        }
    }
}
