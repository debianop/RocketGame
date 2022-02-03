using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockRandom : MonoBehaviour
{
    public Button[] bt;
    int rnd, allSold;
    public Animator ai;
    GameObject cS, sA;
    GameplaySc gP;
    ShopActions shopActions;
    public Button unlock, get;
    public void btClick()
    {
        allSold = 0;
        if (PlayerPrefs.GetInt("coin") >= 9999)
        {
            for (int i = 1; i < 10; i++)
            {
                string alındı = "sold" + i;
                if (PlayerPrefs.GetInt(alındı) == 1)
                {
                    allSold++;
                }
            }
            if (allSold == 9)
            {
                gP.notLoaded.SetActive(true);
                gP.warningText.text = "you have everything!";
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("unlock");
                ai.speed = allSold / 10 + 1;
                ai.SetBool("play", true);
                StartCoroutine(animDelay());
            }

        }
        else
        {
            cS = GameObject.Find("CodeStation");
            gP = cS.GetComponent<GameplaySc>();
            gP.notLoaded.SetActive(true);
            gP.warningText.text = "Not enough money.";
        }

    }
    IEnumerator animDelay()
    {
        unlock.interactable = false;
        get.interactable = false;
        yield return new WaitForSeconds(ai.speed);
        sA = GameObject.Find("Shop");
        shopActions = sA.GetComponent<ShopActions>();
        cS = GameObject.Find("CodeStation");
        gP = cS.GetComponent<GameplaySc>();
        int sat = 1;
        int i = 0;
        do
        {
            rnd = Random.Range(1, 10);

            if (i == rnd)
            {
                string sold = "sold" + rnd;
                if (PlayerPrefs.GetInt(sold) != 1)
                {
                    sat = 0;
                    PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - 9999);
                    PlayerPrefs.SetInt(sold, 1);
                    gP.coinText.text = PlayerPrefs.GetInt("coin").ToString();
                    shopActions.callAll();
                    //satın alma işlemi
                }
            }
            if (i > 9)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        } while (sat != 0);
        ai.SetBool("play", false);
        unlock.interactable = true;
        get.interactable = true;
    }

}
