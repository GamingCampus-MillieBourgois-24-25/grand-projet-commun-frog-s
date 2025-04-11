using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // R�f�rence � votre canvas de menu � d�sactiver/r�activer
    public Canvas menuCanvas;
    // Pour g�rer la transparence et l'interactivit� pendant le drag
    private CanvasGroup canvasGroup;
    // Sauvegarde de la position initiale de l'objet
    private Vector3 initialPosition;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // D�clench� au d�but du drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;
        // Rendre l'objet semi-transparent pendant le drag (optionnel)
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }

        // D�sactiver le menu pendant le drag pour �viter d'interf�rer avec le drop
        if (menuCanvas != null)
        {
            menuCanvas.gameObject.SetActive(false);
        }
    }

    // Mise � jour de la position pendant le drag
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; // Fonctionne aussi pour le toucher sur mobile
    }

    // Logique ex�cut�e � la fin du drag
    public void OnEndDrag(PointerEventData eventData)
    {
        // V�rification de la validit� du drop
        if (!IsValidDrop(eventData))
        {
            // Si le drop n'est pas valide, remettre l'objet � sa position initiale
            transform.position = initialPosition;
            // R�activer le menu
            if (menuCanvas != null)
            {
                menuCanvas.gameObject.SetActive(true);
            }
        }
        else
        {
            // Traitement sp�cifique pour un drop valide (p. ex. placer d�finitivement le b�timent)
            // Vous pouvez conserver le canvas d�sactiv� ou appliquer une autre logique ici
        }

        // Restaurer la transparence et la possibilit� de raycast
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }

    // M�thode de validation du drop
    private bool IsValidDrop(PointerEventData eventData)
    {
        // Exemple d'utilisation d'un raycast pour v�rifier si on touche une zone de drop valide
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Supposons que votre zone valide poss�de le tag "ValidDropZone"
            if (hit.collider.CompareTag("ValidDropZone"))
            {
                return true;
            }
        }
        return false;
    }
}
