using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AnomalyController : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject GameOverPanelStrikes;
    public GameObject[] Anomalies;
    public float spawnTime;
    public float time;
    //public float maxTime = 40f;
    //public float minTime = 30f;
    public int AnomaliesActive;
    public GameObject RoomSelectionMenu;
    public GameObject SendReportButton;
    public Button Button_SendReportButton;
    public string selectedRoom = null;
    public TextMeshProUGUI noanomalyfoundText;
    public GameObject ReportPendingText;
    public bool cooldown = false;
    List<GameObject> anomaliesToRemove = new List<GameObject>();
    public float sendingReportCooldown = 0.0f;
    public float fixingAnomaliesCooldown = 0.0f;
    public GameObject FixingAnomalyPanel;
    public TextMeshProUGUI Strikes;
    public int strikes;

    void Start()
    {
        //Anomalies[Random.Range(0, Anomalies.Length)].SetActive(true);
        SetRandomTime();
        time = 0;

        noanomalyfoundText.CrossFadeAlpha(0.0f, 0.0f, true);
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(45f, 60f);
        Debug.Log("Next object spawns in " + spawnTime + " seconds.");
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= spawnTime)
        {
            //Debug.Log("Time to spawn: " + objectName);
            Spawn();
            SetRandomTime();
            time = 0;
        }

        if (cooldown == false)
        {
            noanomalyfoundText.CrossFadeAlpha(0.0f, 1.0f, false);
        }

        if (fixingAnomaliesCooldown != 0.0f && fixingAnomaliesCooldown <= Time.unscaledTime)
        {
            fixingAnomaliesCooldown = 0.0f;
            FixingAnomalyPanel.SetActive(false);
        }

        if (sendingReportCooldown != 0.0f && sendingReportCooldown <= Time.unscaledTime)
        {
            ReportPendingText.SetActive(false);

            // No anomalies to remove, not an accurate report
            if (anomaliesToRemove.Count == 0)
            {
                noanomalyfoundText.CrossFadeAlpha(1.0f, 2.0f, false);
                Invoke("ResetCooldown", 4.0f);
                cooldown = true;
                Debug.LogError("Reportnul jsi špatnì");
                strikes++;
                sendingReportCooldown = 0.0f;
                return;
            }

            FixingAnomalyPanel.SetActive(true);
            fixingAnomaliesCooldown = Time.unscaledTime + 3.0f;

            foreach (GameObject anomaly in anomaliesToRemove)
            {
                anomaly.SetActive(false);
            }

            anomaliesToRemove.Clear();

            sendingReportCooldown = 0.0f;
        }

        switch (strikes)
        {
            case 1:
                Strikes.text = "{X}{-}{-}";
                break;
            case 2:
                Strikes.text = "{X}{X}{-}";
                break;
            case 3:
                Strikes.text = "{X}{X}{X}";
                break;

        }

        if (strikes == 3)
        {
            GameOverPanelStrikes.SetActive(true);
        }

    }
    void ResetCooldown()
    {
        cooldown = false;
    }
    void Spawn()
    {
        int i = Random.Range(0, Anomalies.Length);
        Anomalies[i].SetActive(true);
        Debug.Log("This anomaly spawned: " + Anomalies[i].name);
       
        AnomaliesActive++;
        Debug.Log(AnomaliesActive);
        if(AnomaliesActive >= 5 ) 
        {
            GameOverPanel.SetActive(true);
        }
    }

    public void ToggleRoomSelectionMenu()
    {
        selectedRoom = null;
        Button_SendReportButton.interactable = false;
        RoomSelectionMenu.SetActive(!RoomSelectionMenu.activeInHierarchy);
        SendReportButton.SetActive(!SendReportButton.activeInHierarchy);
        AudioManager.Instance.PlaySFX("UIButton");
    }

    public void SelectRoom(string roomName)
    {
        AudioManager.Instance.PlaySFX("UIButton");
        selectedRoom = roomName;
        Button_SendReportButton.interactable = true;
    }

    public void SendReport()
    {
        if (sendingReportCooldown != 0.0f)
        {
            Debug.LogError("Momentálnì nemùžeš reportovat");

            return;
        }

        GameObject[] anomalies = GameObject.FindGameObjectsWithTag(selectedRoom);

        foreach (GameObject anomaly in anomalies)
        {
            if (anomaly.activeInHierarchy)
            {
                anomaliesToRemove.Add(anomaly);
            }
        }

        ToggleRoomSelectionMenu();

        ReportPendingText.SetActive(true);
        sendingReportCooldown = Time.unscaledTime + 5.0f;
        //if (!accurateReport)
        //{

        //    noanomalyfoundText.CrossFadeAlpha(1.0f, 2.0f, false);
        //    Invoke("ResetCooldown", 4.0f);
        //    cooldown = true;
        //    Debug.LogError("Reportnul jsi špatnì");

        //    return;
        //}

        //Debug.Log("CG reportnul jsi správnì");
    }

}

