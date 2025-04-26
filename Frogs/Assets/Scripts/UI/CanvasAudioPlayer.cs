using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnEnable : MonoBehaviour
{
    AudioSource _audio;

    void Awake()
    {
        // Récupère l’AudioSource attachée au même GameObject
        _audio = GetComponent<AudioSource>();
        // Sécurité : ne pas jouer tout seul au chargement
        _audio.playOnAwake = true;
    }

 
}
