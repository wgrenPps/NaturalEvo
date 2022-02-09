using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CritterController : MonoBehaviour
{
    
    NavMeshAgent agent;
    public Transform agentT;
    public Transform IconG;
    public Transform IconH;
    public Transform IconC;
    public Transform IconU;
    public Transform IconM;
    GameObject[] Foods;
    private bool agentDes;
int foodTg;  
    // Start is called before the first frame update
    void Start()
    {
        
        agent = this.GetComponent<NavMeshAgent>();
        Foods = GameObject.FindGameObjectsWithTag("Food");
        foodTg = Random.Range(0, Foods.Length - 1);
        agent.SetDestination(Foods[foodTg].transform.position);
        Debug.Log("??" + Foods.Length);

    }

    // Update is called once per frame
    void LateUpdate()
    {
    if(CcScript.dayOn == true) {
        if (Foods[foodTg].activeSelf == true) {
        agent.SetDestination(Foods[foodTg].transform.position);
        }else{
        Foods = GameObject.FindGameObjectsWithTag("Food");
        foodTg = Random.Range(0, Foods.Length - 1);
        }
} else {
agent.SetDestination(IconC.position);
}
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Food")){
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject); 
            
        }
     
    }
}

