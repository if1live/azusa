/*============================================================================== 
 * Copyright (c) 2012-2013 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/

using UnityEngine;
using System.Collections;

public class BackgroundTextureAppManager : AppManager 
{
    public VideoTextureBehaviour m_VideoTexBhvr;
    private bool mCameraView;
    
    public override void InitManager ()
    {
        base.InitManager ();
        m_VideoTexBhvr.InitBehaviour();
    }
    
    public override void Draw()
    {
        base.Draw();
        switch(mActiveViewType)
        {
            case ViewType.UIVIEW:
                mCameraView = false;
                break;
            case ViewType.ARCAMERAVIEW:
                mCameraView = true; 
                break;
        }
    }

    public override void UpdateManager ()
    {
        base.UpdateManager();
        if(mCameraView) {
            m_VideoTexBhvr.UpdateBehaviour();
        }
    }
}
