using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameManager gM;
    [SerializeField] Text coinText;
    [SerializeField] Text lvUpText;

    private void Start()
    {
        gM = GameManager.instance;
    }

    //所持コインのテキストアップデート
    public void CoinTextUpdate(long coin)
    {
        coinText.text = string.Format("{0:C0}", coin);
        lvUpText.text = string.Format("LvUPCost => {0:C0}",gM.lvUpCost);
    }

    public void LvUPButton()
    {
        gM.LevelUp();
    }
}