using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor : EditorWindow
    {
        


        void ListView()
        {
            GUILayout.Label("List of stored Qualities");
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.ExpandWidth(true));

            DIsplayQualities();

            EditorGUILayout.EndScrollView();
        }

        

        void DIsplayQualities()
        {
            for(int cnt=0; cnt<QualityDatabase.Count; cnt++)
            {
                GUILayout.BeginHorizontal("Box");

                if ((QualityDatabase.Get(cnt).Icon))
                    selectedTexture = QualityDatabase.Get(cnt).Icon.texture;
                else
                    selectedTexture = null;

                //icon
                if (GUILayout.Button(selectedTexture, GUILayout.Width(SPRITE_BUTTON_SIZE), GUILayout.Height(SPRITE_BUTTON_SIZE)))
                {
                    int controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
                    EditorGUIUtility.ShowObjectPicker<Sprite>(null, true, null, controlID);
                    selectedIndex = cnt;
                }

                GUILayout.BeginVertical();
                //name
                QualityDatabase.Get(cnt).Name= GUILayout.TextField(QualityDatabase.Get(cnt).Name);

                //delete quality
                if(GUILayout.Button("X",GUILayout.Width(20),GUILayout.Height(20)))
                {
                    string message = "Are you sure that you want to delete [" + QualityDatabase.Get(cnt).Name + "] from the database";

                    if (EditorUtility.DisplayDialog("Delete Quality", message,"Delete", "Cancel"))
                    {
                        QualityDatabase.Remove(cnt);
                    }
                }

              

                string commandName = Event.current.commandName;

                if (commandName == "ObjectSelectorUpdated")
                {
                    if (selectedIndex != -1)
                    {
                        QualityDatabase.Get(selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject();
                        //selectedIndex = -1;
                    }
                    Repaint();
                }

                //delete button;

                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
            //AddQualityToDatabase();
        }
    }
}
