using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreOwnerCtl : MonoBehaviour
{
    private Transform OwnerTr;
    private Transform PlayerTr;
    public Canvas storeUI_buy;
    public Canvas storeUI_sell;
    public CanvasGroup storeUI_group_b;
    public CanvasGroup storeUI_group_s;
    private bool buy_sell;
    public GameObject gameDataCtl;
    public GameDataCtrl data;
    public Text chicken_t;
    public Text sheep_t;
    public Text goat_t;
    public Text gun_t;
    public Text bullet_t;
    public Text shield_t;
    public Text potion_t;
    public Text nail_t;
    public Text gold_t;
    public Text tree_t;
    public Text block_t;
    public Text marble_t;
    public Text cement_t;
    public Text silling_t_s;
    public Text silling_t_b;
    //팔기
    public Text sheeppur_t;
    public Text egg_t;
    public Text goatmilk_t;
    public Text carrot_t;
    public Text eggplant_t;
    public Text pumpkin_t;
    public Text tomato_t;


    //private NavMeshAgent nvAgent;
    public float traceDist = 10.0f;

    // Use this for initialization
    void Start()
    {
        OwnerTr = this.gameObject.GetComponent<Transform>();
        PlayerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        gameDataCtl = GameObject.Find("GameData");
        data = gameDataCtl.GetComponent<GameDataCtrl>();

        buy_sell = true;
        storeUI_buy.enabled = false;
        storeUI_sell.enabled = false;
        storeUI_group_b.alpha = 0;
        storeUI_group_s.alpha = 0;
        silling_t_b.text = data.silling.ToString();
        silling_t_s.text = data.silling.ToString();

        chicken_t.text = data.chicken.ToString();
        sheep_t.text = data.sheep.ToString();
        goat_t.text = data.goat.ToString();
        bullet_t.text = data.bullet.ToString();
        gun_t.text = data.gun.ToString();
        shield_t.text = data.sheild.ToString();
        potion_t.text = data.potion.ToString();
        nail_t.text = data.nail.ToString();
        gold_t.text = data.gold.ToString();
        tree_t.text = data.tree.ToString();
        block_t.text = data.block.ToString();
        marble_t.text = data.marble.ToString();
        cement_t.text = data.cement.ToString();

        goatmilk_t.text = data.goat_milk.ToString();
        egg_t.text = data.chicken_egg.ToString();
        sheeppur_t.text = data.sheep_pur.ToString();
        tomato_t.text = data.tomato.ToString();
        eggplant_t.text = data.eggplant.ToString();
        pumpkin_t.text = data.pumpkin.ToString();
        carrot_t.text = data.carrot.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(this.CheckDist());
    }
    IEnumerator CheckDist()
    {
        yield return new WaitForSeconds(0.2f);
        float dist = Vector3.Distance(PlayerTr.position, OwnerTr.position);
        if (dist <= traceDist)
        {
            //캔버스 활성화
            if (buy_sell == true)
            {
                storeUI_sell.enabled = false;
                storeUI_group_s.alpha = 0;
                storeUI_buy.enabled = true;
                storeUI_group_b.alpha = 1;
            }
            else
            {
                storeUI_buy.enabled = false;
                storeUI_group_b.alpha = 0;
                storeUI_sell.enabled = true;
                storeUI_group_s.alpha = 1;
            }


            //storeUI_group_b.interactable = true;
        }
        else
        {
            storeUI_buy.enabled = false;
            storeUI_group_b.alpha = 0;
            storeUI_sell.enabled = false;
            storeUI_group_s.alpha = 0;
        }

    }
    public void OnClickSellButton(string msg)
    {

        buy_sell = false;
        silling_t_s.text = data.silling.ToString();
        //storeUI_buy.enabled = false;
        //storeUI_group_b.alpha = 0;
        //storeUI_sell.enabled = true;
        //storeUI_group_s.alpha = 1;


    }
    public void OnClickBuyButton(string msg)
    {
        buy_sell = true;
        silling_t_b.text = data.silling.ToString();
        //storeUI_sell.enabled = false;
        //storeUI_group_s.alpha = 0;
        //storeUI_buy.enabled = true;
        //storeUI_group_b.alpha = 1;

    }
    public void OnClickItemBuy(string msg)
    {
        if (msg == "chicken")
        {
            if (data.silling >= data.price_chicken && data.chicken < 3)
            {
                data.chicken += 1;
                chicken_t.text = data.chicken.ToString();
                data.silling -= data.price_chicken;
                silling_t_b.text = data.silling.ToString();
            }

        }
        else if (msg == "sheep")
        {

            if (data.silling >= data.price_sheep && data.sheep<3)
            {
                data.sheep += 1;
                sheep_t.text = data.sheep.ToString();
                data.silling -= data.price_sheep;
                silling_t_b.text = data.silling.ToString();
            }
        }
        else if (msg == "goat")
        {

            if (data.silling >= data.price_goat && data.goat < 3)
            {
                data.goat += 1;
                goat_t.text = data.goat.ToString();
                data.silling -= data.price_goat;
                silling_t_b.text = data.silling.ToString();
            }
        }
        else if (msg == "bullet")
        {

            if (data.silling >= data.price_bullet && data.bullet < 1)
            {
                data.bullet += 1;
                bullet_t.text = data.bullet.ToString();
                data.silling -= data.price_bullet;
                silling_t_b.text = data.silling.ToString();
            }
        }
        else if (msg == "gun")
        {

            if (data.silling >= data.price_gun && data.gun < 1)
            {
                data.gun += 1;
                gun_t.text = data.gun.ToString();
                data.silling -= data.price_gun;
                silling_t_b.text = data.silling.ToString();
            }
        }
        else if (msg == "sheild")
        {

            if (data.silling >= data.price_sheild && data.sheild < 1)
            {
                data.sheild += 1;
                shield_t.text = data.sheild.ToString();
                data.silling -= data.price_sheild;
                silling_t_b.text = data.silling.ToString();
            }
        }
        else if (msg == "potion")
        {

            if (data.silling >= data.price_potion)
            {
                data.potion += 1;
                potion_t.text = data.potion.ToString();
                data.silling -= data.price_potion;
                silling_t_b.text = data.silling.ToString();
            }
        }
        else if (msg == "nail")
        {

            if (data.silling >= data.price_nail)
            {
                data.nail += 1;
                nail_t.text = data.nail.ToString();
                data.silling -= data.price_nail;
                silling_t_b.text = data.silling.ToString();
            }

        }
        else if (msg == "gold")
        {

            if (data.silling >= data.price_gold)
            {
                data.gold += 1;
                gold_t.text = data.gold.ToString();
                data.silling -= data.price_gold;
                silling_t_b.text = data.silling.ToString();
            }

        }
        else if (msg == "tree")
        {

            if (data.silling >= data.price_tree)
            {
                data.tree += 1;
                tree_t.text = data.tree.ToString();
                data.silling -= data.price_tree;
                silling_t_b.text = data.silling.ToString();
            }

        }
        else if (msg == "block")
        {

            if (data.silling >= data.price_block)
            {
                data.block += 1;
                block_t.text = data.block.ToString();
                data.silling -= data.price_block;
                silling_t_b.text = data.silling.ToString();
            }

        }
        else if (msg == "marble")
        {

            if (data.silling >= data.price_marble)
            {
                data.marble += 1;
                marble_t.text = data.marble.ToString();
                data.silling -= data.price_marble;
                silling_t_b.text = data.silling.ToString();
            }

        }
        else if (msg == "cement")
        {

            if (data.silling >= data.price_cement)
            {
                data.cement += 1;
                cement_t.text = data.cement.ToString();
                data.silling -= data.price_cement;
                silling_t_b.text = data.silling.ToString();
            }

        }


    }
    public void OnClickItemSell(string msg)
    {
        if (msg == "carrot")
        {
            if (data.carrot >= 1) {
                data.carrot -= 1;
                data.silling += data.price_carrot;
                carrot_t.text = data.carrot.ToString();
                silling_t_s.text = data.silling.ToString();
            }
        }
        else if (msg == "pumpkin")
        {
            if (data.pumpkin >= 1)
            {
                data.pumpkin -= 1;
                data.silling += data.price_pumpkin;
                pumpkin_t.text = data.pumpkin.ToString();
                silling_t_s.text = data.silling.ToString();
            }

        }
        else if (msg == "eggplant")
        {
            if (data.eggplant >= 1)
            {
                data.eggplant -= 1;
                data.silling += data.price_eggplant;
                eggplant_t.text = data.eggplant.ToString();
                silling_t_s.text = data.silling.ToString();
            }

        }
        else if (msg == "tomato")
        {
            if (data.tomato >= 1)
            {
                data.tomato -= 1;
                data.silling += data.price_tomato;
                tomato_t.text = data.tomato.ToString();
                silling_t_s.text = data.silling.ToString();
            }
        }
        else if (msg == "sheeppur")
        {
            if (data.sheep_pur >= 1)
            {
                data.sheep_pur -= 1;
                data.silling += data.price_sheep_pur;
                sheeppur_t.text = data.sheep_pur.ToString();
                silling_t_s.text = data.silling.ToString();
            }
        }
        else if (msg == "egg")
        {
            if (data.chicken_egg >= 1)
            {
                data.chicken_egg -= 1;
                data.silling += data.price_chicken_egg;
                egg_t.text = data.chicken_egg.ToString();
                silling_t_s.text = data.silling.ToString();
            }
        }
        else if (msg == "goatmilk")
        {
            if (data.goat_milk >= 1)
            {
                data.goat_milk -= 1;
                data.silling += data.price_goat_milk;
                goatmilk_t.text = data.goat_milk.ToString();
                silling_t_s.text = data.silling.ToString();
            }
        }

    }
    public void OnClickUpgradeHouse(string msg)
    {
    
        if (data.house_level == 0 && data.tree >= 100 && data.nail >= 100)
        {
            Debug.Log("집업그레이드 클릭");
            data.tree -= 100;
            data.nail -= 100;
            tree_t.text = data.tree.ToString();
            nail_t.text = data.nail.ToString();
            data.house_level = 1; //나무집
        }
        else if (data.house_level == 1 && data.block >= 100 && data.cement >= 100)
        {
            data.block -= 100;
            data.cement -= 100;
            block_t.text = data.block.ToString();
            cement_t.text = data.cement.ToString();

            data.house_level = 2; //벽돌집
        }
        else if (data.house_level == 2 && data.marble >= 100 && data.gold >= 100 && data.cement >=100)
        {
            data.marble -= 100;
            data.gold -= 100;
            data.cement -= 100;

            marble_t.text = data.marble.ToString();
            gold_t.text = data.gold.ToString();
            cement_t.text = data.cement.ToString();
            data.house_level = 3; //궁전

        }
    }
}
  