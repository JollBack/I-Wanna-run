using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public GameObject gameoverPanel;

    public void NextStage()
    {
        stageIndex++;

        totalPoint += stagePoint;
        stagePoint = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            health--;

        collision.attachedRigidbody.velocity = Vector2.zero;
        collision.transform.position = new Vector3(0, 0, -1);
        UiManager.php();
    }

    void Update()
    {
        if (health == 0)
        {
            GameObject.Find("Canvas").transform.Find("Panel_GameOver").gameObject.SetActive(true);
            PlayerMove.ps();
        }
    }
}
