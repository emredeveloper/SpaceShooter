using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurme : MonoBehaviour
{
    Rigidbody fizik;
    public int speed;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();

        fizik.angularVelocity = Random.onUnitSphere * speed;
    }

   
}
