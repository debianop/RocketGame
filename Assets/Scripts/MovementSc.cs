using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSc : MonoBehaviour
{
    Touch touch;
    public bool on,death;
    float smoothness = 0.005f;
    GameObject cS;
    GameplaySc gP;

    // Start is called before the first frame update
    void Start()
    {
        cS = GameObject.Find("CodeStation");
        gP = cS.GetComponent<GameplaySc>();
        death = false;
        on = false;
    }

    private void Update()
    {
        //Player borders
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.9f, 1.9f), Mathf.Clamp(transform.position.y, -1.9f, 1.9f), transform.position.z);
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.position.y <= 700)
            {
                on = true;
            }
            if (on && !death &&!gP.panelState)//Starting conditions
            {
                gP.mainPanel.SetActive(false);
                gP.gamePanel.SetActive(true);
                if (touch.phase == TouchPhase.Moved)//If touch position changed
                {
                    transform.Translate(new Vector3(touch.deltaPosition.x * smoothness, touch.deltaPosition.y * smoothness, Time.deltaTime * gP.speed));
                }
                if (touch.phase == TouchPhase.Stationary)
                {
                    transform.Translate(new Vector3(0, 0, Time.deltaTime * gP.speed));//If touch position is steady
                }
            }
        }
        else if (on && !death && !gP.panelState)
        {
            transform.Translate(new Vector3(0, 0, Time.deltaTime * gP.speed)); //After start player always going forward
        }
    }
}
