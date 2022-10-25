using UnityEngine;
using System.Collections;

public class close_script : MonoBehaviour {
	public GameObject shop_out;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void close_shop(){
		shop_out.SetActive(false);
		game_manager.shop_now = false;
	}
}
