using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class HookDragHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    RectTransform rect;
    RectTransform canvasRect;
    Canvas canvas;
    bool isDragging;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("HookDragHandler : pas de Canvas parent trouvé.");
            enabled = false;
            return;
        }
        canvasRect = canvas.transform as RectTransform;
    }

    public void OnPointerDown(PointerEventData data)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData data)
    {
        isDragging = false;
    }

    public void OnDrag(PointerEventData data)
    {
        if (!isDragging) return;

        Vector2 pos;
        Camera cam = (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            ? null
            : data.pressEventCamera;

        // Convertit la position écran en position locale du Canvas
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                data.position,
                cam,
                out pos))
        {
            // Calcul des demi-tailles
            Vector2 halfCanvas = canvasRect.rect.size * 0.5f;
            Vector2 halfHook = rect.rect.size * 0.5f;

            // Clamp X et Y pour rester dans le Canvas
            pos.x = Mathf.Clamp(pos.x, -halfCanvas.x + halfHook.x, halfCanvas.x - halfHook.x);
            pos.y = Mathf.Clamp(pos.y, -halfCanvas.y + halfHook.y, halfCanvas.y - halfHook.y);

            rect.anchoredPosition = pos;
        }
    }
}
