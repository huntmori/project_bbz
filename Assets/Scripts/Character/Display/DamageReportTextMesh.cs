using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReportTextMesh : MonoBehaviour {
    public TextMesh DamageReport;
    public float Damage;
    Color textColor;
    public float spwanTime = 2;
    public float killTime = 3;
    public float previousTime = 0;
    bool hasChanged = false;


	// Use this for initialization
	void Start ()
    {
        textColor = DamageReport.color;
        textColor.a = 0;    //알파값
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
