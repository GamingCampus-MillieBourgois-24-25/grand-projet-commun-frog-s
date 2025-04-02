using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Building : MonoBehaviour
{
    public BuildingType buildingType;
    public bool RessourcesReady = true;
    public int resourceAmount = 10; // Exemple

    private bool isSelected = false;

    public void OnClicked()
    {
        if (RessourcesReady)
        {
            CollectResources();
        }
        else
        {
            OpenRadialMenu();
        }
    }

    private void CollectResources()
    {
        Debug.Log($"Collected {resourceAmount} from {buildingType}");
        RessourcesReady = false;

        // Tu peux ajouter ici : ajouter à ton compteur global de ressources
        // ResourceManager.Instance.Add(resourceAmount);

        // Ajoute feedback visuel si besoin (ex: effet de particule ou son)
    }

    private void OpenRadialMenu()
    {
        Debug.Log($"Open radial menu for {buildingType}");

        // Appelle le gestionnaire du menu radial
        RadialMenuManager.Instance.ShowMenu(this);
    }
}
