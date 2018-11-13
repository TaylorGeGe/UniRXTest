using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class PaneEventLock11 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var btna=   transform.Find("ButtonA").GetComponent<Button>();
        var btnb = transform.Find("ButtonB").GetComponent<Button>();
        var btnc = transform.Find("ButtonC").GetComponent<Button>(); 
          var a=  btna.OnClickAsObservable().Select(_=>"A");
          var b=  btnb.OnClickAsObservable().Select(_ => "B");
          var c = btnc.OnClickAsObservable().Select(_ => "C");
        Observable.EveryUpdate().Select(ha => ha+10).Subscribe(_ =>
        {
            Debug.Log(_);
        });
        Observable.Merge(a, b, c).First().Subscribe(haha => {
            Debug.LogFormat("ooooo{0}",haha);
        Observable.Timer(System.TimeSpan.FromSeconds(3f))
            .Subscribe(
            __ => { this.gameObject.SetActive(false);
            });
        });

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
