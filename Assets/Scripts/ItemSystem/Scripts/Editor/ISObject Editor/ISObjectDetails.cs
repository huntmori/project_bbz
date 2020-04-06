using UnityEngine;
using System.Collections;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        ISWeapon tempWeapon = new ISWeapon();
        bool showNewWeaponDetails = false;

        void ItemDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            
//            GUILayout.Label("Detail View");

            if (showNewWeaponDetails)
                DisplayNewWeapon();

            GUILayout.EndVertical();

            GUILayout.Space(50);
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            DisplayButtons();

            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }

        void DisplayNewWeapon()
        {
            tempWeapon.OnGUI();
        }

        void DisplayButtons()
        {
            if (!showNewWeaponDetails)
            {
                if (GUILayout.Button(" Create Weapon"))
                {
                    tempWeapon = new ISWeapon();
                    Debug.Log("Create new Weapon");
                    showNewWeaponDetails = true;
                }
            }
            else
            {
                if (GUILayout.Button("Save"))
                {
                    Debug.Log("Save");
                    showNewWeaponDetails = false;
                    tempWeapon = null;
                }
                if (GUILayout.Button("Cancel"))
                {
                    Debug.Log("Cancel");
                    showNewWeaponDetails = false;
                    tempWeapon = null;
                }
            }
        }
    }
}