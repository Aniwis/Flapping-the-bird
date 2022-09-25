using System;
using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRecovery : MonoBehaviour
{
    [SerializeField] private Button _recoverofButton;

    private Coroutine _passwordResetCoroutine;
    [SerializeField] private GameObject recuperacion;
    private void Reset()
    {
        _recoverofButton = GetComponent<Button>();
    }
    private void Start()
    {
        _recoverofButton.onClick.AddListener(HandleResetPasswordButtonClicked);
    }
    private void HandleResetPasswordButtonClicked()
    {
        string email = GameObject.Find("InputEmail").GetComponent<InputField>().text;
        _passwordResetCoroutine = StartCoroutine(PasswordReset(email));
        recuperacion.SetActive(true);
    }
    private IEnumerator PasswordReset(string emailAddress)
    {
        var auth = FirebaseAuth.DefaultInstance;
        var user = auth.CurrentUser;
        var passwordResetTask = auth.SendPasswordResetEmailAsync(emailAddress);
        
        yield return new WaitUntil(() => passwordResetTask.IsCompleted);

        if (user != null)
        {
            if (passwordResetTask.IsCanceled)
            {
                Debug.LogError("SendPasswordResetEmailAsync was canceled.");
            }
            if (passwordResetTask.IsFaulted)
            {
                Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + passwordResetTask.Exception);
            }
            Debug.Log("Password reset email sent successfully.");
        }
    }

}

