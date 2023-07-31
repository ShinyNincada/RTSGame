using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RTS/UnitStats")]
public class UnitStats : ScriptableObject
{
    public float attackRange;
    public float attackSpeed;
    public int health;
    public int attack;
    public bool canEvolve;
    public UnitStats nextEvolveStep;
}
