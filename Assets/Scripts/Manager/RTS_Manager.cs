using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTS_Manager : MonoBehaviour
{
    public static RTS_Manager instance;
    public Dictionary<int, Enity> selectedUnits = new Dictionary<int, Enity>();
   
    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else if(instance != this){
            Destroy(this);
        }

    }

    public void SelectUnit(GameObject go, bool isMultiSelect){
        int id = go.GetInstanceID();

        if(!isMultiSelect){
            DeSelectAll();
        }

        if(!selectedUnits.ContainsKey(id)){
                selectedUnits.Add(id, go.GetComponent<Enity>());
                selectedUnits[id].controller.Select = true;
                Debug.Log("Added " + id + " to selected dict");
        }
       
    }


    public void DeSelectUnit(int id){
        selectedUnits[id].controller.Select = false;
        selectedUnits.Remove(id);
    }

    public void DeSelectAll(){
        foreach(KeyValuePair<int,Enity> pair in selectedUnits)
        {
            if(pair.Value != null)
            {
                pair.Value.controller.Select = false;
            }
        }
        selectedUnits.Clear();
    }

    public void MoveUnits(Vector3 dest){
        foreach(KeyValuePair<int, Enity> pair in selectedUnits){
            if(pair.Value != null){
                pair.Value.controller.MoveUnit(dest);
            }
        }
    }

    public int SelectedUnitsCount{
        get { return selectedUnits.Count;}
    }
}
