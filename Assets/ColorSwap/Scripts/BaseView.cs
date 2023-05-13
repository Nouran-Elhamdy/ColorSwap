using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    public virtual void ShowView()
    {
        gameObject.SetActive(true);    
    }
    public virtual void HideView()
    {
        gameObject.SetActive(false);
    }
}
[Serializable]
public struct View
{
    public ViewType viewType;
    public GameObject viewGameObject;
}

public enum ViewType
{
    StartView,
    GameView,
    LevelCompletedView
}