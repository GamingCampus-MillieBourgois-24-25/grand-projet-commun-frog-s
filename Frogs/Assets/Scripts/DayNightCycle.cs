using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Cycle Settings")]
    public Light directionalLight;
    public float dayDuration = 120f; // Dur�e d'un cycle jour/nuit en secondes
    public Gradient lightColorOverDay; // D�finir dans l'inspecteur
    public AnimationCurve lightIntensityOverDay; // D�finir dans l'inspecteur

    private float timeOfDay = 0.5f;

    void Update()
    {
        if (directionalLight == null) return;

        // Avancer le temps
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay > 1f) timeOfDay -= 1f; 

        //tourne la lumi�re (360� sur un cycle complet)
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170f, 0f));

        //applique la couleur et l'intensit� selon l'heure
        directionalLight.color = lightColorOverDay.Evaluate(timeOfDay);
        directionalLight.intensity = lightIntensityOverDay.Evaluate(timeOfDay);
    }
}
