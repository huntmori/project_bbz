using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;

namespace ItemsSystem
{
    public class ScriptableObjectDatabase<Type> : ScriptableObject where Type: class
    {
        [SerializeField] List<Type> Database = new List<Type>();

        public void Add(Type item)
        {
            Database.Add(item);
            EditorUtility.SetDirty(this);
        }

        public void Insert(int index, Type item)
        {
            Database.Insert(index, item);
            EditorUtility.SetDirty(this);
        }

        public void Remove(Type item)
        {
            Database.Remove(item);
            EditorUtility.SetDirty(this);
        }

        public void Remove(int index)
        {
            Database.RemoveAt(index);
            EditorUtility.SetDirty(this);
        }

        public int Count
        {
            get { return Database.Count; }
        }

        public Type Get(int index)
        {
            return Database.ElementAt(index);
        }

        public void Replace(int index, Type item)
        {
            Database[index] = item;
            EditorUtility.SetDirty(this);
        }


        public static U GetDatabase<U>(string dbPath, string dbName) where U :ScriptableObject
        {
            string dbFullPath = @"Assets/" + dbPath+"/" + dbName;


            //Load Data
            U db= AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;

            //Check it's null
            if (db == null){
				
                if (!AssetDatabase.IsValidFolder(@"Assets/" + dbPath)){
                    AssetDatabase.CreateFolder("Assets", dbPath);
                }

                db = ScriptableObject.CreateInstance<U>();
                Debug.Log(dbFullPath);
                AssetDatabase.CreateAsset(db, dbFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            return db;
        }
    }
}
