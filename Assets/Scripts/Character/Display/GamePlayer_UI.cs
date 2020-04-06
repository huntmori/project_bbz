using UnityEngine;
using System.Collections;

public class GamePlayer_UI : MonoBehaviour {

	GameObject[] players;
	// Use this for initialization
	void Start () {
		players = GameObject.FindGameObjectsWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
        /*
		Player_PointBar_Display ppd;
		foreach(GameObject go in players)
		{
			ppd = (Player_PointBar_Display)go.GetComponent("Player_PointBar_Display");
			float barLength = ppd.healthBarLength;


            //?무엇을 암시하는 거시지?
			GUI.Box
			(
				new Rect
				(
					Screen.width/2 - 20, Screen.height/2+300,
					barLength, 25f
				)
				,""
			);
            
		}*/
    }
}
