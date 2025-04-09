using NUnit.Framework.Constraints;
using System.Collections;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int Money = 1;

    [Header("UI")]
    [SerializeField] private GameObject workshopUIManager;
    [SerializeField] private bool isStartedMiniGame = false;


    [Header("Stats")]
    [SerializeField] private float goldMultiplayer = 1f;
    [SerializeField] private float goldTimerMultiplayer = 5f;

    private Coroutine goldMultiplierCoroutine;

    private void Start()
    {
        workshopUIManager.SetActive(false);
    }

    public void AddMoney(int addAmount)
    {
        Money += (int)(addAmount * goldMultiplayer);
        Debug.Log(Money);
    }

    public void RemoveMoney(int removeAmount)
    {
        Money -= removeAmount;
    }

    public void SetGoldMultiplayer(float multiplayer)
    {
        goldMultiplayer = multiplayer;

        if (goldMultiplierCoroutine != null)
            StopCoroutine(goldMultiplierCoroutine);

        goldMultiplierCoroutine = StartCoroutine(ResetGoldMultiplierAfterDelay(goldTimerMultiplayer));
    }

    private IEnumerator ResetGoldMultiplierAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        goldMultiplayer = 1f;
    }

    public float GetGoldMultiplayer()
    {
        return goldMultiplayer;
    }
    
    public void SetIsStartedMiniGame(bool isStarted)
    {
        isStartedMiniGame = isStarted;
    }
    
    public bool GetIsStartedMiniGame()
    {
        return isStartedMiniGame;
    }

    public int GetMoney()
    {
        return Money;
    }

    public WorkshopUIManager GetWorkshopUIManger()
    {
        return workshopUIManager.GetComponent<WorkshopUIManager>();
    }

    public void ShowWorkshopUI_Manager()
    {
        workshopUIManager.SetActive(true);
    }

    public void HideWorkshopUI_Manager()
    {
        workshopUIManager.SetActive(false);
    }
}
