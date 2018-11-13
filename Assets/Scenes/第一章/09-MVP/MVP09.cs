using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

//简单的mvp架构的实现

    //V vivw Hierarcy 面板展示的内容
    //C Controller   P(presenter) 展示器 (节目主持人)
public class MVP09 : MonoBehaviour {
   
   public  Enemy enemy;
    public Button button;
    public Text Text;
	// Use this for initialization
	void Start () {
        enemy = new Enemy(200);
       
        button = GameObject.Find("Button").GetComponent<Button>();
        Text = GameObject.Find("Text").GetComponent<Text>();
       
       // Debug.Log(enemy.IsDie.Value);
        button.OnClickAsObservable().Subscribe(_ => { enemy.Hp.Value -= 100;
        
           // Text.text+="  "+enemy.IsDie.Value .ToString()  ;
        } );
        enemy.Hp.SubscribeToText(Text);
        enemy.Hp.Value = 20;
        enemy.IsDie
             .Where(IsDeads => IsDeads)
             .Select(IsDead => !IsDead) // 类型的转换  IsDie的value 转换成！IsDie的value
            .SubscribeToInteractable(button);
      //  Debug.Log(enemy.IsDie.Value);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //M   model
    public class Enemy
    {
        public ReactiveProperty<int> Hp = null;  // hp
        public IReadOnlyReactiveProperty<bool> IsDie = null; //只读的 
        public Enemy(int InitHp)
        {
            this.Hp = new ReactiveProperty<int>(InitHp);
           IsDie = this.Hp.Select(hp => hp <= 0).ToReactiveProperty();  //hp 代表 HP的value
        }

    }
}


