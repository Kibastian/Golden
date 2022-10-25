using UnityEngine;
using System.Collections;

public class rare_object : MonoBehaviour {
	public int rare_id = 1;
	public GameObject cardboard_manager;

	// Use this for initialization
	void Start () {
		cardboard_manager = GameObject.Find("Box");
		this.gameObject.GetComponent <Animator>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		//	SoundManager.Instance.PlaySE(0);
		this.gameObject.GetComponent <Animator>().enabled = false;
		Debug.Log ("taprare");
		cardboard_manager.SendMessage("tap_rare",2);
		StartCoroutine ("pop_close");
	}

	private IEnumerator pop_close(){
		yield return new WaitForSeconds(0.1f);
		Destroy (this.gameObject);

	}

	void close_this(){
		Destroy (this.gameObject);
		//this.gameObject.SetActive(false);
	}
}
