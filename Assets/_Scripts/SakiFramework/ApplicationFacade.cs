using PureMVC.Patterns.Facade;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationFacade : Facade
{
    private ApplicationFacade()
    {
        instance = new ApplicationFacade();
    }

    public static ApplicationFacade GetInstance()
    {
        return (ApplicationFacade)instance;
    }

    public void Init()
    {
        Debug.Log("GameStar");
    }

    protected override void InitializeFacade()
    {
        base.InitializeFacade();
    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
    }

    protected override void InitializeView()
    {
        base.InitializeView();
    }

    protected override void InitializeController()
    {
        base.InitializeController();
    }
}
