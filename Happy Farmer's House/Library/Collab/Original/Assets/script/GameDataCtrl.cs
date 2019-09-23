using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataCtrl : MonoBehaviour {
    public int sheep_pur;
    public int goat_milk;
    public int chicken_egg;
    public int sheep = 2;
    public int goat = 2;
    public int chicken = 2;
    public int carrot;
    public int eggplant;
    public int pumpkin;
    public int tomato;
    public int gun;
    public int bullet;
    public int potion;
    public int sheild;
    public int nail;
    public int gold;
    public int tree;
    public int block;
    public int marble;
    public int cement;
    public int silling;
    //public GameObject gameDataCtrl;
    public int price_sheep_pur = 14;
    public int price_goat_milk = 18;
    public int price_chicken_egg = 6;
    public int price_carrot = 1;
    public int price_eggplant = 4;
    public int price_pumpkin =10;
    public int price_tomato = 7;
    public int price_gun = 15;
    public int price_bullet = 10;
    public int price_potion = 5;
    public int price_sheild = 30;
    public int price_nail = 1;
    public int price_gold =10;
    public int price_tree= 2;
    public int price_block = 5;
    public int price_marble =8;
    public int price_cement = 3;
    public int price_sheep = 20;
    public int price_goat = 25;
    public int price_chicken = 15;
    public int playerHp;
    public bool isShield = false;       //방패 사용 유무
    public int house_level;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        sheep_pur = 0;
        goat_milk = 0;
        chicken_egg = 0;
        carrot = 0;
        eggplant = 0;
        pumpkin = 0;
        tomato = 0;
        gun = 0;
        bullet = 0;
        potion = 0;
        sheild = 0;
        nail = 0;
        gold = 0;
        tree = 0;
        block = 0;
        marble = 0;
        cement = 0;
        silling = 0;
        house_level = 0;
        if (isShield)
            playerHp = 1200;
        else
            playerHp = 700;
    }
    void Start () {
        
       
    }

    // Update is called once per frame
    void Update()
    {
    }
}
