using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCenvasManager : MonoBehaviour 
{
    public MainCenvasManager Instance;
    private void Awake() 
	{
        Instance = this;
    }
}
