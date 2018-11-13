using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class UnityRxUndate02 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Observable.EveryFixedUpdate().Subscribe(_ => { Debug.Log("EveryFixedUpdate"); }).AddTo(this);  //
        Observable.EveryLateUpdate().Subscribe(_ => { Debug.Log("EveryLateUpdate"); }).AddTo(this);
        Observable.EveryUpdate().Subscribe(_ => { Debug.Log("EveryUpdate"); }).AddTo(this);
        Observable.EveryFixedUpdate().Subscribe(_ => { Debug.Log("EveryFixedUpdate"); }).AddTo(this);

        
        #region 这两个相等 都是当前对象销毁后不再调用

        Observable.EveryUpdate().Subscribe(_ => { Debug.Log("EveryUpdate"); }).AddTo(this);  //== 
        this.UpdateAsObservable().Subscribe(_ => { });
        #endregion
    }

    // Update is called once per frame
    void Update () {
		
	}
}
