using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

namespace ItemSystem
{
    [System.Serializable]
    public class ISObject : IISObject
    {
        [SerializeField] Sprite _icon;
        [SerializeField] string _name;
        [SerializeField] int _value;
        [SerializeField] int _burden;
        [SerializeField] ISQuality _quality;

        public int Burden
        {
            get { return _burden; }
            set { _burden = value; }
        }

        public Sprite Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ISQuality Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }


        //this code is going to be in a new class later on
        public virtual void OnGUI()
        {
            GUILayout.BeginVertical();
            _name = EditorGUILayout.TextField("Name : ", _name);
            _value =System.Convert.ToInt32(EditorGUILayout.TextField("Value : ", _value.ToString()));
            _burden = System.Convert.ToInt32(EditorGUILayout.TextField("Burden : ", _burden.ToString()));
            DisplayIcon();
            DisplayQuality();
            GUILayout.EndVertical();
        }

        private void DisplayIcon()
        {
            GUILayout.Label("Icon");
        }

        int qualitySelectedIndex = 0;
        string[] options = new string[] { "com", "unc", "rar" };

        public void DisplayQuality()
        {
            GUILayout.Label("Quality");
            qualitySelectedIndex = EditorGUILayout.Popup("Quality", qualitySelectedIndex, options);

        }

    }
}