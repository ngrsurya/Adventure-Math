using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHitBox : MonoBehaviour
{
    public Enemy enemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.enemyHp -= 1;
            float forcepower = enemy.forceplayer * 20;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcepower);
         
        }

        if(other.gameObject.tag == "Ground")
        {
            enemy.isJump = false;
        }
    }
}
