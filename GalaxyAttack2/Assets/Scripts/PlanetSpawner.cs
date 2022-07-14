using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{

    public GameObject[] Planets; 

    Queue<GameObject> listOfPlanets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        listOfPlanets.Enqueue(Planets[0]); 
        listOfPlanets.Enqueue(Planets[1]); 
        listOfPlanets.Enqueue(Planets[2]);

        InvokeRepeating("animatePlanet", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void animatePlanet(){

        queuePlanets(); 

        if(listOfPlanets.Count == 0){
            return;
        }

        GameObject aPlanet = listOfPlanets.Dequeue(); 

        aPlanet.GetComponent<Planet>().movingFlag = true; 
    }

    void queuePlanets(){
        foreach(GameObject aPlanet in Planets){
            if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().movingFlag)){
                aPlanet.GetComponent<Planet>().resetPlanet();

                listOfPlanets.Enqueue(aPlanet);
            }
        }
    }
}
