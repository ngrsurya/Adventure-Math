using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int jumppower;
    public bool isJump;
    public bool alreadyJump;

    public int speed;
    private float movex;
    private bool flipright;
    public bool isMove;

 

    public int jumpcounter = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
     
            PlayerMove();
        
    }


    public void PlayerMove()
    {

        if (isMove)
        {
            movex = Input.GetAxisRaw("Horizontal");

            if (movex != 0.0f)
            {
                gameObject.GetComponent<Animator>().SetBool("IsRunning", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("IsRunning", false);
            }


            if (Input.GetKeyDown(KeyCode.Space) && isJump == false)
            {
                Jump();
                gameObject.GetComponent<Animator>().SetBool("IsJump", true);
            }


            if (movex < 0.0f && flipright == false)
            {
                flip();
            }
            else if (movex > 0.0f && flipright == true)
            {
                flip();
            }
            float powerspeed = speed * 20f;


            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movex * powerspeed * Time.deltaTime, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if(!isMove)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movex * 0 * Time.deltaTime, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }

        
    }

    public void flip()
    {
        flipright = !flipright;
        Vector2 localscale = gameObject.transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
        transform.rotation = Quaternion.identity;

    }

    void Jump()
    {
        jumpcounter++;
        alreadyJump = true;
        float powerjump = jumppower * 20f;
        if (jumpcounter == 2)
        {
            powerjump += 5;
            isJump = true;
        }
        AudioManager.PlaySound("jump");
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * powerjump);
        transform.rotation = Quaternion.identity;

    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            jumpcounter = 0;
            gameObject.GetComponent<Animator>().SetBool("IsJump", false);
            isJump = false;
            alreadyJump = false;
        }

    }
    
 
  
}
