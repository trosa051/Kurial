//Kurator Register and Login


using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KuratorSys : MonoBehaviour
{
	[SerializeField] InputField Email;
	[SerializeField] InputField Password;
	[SerializeField] Button LoginButton;
	
	[SerializeField] Text ErrorMessage;
	
	
	public void KuratorLogin(){
		LoginButton.interactable = false;
		StartCoroutine (Login());
		
	}
	
	IEnumerator Login(){
		WWWForm Kurial = new WWWForm();
		Kurial.AddField("email", Email.text);
		Kurial.AddField("password", Password.text);
		
		using (UnityWebRequest www = UnityWebRequest.Post("http://kurial.space/php/login.php", Kurial))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
		}
				
		LoginButton.interactable = true;
		Kurial.Dispose();
		
	}
}
