using UnityEngine;
using System.Collections;

public class change_sort_script : MonoBehaviour {
	private int rr = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		rr = UnityEngine.Random.Range(0,2);
		if(rr == 0)
			c.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "back";
		else if(rr == 1)
			c.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "forward";

		//Debug.Log ("ff");
	}

}
