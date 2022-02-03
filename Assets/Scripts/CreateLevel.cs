using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    public GameObject[] player;
    public GameObject way;
    public GameObject[] coins;
    public GameObject[] walls;
    public GameObject[] elements;
    public GameObject mt,end;
    public int mCount, mRate;
    public int levelLength, totalWall, wallSpace, onePiece,twoPieces, threePieces1, threePieces2, fourPieces, fourPieces1;
    public int coinx3, coinx5, coinx7, coinx10;
    int i,c,rot, angle, type;
    bool stop;


    private void Start()
    {
        for (int i = 0; i < levelLength*2; i += Random.Range(8, 18))
        {
            Instantiate(elements[Random.Range(0, 3)], new Vector3(Random.Range(-20, -5), 0f, i), Quaternion.identity);
        }
        for (int i = 0; i < levelLength*2; i += Random.Range(25, 35))
        {
            Instantiate(elements[3], new Vector3(Random.Range(-30, 20), Random.Range(8, 18), i), Quaternion.Euler(0, Random.Range(60, 80), 0));
        }


        GameObject wayScaled = Instantiate(way, new Vector3(0,-2.1f, levelLength / 2+wallSpace), Quaternion.identity); //WayScale
        wayScaled.transform.localScale = new Vector3(1, 1, (levelLength / 10)+5);
        choosePlayer(); // Calling player Class
        i = wallSpace;
        do
        {
            if (i==levelLength)
            {
                stop = true;
                i+=wallSpace;
            }
            else if (i % wallSpace == 0 && !stop)
            {
                rot = Random.Range(0, 6);
                switch (rot)
                {
                    case 1:
                        angle = 0;
                        break;
                    case 2:
                        angle = 90;
                        break;
                    case 3:
                        angle = 180;
                        break;
                    case 4:
                        angle = 270;
                        break;
                }
                type = Random.Range(0, 7);


                if (onePiece > 0 && type == 0)
                {
                    Instantiate(walls[0], new Vector3(0, 0, i), Quaternion.Euler(0, 0, angle));
                    onePiece--;
                    totalWall--;
                    i += wallSpace;
                }

                if (twoPieces > 0 && type == 1)
                {
                    Instantiate(walls[1], new Vector3(0, 0, i), Quaternion.Euler(0, 0, angle));
                    twoPieces -= 1;
                    totalWall--;
                    i += wallSpace;
                }

                if (threePieces1 > 0 && type == 2)
                {
                    Instantiate(walls[2], new Vector3(0, 0, i), Quaternion.Euler(0, 0, angle));
                    threePieces1 -= 1;
                    totalWall--;
                    i += wallSpace;
                }

                if (threePieces2 > 0 && type == 6)
                {
                    Instantiate(walls[3], new Vector3(0, 0, i), Quaternion.Euler(0, 0, angle));
                    threePieces2 -= 1;
                    totalWall--;
                    i += wallSpace;
                }

                if (fourPieces > 0 && type == 4)
                {
                    Instantiate(walls[4], new Vector3(0, 0, i), Quaternion.Euler(0, 0, angle));
                    fourPieces -= 1;
                    totalWall--;
                    i += wallSpace;
                }

                if (fourPieces1 > 0 && type == 5)
                {
                    Instantiate(walls[5], new Vector3(0, 0, i), Quaternion.Euler(0, 0, angle));
                    fourPieces1 -= 1;
                    totalWall--;
                    i += wallSpace;
                }

                if (type==3)
                {
                    type = Random.Range(0, 4);
                    if (coinx3 > 0 && type == 0)
                    {
                        Instantiate(coins[0], new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), i), Quaternion.identity);
                        totalWall--;
                        i += wallSpace;
                        coinx3--;
                    }
                    if (coinx5 > 0 && type == 1)
                    {
                        Instantiate(coins[1], new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), i), Quaternion.identity);
                        totalWall--;
                        i += wallSpace;
                        coinx5--;
                    }
                    if (coinx7 > 0 && type == 2)
                    {
                        Instantiate(coins[2], new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), i), Quaternion.identity);
                        totalWall--;
                        i += wallSpace;
                        coinx7--;
                    }
                    if (coinx10 > 0 && type == 3)
                    {
                        Instantiate(coins[3], new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), i), Quaternion.identity);
                        totalWall--;
                        i += wallSpace;
                        coinx10--;
                    }                  
                }
            }            
        } while (totalWall>0);
        Instantiate(walls[6], new Vector3(0, 0, i), Quaternion.identity);
    }
    public void choosePlayer()
    {
        i = PlayerPrefs.GetInt("currentPlayer");
        GameObject[] pl;
        pl = GameObject.FindGameObjectsWithTag("Parent");
        foreach (var item in pl)
        {
            Destroy(item.gameObject);
        }
        Instantiate(player[i], new Vector3(0, 0, 0),Quaternion.identity);
    }

    public void bonus()
    {
        GameObject wayScaled = Instantiate(way, new Vector3(0, -2.1f, levelLength+(levelLength/2)), Quaternion.identity); //WayScale
        wayScaled.transform.localScale = new Vector3(1, 1, (levelLength / 10)+10);
        int pos = Random.Range(-1, 2);
        for (int i = levelLength+10; i < levelLength*2; i+=mRate)
        {
            if (mCount>0)
            {
                if (mCount % 5 == 0 || mCount % 3 == 0)
                {
                    pos = Random.Range(-1, 2);
                }
                Instantiate(mt, new Vector3(pos, pos, i), Quaternion.identity);
                mCount--;
            }
        }
        Instantiate(end, new Vector3(0,1, levelLength*2), Quaternion.identity);
    }
}
    
    


