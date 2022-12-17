using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasersinir : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {

            Destroy(other.gameObject);

        
    }
}
