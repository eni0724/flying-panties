using UnityEngine;
public class MainCharacterControl : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D playerRigid;
    public GameObject GameController;
    bool jumpable = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame

    
    public bool isAlive = true;
    
    void Update()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isAlive && jumpable)
        {
            
            
            playerRigid.linearVelocityY = 0f;

            playerRigid.AddForceY(jumpForce,ForceMode2D.Impulse);
            
        }


    }



    //collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            playerRigid.gravityScale = 0f;
            playerRigid.linearVelocityY = 0f;
            
            isAlive = false;


        }


        if (collision.tag == "Goal")
        {
            playerRigid.gravityScale = 0f;
            playerRigid.linearVelocityY = 0f;

            jumpable = false;


        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            playerRigid.gravityScale = 1.5f;
            playerRigid.linearVelocityY = 0f;
            jumpable = true;


            if (GameController.GetComponent<GameControl>().roundNumber == 3)
            {
                GetComponent<MainCharacterControl>().jumpForce = 4f;
            }


        }
    }




}
