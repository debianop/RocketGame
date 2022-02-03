using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    //LevelsUI
    public Slider levels;
    public Text levelCount;
    public GameObject glowPos;
    float bar;
    //
    public int currentLevel;
    GameplaySc gP;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private void Start()
    {
        gP = GameObject.FindObjectOfType<GameplaySc>();
        currentLevel = SceneManager.GetActiveScene().buildIndex;  // Taking the index of the current scene
        StartCoroutine(delayVal());

        if (currentLevel != PlayerPrefs.GetInt("lastLevel"))  // If last level and current level isn't equal
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("lastLevel")); // Loads last level            
        }

        TinySauce.OnGameStarted(levelNumber: currentLevel.ToString());
    }
    public void restartLevel()
    {
        SceneManager.LoadScene(currentLevel);  // Restarting the same level
        Time.timeScale = 1;
    }

    public void nextLevel()
    {
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + Mathf.RoundToInt(gP.calcScore));
        PlayerPrefs.SetInt("lastLevel", currentLevel + 1);  // Setting the PlayerPrefs variable to the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loading the next scene              
    }

    
    public void Pause()
    {
        if (Time.timeScale==1)
        {
            Time.timeScale = 0;
            gP.pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            gP.pausePanel.SetActive(false);
        }
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    IEnumerator levelBar(int val1, int val2)
    {
        levels.value = val1;
        do
        {
            levels.value += 0.2f;
            yield return new WaitForEndOfFrame();
        } while (levels.value<val2);
        levels.value = val2;
    }

    IEnumerator delayVal()
    {
        yield return new WaitForSeconds(0.1f);
        if (currentLevel > 35)
        {
            gP.comboMax = 7;
        }
        else
        {
            gP.comboMax = 5;
        }
        gP.comboSlider.maxValue = gP.comboMax;

        //LevelsUI Operations
        if (currentLevel % 5 == 0)
        {
            levelCount.text = (currentLevel + 1).ToString() + "\n" + (currentLevel + 2).ToString() + "\n" +
                (currentLevel + 3).ToString() + "\n" + (currentLevel + 4).ToString() + "\n" + "!";
            PlayerPrefs.SetString("levels", levelCount.text);
            levels.value = 0;
            glowPos.transform.localPosition = new Vector3(0, 390, 0);
        }
        else if (currentLevel % 5 == 1)
        {
            StartCoroutine(levelBar(0, 19));
            glowPos.transform.localPosition = new Vector3(0, 190, 0);
        }
        else if (currentLevel % 5 == 2)
        {
            StartCoroutine(levelBar(19, 40));
            glowPos.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (currentLevel % 5 == 3)
        {

            StartCoroutine(levelBar(40, 60));
            glowPos.transform.localPosition = new Vector3(0, -190, 0);
        }
        else if (currentLevel % 5 == 4)
        {
            StartCoroutine(levelBar(60, 80));
            glowPos.transform.localPosition = new Vector3(0, -390, 0);
        }
        levelCount.text = PlayerPrefs.GetString("levels");
    }
}
