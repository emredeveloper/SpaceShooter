using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int SpawnCount;
    public float SpawnWait;
    public float StartSpawn;
    public float vaweSpawn;
    public int Score;
    public Text scoreText;
    public Text GameOverText;
    public Text RestartText;
    public Text quitTtext;
    private bool gameOver;
    private bool restart;

    private float SpawnTime = 2.5f;
    

    IEnumerator spawn()
    {
        yield return new WaitForSeconds(SpawnTime);
        Vector3 SpawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
        
        Quaternion spawnrotatiom = Quaternion.identity;
        Debug.Log("Meteor Spawn Oldu");
        SpawnTime -= 0.5f;
        SpawnTime = Mathf.Clamp(SpawnTime, -10f, 10f);
        if (SpawnTime==-10f)
        {
            if (gameOver == true)
            {
                RestartText.text = "Press R for Restart";
                quitTtext.text = "Press Q for Quit";
                restart = true;
                
            }
        }
        for (int i = 0; i <= SpawnCount; i++)
        {
            if (i==5)
            {
                yield return new WaitForSeconds(SpawnWait);
            }
        }
        Debug.Log($"Spawn Time : {SpawnTime}");
        Instantiate(hazard, SpawnPosition, spawnrotatiom);
        StartCoroutine(spawn());
    }
    void Update()
    {
        if (restart==true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
                Debug.Log("Çýkýþ Yapýldý");
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        { 

            Application.Quit();
            Debug.Log("Çýkýþ Yapýldý");
        }

    }

    void Start()
    {

        //StartCoroutine(SpawnValues());
        GameOverText.text = "";
        RestartText.text = "";
        quitTtext.text = "";
        gameOver = false;
        restart = false;
        StartCoroutine(spawn());


    }

    //IEnumerator SpawnValues()
    //{
    //    yield return new WaitForSeconds(StartSpawn);

    //    while (true)
    //    {
    //        for (int i = 0; i < SpawnCount; i++)
    //        {
    //            Vector3 SpawnPosition = new Vector3(Random.Range(-3, 3), 0, 10);
    //            Quaternion SpawnRotation = Quaternion.identity;

    //            Instantiate(hazard, SpawnPosition, SpawnRotation);
    //            yield return new WaitForSeconds(SpawnWait);
    //        }
    //        yield return new WaitForSeconds(vaweSpawn);
    //        if (gameOver==true)
    //        {
    //            RestartText.text = "Press R for Restart";
    //            quitTtext.text = "Press Q for Quit";
    //            restart = true;
    //            break;
    //        }
            

    //    }

    //}
    public void UpdateScore()
    {
        Score += 10;
        scoreText.text = "Score :" + Score;
    }

    public void GameOver()
    {

        GameOverText.text = "Game Over";
        gameOver = true;
        if (gameOver==true)
        {
            RestartText.text = "Press R for Restart";
            quitTtext.text = "Press Q for Quit";
            restart = true;
        }
    }
}
