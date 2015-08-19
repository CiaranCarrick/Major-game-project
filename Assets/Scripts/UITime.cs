using UnityEngine;
using System.Collections;

public class UITime : UI{ //Inherit from UI class

	private int i=0;//Field for iterating though hold array
	public float[] hold=new float[10];


	public void LevelTime(){
		float total=0;//Local variables of Function
		i = wintrigger.Level-1;
		if (i <= hold.Length) {
			//print(time+"new:"+(float)(Mathf.Floor(time* 1000) / 1000));
			time=(float)(Mathf.Floor(time* 1000) / 1000);//Takes the float and truncates it down to 4 decimal places
			hold [i] = time;
			total += hold [i];
			i += 1;
			time = 0;
		} 
		else if(i==hold.Length){
			Debug.Log ("Total:" + total.ToString("f2"));
		}
	}
	//
	void Start(){
		if (FindObjectsOfType(GetType()).Length > 1)//Prevent copies of gameobject made, no time to look into Singletons 
		{
			Destroy(gameObject);
		}
			DontDestroyOnLoad (gameObject); //Dont destroy GameManager
	}
	void Update(){
		if (ShowUI == true) {
			time+= Time.deltaTime;
		}
	}

	void OnGUI(){
		guiStyle.fontSize = 10;guiStyle.normal.textColor = Color.white;//change the font size + colour
		GUI.Label (new Rect (5, 30, Screen.width, Screen.height), "Time: " + time.ToString ("f2"));
		GUI.Label (new Rect (5, 45, Screen.width, Screen.height), "LevelTimes:");
		GUI.Label (new Rect (5, 50, Screen.width, Screen.height), "\n"+hold [0]+"\n"+hold [1]+"\n"+hold [2]+"\n"+hold [3]+"\n"+hold [4]+"\n"+hold [5]
		           +"\n"+hold [6]+"\n"+hold [7]+"\n"+hold [8]+"\n"+hold [9], guiStyle);
	}
}
