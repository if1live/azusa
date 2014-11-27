using UnityEngine;
using System.Collections;

public abstract class BaseCommand
{
    abstract public void Run();

    public static BaseCommand ARSceneSwitch()
    {
        return new SceneSwitchCommand(1);
    }
    public static BaseCommand GameSceneSwitch()
    {
        return new SceneSwitchCommand(0);
    }
}

class SceneSwitchCommand : BaseCommand
{
    private int sceneIdx = 0;
    
    public SceneSwitchCommand(int sceneIdx)
    {
        this.sceneIdx = sceneIdx;
    }

    override public void Run()
    {
        Application.LoadLevel(sceneIdx);
    }
}
