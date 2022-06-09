using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string descript;

    public string ItemName { get => itemName; set => itemName = value; }
    public string Descript { get => descript; set => descript = value; }
}
