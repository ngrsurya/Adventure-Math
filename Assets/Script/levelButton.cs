using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelButton : MonoBehaviour
{

    public GameObject[] star;
    public int level;
    public string leveltoLoad;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < star.Length; i++)
        {
            star[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GameManager.instance.scorelevel[level].score; i++)
        {
            if (i <= star.Length)
            {
                star[i].SetActive(true);
            }
        }
    }
    public void pressed()
    {
        SceneManager.LoadScene(leveltoLoad);

        GameManager.instance.scorelevel[level].score = 0;
    }

   
}
