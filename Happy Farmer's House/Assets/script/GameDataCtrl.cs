using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataCtrl : MonoBehaviour {
    public int sheep_pur = 10;
    public int goat_milk = 10;
    public int chicken_egg = 10;
    public int sheep = 1;
    public int goat = 1;
    public int chicken = 0;
    public int carrot = 10;
    public int eggplant = 10;
    public int pumpkin = 10;
    public int tomato = 10;
    public int gun;
    public int bullet;
    public int potion = 10;
    public int sheild;
    public int nail=100;
    public int gold = 100;
    public int tree = 100;
    public int block = 100;
    public int marble = 100;
    public int cement = 100;
    public int silling = 1000;
    //public GameObject gameDataCtrl;
    public int price_sheep_pur = 14;
    public int price_goat_milk = 18;
    public int price_chicken_egg = 6;
    public int price_carrot = 1;
    public int price_eggplant = 4;
    public int price_pumpkin = 10;
    public int price_tomato = 7;
    public int price_gun = 15;
    public int price_bullet = 10;
    public int price_potion = 5;
    public int price_sheild = 30;
    public int price_nail = 1;
    public int price_gold = 10;
    public int price_tree = 2;
    public int price_block = 5;
    public int price_marble = 8;
    public int price_cement = 3;
    public int price_sheep = 20;
    public int price_goat = 25;
    public int price_chicken = 15;
    public int playerHp = 700;
    public bool isShield = false;       //방패 사용 유무
    public int house_level = 0 ;
    // Use this for initialization

    //손에쥔 아이템 정보
    public int hand_plant; //1: 당근 2:가지 3: 토마토 4: 호박
    public bool hand_gun;
    public bool hand_shield;

    // 농작물 수확시간
    public float carrotTime = 10.0f; //
    public float eggplantTime = 20.0f; //
    public float tomatoTime = 30.0f; //  영업이익율이 개인에게 많이 반영되어서 돌아오는편인가 요?
    public float pumpkinTime = 40.0f; //
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        hand_plant = 1;
        hand_gun = false;
        isShield = false;
        /*   sheep_pur = 10;
          goat_milk = 0;
          chicken_egg = 0;
          carrot = 0;
          eggplant = 0;
          pumpkin = 0;
          tomato = 0;
          gun = 1;
          bullet = 0;
          potion = 2;
          sheild = 0;
          nail = 0;
          gold = 0;
          tree = 0;
          block = 0;
          marble = 0;
          cement = 0;
          silling = 0;
          house_level = 0;*/
          playerHp = 700;
    }
    void Start () {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
