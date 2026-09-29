using UnityEngine;


public class WallControl : MonoBehaviour
{
    public Rigidbody2D wallRigid;

    public float wallSpeed = 1;
    GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //load Player
        Player = GameObject.FindGameObjectWithTag("Player");
        

        

    }

    // Update is called once per frame  
    void Update()
    {
        //move wall
        wallRigid.linearVelocityX = -wallSpeed;

        //stop walls if player die.
        if (!Player.GetComponent<MainCharacterControl>().isAlive)
        {
            wallRigid.linearVelocityX = 0;
        }
        
        //inactivate wall
        if(GetComponent<Transform>().position.x <= -10f)
        {
            gameObject.SetActive(false);

        }

        
        if(GetComponent<Transform>().position.y >= 2.1f)
        {
            wallRigid.linearVelocityY = -1f;
        }
        if (GetComponent<Transform>().position.y <= -4.1f)
        {
            wallRigid.linearVelocityY = 1f;
        }

    }
}
