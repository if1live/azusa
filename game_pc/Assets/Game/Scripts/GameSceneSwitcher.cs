﻿using UnityEngine;
using System.Collections;

public class GameSceneSwitcher : BaseSceneSwitcher
{
    public override void SwitchScene()
    {
        BaseCommand cmd = new SceneSwitchCommand(0);
        cmd.Run();
    }
}
