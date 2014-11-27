using UnityEngine;
using System.Collections;

public interface BaseCommand
{
    void Run();
}

class SceneSwitchCommand : BaseCommand
{
    private int sceneIdx = 0;
    
    public SceneSwitchCommand(int sceneIdx)
    {
        this.sceneIdx = sceneIdx;
    }

    public void Run()
    {
        Application.LoadLevel(sceneIdx);
    }
}
