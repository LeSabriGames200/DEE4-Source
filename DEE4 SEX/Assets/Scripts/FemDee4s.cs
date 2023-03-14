using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemDee4s : MonoBehaviour
{
    public GameObject FemDee4;

    public void OnTriggerStay() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            FemDee4.SetActive(false);
            GameController gameController = FindObjectOfType<GameController>();
            if (gameController != null)
            {
                gameController.CollectFemDee4();
            }
        }
    }
}

