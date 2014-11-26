using UnityEngine;
using System.Collections;

public class VRSceneSwitcher : BaseSceneSwitcher
{
    public override void SwitchScene()
    {
        Application.LoadLevel(1);
    }

    
}
