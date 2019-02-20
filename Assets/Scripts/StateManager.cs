using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{

    public Button bPlay, bControls, bExit;
    private CameraManager cManager;

    public GameObject ControlsText, Menu, PausedText;

    void Start()
    {
        cManager = GetComponent<CameraManager>();
        ControlsText.SetActive(false);
        Menu.SetActive(true);

        bPlay.onClick.AddListener(PlayButton);
        bControls.onClick.AddListener(ControlsButton);
        bExit.onClick.AddListener(ExitButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayButton()
    {
        Time.timeScale = 1;
        cManager.switchCamera(1);
        Menu.SetActive(false);
    }
    
    private void ControlsButton()
    {
        if (ControlsText.activeSelf)
            ControlsText.SetActive(false);
        else
            ControlsText.SetActive(true);
    }

    private void ExitButton()
    {
        Application.Quit();
    }
}
