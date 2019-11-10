using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private Player player;
    public GameObject finishPanel;
    public string finishLevelName;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {

            player.isMove = false;
            finishPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            player.isMove = false;
            finishPanel.SetActive(true);
 
        }
    }
}
