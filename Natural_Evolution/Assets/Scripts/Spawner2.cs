using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    [SerializeField]
    Transform food;
    [SerializeField, Range(1, 25)]
    int foodNumber = 5;
    [SerializeField]
    Transform Critter;
    [SerializeField, Range(1, 25)]
    int critterNumber = 6;
    
    [SerializeField]
    int timeDay = 25;
Transform[] foods;
 Critts[] critters;
GameObject[] Foods;

public Transform plane;
    public Transform scale;

private float CurrentTime;
private float roundTimer = 15;
private float Rx;
private float Ry;
private float Rz;
public struct Critts {
    public Critts(float speed, float nrg, Transform crittr){
        Speed = speed;
        Nrg = nrg;
        Crittr = crittr;
    }
    public float Speed {get;}
    public float Nrg{ get; }
    public Transform Crittr{get;} 
};  
//private bool dayOn;

    void Awake() {
        foods = new Transform[foodNumber];
        critters = new Critts[critterNumber];
    }


    void intitalSpawner() {
for(int i = 0; i < foodNumber; i++){
           var randomPos = new Vector3(Random.Range(-(scale.localScale.x * 4.5f) + 1f, scale.localScale.x * 4.5f - 1f), plane.position.y + 1, Random.Range(-(scale.localScale.x * 4.5f) + 1f, scale.localScale.x * 4.5f - 1f));
        foods[i] = Instantiate(food);
        foods[i].position = randomPos;
        foods[i].SetParent(transform, false);
        }
        for(int i = 0; i < critterNumber; i++){
           var randomPos = new Vector3(Random.Range(-(scale.localScale.x * 2f) + 1f, scale.localScale.x * 2f - 1f), plane.position.y + 1, Random.Range(-(scale.localScale.x * 2f) + 1f, scale.localScale.x * 2f - 1f));
        critters[i] = new Critts(Random.Range(3,7), Random.Range(10,30), Instantiate(Critter));
        critters[i].Crittr.transform.position = randomPos;
        critters[i].Crittr.SetParent(transform, false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        intitalSpawner();  
        Data.DayNum -= 1;  
        CurrentTime = timeDay;
        CcScript.dayOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(CcScript.dayOn == true) {
    Foods = GameObject.FindGameObjectsWithTag("Food");
    if(Foods.Length < foodNumber) {
    var randomPos = new Vector3(Random.Range(-(scale.localScale.x * 5f) + 1f, scale.localScale.x * 5f - 1f), plane.position.y + 1, Random.Range(-(scale.localScale.x * 5f) + 1f, scale.localScale.x * 5f - 1f));
        foods[Foods.Length] = Instantiate(food);
        foods[Foods.Length].position = randomPos;
        foods[Foods.Length].SetParent(transform, false);
    }

        Rx += Time.deltaTime * Random.Range(15f, 30f);
        Ry += Time.deltaTime * Random.Range(15f, 30f);
        Rz += Time.deltaTime * Random.Range(15f, 30f);
         for(int i = 0; i < Foods.Length; i++){
            Foods[i].transform.localRotation = (Quaternion.Euler(Rx, Ry, Rz) );
        }
        CurrentTime = CurrentTime - Time.deltaTime;
        if(CurrentTime <= 0) {
            CcScript.dayOn = false;
        }
        } else {
            for(int i = 0; i < foods.Length; i++) {
                //Destroy(Foods[i].gameObject);
                Foods[i].gameObject.SetActive(false);
            }
            for(int i = 0; i < critters.Length; i++) {
                //Destroy(critters[i].gameObject);
                //critters[i].gameObject.SetActive(false);
            }
            if(Data.DayNum > 0) {
        roundTimer = roundTimer - Time.deltaTime;
        if (roundTimer <= 0) {
        intitalSpawner();  
        Data.DayNum -= 1;  
        CurrentTime = timeDay;
        CcScript.dayOn = true;
        }
    } else {
        Debug.Log("Finished");
    }
}

    }



}
