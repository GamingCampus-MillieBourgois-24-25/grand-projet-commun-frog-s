using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames
{
    public class LumberjackMiniGame : BaseMiniGames
    {
        [Header("Lumberjack Mini Game Settings")]
        [SerializeField] private GameObject miniGameObject;
        [SerializeField] private GameObject startMenu;
        [SerializeField] private GameObject endMenu;
        [SerializeField] private GameObject trunk1;
        [SerializeField] private GameObject trunk2;
        [SerializeField] private GameObject trunkSpawnPos;
        [SerializeField] private GameObject leftBranchPos;
        [SerializeField] private GameObject rightBranchPos;
        [SerializeField] private GameObject branchDestroyPos;
        [SerializeField] private Sprite branchSprite;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI endText;

        [SerializeField] private float fallSpeed = 250f;

        [SerializeField] private int requiredHits;
        [SerializeField] private int currentHits = 0;

        private bool _miniGameStarted = false;
        private bool _canClick = true;

        private new void Start()
        {
            GoldMultiplier = 2f;
            base.Start();
            startMenu.SetActive(true);
            endMenu.SetActive(false);
            miniGameObject.SetActive(false);
        }

        private new void Update()
        {
            base.Update();

            if (!_miniGameStarted) return;
            
            if (Input.GetMouseButtonDown(0) && _canClick)
            {
                StartCoroutine(HandleClick());
            }

            scoreText.text = $"{requiredHits - currentHits}";
        }
        
        private void HitBranch()
        {
            HasWin = false;
            HasClosedMiniGame = false;
            ShowEndMenu(false);
        }
        
        public void StartMiniGame()
        {
            startMenu.SetActive(false);
            endMenu.SetActive(false);
            miniGameObject.SetActive(true);
            HasWin = false;
            HasClosedMiniGame = false;
            _miniGameStarted = true;
            requiredHits = Random.Range(7, 16);
            scoreText.text = $"{requiredHits - currentHits}";
            
            StartCoroutine(SpawnBranches());
            StartCoroutine(ScrollTrunks());
        }
        
        private void ShowEndMenu(bool hasWon)
        {
            endMenu.SetActive(true);
            miniGameObject.SetActive(false);
            _miniGameStarted = false;
            HasWin = hasWon;
            
            endText.text = hasWon ? "You won!" : "You lost!";
            
            StopAllCoroutines();
        }
        
        private IEnumerator HandleClick()
        {
            _canClick = false;

            currentHits++;

            if (currentHits >= requiredHits)
            {
                ShowEndMenu(true);
            }

            scoreText.text = $"{requiredHits - currentHits}";

            yield return new WaitForSeconds(1f);
            _canClick = true;
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
                
                var rb = branch.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0;
                rb.isKinematic = true;

                Image img = branch.AddComponent<Image>();
                img.sprite = branchSprite;
                img.rectTransform.sizeDelta = new Vector2(100f, 100f);
                img.SetNativeSize();

                branch.transform.localScale = new Vector3(0.4f, 0.4f, 1f);

                var button = branch.AddComponent<Button>();
                var thisGame = this;
                button.onClick.AddListener(() => thisGame.HitBranch());
                
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
