using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyAttack : MonoBehaviour
{

    public int currentlevel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.instance.scorelevel[currentlevel].score = 0;

        }
    }
}
