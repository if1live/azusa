using UnityEngine;
using System.Collections;

abstract public class BaseSceneSwitcher : MonoBehaviour {

    public abstract void SwitchScene();
    private float delay = 1.0f;

    void Start()
    {
        delay = 1.0f;
    }

    void Update()
    {
        // 연속으로 화면 바꾸는거 방지
        delay -= Time.deltaTime;
        if (delay < 0)
        {
            delay = 0;
            if (Input.anyKey)
            {
                SwitchScene();
            }
        }
    }
}
