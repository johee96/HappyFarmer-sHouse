using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Monster_rabbit_Ctrl : MonoBehaviour {
    

    private Transform MonsterTr;
    private Transform PlayerTr;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    public GameObject bloodEffect;
    public GameObject bloodDecal;

    public enum MonsterState { idle, trace, attack, die };
    public MonsterState monsterState = MonsterState.idle;

    public float traceDist = 10.0f;
    public float attackDist = 2.0f;
    private bool isDie = false;

    public GameObject sparkEffect;

    private int hitCount = 0;
    public GameObject silling;

    [System.Serializable]
    public class Anim
    {
        public AnimationClip idle;
        public AnimationClip run;

        public Animation _animation;
    }
    public Anim anim;
    public Animation _animation;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BULLET")
        {
            GameObject spark = (GameObject)Instantiate(sparkEffect, collision.transform.position, Quaternion.identity);
            hitCount++;
            Destroy(spark, spark.GetComponent<ParticleSystem>().duration+0.001f);
            Destroy(collision.gameObject, 0.2f);
        }
    }

    // Use this for initialization
    void Start()
    {
        MonsterTr = this.gameObject.GetComponent<Transform>();
        PlayerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        _animation = GetComponentInChildren<Animation>();
        _animation.clip = anim.idle;
        _animation.Play();

        StartCoroutine(this.CheckMonsterState());
        StartCoroutine(this.MonsterAction());


    }

    // Update is called once per frame
    void Update()
    {

        if (hitCount == 2)
        {
            hitCount = 0;
            Instantiate(silling, gameObject.transform.position, gameObject.transform.rotation);    //생성하는 것 프리팹을 화면에 보이게 함       
            Destroy(gameObject, 0.2f);
            RandomMonster.rabbitCount--;
         
        }

    }


    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.2f);
            float dist = Vector3.Distance(PlayerTr.position, MonsterTr.position);
            if (dist <= attackDist)
                monsterState = MonsterState.attack;
            else if (dist <= traceDist)
                monsterState = MonsterState.trace;
            else
                monsterState = MonsterState.idle;
        }

    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (monsterState)
            {
                case MonsterState.idle:
                    nvAgent.Stop();
                    _animation.CrossFade(anim.idle.name, 0.3f);
                    //     animator.SetBool("isTrace", false);
                    break;
                case MonsterState.trace:
                    nvAgent.destination = PlayerTr.position;
                    nvAgent.Resume();
                    _animation.CrossFade(anim.run.name, 0.3f);
                    // animator.SetBool("IsAttack", false);
                    //    animator.SetBool("isTrace", true);
                    break;
               

            }

            yield return null;
        }
    }
}
