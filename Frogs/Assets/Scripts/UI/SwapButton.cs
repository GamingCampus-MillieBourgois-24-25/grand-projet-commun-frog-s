using UnityEngine;

public class SwapButton : MonoBehaviour
{
    public void OnSwapButtonClicked()
    {
        PlacementPreset preset = GetComponentInParent<PlacementPreset>();
        if (preset != null)
        {
            SwapManager.Instance.StartSwap(preset);
        }
        else
        {
            Debug.LogWarning("PlacementPreset non trouvé en parent !");
        }
    }
}
