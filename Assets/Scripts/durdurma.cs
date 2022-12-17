using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class durdurma : MonoBehaviour
{
    public bool oyundurdumu;
    //AudioSource _audioPlayer;

    private void Start()
    {
        //_audioPlayer = GetComponent<AudioSource>();
    }
    public void OyunDurdu()
    {
        if (oyundurdumu==true)
        {
           

            Time.timeScale = 1f;
            

            oyundurdumu = false;
            

        }
        else
        {

            Time.timeScale=0f;


            oyundurdumu = true;


        }
       

    }
    //public void sesdurdur()
    //{
    //    if (oyundurdumu== true)
    //    {
    //        _audioPlayer.Stop();
    //    }
    //    else
    //    {
    //        _audioPlayer.Play();
    //    }
    //}
}
