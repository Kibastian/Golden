using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System.Net.NetworkInformation;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.Advertisements;
using Newtonsoft.Json;
using SimpleJSON;



public class TokenData
{
	public string user_token;
}
public class PromoDate
{
	public string user_token;
	public string promo_code;
}

public class game_manager : MonoBehaviour
{
	//Set images you choose 
	public GameObject but;
	public GameObject VersionError;
	public GameObject Error;
	public Sprite chara_sp1;
	public Sprite chara_sp2;
	public Sprite chara_sp3;
	public Sprite chara_sp4;
	public Sprite chara_sp5;
	public Sprite chara_sp6;
	public Sprite chara_sp7;
	public Sprite chara_sp8;
	public Sprite chara_sp9;
	public Sprite chara_sp10;
	public Sprite chara_sp11;
	public Sprite chara_sp12;
	public Sprite music_on;
	public Sprite music_off;


	public GameObject TimePanel;
	public GameObject FakePanel;
	public Text id_text;

	public GameObject Promo1;
	public GameObject Promo2;
	public static string id;
	public GameObject AvtoClick;

	private float startTime = 0f;
	private float startTime10 = 0f;
	private float startTime2 = 0f;
	private float startTime3 = 0f;
	private float progressTime = 0f;//normal
	private float pTime2 = 0f;
	private float pTime3 = 0f;
	private float progressTime2 = 0f;//normal
	private float progressTime3 = 0f;//normal
	public static bool bprogressTime = false;//normal
	public static bool bFake = false;//normal
	public static int nFake = 0;
	//Set your Store URL
	public string iOSStoreURL;
	public string AndroidStoreURL;

	public static string Version;
	public static string LastOnline;

	public static float TimeForSecs;
	public static int Clicked;
	public static int AllWatched;
	public static int InterstitialWatched;
	public static int TimePlayed;
	public static int TrapAlies;
	public static int TrapAds;
	public static string PromoCode;
	public static string PromoName;
	public static bool Interstitial;
	public static ulong PayoutTotal;
	public static ulong PromoCurrency;

	public static int DimondWatched;

	public static bool TrapOff;
	public static ulong BoostAutoClick;
	public static bool BoostX;
	public static bool BoostXBig;
	public static bool BoostCash;
	public static bool AdsOff;
	public static bool Combo;
	public static bool AdsTrapOff;
	public static bool BoostAutoClickMini;
	public static bool BoostCashBig;
	public static bool BoostAutoClickOpen;
	public static bool CurrencyClickXFive;
	public int ClickedLast;
	public Text auto_num;
	public Text multi_text;
	public static bool AdsCrystallOff;
	public static bool CrystallMulti;
	public static bool CrystallChance;
	public static bool DimondMulti;
	public static bool DimondChance;
	public Slider slider;

	public static string TrapOffTime;
	public static string BoostAutoClickTime;
	public static ulong BoostXTime;
	public static string BoostCashTime;
	public static string AdsOffTime;
	public static string ComboTime;
	public static string CurrencyClickXFiveTime;



	public static int BoostAutoClickWatched;
	public static int BoostXWatched;
	public static int BoostClickWatched;

	public static int TrapAdsTime;
	public static int TrapAliesCount;
	public static int TrapAliesTime;

	public static int CurrencyClick;
	public static int CurrencyClickTime;
	public static int AutoClick;
	public static int AutoClickTime;
	public static int XClick;
	public static int XTime;

	private static ulong salt;
	private static ulong _golds;
	private static ulong _Currency;
	public static ulong BattleCurrency;
	public static ulong golds { set { _golds = value ^ salt; } get { return _golds ^ salt; } } 
	public static ulong Currency { set { _Currency = value ^ salt;} get { return _Currency ^ salt; } }
	public static ulong cur_gold;
	public static int tap_lv = 0;
	public static int tap_num = 1;
	public static int auto_lv = -1;
	public static int popup_lv = 0;
	public static bool shop_now = false;
	private List<List<string>> autoclicker_dates = new List<List<string>>();
	public List<List<string>> cointype_dates = new List<List<string>>();
	public List<List<string>> multiclicker_dates = new List<List<string>>();
	public static bool sound_mute = false;
	public GameObject cardbord_manager;
	private ulong needgold = 0;
	public GameObject create_ket;
	public GameObject promo2;
	public GameObject Limit;
	public GameObject NoLimit;
	public GameObject morning;
	public GameObject evening;
	public GameObject night;
	public GameObject shop_panel;
	public GameObject shop_object;
	public GameObject speeds_object;
	public GameObject speeds_panel;
	public GameObject data_manager;
	public GameObject outs_object;
	public GameObject outs_panel;
	public Text promocode;
	public Image shop_music;
	public Text Time123;
	public Text sound_txt;
	public Text promo2_code;
	public Text Fake123;
	public Text shop_gold;
	public Text shop_gold2;
	public Text tap_num_now;
	public Text auto_num_new;
	public GameObject Golds2;
	public GameObject autoActive;
	public GameObject SoundOn;
	public GameObject SoundOff;
	public int ad_time;
	public int start_time;
	private string credit_text = "";
	private int check_cr_sp = 0;
	private List<int[]> pop_list = new List<int[]>();
	//private int[,] pop_list = {{0,0},{0,0},{0,0}};

	// Use this for initialization
    public bool trap_off;
	public bool boost_ac;
	public bool boost_x;
	public bool boost_cash;
	public bool ads_off;
	public bool combo;

	string GetMacAddress()
	{
		//string reesult = "";
		//foreach (NetworkInterface ninf in NetworkInterface.GetAllNetworkInterfaces())
		//{
		//	if (ninf.NetworkInterfaceType != NetworkInterfaceType.Ethernet) continue;
		//	if (ninf.OperationalStatus == OperationalStatus.Up)
		//	{
		//		reesult += ninf.GetPhysicalAddress().ToString();
		//		break;
		//	}
		//}
		return SystemInfo.deviceUniqueIdentifier;
	}

	void Start()
	{
		
		if (Advertisement.isInitialized) Debug.Log("Fuck");
		AdRewarded.S.LoadAd();
		StartCoroutine(autoclicker_gold());
		startTime = Time.time;
		startTime10 = Time.time;
		get_autoclicker_dates();
		get_cointype_dates();
        get_multiclicker_dates();
        //autoActive = shop_object.transform.Find("AutoClicker").gameObject.transform.Find("AutoActiveBlock").gameObject;

        data_manager.SendMessage("first_data_set");
		cardbord_manager.SendMessage("first_manage_set");
		
		tap_num = int.Parse(multiclicker_dates[(tap_lv)][2]);
		cardbord_manager.SendMessage("set_cointype", cointype_dates[(popup_lv)]);
		ad_time = (int)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds)+UnityEngine.Random.RandomRange(180,300);
		start_time = (int)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds) + 3;
		SoundManager.Instance.PlayBGM();
		salt = (ulong)UnityEngine.Random.RandomRange(0, 1 << 64 - 1);
		golds = 0;
		Currency = 0;
	    System.DateTime nowDT = System.DateTime.Now;
		int hour = nowDT.Hour;
		Debug.Log("hour" + nowDT.Hour.ToString(""));

		if (hour <= 4 || hour >= 19)
		{
			morning.SetActive(false);
			evening.SetActive(false);
			night.SetActive(true);
		}
		else if (hour >= 5 && hour <= 15)
		{
			morning.SetActive(true);
			evening.SetActive(false);
			night.SetActive(false);
		}
		else if (hour >= 16 && hour <= 18)
		{
			morning.SetActive(false);
			evening.SetActive(true);
			night.SetActive(false);
		}

		
	}

	// Update is called once per frame
	void Update()
	{
		multi_text.text = (bprogressTime?"АКТИВЕН":"НЕ АКТИВЕН");
		
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			Error.SetActive(true);
			cardbord_manager.SetActive(false);
			shop_close();
			outs_close();
			return;
		}
		else
		{
			Error.SetActive(false);
			cardbord_manager.SetActive(true);
		}
		if (VersionError.active == true || Interstitial == true)
		{
			return;
		}
		slider.value = float.Parse(auto_num.text);
		Promo1.SetActive(PromoCode == "" ? true : false);
		Promo2.SetActive(PromoCode == "" ? false : true);
		int time_played = (int)(Time.time - startTime10);
		TimePlayed += time_played;
		if(time_played>0) startTime10 = Time.time;
		shop_gold.text = (golds < 1e7 ? golds.ToString() : (int)(golds / 1e3) + "K");
		Limit.SetActive(golds >= 250000 ? true : false);
		NoLimit.SetActive(golds < 250000 ? true : false);
		auto_num.text = ((auto_lv) % 20).ToString();
		auto_num_new.text = ((int)((auto_lv) / 20) * 5).ToString();
		if ((auto_lv) < 100)
			auto_num_new.text += ("  	   " + (((int)((auto_lv) / 20) * 5) + 5));
		else auto_num_new.text = (" 25");
		if (BoostAutoClickOpen)
		{
			auto_lv = 100;
			
			
			BoostAutoClickOpen = false;
		}
			if ((BoostCash||BoostCashBig)&&Clicked - ClickedLast >= 100)
        {
            golds += (BoostCash?100ul:0ul)+(BoostCashBig?300ul:0ul);
            Currency += (BoostCash ? 100ul : 0ul) + (BoostCashBig? 300ul : 0ul);
            ClickedLast = Clicked;

        }

        if (bprogressTime||BoostX||CurrencyClickXFive)
		{
			//progressTime = ((BoostX? (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - int.Parse(BoostXTime): 0));
			//pTime2 = (CurrencyClickXFive ? (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - int.Parse(CurrencyClickXFiveTime) : 0);
			pTime3 = (Time.time - startTime);
			string time2 = (BoostX?(BoostXTime -(ulong)(DateTime.UtcNow-new DateTime(1970, 1, 1)).TotalSeconds).ToString():pTime3.ToString())+"c";
			//string time2 = ((int)(progressTime>0?(((BoostXBig ? 3 : 1) * 3600 - progressTime)): pTime2 > 0?3600-pTime2:pTime3>0?30-pTime3:0)).ToString() + "с";
			if (TimePanel.active==false) TimePanel.SetActive(true);
			Time123.text = time2;
			//if (BoostXTime>= (ulong)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds)
			//{
			//	progressTime =0;
			//}
			//if (pTime2 >= 3600)
			//{
			//	pTime2 = 0;
			//	CurrencyClickXFive = false;
			//}
			if (pTime3 >= 30)
			{
				pTime3 = 0;
				bprogressTime = false;
				startTime = Time.time;
			}
		}
		else
		{
			CurrencyClick = 0;
			CurrencyClickTime = 0;
			progressTime = 0;
			startTime = Time.time;
			TimePanel.SetActive(false);
		}
		if (nFake == 0)
		{
			bFake = false;
			if (FakePanel.active) startTime2 = Time.time;
			FakePanel.SetActive(false);
		}
		if (!bFake && nFake == 0&&(!TrapOff))
		{
			progressTime2 = (Time.time - startTime2);
			if (progressTime2 >= 90)
			{
				startTime2 = Time.time;
				if (UnityEngine.Random.Range(0, 2) == 0)
				{
					bFake = true;
					FakePanel.SetActive(true);
					nFake = UnityEngine.Random.Range(100, 200);
				}
			}
		}
		
		Fake123.text = nFake.ToString();

		if (auto_lv >= 100)
		{
			autoActive.SetActive(false);
			//shop_object.transform.Find("ShopPanel").gameObject.transform.Find("AutoClicker").GetComponent<Animator>().enabled = false;
		}
		else autoActive.SetActive(true);
		shop_gold2.text =  golds.ToString();
		progressTime3 = (Time.time - startTime3);
		int rnd = UnityEngine.Random.Range(100, 200);
        //if (progressTime3 >= rnd)
        //{
        //    progressTime3 -= rnd;
        //    startTime3 = Time.time;
        //    string adUnitId = "ca-app-pub-1016045238305294/5468925896";
        //    this.rewardedAd = new RewardedAd(adUnitId);

        //    // Create an empty ad request.
        //    AdRequest request = new AdRequest.Builder().Build();
        //    // Load the rewarded ad with the request.
        //    this.rewardedAd.LoadAd(request);
        //    this.rewardedAd.Show();
        //}
        if ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds >= ad_time && (!AdsOff))
        {
			but.SetActive(true);
			cardbord_manager.SetActive(false);
            
			shop_close();
			outs_close();
			Interstitial = true;
			data_manager.SendMessage("data_save");
            //Advertisement.Load("Interstitial_Android");
            //Advertisement.Show("Interstitial_Android");
        }
		if(golds>=200+cur_gold)
        {
			data_manager.SendMessage("data_save");
			cur_gold = golds;
        }
        //bool f = true;
        //if (f && (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds >= start_time)
        //{
        //    Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        //    Advertisement.Load("Banner_Android");
        //    Advertisement.Banner.Load();
        //    Advertisement.Banner.Show("Banner_Android");
        //    f = false;
        //}
    }

	public IEnumerator promo()
	{
		string link = "https://alienfarm.ru/api/promo?data=";
		TokenData myObject = new TokenData();
		myObject.user_token = GetMacAddress();
		link += System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(myObject)));
		UnityWebRequest Query = UnityWebRequest.Get(link);
		//var Query = new WWW(link);
		Debug.Log(link);
		yield return Query.SendWebRequest();
		Debug.Log(Query.downloadHandler.text);
	}
	void shop_sound()
	{
		if (sound_mute)
		{
			sound_mute = false;
			sound_txt.text = "Выключить звук";
			SoundOff.SetActive(true);
			SoundOn.SetActive(false);
		}
		else
		{
			sound_mute = true;
			sound_txt.text = "Включить звук";
			SoundOff.SetActive(false);
			SoundOn.SetActive(true);
		}
	}

	void tap_num_text_set()
	{
	}

	void multiclicker_gold()
	{

	}

	public void multiclicker_lvup()
	{
		if (!bFake)
		{
			AdRewarded.S.ShowAd(1);
			
		}
		
	}
	

	//private void HandleUserReward2(object sender, Reward e)
	//{
	//	bprogressTime = true;
	//	TimePanel.SetActive(true);
	//}

	void auto_num_text_set()
	{
		//auto_num_now.text = autoclicker_dates[auto_lv][3];
		//if (auto_lv < 50)
		//	auto_num_new.text = autoclicker_dates[(auto_lv + 1)][3];
		//else
		//	auto_num_new.text = autoclicker_dates[(auto_lv)][3];
	}

	
	public IEnumerator autoclicker_gold()
	{
		string link = "https://gold-mine.online/api/load?data=";
		TokenData myObject = new TokenData();
		myObject.user_token = GetMacAddress();
		link += System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(myObject)));
		UnityWebRequest Query = UnityWebRequest.Get(link);
		//var Query = new WWW(link);
		Debug.Log(link);
		yield return Query.SendWebRequest();
		Debug.Log(Query.downloadHandler.text);
		string str = Query.downloadHandler.text;
		var obj = JSONNode.Parse(str.Replace("FyxMBdAv6F9HGGjfWEx5VjEtd9idgf", ""));
		var user_info = obj["user_info"];
		var main = user_info["Main"];
		var money = user_info["Money"];
		var ads = user_info["Ads"];
		var boost = user_info["Boost"];
		var pur = user_info["Purchases"];
		Version = (user_info["Vestion"]);
		LastOnline = (main["LastOnline"]);		
		Clicked = (main["Clicked"]);
		CurrencyClick = (main["Boost"]["CurrencyClick"]);
		CurrencyClickTime = (user_info["Boost"]["CurrencyClickTime"]);
		PromoCode = main["PromoCode"] != null ? (string)main["PromoCode"] : "";
		PromoName = user_info["PromoName"] != null ? (string)user_info["PromoName"] : "";
		TimePlayed = ((main["TimePlayed"]));
		Interstitial = (main["Interstitial"] == "1" ? true : false);
		sound_mute = (main["SoundMute"] == "1" ? true : false);
		golds = ulong.Parse((money["Currency"]));
		Currency = ulong.Parse(money["CurrencyTotal"]);
		PromoCurrency = (money["PromoCurrency"] != null ? ulong.Parse(money["PromoCurrency"]) : 0);
		PayoutTotal = ulong.Parse(money["PayoutTotal"]);
		BattleCurrency = ulong.Parse(money["BattleCurrency"]);

		CurrencyClickXFive = (user_info["Boost"]["CurrencyClickXFive"] == "1" ? true : false);
		CurrencyClickXFiveTime = (user_info["Boost"]["CurrencyClickXFiveTime"]);
		
		
		TrapAdsTime = (user_info["Trap"]["TrapAdsTime"]);
		TrapAliesCount = (user_info["Trap"]["TrapAliesCount"]);
		TrapAliesTime = (user_info["Trap"]["TrapAliesTime"]);
		
		TrapAds = ((user_info["Trap"]["TrapAds"]));
		
		TrapAlies = user_info["Trap"]["Alies"] != null ? (int)user_info["Trap"]["Alies"] : 0;

		DimondWatched = ads["DimondWatched"];
		BoostClickWatched = int.Parse(ads["BoostXWatched"]);
		BoostAutoClickWatched = int.Parse(ads["BoostAutoClickWatched"]);
		InterstitialWatched = ads["InterstitialWatched"];
		AllWatched = ((ads["AllWatched"]));

		id = ((obj["id"]));
		

		auto_lv = (boost["AutoClick"]);
		AutoClickTime = (boost["AutoClickerTime"]);
		XTime = boost["BoostXClickTime"];

		
		BoostCash = (user_info["BoostCash"] == "1" ? true : false);
		Combo = (user_info["Combo"] == "1" ? true : false);
		AdsTrapOff = (user_info["AdsTrapOff"] == "1" ? true : false);
		BoostAutoClickMini= (user_info["BoostAutoClickMini"] == "1" ? true : false);
		BoostCashBig= (user_info["BoostCashBig"] == "1" ? true : false);
		BoostXBig = (user_info["BoostXBig"] == "1" ? true : false);

		TrapOff = (pur["TrapOff"] == "0" ? false : true);
		AdsCrystallOff = (pur["AdsCrystalOff"] == "0" ? false : true);
		CrystallMulti = (pur["CrystalMulti"] == "0" ? false : true);
		CrystallChance = (pur["CrystalChance"] == "0" ? false : true);
		DimondMulti = (pur["DimondMulti"] == "0" ? false : true);
		DimondChance = (pur["DimondChance"] == "0" ? false : true);
		AdsOff = (pur["AdsPopupOff"] == "0" ? false : true);
		//BoostAutoClickOpen = (pur["OpenAutoclick"] == "0" ? false : true);
		BoostAutoClick = ulong.Parse(pur["BoostAutoclick"]);
		BoostXTime = ulong.Parse(pur["BoostXClick"]);
		BoostX = (BoostXTime > 0 ? true : false);

		TrapOffTime = user_info["PurchasesTime"]["TrapOffTime"];
		
		BoostCashTime = user_info["PurchasesTime"]["BoostCashTime"];
		AdsOffTime = user_info["PurchasesTime"]["AdsOffTime"];
		ComboTime = user_info["PurchasesTime"]["ComboTime"];
		cur_gold = golds;
		shop_gold.text = (golds < 1e7 ? golds.ToString() : (int)(golds / 1e3) + "K");
		game_manager.golds = game_manager.Currency - game_manager.PayoutTotal + game_manager.BattleCurrency;
		if (bprogressTime || BoostX||CurrencyClickXFive) TimePanel.SetActive(true);
		ClickedLast = Clicked;
		if (BoostAutoClickOpen) auto_lv = 100;
		auto_num.text = (auto_lv%20).ToString();
		auto_num_new.text = ((int)((auto_lv) / 20) * 5).ToString();
		if ((auto_lv) < 100)
			auto_num_new.text += ("  	   " + (((int)((auto_lv) / 20) * 5) + 5));
		else auto_num_new.text = (" 25");
        id_text.text += " " + id;
        UnityWebRequest QueryVersion = UnityWebRequest.Get("https://gold-mine.online/api/version");
		yield return QueryVersion.SendWebRequest();
		//if (Application.version != QueryVersion.downloadHandler.text)
		//{
		//    VersionError.SetActive(true);
		//    cardbord_manager.SetActive(false);
		//}
		//else
		Interstitial = false;
        if (Interstitial)
        {
            but.SetActive(true);
            cardbord_manager.SetActive(false);
            shop_close();
            outs_close();
        }


        //if (auto_lv == 100)
        //{
        //	shop_object.GetComponent("AutoActiveBlock").gameObject.SetActive(false);
        //}
        //cardboard_script.gold_text.text = golds.ToString();
        Debug.Log(str);
		//Advertisement.Initialize("4662929", false);
		

			//LoadCgf myObject2 = new LoadCgf();
			//myObject2 = JsonUtility.FromJson<LoadCgf>(Query.downloadHandler.text);
			//string str = myObject2.Currency.Replace("FyxMBdAv6F9HGGjfWEx5VjEtd9idgf","");
			//str= str.Replace("FyxMBdAv6F9HGGjfWEx5VjEtd9idgf", "");
			//game_manager.golds = ulong.Parse(str);
			//Debug.Log(myObject2.Currency);
			//Query.Dispose();
			//if(auto_lv < 11){
			//needgoldneedgold = ulong.Parse(autoclicker_dates[(auto_lv + 1)][1]);
			//auto_lv_gold.text = shopgold_manage_set(needgold);
			//}
			//else{
			//	auto_lv_gold.text = "MAX";
			//}
		}
	
	//IEnumerator RequestInterstitial()
 //   {
	//	while (true)
	//	{
	//		yield return new WaitForSeconds(60*(1f+2*UnityEngine.Random.value));
	//		Advertisement.Load("Interstitial_Android");
	//		Advertisement.Show("Interstitial_Android");
	//	}

	//}
	public IEnumerator promo_active2()
	{
		data_manager.SendMessage("data_save");
		string link = "https://gold-mine.online/api/promo?data=";
		PromoDate myObject = new PromoDate();
		myObject.user_token = GetMacAddress();
		myObject.promo_code = promocode.text;
		link += System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(myObject)));
		Debug.Log(link);
		UnityWebRequest Query = UnityWebRequest.Get(link);
		//var Query = new WWW(link);
		yield return Query.SendWebRequest();
		Debug.Log(Query.downloadHandler.text); 
		string str = Query.downloadHandler.text;
		var obj = JSONNode.Parse(str.Replace("FyxMBdAv6F9HGGjfWEx5VjEtd9idgf", ""));
		var user_info = obj;
		PromoCode = (user_info["Main"]["PromoCode"] != null ? (string)user_info["Main"]["PromoCode"] : "");
		golds = ulong.Parse((string)(user_info["Money"]["Currency"]));
		Currency = ulong.Parse((string)(user_info["Money"]["CurrencyTotal"]));
		shop_gold.text = (golds < 1e7 ? golds.ToString() : (int)(golds / 1e3) + "K");
		data_manager.SendMessage("data_save");
	}

	void promo_active()
    {
		StartCoroutine(promo_active2());
    }

	void autoclicker_lvup()
	{
		if (auto_lv < 100)
		{
			if (!bFake)
			{
				AdRewarded.S.ShowAd(2);
			}
			//         auto_lv++;
			//         //auto_num_text_set();
			//         auto_num_new.text = ((int)((auto_lv + 1) / 5) * 5).ToString();
			//if ((auto_lv + 1) < 50)
			//	auto_num_new.text += ("  	  " + (((int)((auto_lv + 1) / 5) * 5) + 5));
			//data_manager.SendMessage("data_save"); 
		}
		else
		{
			Debug.Log("ERR");
			//AvtoClick.SetActive(true);
		}

	}

	//private void HandleUserReward(object sender, Reward e)
	//{
	//	auto_lv++;
	//	//auto_num_text_set();
	//	auto_num_new.text = ((int)((auto_lv + 1) / 5) * 5).ToString();
	//	if ((auto_lv + 1) < 50)
	//		auto_num_new.text += ("  	  " + (((int)((auto_lv + 1) / 5) * 5) + 5));
	//	shopgold_manage();
	//	data_manager.SendMessage("data_save");
	//}

	void get_pop_cointype(List<string> dates)
	{
		pop_list.Clear();
		if (int.Parse(dates[2]) >= 1)
		{
			int[] pp = { 1, int.Parse(dates[2]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[3]) >= 1)
		{
			int[] pp = { 2, int.Parse(dates[3]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[4]) >= 1)
		{
			int[] pp = { 3, int.Parse(dates[4]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[5]) >= 1)
		{
			int[] pp = { 4, int.Parse(dates[5]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[6]) >= 1)
		{
			int[] pp = { 5, int.Parse(dates[6]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[7]) >= 1)
		{
			int[] pp = { 6, int.Parse(dates[7]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[8]) >= 1)
		{
			int[] pp = { 7, int.Parse(dates[8]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[9]) >= 1)
		{
			int[] pp = { 8, int.Parse(dates[9]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[10]) >= 1)
		{
			int[] pp = { 9, int.Parse(dates[10]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[11]) >= 1)
		{
			int[] pp = { 10, int.Parse(dates[11]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[12]) >= 1)
		{
			int[] pp = { 11, int.Parse(dates[12]) };
			pop_list.Add(pp);
		}
		if (int.Parse(dates[13]) >= 1)
		{
			int[] pp = { 12, int.Parse(dates[13]) };
			pop_list.Add(pp);
		}
	}

	private Sprite get_pop_cointype_list(int i)
	{
		Sprite ret_sp = chara_sp1;

		if (i == 2)
		{
			ret_sp = chara_sp2;
		}
		else if (i == 3)
		{
			ret_sp = chara_sp3;
		}
		else if (i == 4)
		{
			ret_sp = chara_sp4;
		}
		else if (i == 5)
		{
			ret_sp = chara_sp5;
		}
		else if (i == 6)
		{
			ret_sp = chara_sp6;
		}
		else if (i == 7)
		{
			ret_sp = chara_sp7;
		}
		else if (i == 8)
		{
			ret_sp = chara_sp8;
		}
		else if (i == 9)
		{
			ret_sp = chara_sp9;
		}
		else if (i == 10)
		{
			ret_sp = chara_sp10;
		}
		else if (i == 11)
		{
			ret_sp = chara_sp11;
		}
		else if (i == 12)
		{
			ret_sp = chara_sp12;
		}

		return ret_sp;
	}

	void cointype_num_set()
	{


		get_pop_cointype(cointype_dates[popup_lv]);

		if (pop_list.Count >= 3)
		{
			//pop_img_img1.gameObject.SetActive(true);
			//pop_img_img1.sprite = get_pop_cointype_list(pop_list[0][0]);
			//pop_img_text1.text = (pop_list[0][1]).ToString("") + "%";

			//pop_img_img2.gameObject.SetActive(true);
			//pop_img_img2.sprite = get_pop_cointype_list(pop_list[1][0]);
			//pop_img_text2.text = (pop_list[1][1]).ToString("") + "%";

			//pop_img_img3.gameObject.SetActive(true);
			//pop_img_img3.sprite = get_pop_cointype_list(pop_list[2][0]);
			//pop_img_text3.text = (pop_list[2][1]).ToString("") + "%";
		}
		else if (pop_list.Count == 2)
		{
			//pop_img_img1.gameObject.SetActive(true);
			//pop_img_img1.sprite = get_pop_cointype_list(pop_list[0][0]);
			//pop_img_text1.text = (pop_list[0][1]).ToString("") + "%";

			//pop_img_img2.gameObject.SetActive(true);
			//pop_img_img2.sprite = get_pop_cointype_list(pop_list[1][0]);
			//pop_img_text2.text = (pop_list[1][1]).ToString("") + "%";

			//pop_img_img3.gameObject.SetActive(false);
		}
		else if (pop_list.Count == 1)
		{
			//pop_img_img1.gameObject.SetActive(true);
			//pop_img_img1.sprite = get_pop_cointype_list(pop_list[0][0]);
			//pop_img_text1.text = (pop_list[0][1]).ToString("") + "%";

			//pop_img_img2.gameObject.SetActive(false);

			//pop_img_img3.gameObject.SetActive(false);
		}
		if (popup_lv < 22)
		{
			get_pop_cointype(cointype_dates[(popup_lv + 1)]);

			if (pop_list.Count >= 3)
			{
				//pop_img_new_img1.gameObject.SetActive(true);
				//pop_img_new_img1.sprite = get_pop_cointype_list(pop_list[0][0]);
				//pop_img_new_text1.text = (pop_list[0][1]).ToString("") + "%";

				//pop_img_new_img2.gameObject.SetActive(true);
				//pop_img_new_img2.sprite = get_pop_cointype_list(pop_list[1][0]);
				//pop_img_new_text2.text = (pop_list[1][1]).ToString("") + "%";

				//pop_img_new_img3.gameObject.SetActive(true);
				//pop_img_new_img3.sprite = get_pop_cointype_list(pop_list[2][0]);
				//pop_img_new_text3.text = (pop_list[2][1]).ToString("") + "%";
			}
			else if (pop_list.Count == 2)
			{
				//pop_img_new_img1.gameObject.SetActive(true);
				//pop_img_new_img1.sprite = get_pop_cointype_list(pop_list[0][0]);
				//pop_img_new_text1.text = (pop_list[0][1]).ToString("") + "%";

				//pop_img_new_img2.gameObject.SetActive(true);
				//pop_img_new_img2.sprite = get_pop_cointype_list(pop_list[1][0]);
				//pop_img_new_text2.text = (pop_list[1][1]).ToString("") + "%";

				//pop_img_new_img3.gameObject.SetActive(false);
			}
			else if (pop_list.Count == 1)
			{
				//pop_img_new_img1.gameObject.SetActive(true);
				//pop_img_new_img1.sprite = get_pop_cointype_list(pop_list[0][0]);
				//pop_img_new_text1.text = (pop_list[0][1]).ToString("") + "%";

				//pop_img_new_img2.gameObject.SetActive(false);

				//pop_img_new_img3.gameObject.SetActive(false);
			}
		}
		else
		{

			//pop_img_new_img1.gameObject.SetActive(false);
			//pop_img_new_img2.gameObject.SetActive(false);
			//pop_img_new_img3.gameObject.SetActive(false);

		}
	}

	void cointype_lvup()
	{

		//Advertisement.Show(" ed_Android");
		golds += 1000;
		Currency += 1000;
		//shopgold_manage();
		data_manager.SendMessage("data_save");




		//      golds += 1000;
		////shopgold_manage();
		//data_manager.SendMessage("data_save");



		//if(popup_lv < 22){
		//needgold = ulong.Parse(cointype_dates[(popup_lv + 1)][1]);
		//if(golds >= needgold){
		//	popup_lv ++;
		//	golds -= needgold;
		//	cointype_num_set();
		//	shopgold_manage();
		//	popup_lv_gold.text = shopgold_manage_set(ulong.Parse(cointype_dates[(popup_lv + 1)][1]));

		//	data_manager.SendMessage("data_save");

		//	cardbord_manager.SendMessage("set_cointype",cointype_dates[(popup_lv)]);
		//}
		//else{
		//	Debug.Log ("ERR");

		//}
		//}
	}

	//private void HandleUserReward3(object sender, Reward e)
	//{
	//	golds += 1000;
	//	//shopgold_manage();
	//	data_manager.SendMessage("data_save");
	//}

	void cointype_gold()
	{
		if (popup_lv < 22)
		{
			needgold = ulong.Parse(cointype_dates[(popup_lv + 1)][1]);
		}
		else
		{
		}
	}

	public void shopgold_manage()
	{
		credit_text = shopgold_manage_set(golds);
		shop_gold.text = credit_text;
		shop_gold2.text = credit_text;
	}



	private string shopgold_manage_set(ulong go)
	{
		/*string cre = go.ToString("");
		if(go>=1000000000000){
			cre = (go/1000000000000f).ToString("f1")+"T";
			check_cr_sp = 4;
		}else if(go>=1000000000){
			cre = (go/1000000000f).ToString("f1")+"B";
			check_cr_sp = 3;
		}else if(go>=1000000){
			cre = (go/1000000f).ToString("f1")+"M";
			check_cr_sp = 2;
		}else if(go>=1000){
			cre = (go/1000f).ToString("f1")+"K";
			check_cr_sp = 1;
		}else{
			cre = go.ToString("f1");
			check_cr_sp = 0;
		}
		return cre; */
		return go.ToString("");

	}



	void get_multiclicker_dates()
	{
		TextAsset csv = Resources.Load("MultiClicker") as TextAsset;

		if (csv != null)
		{
			TextReader reader = new StringReader(csv.text);

			string line = "";
			while ((line = reader.ReadLine()) != null)
			{
				if (line.StartsWith("#")) continue;

				string[] items = line.Split(',');
				//Convert an array to a list
				List<string> litem = new List<string>(items);
				multiclicker_dates.Add(litem);
			}
		}
	}
	void get_autoclicker_dates()
	{
		TextAsset csv = Resources.Load("auto_lv") as TextAsset;

		if (csv != null)
		{
			TextReader reader = new StringReader(csv.text);

			string line = "";
			while ((line = reader.ReadLine()) != null)
			{
				if (line.StartsWith("#")) continue;

				string[] items = line.Split(',');
				//Convert an array to a list
				List<string> litem = new List<string>(items);
				autoclicker_dates.Add(litem);
			}
		}
	}

	void get_cointype_dates()
	{
		TextAsset csv = Resources.Load("CoinTypes") as TextAsset;

		if (csv != null)
		{
			TextReader reader = new StringReader(csv.text);

			string line = "";
			while ((line = reader.ReadLine()) != null)
			{
				if (line.StartsWith("#")) continue;

				string[] items = line.Split(',');
				//Convert an array to a list
				List<string> litem = new List<string>(items);
				cointype_dates.Add(litem);
			}
		}
	}

	void shop_open()
	{
		shop_now = true;
		shop_panel.SetActive(true);
		if (tap_lv < 11)
		{

		}
		if (popup_lv < 22)
		{
			
		}
		if (auto_lv < 11)
		{
			
		}
		data_manager.SendMessage("data_save");
		shopgold_manage();
		multiclicker_gold();
		tap_num_text_set();
		autoclicker_gold();
		auto_num_text_set();
		cointype_gold();
		//cointype_num_set();
		//if (sound_mute)
		//{
		//	sound_txt.text = "ВКЛЮЧИТЬ ЗВУК";
		//}
		//else
		//{
		//	sound_txt.text = "ВЫКЛЮЧИТЬ ЗВУК";
		//}


	}


	void speeds_open()
	{
		shop_now = true;
		speeds_object.SetActive(true);
		data_manager.SendMessage("data_save");
	}

	public IEnumerator enbl_key2()
	{
		string link = "https://gold-mine.online/api/authorization?data=";
		TokenData myObject = new TokenData();
		myObject.user_token = GetMacAddress();
		link += System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(myObject)));
		Debug.Log(link);
		UnityWebRequest Query = UnityWebRequest.Get(link);
		//var Query = new WWW(link);
		yield return Query.SendWebRequest();
		Debug.Log(Query.downloadHandler.text);
		CopyText(Query.downloadHandler.text);
	}
	private void CopyText(string textToCopy)
	{
		TextEditor editor = new TextEditor
		{
			text = textToCopy
		};
		editor.SelectAll();
		editor.Copy();
	}
	void enbl_key()
	{
		StartCoroutine(enbl_key2());
		create_ket.SetActive(false);
		Golds2.SetActive(true);
	}

	void speeds_close()
	{
		data_manager.SendMessage("data_save");
		speeds_panel.GetComponent<Animator>().SetTrigger("close");
		shop_now = false;
	}

	void out_open()
	{
		shop_now = true;
		outs_object.SetActive(true);
		data_manager.SendMessage("data_save");
	}

	void outs_close()
	{
		outs_panel.GetComponent<Animator>().SetTrigger("close");
		shop_now = false;
	}



	void shop_close()
	{
		shop_object.GetComponent<Animator>().SetTrigger("close");
		data_manager.SendMessage("data_save");
	}

	void company_link()
	{
		Application.OpenURL("https://gold-mine.online/");
	}
	void donat_link()
    {
		Application.OpenURL("https://gold-mine.online/profile/shop");

	}
	void download_link()
    {
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.AlienFarmBuild");

	}

}