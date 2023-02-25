using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dee4ClonesTrigger : MonoBehaviour
{
    public GameObject Dee4Clones;

    public void OnTriggerEnter() 
    {
        Dee4Clones.SetActive(true);
    }
}
