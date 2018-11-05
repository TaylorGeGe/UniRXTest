using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class First06 : MonoBehaviour {

	// Use this for initialization
	void Start () {
         Observable.EveryUpdate() //事件源  /数据源   发布者
           //方法1
           //.Where(_ => Input.GetMouseButtonDown(0))
           //方法1
           // .First().Subscribe(_ =>
           //方法2
           .First(_=>Input.GetMouseButtonDown(0))  //处理 组织 整理
           .Subscribe(_ =>  //订阅者
           {
            Debug.Log("First MouseButtonDown");
        }).AddTo(this); //生命周期绑定
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
