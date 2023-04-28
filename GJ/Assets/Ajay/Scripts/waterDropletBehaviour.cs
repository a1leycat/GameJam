using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDropletBehaviour : MonoBehaviour
{

    public ParticleSystem water_particle;
    public GameObject water_spirit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, water_spirit.transform.position);


        if (distance > 7)
        {
            Destroy(gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

       

        if(collision.gameObject.CompareTag("WorldTree"))
        { 
            Destroy(gameObject);
            ParticleSystem water_effect = Instantiate(water_particle, transform.position, Quaternion.identity);
            Destroy(water_effect.gameObject, water_effect.main.duration);

        }
    }

}
