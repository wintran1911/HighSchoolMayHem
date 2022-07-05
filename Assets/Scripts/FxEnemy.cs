
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class FxEnemy : MonoBehaviour
{
    public static FxEnemy ins;
    private void Awake() {
        ins = this;
    }
    public GameObject enemy;
   
   // Spine Animation
   [SpineAnimation] public string blockAniamtionname;
   [SpineAnimation] public string bonkAnimationName;
   [SpineAnimation] public string dieAniamtionName;
   [SpineAnimation] public string powAnimationName;
   
    SkeletonAnimation skeletonAnimation;
	public Spine.AnimationState spineAnimationState;
	public Spine.Skeleton skeleton;
    public bool bienBool = false;
    private void Start() {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
		spineAnimationState = skeletonAnimation.AnimationState;
		skeleton = skeletonAnimation.Skeleton;
        this.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (bienBool)
        {
            this.gameObject.transform.position = new Vector2(enemy.transform.position.x, enemy.transform.position.y + 1f);
            gameObject.transform.eulerAngles = new Vector3(
    enemy.transform.eulerAngles.x,
    enemy.transform.eulerAngles.y,
    enemy.transform.eulerAngles.z
);
        }
        //this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, enemy.transform.position.y + 10f);
    }
    public void ShowBlockFx(){
        this.gameObject.SetActive(true);
        StartCoroutine(BlockFxCortoutine());
    }
    public void ShowPowFx(){
        this.gameObject.SetActive(true);
        StartCoroutine(PowFxCortoutine());
        //spineAnimationState.SetAnimation(0, dieAniamtionName, true);
    }
    public void ShowDieFx(){
        //this.gameObject.transform.position = dieFxPosition.position;
        this.gameObject.SetActive(true);
        StartCoroutine(DieFxCortoutine());
        //spineAnimationState.SetAnimation(0, dieAniamtionName, true);
    }
    IEnumerator BlockFxCortoutine(){
        spineAnimationState.SetAnimation(0, blockAniamtionname, false);
        yield return new WaitForSeconds(.2f);
        this.gameObject.SetActive(false);
    }
    IEnumerator PowFxCortoutine(){
        spineAnimationState.SetAnimation(0, powAnimationName, false);
        yield return new WaitForSeconds(.2f);
        this.gameObject.SetActive(false);
    }
    IEnumerator DieFxCortoutine(){
        spineAnimationState.SetAnimation(0, dieAniamtionName, true);
        bienBool = true;
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
        bienBool = false;
    }
}
