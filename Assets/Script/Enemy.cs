using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Behavior
    public float forceplayer;
    public int enemyHp;

    //Enemy Patrol
    public float speed;
    private int currentPos;
    private Transform currentpatrol;
    public Transform[] moveSpots;

    private bool flipright;

    private GameObject player;
    private Player playerscript;
    private SpriteRenderer sprite;

    //Enemy Chasingd
    public float chasingRange;
    public float triggerRange;
    private bool isChasing;
    public bool isJump;

    //flipbool
    private bool flipchasing;
    private bool flippatrol;

    // Start is called before the first frame update
   
    void Awake()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerscript = player.GetComponent<Player>();

        currentPos = 0;
        currentpatrol = moveSpots[currentPos];


        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        playerscript = player.GetComponent<Player>();
        Chasing();
        Flip();

        if (!isChasing)
        {
            flippatrol = true;
            FollowPatern();
        }
        else
        {
            Chasing();
        }



        if (enemyHp == 0)
        {
            Destroy(gameObject);
        }
    }




    void FollowPatern()
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,transform.position.y), new Vector2(moveSpots[currentPos].position.x,transform.position.y), speed * Time.deltaTime);
        flipchasing = false;
        flippatrol = true;
        if (Vector2.Distance(transform.position, currentpatrol.position) < 0.2f)
        {
            if(currentPos +1 >= moveSpots.Length)
            {
                currentPos = 0;
            }else if( currentPos <= moveSpots.Length)
            {
                currentPos++;
            }

            currentpatrol = moveSpots[currentPos];
        }
    }

    public void Chasing()
    {
        if(Vector2.Distance(player.transform.position,transform.position) < chasingRange)
        {
            if(Vector2.Distance(player.transform.position,transform.position)< triggerRange)
            {
                isChasing = true;
                flipchasing = true;
                flippatrol = false;
                Vector3 playerpos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, playerpos, speed * Time.deltaTime);

                if(player.transform.position.y > transform.position.y && isJump && playerscript.alreadyJump== false)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1850 * Time.deltaTime);
                }
            }
        }
        else
        {
            isChasing = false;
            FollowPatern();
        }
    }


        public void Flip()
        {

        if (flipchasing)
        {
            if (player.transform.position.x < transform.position.x)
            {
                sprite.flipX = true;
            }
            else if (player.transform.position.x > transform.position.x)
            {
                sprite.flipX = false;

            }
        }

        if (flippatrol)
        {
            if(transform.position.x > moveSpots[currentPos].transform.position.x)
            {
                sprite.flipX = true;
            }else if(transform.position.x < moveSpots[currentPos].transform.position.x)
            {
                sprite.flipX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Jump Point"))
        {
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isJump = false;
        }
    }
}
