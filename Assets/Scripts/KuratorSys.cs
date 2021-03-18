//Kurator Register and Login


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KuratorSys : MonoBehaviour
{
	[SerializeField] string URL;
	//WWWForm login;
	[SerializeField] InputField Username;
	[SerializeField] InputField Password;
	[SerializeField] Button LoginButton;
	
	[SerializeField] Text ErrorMessage;
	
	WWWForm form;

	public void KuratorLogin(){
		LoginButton.interactable = false;
		StartCoroutine (Login());
		
	}
	
	IEnumerator Login(){
		form = new WWWForm ();
		form.AddField("username", Username.text);
		form.AddField("password", Password.text);
		
		WWW Kurial = new WWW (URL, form);
		yield return Kurial;
		
		if (Kurial.error != null) {
			ErrorMessage.text = "error";
			Debug.Log("<color=red>"+Kurial.text+"</color>");
		} else {
			if (Kurial.isDone) {
				if (Kurial.text.Contains ("error")) {
					ErrorMessage.text = "invalid username or password!";
					Debug.Log("<color=red>"+Kurial.text+"</color>");//error
				} else {
					SceneManager.LoadScene(0);
					Debug.Log("<color=green>"+Kurial.text+"</color>");//user exist
				}
			}
		}
		
		LoginButton.interactable = true;
		Kurial.Dispose();
		
	}
}
