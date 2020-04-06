using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {
        ISWeaponDatabase Database;
        
        const string DATABASE_FILE_NAME = @"bbzWeaponDatabase.asset";
        const string DATABASE_FOLDER_NAME = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + DATABASE_FILE_NAME;

        [MenuItem("BBZ/Database/Item System Editor %#i")]
        public static void Init()
        {
            ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent =new GUIContent("Item System");
            window.Show();


        }

        void OnEnable()
        {
            if(Database == null)
                Database = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DATABASE_FOLDER_NAME, DATABASE_FILE_NAME);
        }

        void OnGUI()
        {
            TopTabBar();

            GUILayout.BeginHorizontal();
            ListView();
            ItemDetails();

            GUILayout.EndHorizontal();

            BottomStatusBar();
        }
    }
}