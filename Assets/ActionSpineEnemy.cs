using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
public class ActionSpineEnemy : MonoBehaviour
{
    [SpineAnimation] public string AnimationAttack1;
    [SpineAnimation] public string AnimationAttack2;
    [SpineAnimation] public string AnimationIdle;
    public SkeletonAnimation anim;
    public Spine.AnimationState spineAnimtaionState;
    public float duration = 0f;
    private string v1;
    private float v2;
    [SerializeField] private float time;
    public int currentAction;
    public List<DataSpineEnemy> action = new List<DataSpineEnemy>();
    private bool nextAction = true;
    [SerializeField] private int loadlist=1;
    public ActionSpineEnemy(string v1, float v2)
    {
        this.v1 = v1;
        this.duration = v2;
    }
    [System.Serializable]
    public class DataSpineEnemy{
        public string v1; 
        public float duration;
        public DataSpineEnemy() { }
        public DataSpineEnemy(string v1, float v2)
        {
            this.v1 = v1;
            this.duration = v2;
        }
    }
    /*public void AnimationSpine(string attack1,float durat)
    {
        AnimationAttack1 = attack1;
        duration = durat;
    }*/
    private void Awake()
    {

     
    }
    public bool start = false;
    private void Start()
    {
        
        anim = GetComponent<SkeletonAnimation>();
       if(Enemy.ins.isMove)
        {
            if (loadlist == 1)
            {
            action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
            action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
            action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
            action.Add(new DataSpineEnemy(AnimationIdle, 1));
            action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 2)
            {
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 3)
            {
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));           
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f)); 
            }
            if (loadlist == 4)
            {   
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 5)
            {   action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 6)
            {   action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 7)
            {   action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
               
            }
            if (loadlist == 8)
            {   action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 9)
            {   action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 10)
            {   action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));   
            }
            if (loadlist == 11)
            {
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f)); 
            }
            if (loadlist == 12)
            {
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));    
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.67f));
            }
            if (loadlist == 13)
            { 
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            //6attack
            if (loadlist == 14)
            {
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 15)
            {
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                
            }
            if (loadlist == 16)
            {
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 17)
            {
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
            }
            if (loadlist == 18)
            {
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
            }
            if (loadlist == 19)
            {
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
            }
            if (loadlist == 20)
            {
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));            
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationIdle, 1f));
                action.Add(new DataSpineEnemy(AnimationAttack1, 0.63f));
                action.Add(new DataSpineEnemy(AnimationAttack2, 0.67f));
            }
        }    
       
      
   

        ApplyAction(action[0]);
        start = true;
    }
    private void Update()
    {
        if (!Enemy.ins.isDie )
        {
            time += Time.deltaTime;
            if (!start) return;
            if (time >= duration)
            {

                ApplyAction();
                nextAction = false;

            }
        }
    }
    private void ApplyAction(DataSpineEnemy dataAction)
    {
        duration = dataAction.duration;
        time = 0;
        //todo playanim 
      
        anim.AnimationState.SetAnimation(0, action[currentAction].v1, false);
    }
    private void ApplyAction()
    {
        currentAction += 1;
        if(currentAction> action.Count)
        {
            currentAction = 0;
        }
        duration = action[currentAction].duration;
        time = 0;

        if(action[currentAction].v1 == AnimationAttack1)
        {
            Enemy.ins.Attack();
        }
        else
        {
            anim.AnimationState.SetAnimation(0, action[currentAction].v1, false);
        }
        if (action[currentAction].v1 == AnimationAttack2)
        {
            Enemy.ins.AttackCrit();
        }
        else
        {
            anim.AnimationState.SetAnimation(0, action[currentAction].v1, false);
        }
    }
}
