using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript2 : MonoBehaviour {
	public NewBehaviourScript2()
	{
	}
	public int getNumber()
	{
		return ((int.Parse (text.text) + 1)%10);;
	}
	void Start () {
		text = GetComponentsInChildren <Text> ()[0];
		text.text = "3";
		button = GetComponent<Button> ();
		time = 0;
		time1 = Time.time;
	}
	int time = 0;
	Text text;
	Button button;
	float time1;
	void change()
	{
		//time2 = Time.time;
		if (time == 0) {
			int no = ((int.Parse (text.text) + 1)%10);
			text.text = no.ToString ();
			Debug.Log (int.Parse (text.text));
			time++;
		}
	}
	// Update is called once per frame
	void Update () {
		button.onClick.AddListener(()=>change());
		if (Time.time - time1 > 0.1)
			time = 0;
	}
}
