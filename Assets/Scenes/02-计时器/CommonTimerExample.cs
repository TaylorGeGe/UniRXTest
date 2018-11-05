using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class CommonTimerExample : MonoBehaviour {
    private float mStartTime;
    void Start() {
        // 方法1  传统实现方法
        mStartTime = Time.time;

        //方法2 协程方式实现
        StartCoroutine(Timer(2, () => { Debug.Log(" 协程  do sm" ); }));

        //方法3 uniRx方式实现
        Observable.Timer(TimeSpan.FromSeconds(5.0f)).Subscribe(_ => { Debug.Log(" uniRx do sm"); });
    }
	
	// Update is called once per frame
	void Update () {

        // 方法1  传统实现方法
        if (Time.time-mStartTime>5)
        {
            //
            Debug.Log("传统  do sm");

            mStartTime = float.MaxValue;
        }
	}
    
   IEnumerator Timer(float seconds,Action  action)
    {
        yield return new WaitForSeconds(seconds);
        action(); 
    }
}
