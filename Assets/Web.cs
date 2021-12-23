using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Login("testuser" , "852"));
    }

    IEnumerator GetDate()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/Game/GetDate.php"))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);

                byte[] results = webRequest.downloadHandler.data;

            }

        }

    }

    /*IEnumerator GetUsers()
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/Game/GetUsers.php"))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);

                byte[] results = webRequest.downloadHandler.data;

            }

        }

    }*/

    public IEnumerator Login(string username , string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/Game/ajax/loginAjax.php", form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
            }

        }

    }
}
