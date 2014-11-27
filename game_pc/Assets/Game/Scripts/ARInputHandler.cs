using UnityEngine;
using System.Collections;
using InControl;

public class ARInputHandler : MonoBehaviour {
    private float sceneSwitchDelay = 0.5f;

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
	}
}
