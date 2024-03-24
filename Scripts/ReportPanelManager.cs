using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

// THIS SCRIPT IS NOT USED 

public class ReportPanelManager : MonoBehaviour
{

    public GameObject ReportPanel;

    public Button SendButton;
    public Button LRButton;
    public Button BathroomButton;
    public Button BR1Button;
    public Button KitchenButton;
    public Button BR2Button;

    public bool Selected;

    public void SendBTNPressed()
    {
        ReportPanel.SetActive(false);
        Selected = false;
    }
    public void BTNPressed()
    {
        Selected = true;
        Debug.Log(EventSystem.current.currentSelectedGameObject.name + " was selected");
    }


    //https://discussions.unity.com/t/how-can-i-check-if-a-ui-button-is-selected/132967/3


    void Start()
    {
        Selected = false;
        SendButton = GameObject.Find("SendButton").GetComponent<Button>();
        SendButton.interactable = false;
    }

    void Update()
    {
        if (Selected == false)
        {
            SendButton.interactable = false;
        }
        else
        {
            SendButton.interactable = true;
        }
    }
}
