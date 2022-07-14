using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStateManagment : MonoBehaviour
{

    public GameObject playButton;
    public GameObject playerShip; 
    public GameObject enemySpawner; 
    public GameObject scoreText; 
    public GameObject gameOver;
    public GameObject titleCard; 

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip deathMusic; 
    AudioSource audio; 

    public enum GameManageStage 
    {
        Opening, 
        Gameplay, 
        GameOver, 
    }

    GameManageStage GMState; 
    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManageStage.Opening; 
        audio = gameObject.GetComponent<AudioSource>(); 
    }

    void UpdateGameManagerState()
    {
        switch(GMState) 
        { 
            case GameManageStage.Opening:
            
            titleCard.SetActive(true);
            gameOver.SetActive(false);

            audio.clip = menuMusic;
            audio.Play();
            playButton.SetActive(true); 


            break; 
            case GameManageStage.Gameplay:
            titleCard.SetActive(false);
            audio.clip = gameMusic;
            audio.Play();

            playButton.SetActive(false);
            playerShip.GetComponent<PlayerControl>().init();

            enemySpawner.GetComponent<EnemyScript>().turnOnEnemySpawner();

            break; 
            case GameManageStage.GameOver: 

            gameOver.SetActive(true);

            audio.clip = deathMusic;
            audio.Play();

            enemySpawner.GetComponent<EnemyScript>().undoEnemySpawner();
            Invoke("ChangeToOpeningState", 8f);
            break; 
        }
    }


    public void SetGameManagerState(GameManageStage state)
    {
        GMState = state; 
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        scoreText.GetComponent<GameScore>().Score = 0;
        GMState = GameManageStage.Gameplay; 
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManageStage.Opening);
    }
}
