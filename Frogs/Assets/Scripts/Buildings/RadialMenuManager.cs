using UnityEngine;

public class RadialMenuManager : MonoBehaviour
{
    public static RadialMenuManager Instance;
    public GameObject radialMenuPrefab;

    private GameObject currentMenu;

    void Awake()
    {
        Instance = this;
    }

    public void ShowMenu(Building building)
    {
        // Si un menu est déjà ouvert, le fermer
        if (currentMenu != null)
            Destroy(currentMenu);

        // Calculer la position en monde
        Vector3 position = building.transform.position;

        currentMenu = Instantiate(radialMenuPrefab, position, Quaternion.identity, transform);

        // Tu peux passer des infos au menu si besoin
        // currentMenu.GetComponent<RadialMenu>().Setup(building);
    }
}
