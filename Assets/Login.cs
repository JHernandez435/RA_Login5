using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;

    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button LoginButton;

    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Login(UsernameInput.text, PasswordInput.text));
        });
    }

    public void ShowLogin()
	{
		m_registerUI.SetActive(false);
		m_loginUI.SetActive(true);

	}
	public void ShowRegister()
	{
		m_registerUI.SetActive(true);
		m_loginUI.SetActive(false);

	}

}
