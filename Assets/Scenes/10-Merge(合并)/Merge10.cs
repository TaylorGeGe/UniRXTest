using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class Merge10 : MonoBehaviour {

	 
	void Start () {
        var leftmouseButtonDown = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
        var rightmouseButtonDown = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1));
        Observable.Merge(leftmouseButtonDown, rightmouseButtonDown).Subscribe(_ => {
            Debug.Log("点击了鼠标左键或者右键");

        });

	}
	
	  
}
