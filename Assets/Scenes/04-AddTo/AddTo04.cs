using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class  AddTo04 : MonoBehaviour {

    //AddTo 答案是用来进行与销毁时间的绑定 也就是当gameobject或者MonoBehaviour 被销毁的同时去销毁正在进行的UNIRx的任务；
    //当this所在的gameobject销毁时 这个timer就会被销毁  更安全
    void Start () {
        Observable.Timer(System.TimeSpan.FromMinutes(1f))
            .Subscribe()
            .AddTo(this); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
