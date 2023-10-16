using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] GameObject coin;

    public void CoinGenerate()
    {
        Instantiate(coin, transform.position, Quaternion.identity);
    }
}
