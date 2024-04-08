using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score = 0;
    public GameObject endGamePanel;
    public GameObject startGamePanel;
    public GameObject winGamePanel;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

    }
    
    
    public void Start()
    {
        endGamePanel.SetActive(false);
        //startGamePanel.SetActive(true);
        winGamePanel.SetActive(false);
    }

    public void EndGame()
    {
        endGamePanel.SetActive(true);
    }

}
