using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public int value;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            CoinCount coin = other.gameObject.GetComponent<CoinCount>();
            ScoreManager.setScore((int)coin.value);
        }
    }
}
