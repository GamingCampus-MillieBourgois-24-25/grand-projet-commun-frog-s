using UnityEngine;

public class SwapManager : MonoBehaviour
{
    public static SwapManager Instance { get; private set; }

    private PlacementPreset firstSelected;
    private bool isSwapping = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void StartSwap(PlacementPreset selected)
    {
        if (isSwapping)
        {
            Debug.LogWarning("Déjà en train de swap !");
            return;
        }

        firstSelected = selected;
        isSwapping = true;

        Debug.Log("Mode Swap activé : sélectionne un deuxième bâtiment.");
    }

    public void TrySwap(PlacementPreset secondSelected)
    {
        if (!isSwapping || firstSelected == null || secondSelected == null || firstSelected == secondSelected)
            return;

        // Sauvegarder les infos du premier
        Vector3 firstPos = firstSelected.transform.position;
        Quaternion firstRot = firstSelected.transform.rotation;
        Transform firstParent = firstSelected.transform.parent;

        // Swap position / rotation / parent
        firstSelected.transform.position = secondSelected.transform.position;
        firstSelected.transform.rotation = secondSelected.transform.rotation;
        firstSelected.transform.parent = secondSelected.transform.parent;

        secondSelected.transform.position = firstPos;
        secondSelected.transform.rotation = firstRot;
        secondSelected.transform.parent = firstParent;

        Debug.Log("Bâtiments échangés !");

        // Fin du swap
        isSwapping = false;
        firstSelected = null;
    }

    public bool IsSwapping()
    {
        return isSwapping;
    }
}
