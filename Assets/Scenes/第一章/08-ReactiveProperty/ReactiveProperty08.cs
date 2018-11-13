using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

/// <summary>
/// UNIRx中有一个很强大的概念  饺子ReactivePropety 响应式属性
/// 强大在哪里呢？ 他可以代替一切变量， 给变量创造了很多功能
/// 假如我们想监听一个值是否发生了改变
/// </summary>
public class ReactiveProperty08 : MonoBehaviour {
    //第二种方法 ReactiveProperty 实现
    public static ReactiveProperty<int> Age2 = new ReactiveProperty<int>(0); //Age2默认值赋值为0


    IntReactiveProperty intReactive = new IntReactiveProperty(0);

    //第一种方法 使用一般方法
    public Action<int> OnAgeChangeed = null;
    private int mAage;
    public int Age
    {
        get { return mAage; }
        set
        {
            if (mAage != value)
            {
                mAage = value;
                if (OnAgeChangeed != null)
                {
                    OnAgeChangeed(value);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        //第一种方法 使用一般方法
        OnAgeChangeed += (int age) =>
          {
              Debug.Log("inner received age changed");
          };
        //第一种方法 使用一般方法
        OnAgeChangeed += onChangeVoid;

       
        //第二种方法 ReactiveProperty 实现
        Age2.Subscribe(Age2 =>
        {
            Debug.Log("inner received age changed");
        });

        Age2.Value = 10;
        Age2.Value = 120;
    }
	public void onChangeVoid(int value)
    {
        Debug.Log("inner received age changed2");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
public class PersonView
{
    //第一种方法 使用一般方法
    ReactiveProperty08 property08;
    void init()
    {
        property08.OnAgeChangeed += age =>
        {
            Debug.Log("Age");
        };
        ReactiveProperty08.Age2.Subscribe(ss =>
        {
            Debug.Log("ss");
        });
    }

}