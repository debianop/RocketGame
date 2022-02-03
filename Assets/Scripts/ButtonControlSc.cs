using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControlSc : MonoBehaviour
{
    public Button soundBt, vibrationBt;
    public Sprite soundOn, soundOff, vibrationOn, vibrationOff;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Sound")==0)
        {
            soundBt.GetComponent<Image>().sprite = soundOn;
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
            soundBt.GetComponent<Image>().sprite = soundOff;
        }

        if (PlayerPrefs.GetInt("vibration")==0)
        {
            vibrationBt.GetComponent<Image>().sprite = vibrationOn;
        }
        else 
        {
            vibrationBt.GetComponent<Image>().sprite = vibrationOff;
        }
    }
    public void soundControl()
    {
        if (AudioListener.volume == 1f)
        {
            PlayerPrefs.SetInt("Sound", 1);
            AudioListener.volume = 0f;
            soundBt.GetComponent<Image>().sprite = soundOff;

        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            AudioListener.volume = 1f;
            soundBt.GetComponent<Image>().sprite = soundOn;

        }

    }

    public void vibrationControl()
    {
        if (PlayerPrefs.GetInt("vibration")==0)
        {
            PlayerPrefs.SetInt("vibration", 1);
            vibrationBt.GetComponent<Image>().sprite = vibrationOff;
        }
        else
        {
            PlayerPrefs.SetInt("vibration", 0);
            vibrationBt.GetComponent<Image>().sprite = vibrationOn;
        }
    }
}
