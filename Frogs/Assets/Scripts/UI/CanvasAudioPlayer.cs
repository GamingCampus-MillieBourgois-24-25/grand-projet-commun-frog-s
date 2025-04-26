using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnEnable : MonoBehaviour
{
    AudioSource _audio;

    void Awake()
    {
        // R�cup�re l�AudioSource attach�e au m�me GameObject
        _audio = GetComponent<AudioSource>();
        // S�curit� : ne pas jouer tout seul au chargement
        _audio.playOnAwake = true;
    }

 
}
