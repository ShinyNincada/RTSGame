using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enity : MonoBehaviour
{
    public Faction faction;
    public string enityName;
    public string enityDescription;
    
    //Public Component
    public Health health;
    public UnitController controller;
    public UnitStats stats;

    private void Start() {
        health = GetComponent<Health>();
        controller = GetComponent<UnitController>();
        health.SetMaxHP(stats.health);
    }

    public void EntityEvolve(){
        if(stats.canEvolve && stats.nextEvolveStep != null){
            stats = stats.nextEvolveStep;
        }
    }

    

}

public enum Faction{
    PLAYER,
    ENEMY,
    NEUTRAL
}