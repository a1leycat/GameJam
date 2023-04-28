using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wSpiritBehaviour : MonoBehaviour
{

    public string targetTag;
    public float speed;
    public float stopping_distance;
    private Transform target;

    void Start()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
        else
        {
            Debug.LogError("Could not find object with tag");
        }
    }

   
    void Update()
    {




        moveSpirit();


 
    }

    void moveSpirit()
    {
        if (target != null)
        {

            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > stopping_distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }


}
