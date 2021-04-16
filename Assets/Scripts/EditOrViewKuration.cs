using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditOrViewKuration : MonoBehaviour
{
    public sel sr;
    public Canvas editCanvas;
    public Canvas viewCanvas;
    
    
    void Start()
    {
        editCanvas.enabled = false;
        viewCanvas.enabled = false;
        sr = (sel)FindObjectOfType<sel>();
    }

    public void OnClick(){
        if( sr.editing == true) editKuration(); 
        else viewKuration();
    }

    public void editKuration(){
        editCanvas.enabled = true;
        editArtScript eas = GameObject.FindWithTag("edit").GetComponent<editArtScript>();
        eas.assetNamestr = "beans";
        eas.assetDescstr = "beans";
        eas.assetURLstr = "beans";
    }

    public void viewKuration(){
        viewCanvas.enabled = true;
        viewArtScript vas = GameObject.FindWithTag("view").GetComponent<viewArtScript>();
    }

}
