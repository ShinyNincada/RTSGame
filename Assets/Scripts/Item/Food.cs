using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int value;
    
    private void OnTriggerEnter(Collider col) {
        if(col.CompareTag("PlayerUnit")){
            Health hp = col.GetComponent<Health>();
            hp?.UpdateHP(value);
        }
    }
}
