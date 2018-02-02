using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DebugManager : MonoBehaviour 
{
    public static DebugManager Instance;

    public Text text;

    private void Awake() 
	{
        Instance = this;
	}
	
	public  void Print (string text) 
	{
        this.text.text += Environment.NewLine + text;
	}
}
