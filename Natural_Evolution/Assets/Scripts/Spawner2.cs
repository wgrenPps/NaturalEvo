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
 Critts[][] critters;
GameObject[] Foods;

public Transform plane;
    public Transform scale;

private float CurrentTime;
private float roundTimer;
private float Rx;
private float Ry;
private float Rz;
public struct Critts {
    public Critts(float speed, float nrg, float foodEaten, Transform crittr) {
        Speed = speed;
        Nrg = nrg;
        Crittr = crittr;
        FoodEaten = foodEaten;

    }
    public float FoodEaten {get;}
    public float Speed {get;}
    public float Nrg{ get; }
    public Transform Crittr{get;} 
};  
int DayTotal;
//private bool dayOn;

    void Awake() {
        foods = new Transform[foodNumber];
        DayTotal = Data.DayNum;
        critters = new Critts[Data.DayNum][];
        for(int o = 0; o < Data.DayNum; o++) {
            critters[o] = new Critts[critterNumber];
        }
        roundTimer = timeDay;
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
        critters[1][i] = new Critts(Random.Range(3,7), Random.Range(10,30),0, Instantiate(Critter));
        critters[1][i].Crittr.transform.position = randomPos;
        critters[1][i].Crittr.SetParent(transform, false);
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
                Destroy(critters[DayTotal - Data.DayNum][i].Crittr.gameObject);
                //critters[i].gameObject.SetActive(false);
            }
        }
        }
        void LateUpdate() {
            if(DayTotal - Data.DayNum > 0) {
        roundTimer = roundTimer - Time.deltaTime;
        if (roundTimer <= 0) {
      for(int i = 0; i < critterNumber; i++){
           var randomPos = new Vector3(Random.Range(-(scale.localScale.x * 2f) + 1f, scale.localScale.x * 2f - 1f), plane.position.y + 1, Random.Range(-(scale.localScale.x * 2f) + 1f, scale.localScale.x * 2f - 1f));
        critters[DayTotal - Data.DayNum][i] = new Critts(Random.Range(3,7), Random.Range(10,30),0, Instantiate(Critter));
        critters[DayTotal - Data.DayNum][i].Crittr.transform.position = randomPos;
        critters[DayTotal - Data.DayNum][i].Crittr.SetParent(transform, false);
        }
        Data.DayNum -= 1;  
        CurrentTime = timeDay;
        CcScript.dayOn = true;
        roundTimer = timeDay;
        }
    } else {
        Debug.Log("Finished");
    }
        }
            


    }




