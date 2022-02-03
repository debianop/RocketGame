using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSc : MonoBehaviour
{


    public Transform brokenRocket;
    public ParticleSystem impactEffect;
    public GameObject finishEffect, windEffect;
    public Transform brokenWall;
    public int wC,mot;
    float sp, mp;
    GameObject cS;
    GameplaySc gP;
    MovementSc mS;
    void Start()
    {
        mot = 0;
        mS = GameObject.FindObjectOfType<MovementSc>();
        cS = GameObject.Find("CodeStation");
        gP = cS.GetComponent<GameplaySc>();
        sp = gP.speed;
        gP.comboCount = 0;
        finishEffect.SetActive(false);
        windEffect.SetActive(false);
    }
    


    public void OnTriggerEnter(Collider colEnter)
    {
        if (colEnter.gameObject.tag== "Target") //GreenWall Collision
        {
            Boom();
            Destroy(colEnter.transform.parent.gameObject);
            Instantiate(brokenWall, new Vector3(colEnter.transform.position.x, colEnter.transform.position.y - 2, colEnter.transform.position.z), Quaternion.identity);
            Vector3 shockwave = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,colEnter.transform.position.z);
            Collider[] colliders = Physics.OverlapSphere(shockwave, gP.explosionRadius);
            foreach (Collider hit in colliders)
            {
                if (hit.gameObject.tag == "BrokenWall")
                {
                    Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
                    if (rigidbody != null)
                    {
                        rigidbody.AddExplosionForce(gP.explosionForce, shockwave, gP.explosionRadius, 3f);
                    }
                }
            }
            gP.comboCount++;
            if (gP.comboCount==gP.comboMax)
            {
                StartCoroutine(feverMode());
            }
            if (gP.comboCount>=3)
            {
                gP.comboBar.gameObject.SetActive(true);
            }
            if (gP.comboCount==2)
            {
                gP.speed =sp;
            }
            gP.score += 10;
            gP.scoreText.text = gP.score.ToString();
            wC = 1;
        }
        else if (colEnter.gameObject.tag == "Slow") //YellowWall Collision
        {
            gP.comboBar.gameObject.SetActive(false);
            gP.speed -= 1;
            gP.comboCount = 0;
            if (gP.speed<sp-3)
            {
                levelFailed();
            }
            else
            {
                Boom();
                Destroy(colEnter.transform.parent.gameObject);
                Instantiate(brokenWall, new Vector3(colEnter.transform.position.x, colEnter.transform.position.y - 2, colEnter.transform.position.z), Quaternion.identity);
                Vector3 shockwave = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, colEnter.transform.position.z);
                Collider[] colliders = Physics.OverlapSphere(shockwave, gP.explosionRadius);
                foreach (Collider hit in colliders)
                {
                    if (hit.gameObject.tag == "Player")
                    {

                    }
                    else if (hit.gameObject.tag == "BrokenWall")
                    {
                        Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
                        if (rigidbody != null)
                        {
                            rigidbody.AddExplosionForce(gP.explosionForce, shockwave, gP.explosionRadius, 3f);
                        }
                    }
                }
                gP.score -= 10;
                gP.scoreText.text = gP.score.ToString();
                wC = 2;
            }
        }
        else if (colEnter.gameObject.tag == "Boost") //BlueWall Collision
        {
            windEffect.SetActive(true);
            Boom();
            Destroy(colEnter.transform.parent.gameObject);
            Instantiate(brokenWall, new Vector3(colEnter.transform.position.x, colEnter.transform.position.y - 2, colEnter.transform.position.z), Quaternion.identity);
            Vector3 shockwave = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, colEnter.transform.position.z);
            Collider[] colliders = Physics.OverlapSphere(shockwave, gP.explosionRadius);
            foreach (Collider hit in colliders)
            {
                if (hit.gameObject.tag == "Player")
                {

                }
                else if (hit.gameObject.tag == "BrokenWall")
                {
                    Rigidbody rigidbody = hit.GetComponent<Rigidbody>();
                    if (rigidbody != null)
                    {
                        rigidbody.AddExplosionForce(gP.explosionForce, shockwave, gP.explosionRadius, 3f);
                    }
                }
            }
            StartCoroutine(boost(0.5f));
            wC = 3;
        }
        else if (colEnter.gameObject.tag== "Fail") //RedWall Collision 
        {
            levelFailed();
            FindObjectOfType<AudioManager>().Play("crash");
        }
        if (colEnter.gameObject.tag=="Finish")
        {
            gP.comboBar.SetActive(false);
            transform.parent.position = new Vector3(0, 0, transform.position.z);
            mp = 1;
            CreateLevel cL = GameObject.FindObjectOfType<CreateLevel>();
            cL.bonus();
            mS.death = true;
            Boom();
            Destroy(colEnter.gameObject);
            StartCoroutine(finishDelay());
            
        }
        if (colEnter.gameObject.tag=="Coin")
        {
            gP.score += 3;
            gP.scoreText.text = gP.score.ToString();
            mot++;
            StopCoroutine(collect());
            StartCoroutine(collect());
            FindObjectOfType<AudioManager>().Play("coin");
            gP.coinAnim.SetTrigger("cT");
            Destroy(colEnter.gameObject);
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 10);
            gP.coinText.text = PlayerPrefs.GetInt("coin").ToString();

        }
        if (colEnter.gameObject.tag=="Multiplier")
        {
            FindObjectOfType<AudioManager>().Play("coin");
            mp += 0.2f;
            if (mp>1)
            {
                gP.multiplierText.text = "X" +System.Math.Round(mp, 1).ToString();
            }
            else
            {
                gP.multiplierText.text = "";
            }
            Destroy(colEnter.gameObject);
            gP.calcScore = gP.score * mp;
            gP.scoreText.text = Mathf.RoundToInt(gP.calcScore).ToString();
        }
        if (colEnter.gameObject.tag=="End")
        {
            gP.endAnim.SetTrigger("go");
            mS.death = true;
            finishEffect.SetActive(true);
            Boom();
            StartCoroutine(endAnimDelay());            
        }
    }

    IEnumerator endScoreDelay()
    {
        yield return new WaitForSeconds(1);
        gP.scoreText.text = Mathf.RoundToInt(gP.calcScore).ToString();
    }
    IEnumerator endAnimDelay()
    {
        StartCoroutine(endScoreDelay());
        yield return new WaitForSeconds(2);
        gP.gamePanel.SetActive(false);
        gP.succesPanel.SetActive(true);
        gP.calcScoreText.text = Mathf.RoundToInt(gP.calcScore).ToString();
        if (Mathf.RoundToInt(gP.calcScore) > PlayerPrefs.GetInt("bestscore"))
        {
            PlayerPrefs.SetInt("bestscore", Mathf.RoundToInt(gP.calcScore));
            gP.bestscoreText.text = "Best Score: " + PlayerPrefs.GetInt("bestscore");
        }
        else
        {
            gP.bestscoreText.text = "";
        }
        TinySauce.OnGameFinished(levelNumber: LevelManager.FindObjectOfType<LevelManager>().currentLevel.ToString(), Mathf.RoundToInt(gP.calcScore));
    }

    IEnumerator finishDelay()
    {
        gP.cdAnim.SetActive(true);
        yield return new WaitForSeconds(4);
        finishEffect.SetActive(false);
        mS.death = false;
        gP.speed = gP.bonusSpeed;
        windEffect.SetActive(true);
    }
    IEnumerator collect()
    {
        yield return new WaitForSeconds(1);
        if (mot==10)
        {
            StartCoroutine(motDelay());
        }
        else if (mot==7)
        {
            StartCoroutine(motDelay());
        }
        else if (mot==5)
        {
            StartCoroutine(motDelay());
        }
        else if (mot==3)
        {
            StartCoroutine(motDelay());
        }
        mot = 0;
    }

    int motRandom;
    IEnumerator motDelay()
    {
        motRandom = Random.Range(0, 4);
        gP.moti[motRandom].SetActive(true);
        yield return new WaitForSeconds(1);
        gP.moti[motRandom].SetActive(false);
    }
    IEnumerator boost(float boostTime) //Boost
    {
        gP.speed = gP.speed * 3;
        windEffect.SetActive(true);
        yield return new WaitForSeconds(boostTime);
        windEffect.SetActive(false);
        gP.speed = sp;
    }

    void levelFailed()
    {
        mS.on = false;
        mS.death = true;
        Instantiate(brokenRocket, transform.position, Quaternion.identity);
        Destroy(gameObject);
        gP.gamePanel.SetActive(false);
        gP.failPanel.SetActive(true);
    }

    void Boom()
    {
        if (PlayerPrefs.GetInt("vibration")==0)
        {
            Vibration.Vibrate(100);
            //Handheld.Vibrate();
        }
        gP.camAnim.SetTrigger("shake");
        impactEffect.Play();
    }

    GameObject[] fever;
    IEnumerator feverMode()
    {
        gP.score -= 10;
        Vector3 pos = transform.parent.position;
        windEffect.SetActive(true);
        gP.speed = gP.speed * 3;
        if (fever == null)
        {
            fever = GameObject.FindGameObjectsWithTag("Wall");
        }
        foreach (GameObject fev in fever)
        {
            Vector3 distance = fev.transform.position - pos;
            if (distance.z<=gP.feverDistance)
            {
                Instantiate(gP.feverOne, fev.transform.position, Quaternion.identity);
                Destroy(fev);
            }
        }
        fever = null;
        yield return new WaitForSeconds(3);
        windEffect.SetActive(false);
        gP.speed = sp;
        gP.comboBar.SetActive(false);
        gP.comboCount = 0;
    }
}
