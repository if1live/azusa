using UnityEngine;
using System.Collections;

public class ARSceneSwitcher : BaseSceneSwitcher
{
    public override void SwitchScene()
    {
        BaseCommand cmd = new SceneSwitchCommand(1);
        cmd.Run();
    }

    
}
