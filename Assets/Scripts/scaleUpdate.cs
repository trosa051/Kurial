﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scaleUpdate : MonoBehaviour
{
    public Slider inSlide;
    public InputField inInput;
    
    void Awake() {
        //inInput.text = string.Format("{0:G}", 1f);
        inSlide.value = float.Parse(inInput.text);
        //inInput.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
    }

    public void SliderControl(System.Single val){
        inInput.text = string.Format("{0:G}", val);
    }

    public void InputControl(UnityEngine.UI.Text val){
        inSlide.value = float.Parse(val.text);
    }
}
