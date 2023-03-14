using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public TextMeshProUGUI FemDee4Counter;
    public static int FemDee4sCollected = 0;
    public int FemDee4ToCollect = 4;
    public GameObject Music;
    public GameObject ChaseMusic;
    public GameObject Dee4;
    public GameObject Dee4GaySex;
    public GameObject WinTrigger;

    // Start is called before the first frame update
    void Start()
    {
        FemDee4Counter.text = FemDee4sCollected + "/" + FemDee4ToCollect;
        Dee4.SetActive(true);
        Dee4GaySex.SetActive(false);
        Music.SetActive(true);
        ChaseMusic.SetActive(false);
        WinTrigger.SetActive(false);
        RenderSettings.fog = false;
        RenderSettings.ambientLight = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        FemDee4Counter.text = FemDee4sCollected + "/" + FemDee4ToCollect;

        if (FemDee4sCollected >= 1) 
        {
            Music.SetActive(false);
            SpoopMode();
        }
    }

    public void CollectFemDee4()
    {
        FemDee4sCollected++;
        if (FemDee4sCollected >= FemDee4ToCollect)
        {
            ChaseMusic.SetActive(true);
            RenderSettings.fog = true;
            RenderSettings.fogColor = Color.black;
            RenderSettings.ambientLight = Color.grey;
            WinTrigger.SetActive(true);
        }
    }

    public void SpoopMode() 
    {
        Dee4.SetActive(false);
        Dee4GaySex.SetActive(true);
    }
}