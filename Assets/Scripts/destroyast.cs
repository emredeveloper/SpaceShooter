using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyast : MonoBehaviour
{
    public GameObject patlama;
    public GameObject patlama_player;
    public GameController gameController;
    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>(); // bu gamecontroller s�n�f�m�z� ba�ka bir alanda kullanabilmek i�in
        // b�yle bir tan�mlama yap�yoruz.

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            return;
        }
        Instantiate(patlama,other.transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(patlama_player, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Instantiate(patlama,transform.position,transform.rotation); 
        Destroy(other.gameObject);
        Destroy(gameObject);

        gameController.UpdateScore();

    }



}