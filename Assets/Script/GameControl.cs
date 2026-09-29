using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    float time =0;
    float wallGap;
    bool betweenRound =false;

    float round;
    public float roundNumber;

    int movingWall =0;


    float countRound3 = -4f;

    public GameObject building;

    GameObject Player;

    public GameObject round1Goal;
    public GameObject round2Goal;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");    //to check player is alive
        wallGap = 2f;
        round = 3f;       //#of wall to end round
        roundNumber = 1;

    }



    // Update is called once per frame
    void Update()
    {
        if(Player.GetComponent<MainCharacterControl>().isAlive)     //stop everything if player die
        {
            //count time
            time += Time.deltaTime;

        }
        
        if(time >= wallGap)
        {
            //reset time
            time -= wallGap;

            //count how many walls to end the round
            round--;
            if (round !=0)
            {
                //activate the wall if round didn't end
                GameObject newWall = GetComponent<ObjectPool>().Get(); // generate wall after certain time
                //random y of wall
                float y = Random.Range(-4f, 2f);
                newWall.transform.position = new Vector3(10, y, 0);

                if(roundNumber == 2)
                {
                    movingWall ++;
                }

                if(movingWall >= 3 && roundNumber == 2)
                {
                    //when will moving wall spawn again
                    movingWall = Random.Range(0,3);
                    

                    //speed
                    float movingWallSpeed = Random.Range(0,2);
           
                    newWall.GetComponent<Rigidbody2D>().linearVelocityY = (movingWallSpeed - 0.5f) * 2f ;
                    
                }

                if (roundNumber == 4)
                {

                    countRound3 = 20-round;
                    
                    
                    newWall.transform.position = new Vector3(10, countRound3, 0);
                    if(newWall.transform.position.y > 2f)
                    {
                        
                        newWall.transform.position = new Vector3(10, 4f - countRound3, 0);
                        newWall.GetComponent<Rigidbody2D>().linearVelocityY = 0;
                    }
                    if (newWall.transform.position.y < -4f)
                    {

                        newWall.transform.position = new Vector3(10, -12 + countRound3, 0);
                        newWall.GetComponent<Rigidbody2D>().linearVelocityY = 0;
                    }

                }


                if (betweenRound)
                {
                    if(roundNumber == 2)
                    {
                        wallGap = 1.5f;
                        
                    }

                    if(roundNumber == 4)
                    {
                        
                        wallGap = 0.3f;
                        
                    }
                    
                    betweenRound = false;
                }

            }

            if(round == 1)
            {
                wallGap = 5;
            }


        
        }


        



        if(round == 0)
        {
            betweenRound = true;

            roundNumber++;
            if (roundNumber == 2)
            {
                round = 3;
            }
            if (roundNumber == 3)
            {
                
                round = 2;

            }
            if (roundNumber == 4)
            {
                round = 20;

            }




            if (roundNumber != 4)
            {
                //spawn building
                building.SetActive(true);
                float y = Random.Range(-11.2f, -5f);    //random y
                building.transform.position = new Vector3(10,y,0);

                switch (roundNumber)
                {

                    case 2: 
                        round1Goal.SetActive(true);
                        round2Goal.SetActive(false);
                        break;

                    case 3:
                        round1Goal.SetActive(false);
                        round2Goal.SetActive(true);
                        break;

                }

            }

        }

        
    }


    
   

   


}
