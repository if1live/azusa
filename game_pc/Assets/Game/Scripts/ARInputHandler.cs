using UnityEngine;
using System.Collections;
using InControl;

public class ARInputHandler : MonoBehaviour {
    private float sceneSwitchDelay = 0.5f;

    public GameObject scene1;
    public GameObject scene2;
    public GameObject scene3;

    void Start()
    {
        RunScene1();
    }
	// Update is called once per frame
	void Update () {
        sceneSwitchDelay -= Time.deltaTime;

        var inputDevice = InputManager.ActiveDevice;

        if (sceneSwitchDelay < 0 && (inputDevice.Action1.WasPressed
                || inputDevice.Action2.WasPressed
                || inputDevice.Action3.WasPressed
                || inputDevice.Action4.WasPressed))
        {
            BaseCommand.GameSceneSwitch().Run();
        }

        // handle keyboard for gui
        if (Input.GetButtonDown("Scene1"))
        {
            this.RunScene1();   
        }
        else if(Input.GetButtonDown("Scene2"))
        {
            this.RunScene2();
        }
        else if (Input.GetButtonDown("Scene3"))
        {
            this.RunScene3();
        }
	}

    void RunScene1()
    {
        Debug.Log("Scene1");
        scene1.SetActive(true);
        scene2.SetActive(false);
        scene3.SetActive(false);
    }
    void RunScene2()
    {
        Debug.Log("Scene2");
        scene1.SetActive(false);
        scene2.SetActive(true);
        scene3.SetActive(false);
    }
    void RunScene3()
    {
        Debug.Log("Scene3");
        scene1.SetActive(false);
        scene2.SetActive(false);
        scene3.SetActive(true);
    }
}
