using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public long wallet = 0;
    public long coinPerClick = 1;
    public long lvUpCost = 10;

    [SerializeField] UIManager uiManager;

    #region    //Singlton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    void Update()
    {
        uiManager.CoinTextUpdate(wallet);
    }

    public void LevelUp()
    {
        if (wallet >= lvUpCost)
        {
            wallet -= lvUpCost;
            coinPerClick *= 2;
            lvUpCost *= 4;
        }
    }

    public void GetCoin()
    {
        wallet += 1 * coinPerClick;
    }
}
