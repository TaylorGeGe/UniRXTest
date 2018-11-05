using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class Where05 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Observable.EveryUpdate()
            .Where((_) =>  Input.GetMouseButtonDown(0))
            .Subscribe(_ => { Debug.Log("OnMouseButtonDown"); })
            .AddTo(this);
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
