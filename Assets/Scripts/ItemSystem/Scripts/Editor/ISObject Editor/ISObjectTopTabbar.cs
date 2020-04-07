using UnityEngine;
using System.Collections;

    
namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        public void TopTabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

            WeaponTab();
            ArmorTab();
            PotionTab();
            AboutTab();

            GUILayout.EndHorizontal();
        }

        void WeaponTab()
        {
            GUILayout.Button("Weapons");
        }
        void ArmorTab()
        {
            GUILayout.Button("Armor");
        }
        void PotionTab()
        {
            GUILayout.Button("Potions");
        }
        void AboutTab()
        {
            GUILayout.Button("About");
        }
    }
}