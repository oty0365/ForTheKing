using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using WeponS;

namespace Editor
{
    [CustomEditor(typeof(WeaponData))]
    public class WeaponsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var enumValues = Enum.GetValues(typeof(WeaponType));

            var weaponArray = (WeaponData) target;
            if (weaponArray.weapons is not { Length: > 0 } || weaponArray.weapons.Length != enumValues.Length)
            {
                var newArray = new NearWepon[enumValues.Length];
                
                for (var i = 0; i < (weaponArray.weapons?.Length ?? 0); i++) newArray[i] = weaponArray.weapons[i];
                for (var i = (weaponArray.weapons?.Length ?? 0) - 1; i >= 0 && i < newArray.Length; i++) newArray[i] = new NearWepon();

                weaponArray.weapons = newArray;
            }

            if (weaponArray.toggled == null || weaponArray.toggled.Length != enumValues.Length) weaponArray.toggled = new bool[enumValues.Length];
            
            GUILayout.Space(20);

            int idx;
            foreach (var type in enumValues)
            {
                idx = (int)type;
                var nearWeapon = weaponArray.weapons[idx];
                if (weaponArray.toggled[idx] = EditorGUILayout.BeginFoldoutHeaderGroup(weaponArray.toggled[idx], $"{((WeaponType)type).ToString()}: {nearWeapon.weponname}"))
                {
                    nearWeapon.weponname = EditorGUILayout.TextField("Name", nearWeapon.weponname);
                    nearWeapon.wepondamage = EditorGUILayout.FloatField("Damage", nearWeapon.wepondamage);
                    nearWeapon.weponrarity = (Rarity)EditorGUILayout.EnumPopup("Rarity", nearWeapon.weponrarity);
                    EditorGUILayout.LabelField("Description");
                    nearWeapon.wepondiscription = EditorGUILayout.TextArea(nearWeapon.wepondiscription, new GUIStyle(EditorStyles.textArea)
                    {
                        wordWrap = true
                    });
                    nearWeapon.weponimage =
                        (Sprite)EditorGUILayout.ObjectField("Image", nearWeapon.weponimage, typeof(Sprite), false);
                    nearWeapon.prefab =
                        (GameObject)EditorGUILayout.ObjectField("Prefab", nearWeapon.prefab, typeof(GameObject), false);
                    nearWeapon.value = EditorGUILayout.IntField("Value", nearWeapon.value);
                    EditorGUILayout.Space(14);
                }

                EditorGUILayout.EndFoldoutHeaderGroup();
            }
        }
    }
}