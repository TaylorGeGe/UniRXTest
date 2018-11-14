using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class WWW07 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ObservableWWW.Get("http://WWW.baidu.com").Subscribe(result => {
            Debug.Log(result);
        }  ,e => { 
            Debug.LogError("Error" + e);
        });


        var get1 = ObservableWWW.Get("http://WWW.baidu.com");

        var get2 = ObservableWWW.Get("http://www.sohu.com/");


        Observable.WhenAll(get1, get2).Subscribe(result =>
        {
            Debug.Log(result[0].Substring(0, 100));
            Debug.Log(result[1].Substring(0, 100));

        });

        #region 获取下载进度
        var progressObservable = new ScheduledNotifier<float>();

        ObservableWWW.GetAndGetBytes("http://www.sohu.com/" ,null, progress:progressObservable).Subscribe(bytes =>
        { 
        } );
         
        progressObservable.Subscribe(progress =>
        {
            Debug.LogFormat("进度为 {0}", progress);
        });
        #endregion
    }

    // Update is called once per frame
    void Update () {
		
	}
}

public interface M_A<T>
{ 
}
public class M_B<T> :M_A<T>
{ 
}
public class M_C
{ 
    public void Print(string s, string ss=null,M_A<float> m_A = null)
    { 
    }
} 
public class M_D
{ 
    public void Set()
    {
        M_C m_C = new M_C();
        var flatVar = new M_B<float>();

        m_C.Print("s", m_A: flatVar);


    }
}