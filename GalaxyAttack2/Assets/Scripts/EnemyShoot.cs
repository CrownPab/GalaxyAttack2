using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject EnemyBullet; 
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet(){
        GameObject playership = GameObject.Find("Player");

        
            if(playership != null) {
                GameObject bullet = (GameObject)Instantiate(EnemyBullet);

                bullet.transform.position = transform.position; 

                Vector2 direction = playership.transform.position - bullet.transform.position; 

                bullet.GetComponent<EnemyBullet>().SetDirection(direction); 
            }
        
    }
}
