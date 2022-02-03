using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowSc : MonoBehaviour
{
    Transform target;
    GameObject obj;
    public Vector3 offset;
    bool found;
    void Start()
    {
        StartCoroutine(delay());
    }
    void LateUpdate()
    {
        if (found)
        {
            if (target==null)
            {
                obj = GameObject.FindGameObjectWithTag("Parent");
                target = obj.transform;
            }
            transform.position = new Vector3(offset.x, offset.y, target.position.z + offset.z);
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.1f);
        obj = GameObject.FindGameObjectWithTag("Parent");
        target = obj.transform;
        found = true;
    }

}
