using UnityEngine;
using UnityEngine.EventSystems;


public class CameraController : MonoBehaviour
{
    [Header("Pan Settings")]
    public float dragSpeed = 0.15f;
    public float zoomSpeedTouch = 0.01f;
    public float zoomSpeedMouse = 50f;

    [Header("Zoom Limits")]
    public float minZoom = 60f;
    public float maxZoom = 130f;

    private Camera cam;
    private Vector2 lastPanPosition;
    private int panFingerId;
    private bool isPanning;

    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseInput();
#else
        HandleTouchInput();
#endif
    }

    // Input PC / Éditeur
    void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPanPosition = Input.mousePosition;
            isPanning = true;

            TryInteract(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0) && isPanning)
        {
            Vector2 delta = (Vector2)Input.mousePosition - lastPanPosition;
            PanCamera(delta);
            lastPanPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPanning = false;
        }

        float scroll = -Input.GetAxis("Mouse ScrollWheel");
        ZoomCamera(scroll * zoomSpeedMouse);
    }

    // 📱 Input Mobile
    void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastPanPosition = touch.position;
                panFingerId = touch.fingerId;
                isPanning = true;

                TryInteract(touch.position);
            }
            else if (touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved && isPanning)
            {
                Vector2 delta = touch.position - lastPanPosition;
                PanCamera(delta);
                lastPanPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isPanning = false;
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 prevTouch1 = touch1.position - touch1.deltaPosition;
            Vector2 prevTouch2 = touch2.position - touch2.deltaPosition;

            float prevDistance = (prevTouch1 - prevTouch2).magnitude;
            float currentDistance = (touch1.position - touch2.position).magnitude;

            float deltaDistance = prevDistance - currentDistance;
            ZoomCamera(deltaDistance * zoomSpeedTouch);
        }
    }
    void TryInteract(Vector2 screenPos)
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            // On clique sur un bouton UI → ne rien faire
            return;
        }

        Ray ray = cam.ScreenPointToRay(screenPos);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            Debug.Log("Interacted with: " + hit.collider.name);

            // Exemple : appeler une fonction sur le bâtiment cliqué
            hit.collider.SendMessage("OnClicked", SendMessageOptions.DontRequireReceiver);
        }
    }

    void PanCamera(Vector2 delta)
    {
        Vector3 move = new Vector3(-delta.x, 0,-delta.y) * dragSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);
    }



    // void ZoomCamera(float delta)
    // {
    //     float newSize = cam.orthographic ? cam.orthographicSize + delta : cam.transform.position.y + delta;

    //     newSize = Mathf.Clamp(newSize, minZoom, maxZoom);

    //     if (cam.orthographic)
    //     {
    //         cam.orthographicSize = newSize;
    //     }
    //     else
    //     {
    //         Vector3 camPos = cam.transform.position;
    //         camPos.y = newSize;
    //         cam.transform.position = camPos;
    //     }
    // }

    void ZoomCamera(float delta)
{
    float newFOV = cam.fieldOfView + delta;

    // Limiter la valeur du FOV dans une plage spécifiée
    newFOV = Mathf.Clamp(newFOV, minZoom, maxZoom);

    // Appliquer le nouveau FOV à la caméra
    cam.fieldOfView = newFOV;
}

}
