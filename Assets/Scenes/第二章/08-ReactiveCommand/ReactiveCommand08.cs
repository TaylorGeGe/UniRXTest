using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class ReactiveCommand08 : MonoBehaviour {

	// Use this for initialization
	void Start () {

        #region ReactiveCommand 用法

        var leftMouseDown = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0)).Select(_=>true);
        var leftMouseUp = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0)).Select(_ => false);

        //进行合并 点击或者 松开鼠标
        var  isMouseUp=   Observable.Merge(leftMouseUp, leftMouseDown);

        //如果 ReactiveCommand 的ReactiveProperty<bool> canExecut ==true的话就 自动执行 Execute ()方法 
        var reactiveCommand = new ReactiveCommand(isMouseUp, false);

        reactiveCommand.Subscribe(_ => {

            Debug.Log("Reactive command executed");
        });

        Observable.EveryUpdate().Subscribe(_ =>
        {
            reactiveCommand.Execute();

        });
        #endregion


        #region  ReactiveCommand  泛型用法
        var reactiveCommandT = new ReactiveCommand<int>();

        reactiveCommandT.Where(x => x % 2 == 0).Subscribe(_ => {
            Debug.Log("是偶数");

        });
        reactiveCommandT.Where(x => x % 2 != 0).Timestamp().Subscribe(x => {

            Debug.LogFormat("{0}是奇数",x.Value,x.Timestamp);
        });

        reactiveCommandT.Execute(10);
        reactiveCommandT.Execute(11);

        #endregion
    }

    // Update is called once per frame
    void Update () {
		
	}
}
