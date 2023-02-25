using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dee4MadTrigger : MonoBehaviour
{
    public GameObject Dee4;
    public GameObject Dee4Mad;
    public GameObject Chase;

    public void OnTriggerEnter() 
    {
        Dee4.SetActive(false);
        Dee4Mad.SetActive(true);
        Chase.SetActive(true);
    }
}
