using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySc : MonoBehaviour
{
    //UI Variables
    public Slider comboSlider;
    public Text warningText, scoreText, coinText, calcScoreText, bestscoreText, multiplierText;
    //
    public GameObject feverOne, cdAnim, notLoaded;

    public GameObject[] moti;

    //InGame Calculations
    public int comboMax, score, comboCount, multiplier, feverDistance;
    public float calcScore, explosionRadius, explosionForce;
    public bool panelState;
    //
    GameObject pL;
    MovementSc mv;
    //PanelControl
    public GameObject mainPanel, gamePanel, pausePanel, succesPanel, failPanel, comboBar;
    //
    //AnimControl
    public Animator camAnim, coinAnim, endAnim;

    public float speed, bonusSpeed;
    void Start()
    {        
        panelState = false;
        score = 0;
        gamePanel.SetActive(false);
        failPanel.SetActive(false);
        coinText.text = PlayerPrefs.GetInt("coin").ToString();
    }

    void Update()
    {
        if (score<0)
        {
            score = 0;
        }
        comboSlider.value = comboCount;
    }

    //Start Condition
    public void pS()
    {
        if (panelState)
        {
            panelState = false;
            mainPanel.gameObject.SetActive(true);
        }
        else
        {
            panelState = true;
            mainPanel.gameObject.SetActive(false);
        }
        pL = GameObject.FindGameObjectWithTag("Parent");
        mv = pL.GetComponent<MovementSc>();
        mv.on = false;
        
    }

}
