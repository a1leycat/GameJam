using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wSpiritBehaviour : MonoBehaviour
{

    public GameObject water_projectile;
    public string targetTag;
    public float speed;
    public float stopping_distance;
    private Transform target;
    private int water_speed = 1;


    void Start()
    {
        //setup
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
        isWatering();

 
    }

    void moveSpirit()
    {
        if (target != null)
        {

            float distance = Vector2.Distance(transform.position, target.position);
            if (distance > stopping_distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }

    void isWatering()
    {

        float distance = Vector2.Distance(transform.position, target.position);
        if (distance < stopping_distance)
        {
            GameObject waterDroplet = Instantiate(water_projectile, transform.position, Quaternion.identity);
            Rigidbody2D rb = waterDroplet.GetComponent<Rigidbody2D>();
            Vector2 direction = (target.position - transform.position).normalized;
            float angle = Random.Range(-5f, 5f);
            direction = Quaternion.Euler(0, 0, angle) * direction;
            rb.velocity = direction * water_speed;
        }



    }


}
