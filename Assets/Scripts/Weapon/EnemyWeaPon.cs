using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity.Examples
{
    public class EnemyWeaPon : MonoBehaviour
    {
        [SpineSkin] public string[] WeaponSkins ;
        public int activeWeaponIndex = 0;
        [SpineSkin] public string[] HairSkins ;
        public int activeHairIndex = 0;

        SkeletonAnimation skeletonAnimation;
        Skin characterSkin;

        void Awake()
        {
            skeletonAnimation = this.GetComponent<SkeletonAnimation>();
        }

        void Start()
        {
            UpdateCharacterSkin();
            UpdateCombinedSkin();
        }

        // Start is called before the first frame update
   

        // Update is called once per frame
        void Update()
        {

        }
		void UpdateCharacterSkin()
		{
			var skeleton = skeletonAnimation.Skeleton;
			var skeletonData = skeleton.Data;
			characterSkin = new Skin("character-base");
			// Note that the result Skin returned by calls to skeletonData.FindSkin()
			// could be cached once in Start() instead of searching for the same skin
			// every time. For demonstration purposes we keep it simple here.
			
			characterSkin.AddSkin(skeletonData.FindSkin(WeaponSkins[activeWeaponIndex]));
			characterSkin.AddSkin(skeletonData.FindSkin(HairSkins[activeHairIndex]));
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
	}
}

