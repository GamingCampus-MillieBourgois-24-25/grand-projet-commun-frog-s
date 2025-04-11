using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Référence à votre canvas de menu à désactiver/réactiver
    public Canvas menuCanvas;
    // Pour gérer la transparence et l'interactivité pendant le drag
    private CanvasGroup canvasGroup;
    // Sauvegarde de la position initiale de l'objet
    private Vector3 initialPosition;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Déclenché au début du drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;
        // Rendre l'objet semi-transparent pendant le drag (optionnel)
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        // Désactiver le menu pendant le drag pour éviter d'interférer avec le drop
        if (menuCanvas != null)
        {
            menuCanvas.gameObject.SetActive(false);
        }
    }

    // Mise à jour de la position pendant le drag
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; // Fonctionne aussi pour le toucher sur mobile
    }

    // Logique exécutée à la fin du drag
    public void OnEndDrag(PointerEventData eventData)
    {
        // Vérification de la validité du drop
        if (!IsValidDrop(eventData))
        {
            // Si le drop n'est pas valide, remettre l'objet à sa position initiale
            transform.position = initialPosition;
            // Réactiver le menu
            if (menuCanvas != null)
            {
                menuCanvas.gameObject.SetActive(true);
            }
        }
        else
        {
            // Traitement spécifique pour un drop valide (p. ex. placer définitivement le bâtiment)
            // Vous pouvez conserver le canvas désactivé ou appliquer une autre logique ici
        }

        // Restaurer la transparence et la possibilité de raycast
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }

    // Méthode de validation du drop
    private bool IsValidDrop(PointerEventData eventData)
    {
        // Exemple d'utilisation d'un raycast pour vérifier si on touche une zone de drop valide
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Supposons que votre zone valide possède le tag "ValidDropZone"
            if (hit.collider.CompareTag("ValidDropZone"))
            {
                return true;
            }
        }
        return false;
    }
}
