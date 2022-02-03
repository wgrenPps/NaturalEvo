using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    int DayTime = 1000;
    [SerializeField]
    int DayNum = 100;
    [SerializeField]
    Transform food;
    [SerializeField, Range(1, 25)]
    int foodNumber = 5;
Transform[] foods;
[SerializeField]
    Transform Critter;
    [SerializeField, Range(1, 25)]
    int critterNumber = 6;
Transform[] critters;
public Transform plane;
    public Transform scale;
    private bool DayOn;
    private float roundTimer;
private float Rx;
private float Ry;
private float Rz;

float timeDay = 0;
bool DayNight =true;
GameObject[] Foods;
    void Awake() {
        foods = new Transform[foodNumber];
        critters = new Transform[critterNumber];
    }
    // Start is called before the first frame update
    void Start()
    {
        if(DayNum > 1){
        intitalSpawner();
        DayNum -= 1;
        DayOn = true;}
        }
    
    void intitalSpawner() {
for(int i = 0; i < foodNumber; i++){
           var randomPos = new Vector3(Random.Range(-(scale.localScale.x * 5f), scale.localScale.x * 5f), plane.position.y + 1, Random.Range(-(scale.localScale.x * 5f) + 1f, scale.localScale.x * 5f));
        foods[i] = Instantiate(food);
        foods[i].position = randomPos;
        foods[i].SetParent(transform, false);
        }
        for(int i = 0; i < critterNumber; i++){
           var randomPos = new Vector3(Random.Range(-(scale.localScale.x * 2f), scale.localScale.x * 2f), plane.position.y + 1, Random.Range(-(scale.localScale.x * 2f) + 1f, scale.localScale.x * 2f));
        critters[i] = Instantiate(Critter);
        critters[i].position = randomPos;
        critters[i].SetParent(transform, false);
        }
    }
     void Update(){
         if (DayNight == true) {
             Foods =GameObject.FindGameObjectsWithTag("Food");
        if (Foods.Length < foodNumber){
            var randomPos = new Vector3(Random.Range(-(scale.localScale.x * 5f), scale.localScale.x * 5f), plane.position.y + 1, Random.Range(-(scale.localScale.x * 5f) + 1f, scale.localScale.x * 5f));
        foods[foods.Length - 1] = Instantiate(food);
        foods[foods.Length - 1].position = randomPos;
        foods[foods.Length - 1].SetParent(transform, false);
        }
        Rx += Time.deltaTime * Random.Range(15f, 30f);
        Ry += Time.deltaTime * Random.Range(15f, 30f);
        Rz += Time.deltaTime * Random.Range(15f, 30f);
         for(int i = 0; i < foodNumber; i++){
            foods[i].transform.localRotation = (Quaternion.Euler(Rx, Ry, Rz) );
        }
        if(DayOn == true){
        timeDay += Time.deltaTime;
        } else { 
        roundTimer += Time.deltaTime;
        } 
        if ( roundTimer > 10 ) {
            if(DayNum > 1){
        intitalSpawner();
        DayNum -= 1;
        } else {
            Debug.Log("Done");
        }
        roundTimer = 0;
        }
}
        
        if(timeDay > DayTime) {
            DayNight = false;
            for(int i = 0; i < foods.Length; i++) {
                Destroy(Foods[i].gameObject);
            }
            for(int i = 0; i < critters.Length; i++) {
                Destroy(critters[i].gameObject);
            }
            timeDay = 0;
            DayOn = false;
        }
        
    }

    // Update is called once per frame
     
    
}