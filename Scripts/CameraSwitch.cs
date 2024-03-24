using UnityEngine;
using TMPro;

public class CameraSwitch : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;
    public GameObject Camera5;

    public int cameraid = 1;

    const int MIN_CAMERA_ID = 1;
    const int MAX_CAMERA_ID = 5;

    public bool cooldown = false;

    public TextMeshProUGUI camlocationText;

    public void RBPressed()
    {
        if (!PausePanelScript.GameIsPaused) 
        { 
            if (cooldown == false)
            {
            cameraid++;
            SwitchCamera();
            Invoke("ResetCooldown", 0.2f);
            cooldown = true;
            AudioManager.Instance.PlaySFX("UIButton");
            }
            //cameraid++;
            //SwitchCamera();
            //Debug.Log("Right button was pressed!");
        }
    }
    public void LBPressed()
    {
        if (!PausePanelScript.GameIsPaused) 
        { 
            if (cooldown == false)
            {
            cameraid--;
            SwitchCamera();
            Invoke("ResetCooldown", 0.2f);
            cooldown = true;
            AudioManager.Instance.PlaySFX("UIButton2");
            }
        //cameraid--;
        //SwitchCamera();
        //Debug.Log("Left button was pressed!");
        }
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

    void SwitchCamera()
    {
        if (cameraid < MIN_CAMERA_ID)
        {
            cameraid = MAX_CAMERA_ID;
        }
        else if (cameraid > MAX_CAMERA_ID)
        {
            cameraid = MIN_CAMERA_ID;
        }

        switch (cameraid)
        {
            case 1:
                Camera1.SetActive(true);
                Camera2.SetActive(false);
                Camera3.SetActive(false);
                Camera4.SetActive(false);
                Camera5.SetActive(false);
                break;

            case 2:
                Camera1.SetActive(false);
                Camera2.SetActive(true);
                Camera3.SetActive(false);
                Camera4.SetActive(false);
                Camera5.SetActive(false);
                break;

            case 3:
                Camera1.SetActive(false);
                Camera2.SetActive(false);
                Camera3.SetActive(true);
                Camera4.SetActive(false);
                Camera5.SetActive(false);
                break;

            case 4:
                Camera1.SetActive(false);
                Camera2.SetActive(false);
                Camera3.SetActive(false);
                Camera4.SetActive(true);
                Camera5.SetActive(false);
                break;

            case 5:
                Camera1.SetActive(false);
                Camera2.SetActive(false);
                Camera3.SetActive(false);
                Camera4.SetActive(false);
                Camera5.SetActive(true);
                break;
        }

    }

    void Update()
    {
        if (!PausePanelScript.GameIsPaused) 
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (cooldown == false)
                {
                    cameraid++;
                    SwitchCamera();
                }
                //Debug.Log("Cameraid incremented");
                //Debug.Log(cameraid);
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (cooldown == false)
                {
                    cameraid--;
                    SwitchCamera();
                }
                //Debug.Log("Cameraid decremented");
                //Debug.Log(cameraid);
            }
        }
        // Any reference changes / acquisitions that happen via code will always override whatever's been set up in the Inspector
        // tak jak to že tobhngtm ghbntzjfm

        //camlocationText = FindObjectOfType<TextMeshProUGUI>();

        switch (cameraid) 
        {
            case 1:
                camlocationText.text = "LIVING ROOM";
                break;
            case 2:
                camlocationText.text = "BATHROOM";
                break;
            case 3:
                camlocationText.text = "BEDROOM 1";
                break;
            case 4:
                camlocationText.text = "KITCHEN";
                break;
            case 5:
                camlocationText.text = "BEDROOM 2";
                break;
        }


        //    if (Input.GetKeyDown(KeyCode.Keypad1))
        //    {
        //        Camera1.SetActive (true);
        //        Camera2.SetActive (false);
        //        Camera3.SetActive (false);
        //        Camera4.SetActive (false);
        //        Camera5.SetActive (false);
        //    }

        //    if (Input.GetKeyDown(KeyCode.Keypad2))
        //    {
        //        Camera1.SetActive (false);
        //        Camera2.SetActive (true);
        //        Camera3.SetActive (false);
        //        Camera4.SetActive (false);
        //        Camera5.SetActive (false);
        //    }

        //    if (Input.GetKeyDown(KeyCode.Keypad3))
        //    {
        //        Camera1.SetActive (false);
        //        Camera2.SetActive (false);
        //        Camera3.SetActive (true);
        //        Camera4.SetActive (false);
        //        Camera5.SetActive (false);
        //    }

        //    if (Input.GetKeyDown(KeyCode.Keypad4))
        //    {
        //        Camera1.SetActive (false);
        //        Camera2.SetActive (false);
        //        Camera3.SetActive (false);
        //        Camera4.SetActive (true);
        //        Camera5.SetActive (false);
        //    }

        //    if (Input.GetKeyDown(KeyCode.Keypad5))
        //    {
        //        Camera1.SetActive (false);
        //        Camera2.SetActive (false);
        //        Camera3.SetActive (false);
        //        Camera4.SetActive (false);
        //        Camera5.SetActive (true);
        //    }

        //}
    }
}