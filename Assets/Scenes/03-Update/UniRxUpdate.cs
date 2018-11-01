using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class UniRxUpdate : MonoBehaviour {

	 // 2 第二种方法 利用 Unirx 
	void Start () {
        Observable.EveryUpdate().Subscribe((_) => {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("鼠标左键点击");
                mButtonClick = true;
            } 
        });
        Observable.EveryUpdate().Subscribe((_) => {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("鼠标右键点击");
                mButtonClick = true;
            } 
        });
        Observable.EveryUpdate().Subscribe(_=> {
            if (mButtonClick && mButtonState == ButtonState.None)
            {
                mButtonState = ButtonState.Clicked;
            }
        });
       

    }
    public enum ButtonState
    {
        None,
        Clicked,
        Dobleclicked,
    }
   public   ButtonState mButtonState ;

    private bool mButtonClick = false;
	// 1 第一种方法  利用update 
	void Updaste () {

        CheckLeftMouseClicked();
         
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("鼠标右键点击");
            mButtonClick = true;
        }
        if (mButtonClick && mButtonState==ButtonState.None)
        {
            mButtonState = ButtonState.Clicked;
        }

    }

    void CheckLeftMouseClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("鼠标左键点击");
            mButtonClick = true;
        }
    }

}
