using UnityEngine;
using System.Collections;

abstract public class BaseSceneSwitcher : MonoBehaviour {

    public abstract void SwitchScene();

    // 연속으로 화면 바꾸는거 방지
    // 일반적으로 의도한 상황이 아닐거다
    private float uiActiveDelay;

    void Start()
    {
        uiActiveDelay = 0.1f;
    }

    void Update()
    {
        uiActiveDelay -= Time.deltaTime;
    }

    void OnGUI () {
        if (uiActiveDelay > 0)
        {
            return;
        }
        Rect switchSceneRect = new Rect(0, 0, 200, 100);
        if (GUI.Button(switchSceneRect, "Switch Scene")){
            Debug.Log("Switch Scene");
            SwitchScene();
        }
    }
}
