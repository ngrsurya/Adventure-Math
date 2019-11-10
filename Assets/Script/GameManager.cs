using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public ScoreLevel[] scorelevel;
    public GameObject[] starLevel1;
    public GameObject[] starLevel2;

    public static GameManager instance;

    public GameObject[] finishLevelName;

    public GameObject level1finishpanel, level2finishpane, level3finishpane;
    public bool ispaused = false;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
 
    }
    
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2")
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !ispaused)
            {
                Paused();
                Debug.Log("Pause");
            }

         
        }




        checkingscene();
       if(scorelevel[0].score > 0)
        {
            if(scorelevel[0].score == 1)
            {
                starLevel1[0].SetActive(true);
                starLevel1[1].SetActive(false);
                starLevel1[2].SetActive(false);

            }
            else if (scorelevel[0].score == 2)
            {
                starLevel1[0].SetActive(true);
                starLevel1[1].SetActive(true);
                starLevel1[2].SetActive(false);

            }
            else if(scorelevel[0].score == 3)
            {
                starLevel1[0].SetActive(true);
                starLevel1[1].SetActive(true);
                starLevel1[2].SetActive(true);

            }
        }
        else
        {
            starLevel1[0].SetActive(false);
            starLevel1[1].SetActive(false);
            starLevel1[2].SetActive(false);
        }

        if (scorelevel[1].score > 0)
        {
            if (scorelevel[1].score == 1)
            {
                starLevel2[0].SetActive(true);
                starLevel2[1].SetActive(false);
                starLevel2[2].SetActive(false);

            }
            else if (scorelevel[1].score == 2)
            {
                starLevel2[0].SetActive(true);
                starLevel2[1].SetActive(true);
                starLevel2[2].SetActive(false);

            }
            else if (scorelevel[1].score == 3)
            {
                starLevel2[0].SetActive(true);
                starLevel2[1].SetActive(true);
                starLevel2[2].SetActive(true);

            }
        }
        else
        {
            starLevel2[0].SetActive(false);
            starLevel2[1].SetActive(false);
            starLevel2[2].SetActive(false);
        }
    }

    public void nextLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
        level1finishpanel.SetActive(false);
        level2finishpane.SetActive(false);
        
    }


    void checkingscene()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            finishLevelName[0].SetActive(true);
            finishLevelName[1].SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            finishLevelName[0].SetActive(false);
            finishLevelName[1].SetActive(true);
        }
    }


    void Paused()
    {
        Time.timeScale = 0;
        ispaused = true;
        pausePanel.SetActive(true);

       
    }

    public void Resume()
    {
        Time.timeScale = 1;
        ispaused = false;
        pausePanel.SetActive(false);

    }

    public void BackToMenu()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            scorelevel[0].score = 0;
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            scorelevel[1].score = 0;
        }
        pausePanel.SetActive(false);
        ispaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }
}
