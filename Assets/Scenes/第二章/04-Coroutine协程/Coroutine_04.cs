using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class Coroutine_04 : MonoBehaviour {


    IEnumerator CoroutineA()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("A");
    }

	// Use this for initialization
	void Start () {
        //StartCoroutine(CoroutineA());
        StartCoroutine(delaySecond());
        //Observable.FromCoroutine( _=> CoroutineA() ).Subscribe(     _ => {   }     );

    }
    public IEnumerator delaySecond()
    { 
       yield return Observable.Timer(System.TimeSpan.FromSeconds(1f)).ToYieldInstruction();
        Debug.Log("delay second");

    }

	public IEnumerator Test()
    {
        return CoroutineA();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
