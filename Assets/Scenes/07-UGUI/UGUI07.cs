using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx.Triggers;
public class UGUI07 : MonoBehaviour 
{
    public Button m_Button;
    public Slider m_Slider;
    public Toggle m_toggle;
    public Image m_Image;

     

    void Start () {
        m_Button.OnClickAsObservable().Subscribe(_ => { Debug.Log("OnClickButton"); });
        m_Slider.OnValueChangedAsObservable().Subscribe(_ => { Debug.Log("Slider"+m_Slider.value); });
        m_toggle.OnValueChangedAsObservable()
            .Where(isDown=> isDown) //只处理ison=true
            .Where(isDown=> !isDown) //只处理on=false
            .Subscribe(isDown => { Debug.Log(isDown); });

        m_Image.OnBeginDragAsObservable().Subscribe(_ => { Debug.Log("begin");  });
        m_Image.OnDragAsObservable().Subscribe(_ => { Debug.Log("drag"); });
        m_Image.OnEndDragAsObservable().Subscribe(_ => { Debug.Log("end"); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
