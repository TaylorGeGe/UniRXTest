using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class CoroutineWhenAll05 : MonoBehaviour {

    [SerializeField]
    Button m_btnA;
    [SerializeField]
    Button m_btnB;
    [SerializeField]
    Button m_btnC;
    IEnumerator A()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("A");
    }
    IEnumerator B()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("B");
    }
    IEnumerator C()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("C");
    }

    // Use this for initialization
    void Start () {
     //   var Asteam = Observable.FromCoroutine(_ => A());
      //  var Bsteam = Observable.FromCoroutine(_ => B());
      //  var Csteam = Observable.FromCoroutine(_ => C());

       // Observable.WhenAll(Asteam, Bsteam, Csteam).Subscribe(_ => { Debug.Log("When All 处理了"); });

      //  var m_btnAClick = m_btnA.OnClickAsObservable().First();
       // var m_btnBClick = m_btnB.OnClickAsObservable().First();
      //  var m_btnCClick = m_btnC.OnClickAsObservable().First();

      //  Observable.WhenAll(m_btnAClick, m_btnBClick, m_btnCClick).Subscribe(_ => { Debug.Log("完成了一轮点击"); }).AddTo(this);

        Observable.EveryUpdate().Subscribe(_ => { Debug.Log("update"); }, () => { Debug.Log("end"); });  //end永远不会执行
        Observable.EveryUpdate().First().Subscribe(_ => { Debug.Log("update"); }, () => { Debug.Log("end"); });

        Observable.FromCoroutine(A).Subscribe(_ => { Debug.Log("2333"); }, () => { Debug.Log("end"); }); //2333 和 end 只执行了一次 2333 不会多次执行
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
