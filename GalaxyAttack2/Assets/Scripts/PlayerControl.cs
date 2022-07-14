using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerControl : MonoBehaviour
{
    
    public GameObject GameStateManagment;

    public float speed; 

    public GameObject PlayerBullet; 
    public GameObject BulletPosition01; 
    public GameObject BulletPosition02; 
    public GameObject Explosion;


    public Text TextLives; 

    const int MaxLives = 3; 
    int lives; 

    public void init(){
        lives = MaxLives; 

        TextLives.text = lives.ToString();

        transform.position = new Vector2(0,0);

        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("space")){

            GetComponent<AudioSource>().Play();
            GameObject bullet_1 = (GameObject)Instantiate (PlayerBullet);
            bullet_1.transform.position = BulletPosition01.transform.position;


            GameObject bullet_2 = (GameObject)Instantiate (PlayerBullet);
            bullet_2.transform.position = BulletPosition02.transform.position;

        }


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x,y).normalized; 

        Move (direction);
    }

    void Move(Vector2 direction) { 

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0)); 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1)); 

        max.x = max.x - 0.225f; 
        min.x = min.x + 0.225f; 

        max.y = max.y - 0.285f; 
        min.y = min.y + 0.285f; 

        Vector2 pos = transform.position; 
        pos += direction * speed * Time.deltaTime; 

        pos.x = Mathf.Clamp(pos.x,min.x,max.x); 
        pos.y = Mathf.Clamp(pos.y,min.y,max.y); 

        transform.position = pos; 
    }



    void OnTriggerEnter2D(Collider2D col){ 
        if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag")) {

            PlayExplosion();
            lives--; 
            TextLives.text = lives.ToString();
            if(lives == 0){ 
                GameStateManagment.GetComponent<gameStateManagment>().SetGameManagerState(gameStateManagment.GameManageStage.GameOver);
                gameObject.SetActive(false); 
            }
            
        }
    }

    void PlayExplosion(){

        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position; 

    }
}
