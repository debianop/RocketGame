using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSc : MonoBehaviour
{
    public Material[] colors;
    ControlSc cS;
    // Start is called before the first frame update
    void Start()
    {
        cS = GameObject.FindObjectOfType<ControlSc>();
        if (cS.wC == 1)
        {
            gameObject.GetComponent<MeshRenderer>().material = colors[0];
        }
        if (cS.wC == 2)
        {
            gameObject.GetComponent<MeshRenderer>().material = colors[1];
        }
        if (cS.wC == 3)
        {
            gameObject.GetComponent<MeshRenderer>().material = colors[2];
        }
        Destroy(transform.parent.gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
