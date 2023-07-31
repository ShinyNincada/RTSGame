using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] bool isSelected = false;
    [SerializeField] GameObject HighLight;
    [SerializeField] Transform target;
    [SerializeField] float attackRange;
    [SerializeField] float attackSpeed;
    [SerializeField] float attack;

    Enity _enity;
    Health _health;

    //Local var
    float attackCD;
   private void Start() {
        agent = GetComponent<NavMeshAgent>();
        _enity = GetComponent<Enity>();
        _health = GetComponent<Health>();
   }
    private void OnEnable() {
        Select = false;
    }

    private void OnDisable() {
        Select = false;    
    }

    private void Update() {
        if(target != null){
            agent.destination = target.position;

            var distance = Vector3.Distance(transform.position, target.position);

            if(distance <=  attackRange){
                Attack();
            }
        }
    }

    private void Attack()
    {
        if(attackCD >= attackSpeed){
            attackCD = 0;
        }
    }

    public bool Select{
        get{ return isSelected;}
        set { 
            isSelected = value;
            HighLight?.SetActive(value);
        }
    }
    

    public void MoveUnit(Vector3 dest){
        if(isSelected){
            agent.destination = dest;
        }
    }
    
    public void SetNewTarget(Transform enemy){
        target = enemy;
    }

    public void Evolve(){
        _enity.EntityEvolve();
    }
    
}
