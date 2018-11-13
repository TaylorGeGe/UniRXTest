using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Test01_InputMouse : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_=> isDown()) 
            .First()
            .Subscribe(_=> DebugLog()); 

         
    }

    public Action action;
    Action<string> loaded;
    public void hahah(string st)
    { 
        Debug.Log(st);
    }
    public void hahah2(Action<string> loaded )
    {
      
        Debug.Log("哈哈哈");
        loaded("??");
    } 
    public static void test(Action<string> loaded)
    {

        //loaded("我是我啊");

       // Debug.Log("那我是谁");

    }
    public bool isDown()
    {
        return Input.GetMouseButtonDown(0);
    }
    public void DebugLog()
    {
        Debug.Log("Mouse left Down");
    }
}
