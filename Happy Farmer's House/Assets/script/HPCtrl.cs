using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPCtrl : MonoBehaviour {
    public GameObject gameDataCtl;
    public GameDataCtrl data;
    public Text hpText;
    public Text maxhpText;

    // Use this for initialization
    void Start () {
        gameDataCtl = GameObject.Find("GameData");
        data = gameDataCtl.GetComponent<GameDataCtrl>();
        hpText.text = data.playerHp.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        hpText.text = data.playerHp.ToString();
        if (data.isShield == true)
        {
            maxhpText.text = "/1200";
        }
        else {
            maxhpText.text = "/700";
        }
    }

    public void OnClickPosion(string msg) {
        if (data.potion >0) {
            if (data.isShield == true)
            {
                if (data.playerHp < 1200)
                {
                    data.potion -= 1;
                    if (data.playerHp >= 1100)
                    {
                        data.playerHp = 1200;
                    }
                    else
                    {
                        data.playerHp += 100;
                    }
                }

            }
            else {
                if (data.playerHp < 700)
                {
                    data.potion -= 1;
                    if (data.playerHp >= 600)
                    {
                        data.playerHp = 700;
                    }
                    else
                    {
                        data.playerHp += 100;
                    }
                }
            }

        }
      
     }
   
}
