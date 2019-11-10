using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public bool isActive = true;
    public GameObject alert;
    public GameObject QuizPanel;
    public GameObject Question;
    private Player player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player") && isActive)
        {
            alert.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F) && isActive)
            {
                player.isMove = false;
                isActive = false;
                QuizPanel.SetActive(true);
                Question.SetActive(true);

            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player") && isActive)
        {
            alert.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && isActive)
            {
                player.isMove = false;
                isActive = false;
                alert.SetActive(false);
                QuizPanel.SetActive(true);
                Question.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        alert.SetActive(false);
    }


}
