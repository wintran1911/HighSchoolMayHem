using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine.Unity.AttachmentTools;
using Spine;
using UnityEngine.UI;
using TMPro;
public class WeaPonPlayer : MonoBehaviour
{
    //button
    [SerializeField] private Button btnPrew;
    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnequip;
    [SerializeField] private TextMeshProUGUI txtnequip;

    // character skins
    [SpineSkin] public string[] InitaialSkin = {"boxing","bua","chao","gang_tay","gay_bong_chay","gay_goft","iron_fist","muoi_chien_com","thuoc_ke" };
    public static int activeWeaponIndex = 0;
    public int abc;
    SkeletonAnimation skeletonAnimation;
    Skin characterSkin;
    private bool IsWeapon;
   /* [Header("PLay/Buy btn")]
      [SerializeField] private Button btnPlay;
      [SerializeField] private Button btnBuy;
      [SerializeField] private TextMeshProUGUI txtCoinsPrice;
      

    [Header("weapon unlock")]
      [SerializeField] private int[] WeaponPrices;*/

    // Start is called before the first frame update
    private void Awake()
    {
        skeletonAnimation = this.GetComponent<SkeletonAnimation>();
        PlayerPrefs.GetInt("activeWeaponIndex", activeWeaponIndex);
       
    }
    void Start()
    {
        
        /*
         if (!PlayerPrefs.HasKey("activeWeaponIndex"))
         {
             activeWeaponIndex = 0;
         }
         else*/
        {
           LoadWeaPon();
        }
        UpdateCharacterSkin();
        UpdateCombinedSkin();
        btnPrew.onClick.AddListener(PrevWeponSkin);
        btnPrew.onClick.AddListener(NextWeaponSkin);
    }

    // Update is called once per frame
    void Update()
    {
        abc = selectIdle=activeWeaponIndex ;
       // openWeapon();
       /* if (selectIdle == 0)
        {
            spineAnimationState.SetAnimation(0, idleAnimationgangtay, true);
            spineAnimationState.SetAnimation(1, mix_pinwheel, true);

        }
        if (selectIdle == 1)
        {
            spineAnimationState.SetAnimation(0, idleAnimation12hand, true);
            spineAnimationState.SetAnimation(1, mix_pinwheel, true);

        }
        if (selectIdle == 2)
        {
            spineAnimationState.SetAnimation(0, idleAnimation12hand, true);
            spineAnimationState.SetAnimation(1, mix_pinwheel, true);

        }
        if (selectIdle == 3)
        {
            spineAnimationState.SetAnimation(0, idleAnimationgangtay, true);
            spineAnimationState.SetAnimation(1, mix_pinwheel, true);

        }
        if (selectIdle == 4)
        {
            spineAnimationState.SetAnimation(0, idleAnimationgangtay, true);
            spineAnimationState.SetAnimation(1, mix_pinwheel, true);

        }
        if (selectIdle == 5)
        {
            spineAnimationState.SetAnimation(0, idleAnimation12hand, true);
            spineAnimationState.SetAnimation(1, mix_pinwheel, true);
        }
        if (selectIdle == 6)
        {
            spineAnimationState.SetAnimation(0, idleAnimation12hand, true);
            spineAnimationState.SetAnimation(1, mix_pinwheel, true);
        }
        if (selectIdle == 7)
        {
            spineAnimationState.SetAnimation(0, idleAnimation12hand, true);
            spineAnimationState.SetAnimation(1, mix_pinwheel, true);
        }
        if (selectIdle == 8)
        {
            spineAnimationState.SetAnimation(0, idleAnimationbonxing, true);
            spineAnimationState.SetAnimation(1, mix_pinwheel, true);
        }*/
    }
     public void btnEquip()
    {
        SaveWeaPones();
        if (Selectionprices.buyweapon) 
        {
         txtnequip.text = "EQUIPED";
        }
        else { txtnequip.text = "EQUIP"; }
        PlayerPrefs.SetString("EQUIIED", txtnequip.text);
        PlayerPrefs.Save();
        
    }
        
    public void NextWeaponSkin()
    {
        txtnequip.text = "EQUIP";
        activeWeaponIndex = (activeWeaponIndex + 1) % InitaialSkin.Length;
        UpdateCharacterSkin();
        UpdateCombinedSkin();
        // SaveWeaPones();
        // GobalDataWeapon.IndexWeaPon = activeWeaponIndex;
    }

    public void PrevWeponSkin()
    {
        txtnequip.text = "EQUIP";
        activeWeaponIndex = (activeWeaponIndex + InitaialSkin.Length - 1) % InitaialSkin.Length;
        UpdateCharacterSkin();
        UpdateCombinedSkin();
        //  SaveWeaPones();
        //  GobalDataWeapon.IndexWeaPon = activeWeaponIndex;
       
    }
   public void UpdateCharacterSkin()
    {
        var skeleton = skeletonAnimation.Skeleton;
        var skeletonData = skeleton.Data;
        characterSkin = new Skin("character-base");
        // Note that the result Skin returned by calls to skeletonData.FindSkin()
        // could be cached once in Start() instead of searching for the same skin
        // every time. For demonstration purposes we keep it simple here.
       
        characterSkin.AddSkin(skeletonData.FindSkin(InitaialSkin[activeWeaponIndex]));
    }

    void AddEquipmentSkinsTo(Skin combinedSkin)
    {
        var skeleton = skeletonAnimation.Skeleton;
        var skeletonData = skeleton.Data;

       
    }

    void UpdateCombinedSkin()
    {
        var skeleton = skeletonAnimation.Skeleton;
        var resultCombinedSkin = new Skin("character-combined");

        resultCombinedSkin.AddSkin(characterSkin);
        AddEquipmentSkinsTo(resultCombinedSkin);

        skeleton.SetSkin(resultCombinedSkin);
        skeleton.SetSlotsToSetupPose();
    }
   public void LoadWeaPon()
    {
        activeWeaponIndex = PlayerPrefs.GetInt("activeWeaponIndex");
    }
   public void SaveWeaPones()
    {

        //if (GameManager.saveweapon)
        {
            PlayerPrefs.SetInt("activeWeaponIndex", activeWeaponIndex);
            PlayerPrefs.Save();
            IsWeapon = true;
        }
     /*   else
        {
            IsWeapon = false;
        }*/
    }
    [Header("mix idle")]
    [SpineAnimation] public string idleAnimation12hand;
    [SpineAnimation] public string idleAnimationgangtay;
    [SpineAnimation] public string idleAnimationbonxing;
    [SpineAnimation] public string mix_pinwheel;

    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    public int selectIdle;
    public void openWeapon()
    {
    
    }
}
