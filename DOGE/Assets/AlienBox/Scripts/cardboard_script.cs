using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Advertisements;

public class cardboard_script : MonoBehaviour {
	public GameObject pop_point;
	public GameObject chara_pref1;
	public GameObject chara_pref2;
	public GameObject chara_pref3;
	public GameObject chara_pref4;
	public GameObject chara_pref5;
	public GameObject chara_pref6;
	public GameObject chara_pref7;
	public GameObject chara_pref8;
	public GameObject chara_pref9;
	public GameObject chara_pref10;
	public GameObject chara_pref11;
	public GameObject chara_pref12;
	public GameObject rare_pref1;
	public GameObject rare_pref2;
	public GameObject data_manager;
	public int diamond_count = 0;
	private float startTime = 0f;
	private float startTime2 = 0f;
	private float startTime3 = 0f;
	private float  progressTime = 0f;//normal
	private float  progressTime2 = 0f;//rare1
	private float  progressTime3 = 0f;//rare2
	private bool ActiveClick = true;
	public Text gold_text;

	private int credit_lv = 0;
	private string credit_text = "";
	private List<int[]> cointype_date = new List<int[]>();//id,probability of appearance
	private List<List<string>> coin_value_dates = new List<List<string>>();
	private List<string> cointype_rare = new List<string>();
	private List<ulong> coin_value = new List<ulong>();
	//private ulong[] get_golds = {1,100,10000,1000000,100000000,10000000000,1000000000000,100000000000000,500000000000000,10000000000000000};
	private GameObject use_chara_pref = null;
	//private Sprite[] credits = new Sprite[4];
	// Use this for initialization
	void Start () {


	}

	void first_manage_set(){
		startTime = Time.time;
		startTime2 = Time.time;
		startTime3 = Time.time;
		get_coin_value_dates();
		gold_manage_set();
	}


	void set_cointype(List<string> send_type){
		cointype_rare.Clear();
		cointype_rare = send_type;
		cointype_date.Clear();
		if(int.Parse(send_type[2]) >= 1){
			int[] coin = {1,int.Parse(send_type[2])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[3]) >= 1){
			int[] coin = {2,int.Parse(send_type[3])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[4]) >= 1){
			int[] coin = {3,int.Parse(send_type[4])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[5]) >= 1){
			int[] coin = {4,int.Parse(send_type[5])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[6]) >= 1){
			int[] coin = {5,int.Parse(send_type[6])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[7]) >= 1){
			int[] coin = {6,int.Parse(send_type[7])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[8]) >= 1){
			int[] coin = {7,int.Parse(send_type[8])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[9]) >= 1){
			int[] coin = {8,int.Parse(send_type[9])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[10]) >= 1){
			int[] coin = {9,int.Parse(send_type[10])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[11]) >= 1){
			int[] coin = {10,int.Parse(send_type[11])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[12]) >= 1){
			int[] coin = {11,int.Parse(send_type[12])};
			cointype_date.Add(coin);
		}
		if(int.Parse(send_type[13]) >= 1){
			int[] coin = {12,int.Parse(send_type[13])};
			cointype_date.Add(coin);
		}
	}

	// Update is called once per frame
	void Update () {

		progressTime = (Time.time - startTime);
		progressTime2 = (Time.time - startTime2);
		progressTime3 = (Time.time - startTime3);

		if (progressTime >= 1) {
			progressTime -= 1;
			startTime = Time.time;
			if (game_manager.nFake == 0 && game_manager.auto_lv >= 20)
			{
				for (int i = 0; i < 3; i++)
				{
					Vector3 pos2 = new Vector3(UnityEngine.Random.RandomRange(-1.5f, 1.5f), 1f, 2);
					GameObject new_chara = Instantiate( chara_pref5, pos2, transform.rotation) as GameObject;
					//new_chara.GetComponent<Rigidbody2D>().velocity = transform.up * 1;


					new_chara.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, UnityEngine.Random.Range(320, 360)));
				}
				game_manager.golds += (ulong)((int)(game_manager.auto_lv) / 20  * 5)+(game_manager.BoostAutoClick*50ul);
				game_manager.Currency += (ulong)((int)(game_manager.auto_lv) / 20 * 5) + (game_manager.BoostAutoClick *50ul);
				gold_text.text = game_manager.golds.ToString("");
				
			}
		}

		if (progressTime2 >= 40) {
			progressTime2 -= 40;
			startTime2 = Time.time;
			Debug.Log ("rare2");
			if (UnityEngine.Random.Range(0, 8/((game_manager.CrystallChance)?3:1)) == 0) rare_popup2();
		}
		//if (progressTime3 >= 60) {
		//	progressTime3 -= 60;
		//	startTime3 = Time.time;
		//	Debug.Log ("rare2");
		//	if(UnityEngine.Random.Range (0,6) == 0)
		//	rare_popup2();
		//}
	}

	void rare_popup1(){
		Debug.Log ("rea1");

		Vector3 pos = new Vector3(-4.5f, 3f, 0f);
		
		GameObject p_r = Instantiate(rare_pref1, pos, transform.rotation) as GameObject;
		p_r.GetComponent<rare_object>().rare_id = 1;

	}

	void rare_popup2(){
		Debug.Log ("rea2");
		Vector3 pos2 = new Vector3(UnityEngine.Random.value*4f-1.5f, 5f, 0f);
		
		GameObject p_r = Instantiate(rare_pref2, pos2, transform.rotation) as GameObject;
		p_r.SetActive(true);
		//p_r.GetComponent<rare_object>().rare_id = 2;

	}


	void auto_popup(){

		popup_chara_set(UnityEngine.Random.Range (1,101));
		//this.gameObject.GetComponent<Animator>().SetTrigger("tap");
		gold_text.text = game_manager.golds.ToString("");
		gold_manage_set();
	}

	//TapCardBoard
	void OnMouseDown () {
		if(!game_manager.shop_now){
		if(!game_manager.sound_mute) SoundManager.Instance.PlaySE();
			this.gameObject.GetComponent<Animator>().SetTrigger("tap");
			if (ActiveClick == false) return;
			StartCoroutine(DeactiveClick());
			if (game_manager.nFake == 0)
			{
				//for (int i = 0; i < game_manager.tap_num; i++)
				//{
				popup_chara_set(UnityEngine.Random.Range(1, 101));
				if (diamond_count > 100/ (game_manager.DimondChance ? 3 : 1))
				{
					diamond_count = 0;
						game_manager.golds += 60*(ulong)(game_manager.DimondMulti?5:1);
						game_manager.Currency += 60 * (ulong)(game_manager.DimondMulti ? 5 : 1);
				}
				else diamond_count++;
				if(game_manager.BoostX)
                {
					game_manager.golds += 19;
					game_manager.Currency += 19;
				}
				else if(game_manager.CurrencyClickXFive)
                {
					game_manager.golds += 4;
					game_manager.Currency += 4;
				}
				else if (game_manager.bprogressTime) {
					game_manager.golds += 9;
					game_manager.Currency += 9;
				}
				//}
				//popup_chara_set();
				gold_manage_set();
				game_manager.Clicked += 1;
				game_manager.TrapAlies += 1;
			}
			else
			{
				game_manager.nFake -= 1;
				for (int i = 0; i < 3; i++)
				{
					Vector3 pos2 = new Vector3(UnityEngine.Random.RandomRange(-1f, 1f), 1f, 2);
					GameObject new_chara = Instantiate(chara_pref12, pos2, transform.rotation) as GameObject;
					//new_chara.GetComponent<Rigidbody2D>().velocity = transform.up * 1;


					new_chara.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, UnityEngine.Random.Range(320, 360)));
				}
			}
		}
	}

	IEnumerator DeactiveClick()
    {
		ActiveClick = false;
		yield return new WaitForSeconds(0.2f);
		ActiveClick = true;
    }
	void chara_choice(int cc){
		//Debug.Log ("cc" + cc.ToString(""));
		get_gold(cc);
		if(cc == 1)
			use_chara_pref = chara_pref1;
		else if(cc == 2)
			use_chara_pref = chara_pref2;
		else if(cc == 3)
			use_chara_pref = chara_pref3;
		else if(cc == 4)
			use_chara_pref = chara_pref4;
		else if(cc == 5)
			use_chara_pref = chara_pref5;
		else if(cc == 6)
			use_chara_pref = chara_pref6;
		else if(cc == 7)
			use_chara_pref = chara_pref7;
		else if(cc == 8)
			use_chara_pref = chara_pref8;
		else if(cc == 9)
			use_chara_pref = chara_pref9;
		else if(cc == 10)
			use_chara_pref = chara_pref10;
		else if(cc == 11)
			use_chara_pref = chara_pref11;
		else if(cc == 12)
			use_chara_pref = chara_pref12;
	}


	void popup_chara_set(int dec){
		//cointype_date [id,probability of appearance]
		if(cointype_date.Count == 1){
			chara_choice(1);
		}
		else if(cointype_date.Count == 2){
			if(cointype_date[0][1] >= dec){
				chara_choice(cointype_date[0][0]);
			}
			else {
				chara_choice(cointype_date[1][0]);
			}
		}
		else {
			if(cointype_date[0][1] >= dec){
				chara_choice(cointype_date[0][0]);
			}
			else if(cointype_date[1][1] + cointype_date[0][1] < dec){
				chara_choice(cointype_date[2][0]);
			}
			else{
				chara_choice(cointype_date[1][0]);
			}

		}
		for (int i = 0; i < 3; i++)
		{
			Vector3 pos2 = new Vector3(UnityEngine.Random.RandomRange(-1f, 1f), 1f, 2);
			GameObject new_chara = Instantiate((diamond_count > 100 / (game_manager.DimondChance ? 3 : 1) ? chara_pref6 : chara_pref5), pos2, transform.rotation) as GameObject;
			//new_chara.GetComponent<Rigidbody2D>().velocity = transform.up * 1;


			new_chara.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, UnityEngine.Random.Range(320, 360)));
		}

		gold_manage_set();
        if (UnityEngine.Random.Range(0, 30) == 0)
            data_manager.SendMessage("data_save");
    }



	public void gold_manage_set(){
		//credit_text = game_manager.golds.ToString("");
		//if(game_manager.golds>=1000000000000){
		//	credit_text = (game_manager.golds/1000000000000f).ToString("f1")+"T";
		//}else if(game_manager.golds>=1000000000){
		//	credit_text = (game_manager.golds/1000000000f).ToString("f1")+"B";
		//}else if(game_manager.golds>=1000000){
		//	credit_text = (game_manager.golds/1000000f).ToString("f1")+"M";
		//}else if(game_manager.golds>=1000){
		//	credit_text = (game_manager.golds/1000f).ToString("f1")+"K";
		//}else{
		//	credit_text = game_manager.golds.ToString("f1");
		//}

		//gold_text.text = credit_text;
		gold_text.text = game_manager.golds.ToString("");
	}

	void get_coin_value_dates(){
		TextAsset csv = Resources.Load("CoinValue") as TextAsset;
		
		if (csv != null)
		{
			TextReader reader = new StringReader(csv.text);

			string line = "";
			while ( ( line = reader.ReadLine()) != null ) 
			{
				if(line.StartsWith("#")) continue;

				string[] items = line.Split(',');
				//Convert an array to a list
				List<string> litem = new List<string>(items);
				coin_value_dates.Add(litem);
			}
		}

		coin_value.Clear();
		foreach(List<string> cv in coin_value_dates){
			coin_value.Add (ulong.Parse(cv[1]));
		}


	}
	void tap_rare(int rare_id){
		game_manager.TrapAds += 1;
		Debug.Log ("Rareid" + rare_id.ToString(""));
		if(game_manager.AdsCrystallOff)
        {
			
			game_manager.Clicked += 1;
			game_manager.TrapAds += 1;
			game_manager.TrapAdsTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
			ulong add_gold = (ulong)UnityEngine.Random.Range(2000, 4000) * (ulong)(game_manager.CrystallMulti ? 5 : 1);
			game_manager.golds += add_gold;
			game_manager.Currency += add_gold;
		}
		else AdRewarded.S.ShowAd(2+rare_id);
		gold_manage_set();

		//StartCoroutine ("pop_open");
	}


	private IEnumerator pop_open(){
		yield return new WaitForSeconds(3.0f);
		Vector3 pos = new Vector3(-4.5f, 3f, 0f);

		Instantiate(rare_pref1, pos, transform.rotation);

		Vector3 pos2 = new Vector3(4.5f, 4f, 0f);
		
		Instantiate(rare_pref2, pos2, transform.rotation);

	//	rare_pref1.SetActive(true);
	//	rare_pref2.SetActive(true);
	}
	
	void get_gold(int chara){
		//Debug.Log ("get_gold" + chara.ToString(""));
		game_manager.golds += coin_value[(chara - 1)];
		game_manager.Currency += coin_value[(chara - 1)];
		if (game_manager.golds > 9999999999999999999){
			game_manager.golds = 9999999999999999999;
		}

	}
}
