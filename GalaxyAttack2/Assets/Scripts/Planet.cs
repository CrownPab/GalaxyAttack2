using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public float speed; 
    public bool movingFlag; 


    Vector2 min; 
    Vector2 max; 
    // Start is called before the first frame update
    void Start()
    {
        movingFlag = false; 

        min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;


        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {

        if(!movingFlag){
            return; 
        }
        
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        if(transform.position.y < min.y){
            movingFlag = false;
        }
    }

    public void resetPlanet(){
        transform.position = new Vector2(Random.Range(min.x,max.x), max.y);
    }
}
