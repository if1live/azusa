/*============================================================================== 
 * Copyright (c) 2012-2013 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class manages different views in the scene like AboutPage, SplashPage and ARCameraView.
/// All of its Init, Update and Draw calls take place via SceneManager's Monobehaviour calls to ensure proper sync across all updates
/// </summary>
public class AppManager : MonoBehaviour
{

		public GameObject go;
    
    #region PUBLIC_MEMBER_VARIABLES
    #endregion PUBLIC_MEMBER_VARIABLES
    
    #region PROTECTED_MEMBER_VARIABLES
		public static ViewType mActiveViewType;
		public enum ViewType
		{
				ARCAMERAVIEW
        };
    #endregion PROTECTED_MEMBER_VARIABLES
    
    #region PRIVATE_MEMBER_VARIABLES
    #endregion PRIVATE_MEMBER_VARIABLES

		private static AppManager instance;
    
		//This gets called from SceneManager's Start() 
		public virtual void InitManager ()
		{
				instance = this;
				InputController.SingleTapped += OnSingleTapped;
				InputController.DoubleTapped += OnDoubleTapped;
				InputController.BackButtonTapped += OnBackButtonTapped;
        
                mActiveViewType = ViewType.ARCAMERAVIEW;
		}
    
		public static AppManager getInstance ()
		{
				return instance;
		}

		public virtual void UpdateManager ()
		{
				//Does nothing but anyone extending AppManager can run their update calls here
		}
    
		public virtual void Draw ()
		{
				switch (mActiveViewType) {
				case ViewType.ARCAMERAVIEW:
						break;
				}
		}
    
    #region UNITY_MONOBEHAVIOUR_METHODS
    
		void OnApplicationPause (bool tf)
		{
				//On hitting the home button, the app tends to turn off the flash
				//So, setting the UI to reflect that
				//m_UIEventHandler.SetToDefault (tf);
		}
    
    #endregion UNITY_MONOBEHAVIOUR_METHODS
    
    #region PRIVATE_METHODS
    
		public void OnSingleTapped ()
		{
				if (mActiveViewType == ViewType.ARCAMERAVIEW) {
						// trigger focus once
						//m_UIEventHandler.TriggerAutoFocus ();
				}
		}

		public void OnSingleTappedBack ()
		{
				if (mActiveViewType == ViewType.ARCAMERAVIEW) {
						// trigger focus once
						//m_UIEventHandler.TriggerAutoFocus ();
				}
		}
    
		private void OnDoubleTapped ()
		{
				if (mActiveViewType == ViewType.ARCAMERAVIEW) {
						//mActiveViewType = ViewType.UIVIEW;
				}
		}
    
		private void OnBackButtonTapped ()
		{
				if (mActiveViewType == ViewType.ARCAMERAVIEW) { //if it's in ARCameraView
                    Application.Quit();
				}
        
		}
    
		private void OnTappedOnCloseButton ()
		{
				mActiveViewType = ViewType.ARCAMERAVIEW;
		}
    
		private void OnAboutStartButtonTapped ()
		{
				mActiveViewType = ViewType.ARCAMERAVIEW;
		}
    
    #endregion PRIVATE_METHODS
    
}
