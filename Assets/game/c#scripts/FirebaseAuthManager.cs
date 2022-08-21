using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;

public class FirebaseAuthManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private FirebaseUser user;

    public InputField email;
    public InputField password;

    // Start is called before the first frame update
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }
    public void Create()
    {
            auth.CreateUserWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
            {
                if(task.IsCanceled)
                {
                    Debug.Log("회원가입 취소");
                    return;
                }
                if(task.IsFaulted)
                {
                    //회원 가입 실패 이유 > 이메일 비정상, 비밀번호 간단, 이미 가입된 이메일 등등...
                    Debug.Log("회원가입 실패");
                    return;
                    //
                }
                FirebaseUser newUser = task.Result;
                Debug.Log("회원가입 완료");
            });
    }
    public void Login()
    {
            auth.SignInWithEmailAndPasswordAsync(email.text, password.text).ContinueWith(task =>
            {
                if(task.IsCanceled)
                {
                    Debug.Log("회원가입 취소");
                    return;
                }
                if(task.IsFaulted)
                {
                    //회원 가입 실패 이유 > 이메일 비정상, 비밀번호 간단, 이미 가입된 이메일 등등...
                    Debug.Log("회원가입 실패");
                    return;
                    //
                }
                FirebaseUser newUser = task.Result;
                Debug.Log("회원가입 완료");
            });
    }
    public void Logout()
    {
        auth.SignOut();
        Debug.Log("로그아웃");
    }
}
