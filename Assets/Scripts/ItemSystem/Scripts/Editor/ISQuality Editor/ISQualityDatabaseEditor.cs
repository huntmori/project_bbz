using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ItemSystem.Editor
{
    public partial class ISQualityDatabaseEditor : EditorWindow
    {
        ISQualityDatabase QualityDatabase;
        Texture2D selectedTexture;

        Vector2 _scrollPos; // scroll position for list view

        int selectedIndex = -1;

        const string DATABASE_FILE_NAME = @"bbzQualityDatabase.asset";
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/"+DATABASE_FOLDER_NAME + "/"+DATABASE_FILE_NAME;

        const int SPRITE_BUTTON_SIZE = 46;

        [MenuItem("BBZ/Database/Quality Editor %#w")]
        public static void Init()
        {
            ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor>();
            window.minSize = new Vector2(400, 300);
            window.titleContent = new GUIContent("Quality Database");
            window.Show();


        }

        void OnEnable()
        {
            /**
                        //Load Data
                        QualityDatabase = AssetDatabase.LoadAssetAtPath(DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;

                        //Check it's null
                        if (QualityDatabase == null)
                        {
                            if (!AssetDatabase.IsValidFolder("Assets/" + DATABASE_FOLDER_NAME))
                            {
                                AssetDatabase.CreateFolder("Assets", DATABASE_FOLDER_NAME);
                            }

                            QualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
                            Debug.Log(DATABASE_FULL_PATH);
                            AssetDatabase.CreateAsset(QualityDatabase, DATABASE_FULL_PATH);
                            AssetDatabase.SaveAssets();
                            AssetDatabase.Refresh();
                        }

                        selectedItem = new ISQuality();
*/
            //QualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase>();
            if(QualityDatabase == null)
                QualityDatabase = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
        }



        void OnGUI()
        {
            if(QualityDatabase == null)
            {
                Debug.LogWarning("QualityDatabase not loaded.");
            }

            ListView();
            //AddQualityToDatabase();
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            BottomBar();
            GUILayout.EndHorizontal();
        }

        void BottomBar()
        {
            GUILayout.Label("Qualities: " + QualityDatabase.Count);

            if(GUILayout.Button("Add"))
            {
                QualityDatabase.Add(new ISQuality());
            }
        }
    }
}