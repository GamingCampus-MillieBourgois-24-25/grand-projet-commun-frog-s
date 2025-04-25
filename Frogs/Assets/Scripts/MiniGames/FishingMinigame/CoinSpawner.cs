using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour
{
    [Tooltip("Prefab UI de la pièce (avec CoinMovement).")]
    public GameObject coinPrefab;

    [Tooltip("Prefab UI du déchet (avec CoinMovement).")]
    public GameObject trashPrefab;

    [Tooltip("Probabilité de spawn d’un déchet [0–1].")]
    [Range(0f, 1f)]
    public float trashSpawnChance = 0.2f;

    [Tooltip("RectTransform du Canvas (le parent).")]
    public RectTransform canvasRect;

    [Tooltip("Temps entre deux spawns (s).")]
    public float spawnInterval = 0.5f;

    private float xMin, xMax, spawnY;

    void Start()
    {
        float halfW = canvasRect.rect.width * 0.5f;
        xMin = -halfW;
        xMax = halfW;
        float itemH = coinPrefab.GetComponent<RectTransform>().rect.height;
        spawnY = canvasRect.rect.height * 0.5f + itemH * 0.5f;

        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnOne();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnOne()
    {
        // Choix aléatoire coin vs trash
        GameObject prefab = (Random.value < trashSpawnChance)
                             ? trashPrefab
                             : coinPrefab;

        // Instanciation sous le Canvas, coordonnées locales
        var go = Instantiate(prefab, canvasRect, worldPositionStays: false);
        var rt = go.GetComponent<RectTransform>();
        float randX = Random.Range(xMin, xMax);
        rt.anchoredPosition = new Vector2(randX, spawnY);
    }
}
