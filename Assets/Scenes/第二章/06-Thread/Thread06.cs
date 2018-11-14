using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;
public class Thread06 : MonoBehaviour {

	// Use this for initialization
	void Start () {
      var threadAStream =  Observable.Start(() =>
        { 
            Thread.Sleep(System.TimeSpan.FromSeconds(1));
            return 10;
        });

        var threadBStream = Observable.Start(() =>
        {
            Thread.Sleep(System.TimeSpan.FromSeconds(1));
            return 10;
        });
        //等等两个线程结束以后转到主线程  解决线程的管理问题
        Observable.WhenAll(threadAStream, threadBStream).ObserveOnMainThread().Subscribe(result =>
         {
             Debug.LogFormat("{0}:{1}", result[0], result[1]);
         });

    }

    // Update is called once per frame
    void Update () {
		
	}
}
