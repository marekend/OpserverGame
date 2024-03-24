using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class DigitalClock : MonoBehaviour
{
    public GameObject EndGamePanel;

    public bool clockranningxd = false;
    void Start()
    {
        clockranningxd = true;
    }
    
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    float timeScale = 0.5f; //0.5f
    void Update()
    {
        if (clockranningxd)
        {
            //elapsedTime += Time.deltaTime * timeScale;
            int hours = Mathf.FloorToInt(elapsedTime / 60);
            int minutes = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", hours, minutes);
            //Debug.Log("Cas: " + (elapsedTime));

            if (elapsedTime <= 360) 
            {
                elapsedTime += Time.deltaTime * timeScale;
            }
            else
            {
                Debug.Log("Konec hry!");
                elapsedTime = 0;
                clockranningxd = false;
                EndGamePanel.SetActive(true);
            }

        }

    }







}
