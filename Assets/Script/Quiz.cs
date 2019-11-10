using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{

    public int level;
    public GameObject quizPanel;
    public GameObject quizQuestion;
    private Player player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }


    public void pressed(int score)
    {
        player.isMove = true;
        GameManager.instance.scorelevel[level].score += score;
        quizPanel.SetActive(false);
        quizQuestion.SetActive(false);
    }
}

