using UnityEngine;
using System.Collections;

public class GameSceneSwitcher : BaseSceneSwitcher
{
    public override void SwitchScene()
    {
        BaseCommand.GameSceneSwitch().Run();
    }
}
