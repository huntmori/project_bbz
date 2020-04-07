using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

namespace ItemSystem
{
    [System.Serializable]
    public class ISWeapon : ISObject, IISWeapon, IISDestructable, IISEquipable, IISGameObject
    {
        [SerializeField]    int _minDamage;
        [SerializeField]    int _durability;
        [SerializeField]    int _maxDurability;
        [SerializeField]    ISEquipmentSlot _equipmentSlot;
        [SerializeField]    GameObject _prefab;
        //Constructor
        public ISWeapon()
        {
            _equipmentSlot = new ISEquipmentSlot();
            //_prefab = new GameObject();
        }
        public ISWeapon(int durability, int maxdurability, ISEquipmentSlot equipmentSlot, GameObject prefab)
        {
            _durability = durability;
            _maxDurability = maxdurability;
            _equipmentSlot = equipmentSlot;
            _prefab = prefab;
        }
        //

        //Getsetter
        public int Durability
        {
            get { return _durability; }
        }
        public int MaxDurability
        {
            get { return _maxDurability; }
        }
        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }

        public GameObject Prefab
        {
            get { return _prefab; }
        }

        public ISEquipmentSlot EquipmentSlot
        {
            get { return _equipmentSlot; }
        }
        //

        public bool Equip()
        {
            throw new NotImplementedException();
        }

        //Methods        
        public int Attack()
        {
            throw new NotImplementedException();
        }

        //Reduce the durability to 0;
        public void Break()
        {
            _durability = 0;
        }



        public void Repair()
        {
            _maxDurability--;

            if (_maxDurability > 0)
                _durability = _maxDurability;
        }

        public void TakeDamage(int amount)
        {
            _durability -= amount;

            if (_durability < 0)
                _durability = 0;

            if (_durability == 0)
                Break();
        }

        public override void OnGUI()
        {
            base.OnGUI();
            _minDamage = System.Convert.ToInt32(EditorGUILayout.TextField("Damage : ", _minDamage.ToString()));
            _durability = System.Convert.ToInt32(EditorGUILayout.TextField("Durability : ", _durability.ToString()));
            _maxDurability = System.Convert.ToInt32(EditorGUILayout.TextField("MaxDurability : ", _maxDurability.ToString()));

            DisplayEquipmentSlot();
            DisplayPrefab();
        }

        public void DisplayEquipmentSlot()
        {
            GUILayout.Label("EquipmentSlot");
        }
        public void DisplayPrefab()
        {
            GUILayout.Label("Prefab");
        }
    }
}