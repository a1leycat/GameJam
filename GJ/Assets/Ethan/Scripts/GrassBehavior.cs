using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehavior : MonoBehaviour
{
    public bool onFire;
    public bool Grass;
    public bool Dead;
    public SpriteRenderer Sprite;
    public Sprite deadBlock;
    public Sprite grassBlock;
    public GameObject Fire;
    public float deadToGrass;
    public bool nextToGrass;
    public int deadCount;

    // Start is called before the first frame update
    void Start()
    {
        Dead = true;
        nextToGrass = false;
        deadToGrass = 60;
        deadCount = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextToGrass == true && deadToGrass > 0)
        {
            deadToGrass -= Time.deltaTime;
        }
        if (deadToGrass == 0)
        {
            Grass = true;
        }
        if (Grass == true)
        {
            Dead = false;
            Sprite.sprite = grassBlock;
        }
        else if (Dead == true)
        {
            Grass = false;
            Sprite.sprite = deadBlock;
        }
        if (onFire == true)
        {
            Instantiate(Fire, transform.position, transform.rotation);
            Grass = false;
            Dead = true;
            onFire = false;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Fire") && Grass == true)
        {
            Dead = true;
            deadToGrass = 60;
        }
        else if (collision.gameObject.GetComponent<GrassBehavior>().Grass == true)
        {
            deadCount += 1; 
            nextToGrass = true;
        }
        else if (collision.gameObject.GetComponent<GrassBehavior>().Dead == true && deadCount > 0)
        {
            deadCount -= 1;
        }
    }
}
