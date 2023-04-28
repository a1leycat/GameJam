using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject Plot;
    GameObject[] list;
    int numPlots;
    GameObject startPlot;
    public GameObject basicPlot;
    public float plotSpawnTimer;
    public int chanceForPlot;
    // Start is called before the first frame update
    void Start()
    {
        startPlot = GameObject.FindGameObjectWithTag("start fellow");
        plotSpawnTimer = Random.Range(1, 5);
        chanceForPlot = Random.Range(1, 20);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Plot"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Spawner"))
        {
            print("other guy");
            switch (this.name)
            {
                case string s when s.Contains("Left"):
                    Destroy(collision.gameObject);
                    print("left wins");
                    break;
                case string s when s.Contains("right"):
                    if(collision.name.Contains("Up") || collision.name.Contains("Down"))
                    {
                        Destroy(collision.gameObject);
                        print("rihgt wins");
                    }
                    break;
                case string s when s.Contains("Down"):
                    if (collision.name.Contains("Up"))
                    {
                        Destroy(collision.gameObject);
                        print("down wins");
                    }
                    break;
                default:
                    Destroy(this.gameObject);
                    print("what");
                    break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(chanceForPlot == 1)
        {
            Destroy(gameObject);
        }
        if (plotSpawnTimer > 0)
        {
            plotSpawnTimer -= Time.deltaTime;
        }


        numPlots = Random.Range(1, 6);
        Debug.Log((startPlot.GetComponent<StartPlotCounter>().numOfPlots).ToString());
        if (startPlot.GetComponent<StartPlotCounter>().numOfPlots >= 1 && plotSpawnTimer <= 0)
        {
            Debug.Log("Spawn");
            Instantiate(Plot, transform.position, transform.rotation);
            startPlot.GetComponent<StartPlotCounter>().numOfPlots -= 1;
            Destroy(gameObject);
        }
        if (startPlot.GetComponent<StartPlotCounter>().numOfPlots <= 0 && plotSpawnTimer <= 0)
        {
            Instantiate(basicPlot, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}
