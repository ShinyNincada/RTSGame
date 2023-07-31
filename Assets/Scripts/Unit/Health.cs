using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHP = 100;
    [SerializeField] int HP;

    
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }

    public void UpdateHP(int amount){
        HP += amount;
        if(HP <= 0){
            Dead();
        }
    }

    public void SetMaxHP(int value){
        maxHP = value;
        HP = maxHP;
    }


    void Dead(){

    }
}
