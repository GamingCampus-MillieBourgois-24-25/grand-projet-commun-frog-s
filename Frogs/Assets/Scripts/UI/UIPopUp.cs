using UnityEngine;
using UnityEngine.EventSystems;

public class UIPopUp2D : MonoBehaviour
{
    [Tooltip("Le Canvas World Space à afficher/masquer.")]
    public Canvas targetCanvas;

    [Tooltip("Si vrai, le Canvas démarre masqué.")]
    public bool startHidden = true;

    private Camera cam;

    void Start()
    {
        if (targetCanvas == null)
        {
            Debug.LogError("UIPopUp2D : aucun Canvas assigné.");
            enabled = false;
            return;
        }

        // Masquer ou afficher selon startHidden
        targetCanvas.gameObject.SetActive(!startHidden);

        cam = Camera.main;
        if (cam == null)
            Debug.LogWarning("UIPopUp2D : pas de MainCamera taguée.");
    }

    void Update()
    {
        // souris (éditeur/WebGL)  
#if UNITY_EDITOR || UNITY_WEBGL
        if (Input.GetMouseButtonDown(0))
            TryInteract(Input.mousePosition);
#endif

        // touches (mobile)
        if (Input.touchCount > 0)
        {
            var t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
                TryInteract(t.position);
        }
    }

    void TryInteract(Vector2 screenPos)
    {
        // 1) Si on clique sur une UI (overlay ou World Space), on ignore  
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;

        // 2) Raycast 2D  
        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            // Si c'est notre objet, on ouvre le pop-up
            if (hit.collider.gameObject == gameObject)
            {
                targetCanvas.gameObject.SetActive(true);
                return;
            }
        }

        // 3) Sinon : on ferme (si c'est déjà ouvert)
        if (targetCanvas.gameObject.activeSelf)
            targetCanvas.gameObject.SetActive(false);
    }
}
