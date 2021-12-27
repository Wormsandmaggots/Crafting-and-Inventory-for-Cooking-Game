using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Crafting/Recipe", order = 0)]
public class Recipe : ScriptableObject
{
    public List<Item> recipe = new List<Item>();
    public Item result;
}
