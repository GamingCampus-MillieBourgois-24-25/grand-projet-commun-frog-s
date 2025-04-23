using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject workshopUIManager;
    [SerializeField] private bool isStartedMiniGame = false;

    [Header("Player")]
    [SerializeField] private int golds;
    [SerializeField] private int diamonds;

    private void Start()
    {
        workshopUIManager.SetActive(false);        
    }

    public void StartPassiveGeneration(){
        StartCoroutine(GeneratePassiveGold());
    }

    IEnumerator GeneratePassiveGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            AddMoney(1);
        }
    }

    public void AddMoney(int addAmount)
    {
        golds += addAmount;
        FindAnyObjectByType<SaveManager>().SaveGame();
    }

    public void RemoveGolds(int removeAmount)
    {
        golds -= removeAmount;
        FindAnyObjectByType<SaveManager>().SaveGame();
    }

    public int GetGolds()
    {
        return golds;
    }

    public void SetGolds(int ammount){
        golds = ammount;
        FindAnyObjectByType<SaveManager>().SaveGame();
    }

    public void AddDiamonds(int addAmount)
    {
        diamonds += addAmount;
    }

    public void RemoveDiamonds(int removeAmount)
    {
        diamonds -= removeAmount;
    }

    public int GetDiamonds()
    {
        return diamonds;
    }

    public void SetIsStartedMiniGame(bool isStarted)
    {
        isStartedMiniGame = isStarted;
    }

    public bool GetIsStartedMiniGame()
    {
        return isStartedMiniGame;
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
