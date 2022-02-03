using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopActions : MonoBehaviour
{
    public Sprite orange, green;
    public GameObject[] img;
    public GameObject[] rocket;
    public GameObject[] mysBox;

    private void Start()
    {
        PlayerPrefs.SetInt("sold1", 1);
        callAll();
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        int j=PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
    }

    public void pr1Click()
    {
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        PlayerPrefs.SetInt("currentPlayer", 0);
        int j = PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
        crLevel.choosePlayer();
    }
    public void pr2Click()
    {
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        PlayerPrefs.SetInt("currentPlayer", 1);
        int j = PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length ; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
        crLevel.choosePlayer();
    }
    public void pr3Click()
    {
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        PlayerPrefs.SetInt("currentPlayer", 2);
        int j = PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length ; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
        crLevel.choosePlayer();
    }
    public void pr4Click()
    {
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        PlayerPrefs.SetInt("currentPlayer", 3);
        int j = PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length ; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
        crLevel.choosePlayer();
    }
    public void pr5Click()
    {
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        PlayerPrefs.SetInt("currentPlayer", 4);
        int j = PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length ; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
        crLevel.choosePlayer();
    }
    public void pr6Click()
    {
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        PlayerPrefs.SetInt("currentPlayer", 5);
        int j = PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length ; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
        crLevel.choosePlayer();
    }
    public void pr7Click()
    {
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        PlayerPrefs.SetInt("currentPlayer", 6);
        int j = PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length ; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
        crLevel.choosePlayer();
    }
    public void pr8Click()
    {
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        PlayerPrefs.SetInt("currentPlayer", 7);
        int j = PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length ; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
        crLevel.choosePlayer();
    }
    public void pr9Click()
    {
        GameObject cS = GameObject.Find("CodeStation");
        CreateLevel crLevel = cS.GetComponent<CreateLevel>();
        PlayerPrefs.SetInt("currentPlayer", 8);
        int j = PlayerPrefs.GetInt("currentPlayer");
        for (int i = 0; i < crLevel.player.Length; i++)
        {
            if (i != j)
            {
                img[i].gameObject.SetActive(false);
            }
            else
            {
                img[i].gameObject.SetActive(true);
            }
        }
        crLevel.choosePlayer();
    }


    public void callAll()
    {
        pr1();
        pr2();
        pr3();
        pr4();
        pr5();
        pr6();
        pr7();
        pr8();
        pr9();
    }
    public void pr1()
    {
        Button bt;
        bt = GameObject.Find("Product1").GetComponent<Button>();
        if (PlayerPrefs.GetInt("sold1") == 1)
        {
            bt.interactable = true;
            bt.GetComponent<Image>().sprite = green;
            rocket[0].gameObject.SetActive(true);
            mysBox[0].gameObject.SetActive(false);
        }
        else
        {
            bt.interactable = false;
            bt.GetComponent<Image>().sprite = orange;
            rocket[0].gameObject.SetActive(false);
            mysBox[0].gameObject.SetActive(true);
        }
    }

    public void pr2()
    {
        Button bt;
        bt = GameObject.Find("Product2").GetComponent<Button>();
        if (PlayerPrefs.GetInt("sold2") == 1)
        {
            bt.interactable = true;
            bt.GetComponent<Image>().sprite = green;
            rocket[1].gameObject.SetActive(true);
            mysBox[1].gameObject.SetActive(false);
        }
        else
        {
            bt.interactable = false;
            bt.GetComponent<Image>().sprite = orange;
            rocket[1].gameObject.SetActive(false);
            mysBox[1].gameObject.SetActive(true);
        }
    }
    public void pr3()
    {
        Button bt;
        bt = GameObject.Find("Product3").GetComponent<Button>();
        if (PlayerPrefs.GetInt("sold3") == 1)
        {
            bt.interactable = true;
            bt.GetComponent<Image>().sprite = green;
            rocket[2].gameObject.SetActive(true);
            mysBox[2].gameObject.SetActive(false);
        }
        else
        {
            bt.interactable = false;
            bt.GetComponent<Image>().sprite = orange;
            rocket[2].gameObject.SetActive(false);
            mysBox[2].gameObject.SetActive(true);
        }
    }
    public void pr4()
    {
        Button bt;
        bt = GameObject.Find("Product4").GetComponent<Button>();
        if (PlayerPrefs.GetInt("sold4") == 1)
        {
            bt.interactable = true;
            bt.GetComponent<Image>().sprite = green;
            rocket[3].gameObject.SetActive(true);
            mysBox[3].gameObject.SetActive(false);
        }
        else
        {
            bt.interactable = false;
            bt.GetComponent<Image>().sprite = orange;
            rocket[3].gameObject.SetActive(false);
            mysBox[3].gameObject.SetActive(true);
        }
    }
    public void pr5()
    {
        Button bt;
        bt = GameObject.Find("Product5").GetComponent<Button>();
        if (PlayerPrefs.GetInt("sold5") == 1)
        {
            bt.interactable = true;
            bt.GetComponent<Image>().sprite = green;
            rocket[4].gameObject.SetActive(true);
            mysBox[4].gameObject.SetActive(false);
        }
        else
        {
            bt.interactable = false;
            bt.GetComponent<Image>().sprite = orange;
            rocket[4].gameObject.SetActive(false);
            mysBox[4].gameObject.SetActive(true);
        }
    }
    public void pr6()
    {
        Button bt;
        bt = GameObject.Find("Product6").GetComponent<Button>();
        if (PlayerPrefs.GetInt("sold6") == 1)
        {
            bt.interactable = true;
            bt.GetComponent<Image>().sprite = green;
            rocket[5].gameObject.SetActive(true);
            mysBox[5].gameObject.SetActive(false);
        }
        else
        {
            bt.interactable = false;
            bt.GetComponent<Image>().sprite = orange;
            rocket[5].gameObject.SetActive(false);
            mysBox[5].gameObject.SetActive(true);
        }
    }
    public void pr7()
    {
        Button bt;
        bt = GameObject.Find("Product7").GetComponent<Button>();
        if (PlayerPrefs.GetInt("sold7") == 1)
        {
            bt.interactable = true;
            bt.GetComponent<Image>().sprite = green;
            rocket[6].gameObject.SetActive(true);
            mysBox[6].gameObject.SetActive(false);
        }
        else
        {
            bt.interactable = false;
            bt.GetComponent<Image>().sprite = orange;
            rocket[6].gameObject.SetActive(false);
            mysBox[6].gameObject.SetActive(true);
        }
    }
    public void pr8()
    {
        Button bt;
        bt = GameObject.Find("Product8").GetComponent<Button>();
        if (PlayerPrefs.GetInt("sold8") == 1)
        {
            bt.interactable = true;
            bt.GetComponent<Image>().sprite = green;
            rocket[7].gameObject.SetActive(true);
            mysBox[7].gameObject.SetActive(false);
        }
        else
        {
            bt.interactable = false;
            bt.GetComponent<Image>().sprite = orange;
            rocket[7].gameObject.SetActive(false);
            mysBox[7].gameObject.SetActive(true);
        }
    }
    public void pr9()
    {
        Button bt;
        bt = GameObject.Find("Product9").GetComponent<Button>();
        if (PlayerPrefs.GetInt("sold9") == 1)
        {
            bt.interactable = true;
            bt.GetComponent<Image>().sprite = green;
            rocket[8].gameObject.SetActive(true);
            mysBox[8].gameObject.SetActive(false);
        }
        else
        {
            bt.interactable = false;
            bt.GetComponent<Image>().sprite = orange;
            rocket[8].gameObject.SetActive(false);
            mysBox[8].gameObject.SetActive(true);
        }
    }
}
