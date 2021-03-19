//Kurator Register and Login


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
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
		
		var kurator = UnityWebRequest.Post("http://kurial.space/php/login.php", Kurial);
        
        yield return kurator.SendWebRequest();
//getting error for result not existing and im lost
//reference https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequest.Post.html
        if (kurator.result != UnityWebRequest.Result.Success)
		{
			Debug.Log(kurator.error);
        }
        else
        {
			Debug.Log("Form upload complete!");
        }
		
		LoginButton.interactable = true;
				
	}
}
