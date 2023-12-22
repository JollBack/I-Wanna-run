using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{

    [Header("Source")]
    public GameObject tilePrefab;
    public Transform backgroundNode;
    public Transform boardNode;
    public Transform tetrominoNode;
    public GameObject gameoverPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
