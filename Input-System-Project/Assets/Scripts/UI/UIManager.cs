using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private Transform WinContainer;
    [SerializeField] private TextMeshProUGUI collectText;
    [SerializeField] private TextMeshProUGUI collectToWinText;
    [SerializeField] private TextMeshProUGUI vitoriaDerrotaText;

    private int cherrysCollectables;
    private int numberOfCherrysToWin;
    private bool playerAlive = true;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
    }

    private void Update()
    {
        collectText.text = "CherrysCollect: " + cherrysCollectables;
        collectToWinText.text = "CherryToCollect: " + numberOfCherrysToWin;


        cherrysCollectables = PlayerMovement.instance.CheckCherrysCollectables(cherrysCollectables);
        numberOfCherrysToWin = PlayerMovement.instance.CheckNumberOfCherrysToWin(numberOfCherrysToWin);
        if (cherrysCollectables >= numberOfCherrysToWin)
        {
            WinContainer.gameObject.SetActive(true);
        }
        else if (playerAlive == false)
        {
            vitoriaDerrotaText.text = "Derrota";
            WinContainer.gameObject.SetActive(true);
        }
        else
        {
            WinContainer.gameObject.SetActive(false);
        }
    }

    public bool CheckPlayerAlive(bool isAlive)
    {
        playerAlive = isAlive;
        return playerAlive;
    }

}
