using UnityEngine;
using System.Collections;
using InControl;

public class Player : MonoBehaviour 
{
    public float moveSpeed = 10.0f;
    public float turnSpeed = 120.0f;
    public GameObject camera;

    private float sceneSwitchDelay = 0.5f;

	void Update () {
        sceneSwitchDelay -= Time.deltaTime;

        // Use last device which provided input.
        var inputDevice = InputManager.ActiveDevice;

        // Rotate target object with left stick.
        //transform.Rotate(Vector3.down, 500.0f * Time.deltaTime * inputDevice.LeftStickX, Space.World);
        //transform.Rotate(Vector3.right, 500.0f * Time.deltaTime * inputDevice.LeftStickY, Space.World);
        float leftRight = inputDevice.LeftStickX;
        float forwardBackward = inputDevice.LeftStickY;
        //transform.position += transform.right * leftRight * Time.deltaTime * moveSpeed;
        //transform.position += transform.forward * forwardBackward * Time.deltaTime * moveSpeed;

        Vector3 right = camera.transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 forward = camera.transform.forward;
        forward.y = 0;
        forward.Normalize();

        transform.position += right * leftRight * Time.deltaTime * moveSpeed;
        transform.position += forward * forwardBackward * Time.deltaTime * moveSpeed;

        // only work on pc
        transform.Rotate(Vector3.up, inputDevice.RightStickX * Time.deltaTime * turnSpeed);


        if (sceneSwitchDelay < 0 && (inputDevice.Action1.WasPressed
                || inputDevice.Action2.WasPressed
                || inputDevice.Action3.WasPressed
                || inputDevice.Action4.WasPressed))
        {
            BaseCommand.ARSceneSwitch().Run();
        }
	}
}
