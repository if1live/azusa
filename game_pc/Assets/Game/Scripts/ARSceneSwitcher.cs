using UnityEngine;
using System.Collections;

public class ARSceneSwitcher : BaseSceneSwitcher
{
    public override void SwitchScene()
    {
        BaseCommand.ARSceneSwitch().Run();
    }

    
}
