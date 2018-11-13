using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class LoginPanel01 : MonoBehaviour {

    Button m_loginBtn;

    InputField m_userName;

    InputField m_passworld;
    Button m_register;

    Button m_registerBtn;
    Button m_backBtn;

    InputField m_registerUsername;
    InputField m_registerpassworld1;
    InputField m_registerpassworld2;


    // Use this for initialization
    void Start () {
        m_loginBtn = transform.Find("LoginPanel/Login").GetComponent<Button>();

        m_userName = transform.Find("LoginPanel/userName").GetComponent<InputField>();

        m_passworld = transform.Find("LoginPanel/password").GetComponent<InputField>();

        m_register = transform.Find("LoginPanel/Register").GetComponent<Button>();

        m_registerBtn = transform.Find("RegisterPanel/Register").GetComponent<Button>();
        m_backBtn = transform.Find("RegisterPanel/Back").GetComponent<Button>();
        m_registerUsername = transform.Find("RegisterPanel/userName").GetComponent<InputField>();
        m_registerpassworld1 = transform.Find("RegisterPanel/password1").GetComponent<InputField>();
        m_registerpassworld2 = transform.Find("RegisterPanel/password2").GetComponent<InputField>();



        m_loginBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("On login Clicked");
        });

        m_userName.OnEndEditAsObservable().Subscribe(txt =>
        {
            Debug.Log("Username为" + txt);
            m_passworld.Select(); //跳转到下一个
        });
        m_passworld.OnEndEditAsObservable().Subscribe(txt =>
        {
            Debug.Log("password为" + txt);
            //m_loginBtn.Select();
            m_loginBtn.onClick.Invoke();
        });

        m_register.OnClickAsObservable().Subscribe(_ => {
            Debug.Log("register");
        });




        m_registerBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("On m_registerBtn Clicked");
        });
        m_backBtn.OnClickAsObservable().Subscribe(_ =>
        {
            Debug.Log("On m_registerBtn Clicked");
        });
        m_registerUsername.OnEndEditAsObservable().Subscribe(txt =>
        {
            Debug.Log("m_registerUsername " + txt);

            m_registerpassworld1.Select();
        });
        m_registerpassworld1.OnEndEditAsObservable().Subscribe(txt =>
        {
            Debug.Log("m_registerUsername " + txt);
            m_registerpassworld2.Select();
        });
        m_registerpassworld2.OnEndEditAsObservable().Subscribe(txt =>
        {
            Debug.Log("m_registerUsername " + txt);
            m_registerBtn.onClick.Invoke();

        });

    }

    // Update is called once per frame
    void Update () {
		
	}
}
