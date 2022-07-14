using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStars : MonoBehaviour
{

    public GameObject star_small;
    public int maxNumStars; 

    Color[] starColours = { 
        new Color(0.6f, 0.6f, 0f),
        new Color(0.2f, 0.1f, 1f),
        new Color(0f, 1f, 1f),
        new Color(1f, 0f, 0f)
    };
    // Start is called before the first frame update
    void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        for(int i = 0; i < maxNumStars; ++i){
            GameObject star = (GameObject)Instantiate(star_small);

            star.GetComponent<SpriteRenderer>().color = starColours[i % starColours.Length];

            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y,max.y));

            star.GetComponent<StarScript>().speed = -(1f * Random.value + 0.5f);

            star.transform.parent = transform; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
