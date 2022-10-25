using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.Networking;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using SimpleJSON;
public class UserInfo
{
	public string Currency;
	public int LastOnline;
	public string Clicked;
	public int AllWatched;
	public string CurrencyTotal;
	public string TimePlayed;
	public string PromoCode;
	public string PromoName;
	public string Interstitial;
	public string Version;
	public int PayoutTotal;
	public int SoundMute;
};

public class TrapInfo
{
	public string TrapAds;
	public string TrapAdsTime;
	public string TrapAlies;
	public string TrapAliesCount;
	public string TrapAliesTime;
};

public class PurchasesInfo
{
	public string TrapOff;
	public string BoostAutoClick;
	public string BoostX;
	public string BoostCash;
	public string AdsOff;
	public string Combo;
};

public class PurchasesTime
{
	public string TrapOffTime;
	public string BoostAutoClickTime;
	public string BoostXTime;
	public string BoostCashTime;
	public string AdsOffTime;
	public string ComboTime;
};

public class BoostInfo
{
	public int CurrencyClick;
	public int CurrencyClickTime;
	public int AutoClick;
	public int AutoClickTime;
};

public class AdsInfo
{
	public string AllWatched;
	public string InterstitialWatched;
	public string DimondWatched;
	public string BoostXWatched;
	public string BoostAutoClickWatched;
}
public class LoadData
{
	public string user_token;
}

public class Money
{
	public string Currency;
	public string CurrencyTotal;
	public string PayoutTotal;
	public string PromoCurrency;
}

public class data_manager : MonoBehaviour {



	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void first_data_set(){
		data_load();
	}


	void reset_save_date(){
		
		PlayerPrefs.DeleteAll();
		Application.LoadLevel("Main");
		game_manager.golds = 0;
		game_manager.tap_lv = 0;
		game_manager.tap_num = 1;
		game_manager.auto_lv = 0;
		game_manager.popup_lv = 0;
		game_manager.shop_now = false;
	}

	string GetMacAddress()
	{
		//SystemInfo.deviceUniqueIdentifier
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
	public IEnumerator data_load(){
        string link = "https://gold-mine.online/api/authorization?data=";
        TokenData myObject = new TokenData();
        myObject.user_token = "test_token";
        link += System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(myObject)));
        UnityWebRequest Query = UnityWebRequest.Get(link);
        //var Query = new WWW(link);
        Debug.Log(link);
        yield return Query.SendWebRequest();
        Debug.Log(Query.downloadHandler.text);


        game_manager.golds = ulong.Parse(PlayerPrefs.GetString("golds","300000"));
		game_manager.tap_lv = PlayerPrefs.GetInt("tap_lv",0);
		game_manager.tap_num = PlayerPrefs.GetInt("tap_num",0);
		game_manager.auto_lv = PlayerPrefs.GetInt("auto_lv",0);
		game_manager.popup_lv = PlayerPrefs.GetInt("popup_lv",0);

	}

	public void data_save()
	{
		StartCoroutine(data_save2());
	}

	public IEnumerator data_save2()
	{
		string link = "https://gold-mine.online/api/post";
		LoadData myObject = new LoadData();
		myObject.user_token = GetMacAddress();
		var bytes = System.Text.Encoding.UTF8.GetBytes(game_manager.golds.ToString());
		var b64 = System.Convert.ToBase64String(bytes);
		Debug.Log(b64);
		UserInfo myObject2 = new UserInfo();
		int i = 0;
		Debug.Log(i++);
		TrapInfo myObject3 = new TrapInfo();
		Debug.Log(i++);
		//myObject2.Currency = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.golds.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; Debug.Log(i++);
		string str5 = JsonUtility.ToJson(myObject); ;
		str5 = str5.Remove(str5.Length - 1); ;
		myObject2.LastOnline = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds; ;
		myObject2.Clicked = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.Clicked.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
		
		
		myObject2.TimePlayed = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.TimePlayed.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
		myObject2.PromoCode = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.PromoCode.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
		//myObject2.PromoName = game_manager.PromoName;
		myObject2.Interstitial = Convert.ToInt32(game_manager.Interstitial).ToString();
		myObject2.Version = Application.version;
		myObject2.SoundMute = Convert.ToInt32(game_manager.sound_mute);

		Money _money = new Money();
        _money.Currency = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.golds.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
        _money.CurrencyTotal = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.Currency.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
        _money.PayoutTotal = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.PayoutTotal.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
		_money.PromoCurrency = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.PromoCurrency.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
		AdsInfo _ads = new AdsInfo();
		_ads.AllWatched= "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.AllWatched.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf";
		_ads.DimondWatched = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.DimondWatched.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf";
		_ads.InterstitialWatched = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.InterstitialWatched.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf";
		_ads.BoostXWatched = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.BoostXWatched.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf";
		_ads.BoostAutoClickWatched = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.auto_lv.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf";
		//myObject3.TrapAds = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.TrapAds.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
		//myObject3.TrapAlies = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.TrapAlies.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
		//myObject3.TrapAdsTime = game_manager.TrapAdsTime.ToString(); ;
		//myObject3.TrapAliesTime = game_manager.TrapAliesTime.ToString(); ;
		//myObject3.TrapAlies = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + game_manager.TrapAlies.ToString() + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf"; ;
		//myObject3.TrapAliesCount = game_manager.TrapAliesCount.ToString(); ;

		BoostInfo _boost = new BoostInfo(); ;
		_boost.AutoClick = game_manager.auto_lv; ;
		_boost.AutoClickTime = game_manager.AutoClickTime; ;

		//PurchasesInfo _PurchasesInfo = new PurchasesInfo(); ;
		//_PurchasesInfo.AdsOff = Convert.ToInt32(game_manager.AdsOff).ToString(); ;
		//_PurchasesInfo.BoostAutoClick = Convert.ToInt32(game_manager.BoostAutoClick).ToString(); ;
		//_PurchasesInfo.BoostCash = Convert.ToInt32(game_manager.BoostCash).ToString(); ;
		//_PurchasesInfo.BoostX = Convert.ToInt32(game_manager.BoostX).ToString(); ;
		//_PurchasesInfo.Combo = Convert.ToInt32(game_manager.Combo).ToString(); ;

		//PurchasesTime _PurchasesTime = new PurchasesTime(); ;
		//_PurchasesTime.AdsOffTime = game_manager.AdsOffTime; ;
		//_PurchasesTime.BoostAutoClickTime = game_manager.BoostAutoClickTime; ;
		//_PurchasesTime.BoostCashTime = game_manager.BoostCashTime; ;
		//_PurchasesTime.BoostXTime = game_manager.BoostXTime; ;
		//_PurchasesTime.ComboTime = game_manager.ComboTime; ;
		//var js2 = JsonUtility.ToJson(myObject2);
		//js2.Remove(js2.Length - 3);
		//js2 += ",\"Trap\": " + JsonUtility.ToJson(myObject3) + "}";
		str5 += ",\"user_info\": {\"Main\":" + JsonUtility.ToJson(myObject2) /*+ "}"*/; ;
		//str5 = str5.Remove(str5.Length - 1); ;
		str5 += ",\"Ads\": " + JsonUtility.ToJson(_ads) /*+ "}"*/; ;
		str5 += ",\"Money\": " + JsonUtility.ToJson(_money) /*+ "}"*/; ;
		str5 += ",\"Boost\": " + JsonUtility.ToJson(_boost) /*+ "}"*/; ;
		//str5 += ",\"Trap\": " + JsonUtility.ToJson(myObject3); ;
		//str5 += ",\"Purchases\": " + JsonUtility.ToJson(_PurchasesInfo); ;
		//str5 += ",\"PurchasesTime\": " + JsonUtility.ToJson(_PurchasesTime) + "}}"; ;
		Debug.Log(str5);
		//myObject.user_info.Currency = "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf" + b64 + "FyxMBdAv6F9HGGjfWEx5VjEtd9idgf";
		Debug.Log(link);
		UnityWebRequest Query = UnityWebRequest.Post(link, str5+"}}");
		Query.SetRequestHeader("Content-Type", "application/json");
		//var Query = new WWW(link);
		yield return Query.SendWebRequest();
		Debug.Log(Query.downloadHandler.text);
		string str = Query.downloadHandler.text;
		var obj = JSONNode.Parse(str.Replace("FyxMBdAv6F9HGGjfWEx5VjEtd9idgf", ""));
		var user_info = obj;
		var pur = obj["Purchases"];
		game_manager.TrapOff = (pur["TrapOff"] == "0" ? false : true);
		game_manager.AdsCrystallOff = pur["AdsCrystalOff"] == "0" ? false : true;
		game_manager.CrystallMulti = pur["CrystalMulti"] == "0" ? false : true;
		game_manager.CrystallChance = pur["CrystalChance"] == "0" ? false : true;
		game_manager.DimondMulti = pur["DimondMulti"] == "0" ? false : true;
		game_manager.DimondChance = pur["DimondChance"] == "0" ? false : true;
		game_manager.AdsOff = (pur["AdsPopupOff"] == "0" ? false : true);
		//BoostAutoClickOpen = (pur["OpenAutoclick"] == "0" ? false : true);
		game_manager.BoostAutoClick = ulong.Parse(pur["BoostAutoclick"]);
		game_manager.BoostXTime = ulong.Parse(pur["BoostXClick"]);
		game_manager.BoostX = (game_manager.BoostXTime > 0 ? true : false);
		game_manager.PayoutTotal = ulong.Parse((user_info["Money"]["PayoutTotal"]));
		game_manager.BattleCurrency = ulong.Parse(obj["Money"]["BattleCurrency"]);
		game_manager.golds = game_manager.Currency - game_manager.PayoutTotal + game_manager.BattleCurrency;
		game_manager.auto_lv = (obj["Boost"]["AutoClick"]);
		game_manager.TrapOffTime = user_info["PurchasesTime"]["TrapOffTime"];
		game_manager.BoostAutoClickTime = user_info["PurchasesTime"]["BoostAutoClickTime"];
		//game_manager.BoostXTime = user_info["PurchasesTime"]["BoostXTime"];
		game_manager.BoostCashTime = user_info["PurchasesTime"]["BoostCashTime"];
		game_manager.AdsOffTime = user_info["PurchasesTime"]["AdsOffTime"];
		game_manager.ComboTime = user_info["PurchasesTime"]["ComboTime"];
		
		Debug.Log("datasave");
		//PlayerPrefs.SetString("golds", game_manager.golds.ToString(""));
		//PlayerPrefs.SetInt("tap_lv", game_manager.tap_lv);
		//PlayerPrefs.SetInt("tap_num", game_manager.tap_num);
		//PlayerPrefs.SetInt("auto_lv", game_manager.auto_lv);
		//PlayerPrefs.SetInt("popup_lv", game_manager.popup_lv);

	}
}
