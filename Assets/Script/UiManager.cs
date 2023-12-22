using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public float maxHeart = 3f;
    public float heart = 3f;
    public static Action php;
    PlayerMove playermove;
    [SerializeField]
    private Slider playerhp;


    public GameObject gameoverPanel;
    void Awake()
    {
        php = () =>
        {
            CanDamage(); HandleHp();
        };

    }

    private void Start()
    {
        playermove = GetComponent<PlayerMove>();
        HandleHp();
        gameoverPanel.SetActive(false);
    }
    private void Update()
    {

    }
    private void HandleHp()
    {
        playerhp.value = (float)heart / (float)maxHeart;
    }
    private void CanDamage()
    {
        heart -= 1f;
    }
}
