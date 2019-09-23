using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmCtrl : MonoBehaviour {
    public Canvas Choose_P;
    public Canvas Choose_G;
    public Canvas Choose_S;
    public GameObject gameDataCtl;
    public GameDataCtrl data;
    public Image carrot_img; //핸드 아이템 이미지
    public Image eggplant_img;
    public Image tomato_img;
    public Image pumpkin_img;
    public Image gun_img; //핸드 건 이미지
    public Image sheild_img; //핸드 쉴드 이미지
    public Button gun_img_p; //팝업창의 건 버튼
    public Button sheild_img_p; //팝업창의 쉴드 버튼

    // Use this for initialization
    void Start () {
        gameDataCtl = GameObject.Find("GameData");
        data = gameDataCtl.GetComponent<GameDataCtrl>();
        Choose_P.enabled = false;
        Choose_G.enabled = false;
        Choose_S.enabled = false;
        if (data.gun == 0 ) {
            gun_img.enabled = false;//핸드의 건
            gun_img_p.enabled = false;
        }
        if (data.sheild == 0 )
        {
            sheild_img.enabled = false;
            sheild_img_p.enabled = false;

        }

        if (data.hand_gun == false) {
            gun_img.enabled = false;
        }
        if (data.isShield == false)
        {
            sheild_img.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (data.gun != 0)
        {
            
            gun_img_p.enabled = true;
        }
        if (data.sheild != 0)
        {
          
            sheild_img_p.enabled = true;

        }

    }
    public void OnclickItemHand(int msg)
    {
        if (msg == 1)
        {
            Choose_P.enabled = true;
            Choose_G.enabled = false;
            Choose_S.enabled = false;
        }
        else if (msg == 2)
        {
            Choose_P.enabled = false;
            Choose_G.enabled = true;
            Choose_S.enabled = false;
        }
        else {
            Choose_P.enabled = false;
            Choose_G.enabled = false;
            Choose_S.enabled = true;
        }

    }
    public void OnclickPlant(string msg)
    {
        if (msg == "carrot")
        {
            carrot_img.enabled = true;
            eggplant_img.enabled = false;
            tomato_img.enabled = false;
            pumpkin_img.enabled = false;//그림바꿔주고
            data.hand_plant = 1;                 //데이터에서 내손에 있는정보 바꾸기
        }
        else if (msg == "eggplant")
        {
            carrot_img.enabled = false;
            eggplant_img.enabled = true;
            tomato_img.enabled = false;
            pumpkin_img.enabled = false;//그림바꿔주고
            data.hand_plant = 2;
        }
        else if (msg == "tomato")
        {
            carrot_img.enabled = false;
            eggplant_img.enabled = false;
            tomato_img.enabled = true;
            pumpkin_img.enabled = false;//그림바꿔주고
            data.hand_plant = 3;
        }
        else if (msg == "pumpkin")
        {
            carrot_img.enabled = false;
            eggplant_img.enabled = false;
            tomato_img.enabled = false;
            pumpkin_img.enabled = true;//그림바꿔주고
            data.hand_plant = 4;
        }

    }
    public void Onclickcancle(string msg)
    {
        
            Choose_P.enabled = false;
            Choose_G.enabled = false;
            Choose_S.enabled = false;
        

    }
    public void OnclickGun(string msg)
    {
        
            gun_img.enabled = true;
            data.hand_gun = true;                 //데이터에서 내손에 있는정보 바꾸기
      
    }
    public void OnclickShield(string msg)
    {
      
            sheild_img.enabled = true;
            data.isShield = true;                 //데이터에서 내손에 있는정보 바꾸기
      

    }
}
