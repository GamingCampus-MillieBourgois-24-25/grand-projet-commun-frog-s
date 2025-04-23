using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames
{
    public class LumberjackMiniGame : BaseMiniGames
    {
        [Header("Lumberjack Mini Game Settings")]
        [SerializeField] private GameObject trunk1;
        [SerializeField] private GameObject trunk2;
        [SerializeField] private GameObject trunkSpawnPos;
        [SerializeField] private GameObject leftBranchPos;
        [SerializeField] private GameObject rightBranchPos;
        [SerializeField] private GameObject branchDestroyPos;
        [SerializeField] private Sprite branchSprite;
        [SerializeField] private TextMeshProUGUI scoreText;

        [SerializeField] private float fallSpeed = 200f;

        [SerializeField] private int requiredHits;
        [SerializeField] private int currentHits = 0;

        private new void Start()
        {
            GoldMultiplier = 2f;
            base.Start();
    
            requiredHits = Random.Range(7, 16);
            scoreText.text = $"{requiredHits - currentHits}";
    
            StartCoroutine(SpawnBranches());
            StartCoroutine(ScrollTrunks());
        }


        private new void Update()
        {
            base.Update();

            if (Input.GetMouseButtonDown(0))
            {
                if (IsHittingBranch())
                {
                    Debug.Log("DEAD");
                    HasWin = false;
                    StopAllCoroutines();
                    CloseMiniGame();
                    return;
                }

                currentHits++;

                if (currentHits >= requiredHits)
                {
                    Debug.Log("WIN");
                    HasWin = true;
                    CloseMiniGame();
                }
            }
            
            scoreText.text = $"{requiredHits - currentHits}";
        }
        
        private bool IsHittingBranch()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);
    
            if (hit.collider != null && hit.collider.CompareTag("Branch"))
            {
                Debug.Log("Branch hit: " + hit.collider.name);
                return true;
            }
    
            return false;
        }
        
        private IEnumerator ScrollTrunks()
        {
            RectTransform rect1 = trunk1.GetComponent<RectTransform>();
            RectTransform rect2 = trunk2.GetComponent<RectTransform>();

            float height = rect1.rect.height;
            float screenBottom = -height;

            while (!HasWin)
            {
                Vector3 move = Vector3.down * fallSpeed * Time.deltaTime;
                rect1.anchoredPosition += (Vector2)move;
                rect2.anchoredPosition += (Vector2)move;

                if (rect1.anchoredPosition.y <= screenBottom)
                {
                    rect1.anchoredPosition = new Vector2(rect1.anchoredPosition.x, rect2.anchoredPosition.y + height);
                }

                if (rect2.anchoredPosition.y <= screenBottom)
                {
                    rect2.anchoredPosition = new Vector2(rect2.anchoredPosition.x, rect1.anchoredPosition.y + height);
                }

                yield return null;
            }
        }


        private IEnumerator SpawnBranches()
        {
            while (!HasWin)
            {
                float waitTime = Random.Range(.5f, 2f);
                yield return new WaitForSeconds(waitTime);

                bool isLeft = Random.value > 0.5f;
                GameObject spawnPoint = isLeft ? leftBranchPos : rightBranchPos;

                GameObject branch = new GameObject("Branch");
                branch.AddComponent<CanvasRenderer>();
                branch.transform.SetParent(trunk1.transform.parent, false);
                branch.transform.SetSiblingIndex(0);
                
                branch.transform.position = spawnPoint.transform.position;
                
                branch.tag = "Branch";

                var branchCollider = branch.AddComponent<BoxCollider2D>();
                branchCollider.isTrigger = true;

                var rb = branch.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0;
                rb.isKinematic = true;


                Image img = branch.AddComponent<Image>();
                img.sprite = branchSprite;
                img.SetNativeSize();

                branch.transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                
                RectTransform branchRect = branch.GetComponent<RectTransform>();
                Vector2 size = branchRect.sizeDelta * 0.4f;
                branchCollider.size = size;
                branchCollider.offset = Vector2.zero;


                if (isLeft)
                {
                    branch.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                StartCoroutine(MoveAndDestroy(branch));
            }
        }

        private IEnumerator MoveAndDestroy(GameObject branch)
        {
            RectTransform rect = branch.GetComponent<RectTransform>();

            while (rect.anchoredPosition.y > branchDestroyPos.GetComponent<RectTransform>().anchoredPosition.y)
            {
                rect.anchoredPosition += Vector2.down * fallSpeed * Time.deltaTime;
                yield return null;
            }

            Destroy(branch);
        }
    }
}
