

using System.Collections;

using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public static Enemy ins;
    private void Awake()
    {
        ins = this;
    }
    public GameObject player;
    public float speed;
    public float speedPush;
    public int health = 100;
    public int currHeath;
    public Transform attackPoint;

    // public float attackRangeBoxing;
    public int damageAttack;
    public int intAttackCrit;
    public float miniumDistance;
    private Rigidbody2D rb;
    public bool isEnemyBlocked;
    public bool isEnemyAttacked = false;
    public bool startBlock;
    public GameObject fxWall;
    [SerializeField] public bool isMove = true;
    private bool isStop = true;
    [SerializeField] public bool isDie = false;
    private bool DieBool = true;
    SkeletonAnimation skeletonAnimation;
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    public AnimationCurve curve;
    [SerializeField] private float attackRange;
    [SerializeField] private LayerMask playerLayers;
    [SerializeField] private bool canMove;
    [SerializeField] private bool isRandomEnemyBlock;
    [SerializeField] private bool isPlayerAttacked;
    //animation
    [SpineAnimation] public string blockAniamtionname;
    [SpineAnimation] public string idleAnimationName;
    [SpineAnimation] public string hitAniamtionName;
    [SpineAnimation] public string moveAnamationName;
    [SpineAnimation] public string dieAniamtionName;



    //animation
    [SpineAnimation] public string attackAnimationName;
    [SpineAnimation] public string attackCritAnimationName;
    [SerializeField] private bool attacked;

    [Header("HealthBar")]
    [SerializeField] private Slider healthEnemy;
    [SerializeField] private int currenhealthbar;
    [SerializeField] private TextMeshProUGUI txthealthbar;
    ///
    //public 
    private void Start()
    {
        //
       /* List<ActionSpineEnemy> action = new List<ActionSpineEnemy>();
        action.Add(new ActionSpineEnemy("1hwp_attack1", 0.63f));
        action.Add(new ActionSpineEnemy("1hwp_attack2", 0.67f));
        action.Add(new ActionSpineEnemy("otherwp_idle", 1f));*/
        //
        Time.timeScale = 1;
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        rb = GetComponent<Rigidbody2D>();
        currHeath = health;
        isDie = false;
        if (!isDie)
        {
           //StartCoroutine(AutoAttack());
        }

        //silder health
        currenhealthbar = currHeath;
        healthEnemy.maxValue = currHeath;
        healthEnemy.value = currHeath;
        txtRound.text = "ROUND" + (Winlose.intWin_lose + 1);
        // Rewardscoins.text = "" + Rewardscoin;
        //scrWin.gameObject.SetActive(false);
    }

    public TextMeshProUGUI txtRound;
    /* [Header("win/lose")]
       public GameObject scrWin;
     public int Rewardscoin =1;
     public TextMeshProUGUI Rewardscoins;*/
    public void DamageTake(int damageTake)
    {
        if (currHeath > 0)
        {
            currHeath -= damageTake;
            DamagePush();
            healthEnemy.value = currHeath;
            FxEnemy.ins.ShowPowFx();
        }
        //  if (currHeath <= 0){
        //     //DamagePush();
        //     if(DieBool){
        //         Die();
        //         DieBool = false;
        //     }
        // }
    }
    /* private void scrWin1()
     {    Time.timeScale = 0;
          scrWin.SetActive(true);     
         //SaveCoins.instance.money += Rewardscoin 
     }*/
    private void Update()
    {

        CheckDie();
        Move();
        if (!isDie)
        {
          /*  if (attacked)
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("attack");
                    attacked = false;
                    Attack();
                    StartCoroutine(AttackCountdownCoroutine(.6f));
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Debug.Log("attackcrit");
                    AttackCrit();
                    attacked = false;
                    StartCoroutine(AttackCountdownCoroutine(.6f));
                }
            }*/
          
        }
        /*  if(win>=2)
          {
              Invoke("scrWin1", 2f);
             // scrWin1();


          }*/
        // if(startBlock){
        //     StartCoroutine(BlockCoroutine());
        //     startBlock = false;
        // }
        // if(Input.GetMouseButtonDown(0)){
        //     StartCoroutine(BlockCoroutine());
        // }
        // else {
        //     spineAnimationState.AddAnimation(0, idleAnimationName, false, 0);
        // }
        txthealthbar.text = "" + currHeath;

    }
    IEnumerator AttackCountdownCoroutine(float boxingAttackCountdown)
    {
        yield return new WaitForSeconds(boxingAttackCountdown);
        attacked = true;
    }
    private void Move()
    {
        if (!isDie)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > miniumDistance)
            {
                if (isMove)
                {
                    StartCoroutine(MoveAnimation());
                    isMove = false;
                }
            }
            else
            {
                //    if(isStop){
                //     StartCoroutine(IdleAnimation());
                //     isStop = false;
                //     }
                spineAnimationState.AddAnimation(0, idleAnimationName, true, 0);
            }
        }
    }

    // private void DamagePush(){
    //     transform.Translate(Vector3.right * speedPush * Time.deltaTime);
    // }
    private void DamagePush()
    {
        rb.AddForce(Vector3.right * speedPush);
        spineAnimationState.SetAnimation(0, hitAniamtionName, false);
        spineAnimationState.AddAnimation(0, idleAnimationName, true, 0);
        FxEnemy.ins.ShowPowFx();
    }
    IEnumerator BlockCoroutine(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        spineAnimationState.SetAnimation(0, blockAniamtionname, false);
        yield return new WaitForSeconds(.1f);
        isEnemyBlocked = true;
        yield return new WaitForSeconds(.3f);
        isEnemyBlocked = false;
    }

    public void Block(float timeDelay)
    {
        //timedelay = .1 thi block, khac 0.1 thi block hut
        StartCoroutine(BlockCoroutine(timeDelay));
    }
    IEnumerator MoveAnimation()
    {
        spineAnimationState.SetAnimation(0, moveAnamationName, false).TimeScale = 1.5f;
        yield return new WaitForSeconds(.111f);
        //rb.AddForce(Vector3.right * speed * Time.deltaTime);
        rb.velocity = new Vector2(-1.5f, 0);
        yield return new WaitForSeconds(.444f);
        isMove = true;
    }
    // IEnumerator IdleAnimation(){
    //     spineAnimationState.AddAnimation(0, idleAnimationName, true, 0);
    //     yield return new WaitForSeconds(1f);
    //     isStop = true;
    // }
    private void Die()
    {
        StartCoroutine(DieCoroutine());
    }
    IEnumerator DieCoroutine()
    { enemylose = true;
        isDie = true;
        Debug.Log("enemy die cmnr");
        rb.AddForce(Vector3.right * speedPush / 30);
        spineAnimationState.SetAnimation(0, hitAniamtionName, false);
        yield return new WaitForSeconds(0.4f);
        FxEnemy.ins.ShowDieFx();
        spineAnimationState.SetAnimation(1, dieAniamtionName, false);
       // yield return new WaitForSeconds(0.6f);
        
       
        yield return null;
    }
    public static bool enemylose;
    private void CheckDie()
    {
        if (currHeath <= 0)
        {
            if (DieBool)
            {
                Die();
                DieBool = false;
                isDie = true;
               
                Winlose.win++;
                Winlose.intWin_lose++;
                Debug.Log(Winlose.win + "enemy");
               // Winlose.intRound++;

            }
        }
    }
    /*public void turnoffscrwin()
    {
        scrWin.gameObject.SetActive(false);
        win = 0;
        SaveCoins.instance.money += Rewardscoin;
    } */
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if (!isDie)
            {
                rb.velocity = new Vector2(-2f, 0);
                StartCoroutine(hitWall());
            }
            else
            {
                rb.velocity = new Vector2(-3f, 0);
                StartCoroutine(hitWall());
            }
        }
        
    }
    IEnumerator hitWall()
    {
        fxWall.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        fxWall.SetActive(false);
    }
    // danh thuong
    public void Attack()
    {
        //if(canAttack){
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (Collider2D player in hitplayer)
        {
            if (player)
            {
               // player.GetComponent<PlayerController>().DamageTake(damageAttack);
               // Debug.Log(player.name);
                StartCoroutine(AttackCoroutine());
                isMove = true;
            }
            else
            {
                return;
            }
        }
        spineAnimationState.SetAnimation(0, attackAnimationName, false);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator AttackCoroutine()
    {
        canMove = false;
       //layerController.ins.Block(.1f);
       
        yield return new WaitForSeconds(0.3f);
        isEnemyAttacked = true;
        if(isEnemyAttacked && !PlayerController.ins.isPlayerBlock)
        {
            PlayerController.ins.DamageTake(damageAttack);
        }
        
        else if (PlayerController.ins.isPlayerBlock && isEnemyAttacked)
        {
            FxPlayer.inst.ShowBlockFx();
            Debug.Log("player block");
        }
        yield return new WaitForSeconds(.2f);
        isEnemyAttacked = false;
        canMove = true;
    }
    //danh chi mang
    public void AttackCrit()
    {
        //if(canAttack){
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (Collider2D player in hitPlayer)
        {
            if (player)
            {
                StartCoroutine(AttackCritCoroutine());
                isMove = true;
            }
            else
            {
                return;
            }
        }
        spineAnimationState.SetAnimation(0, attackCritAnimationName, false);
       
        //}
    }
    //delay
    IEnumerator AttackCritCoroutine()
    {
        canMove = false;
       //layerController.ins.Block(.1f);
        yield return new WaitForSeconds(0.3f);
        isEnemyAttacked = true;

        if (isEnemyAttacked && !PlayerController.ins.isPlayerBlock)
        {
            PlayerController.ins.DamageTake(damageAttack*intAttackCrit);
        }

        else if (PlayerController.ins.isPlayerBlock && isEnemyAttacked)
        {
            FxPlayer.inst.ShowBlockFx();
            Debug.Log("player block");
        } 
        yield return new WaitForSeconds(.2f);
        isEnemyAttacked = false;
        canMove = true;
    }
    //public bool isStartAttack = true;
    /*IEnumerator AutoAttack()
    {
        while (isStartAttack)
        {

            yield return new WaitForSeconds(1f);
            Attack();
            StartCoroutine(AttackCountdownCoroutine(.63f)); 
           yield return new WaitForSeconds(0.6f);
            AttackCrit();
            Attack();
             StartCoroutine(AttackCountdownCoroutine(1f));
            yield return new WaitForSeconds(1.2f);
            Attack();
            yield return new WaitForSeconds(1.8f);
            Attack();
            yield return new WaitForSeconds(1f);
            AttackCrit();
           *//* yield return new WaitForSeconds(3.3f);
            Attack();*//*
            //  StartCoroutine(AttackCountdownCoroutine(.63f));
        }


    }*/
}
