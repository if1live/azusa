/*============================================================================== 
 * Copyright (c) 2012-2013 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// UI Event Handler class that handles events generated by user-tap actions
/// over the UI Options Menu
/// </summary>
public class BackgroundTextureUIEventHandler : UIEventHandler { 
    
    #region PUBLIC_MEMBER_VARIABLES
    public override event System.Action CloseView;
    public override event System.Action GoToAboutPage;
    public static bool offTargetTrackingIsEnabled = false;

	private static BackgroundTextureUIEventHandler instance;
	public static BackgroundTextureUIEventHandler getInstance(){
		return instance;
	}

    #endregion PUBLIC_MEMBER_VARIABLES
    
    #region PRIVATE_MEMBER_VARIABLES
    private BackgroundTextureUIView mView;
    private bool mCameraFacingFront;
    #endregion PRIVATE_MEMBER_VARIABLES
    
    #region PUBLIC_MEMBER_PROPERTIES
    public BackgroundTextureUIView View
    {
        get {
            if(mView == null){
                mView = new BackgroundTextureUIView();
                mView.LoadView();
            }
            return mView;
        }
    }
    #endregion PUBLIC_MEMBER_PROPERTIES
    
    #region PUBLIC_METHODS
    public override void UpdateView (bool tf)
    {
		instance = this;
        this.View.UpdateUI(tf);
    }
    
    public override  void Bind()
    {
        this.View.mCameraFlashSettings.TappedOn += OnTappedToTurnOnFlash;
        this.View.mAutoFocusSetting.TappedOn    += OnTappedToTurnOnAutoFocus;
        this.View.mCloseButton.TappedOn         += OnTappedOnCloseButton;
        this.View.mAboutLabel.TappedOn          += OnTappedOnAboutButton;
        
        EnableContinuousAutoFocus();
    }
    
    public override  void UnBind()
    { 
        this.View.mCameraFlashSettings.TappedOn -= OnTappedToTurnOnFlash;
        this.View.mAutoFocusSetting.TappedOn    -= OnTappedToTurnOnAutoFocus;
        this.View.mCloseButton.TappedOn         -= OnTappedOnCloseButton;
        this.View.mAboutLabel.TappedOn          -= OnTappedOnAboutButton;
    
        this.View.UnLoadView();
        mView = null;
    }
    
    //SingleTap Gestures are captured by AppManager and calls this method for TapToFocus
    public override  void TriggerAutoFocus()
    {
        StartCoroutine(TriggerAutoFocusAndEnableContinuousFocusIfSet());
    }
    
    public override  void SetToDefault(bool tf)
    {
        this.View.mCameraFlashSettings.Enable(tf);
    }
    #endregion PUBLIC_METHODS
    
    #region PRIVATE_METHODS
    /// <summary>
    /// Activating trigger autofocus mode unsets continuous focus mode (if was previously enabled from the UI Options Menu)
    /// So, we wait for a second and turn continuous focus back on (if options menu shows as enabled)
    /// </returns>d on in the UIMenu.
    private IEnumerator TriggerAutoFocusAndEnableContinuousFocusIfSet()
    {
        //triggers a single autofocus operation 
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO)) {
              this.View.FocusMode = CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO;
        }
        
        yield return new WaitForSeconds(1.0f);
         
        //continuous focus mode is turned back on if it was previously enabled from the options menu
        if(this.View.mAutoFocusSetting.IsEnabled)
        {
            if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO)) {
              this.View.FocusMode = CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO;
            }
        }
        
        Debug.Log (this.View.FocusMode);
        
    }
    
    public void OnTappedOnAboutButton(bool tf)
    {
        if(this.GoToAboutPage != null)
        {
            this.GoToAboutPage();
        }
    }
    
    //We want autofocus to be enabled when the app starts
    public void EnableContinuousAutoFocus()
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
        {
            this.View.FocusMode = CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO;
            this.View.mAutoFocusSetting.Enable(true);
        }
    }
    
    public void OnTappedToTurnOnFlash(bool tf)
    {
        if(tf)
        {
            if(!CameraDevice.Instance.SetFlashTorchMode(true))
            {
                this.View.mCameraFlashSettings.Enable(false);
            }
        }
        else 
        {
            CameraDevice.Instance.SetFlashTorchMode(false);
        }
        
        OnTappedToClose();
    }
    
    public void OnTappedToTurnOnAutoFocus(bool tf)
    {
        if(tf)
        {
            if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
            {
                this.View.FocusMode = CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO;
            }
            else 
            {
                this.View.mAutoFocusSetting.Enable(false);
            }
        }
        else 
        {
            if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL))
            {
                this.View.FocusMode = CameraDevice.FocusMode.FOCUS_MODE_NORMAL;
            }
        }
        
        OnTappedToClose();
    }
    
    private void OnTappedToClose()
    {
        if(this.CloseView != null)
        {
            this.CloseView();
        }
    }
    
    private void OnTappedOnCloseButton()
    {
        OnTappedToClose();
    }
    
    #endregion PRIVATE_METHODS
}

