using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public ScoreLevel[] scorelevel;
    public GameObject[] starLevel1;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
 
    }
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scorelevel[0].score; i++)
        {
            if(i<= scorelevel[0].maxscore)
            {
                starLevel1[i].SetActive(true);
            }
        }
    }
}
