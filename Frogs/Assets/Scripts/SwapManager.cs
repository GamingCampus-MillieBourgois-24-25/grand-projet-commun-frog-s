using UnityEngine;
using Workshop;

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

        BaseWorkshop firstWorkshop = firstSelected.GetComponentInChildren<BaseWorkshop>();
        BaseWorkshop secondWorkshop = secondSelected.GetComponentInChildren<BaseWorkshop>();

        if (firstWorkshop != null)
        {
            firstWorkshop.transform.SetParent(secondSelected.transform);
            firstWorkshop.transform.localPosition = Vector3.zero;
        }

        if (secondWorkshop != null)
        {
            secondWorkshop.transform.SetParent(firstSelected.transform);
            secondWorkshop.transform.localPosition = Vector3.zero;
        }

        Debug.Log("Swap effectué entre " + firstSelected.name + " et " + secondSelected.name);

        isSwapping = false;
        firstSelected = null;
    }



    public bool IsSwapping()
    {
        return isSwapping;
    }
}
