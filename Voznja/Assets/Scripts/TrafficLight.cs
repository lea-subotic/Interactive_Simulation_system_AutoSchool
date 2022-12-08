using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public GameObject traffic_light_3d;

    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;
    public GameObject plane4;

    public Material[] mats;


    void Start()
    {
        // trazi child 3d objekt sveukupnog semafora
        traffic_light_3d = GameObject.Find("traffic_light_3d");

        // plane1 = GameObject.Find("Plane 1");
        // plane2 = GameObject.Find("Plane 2");
        // plane3 = GameObject.Find("Plane 3");
        // plane4 = GameObject.Find("Plane 4");

        mats = traffic_light_3d.GetComponent<Renderer>().materials;

        for(int i=1; i<mats.Length; i++){
            mats[i].EnableKeyword("_EMISSION");
            mats[i].SetColor("_EmissionColor", Color.black);
        }

        //InvokeRepeating("light_control", 0.0f, 20.0f);
        StartCoroutine(light_control());

        
    }

    IEnumerator light_control(){
        while(true){
            //zuta isklj
            mats[2].SetColor("_EmissionColor", Color.black);
            mats[5].SetColor("_EmissionColor", Color.black);

            //zelena i crvena
            mats[1].SetColor("_EmissionColor", Color.black);
            mats[4].SetColor("_EmissionColor", Color.red);

            mats[6].SetColor("_EmissionColor", Color.black);
            mats[3].SetColor("_EmissionColor", Color.green);

            yield return new WaitForSeconds(15);




            //isklj obje zelene
            mats[3].SetColor("_EmissionColor", Color.black);
            mats[6].SetColor("_EmissionColor", Color.black);

            //zuta uklj
            mats[2].SetColor("_EmissionColor", Color.yellow);
            mats[5].SetColor("_EmissionColor", Color.yellow);

            yield return new WaitForSeconds(2);




            //zuta isklj
            mats[2].SetColor("_EmissionColor", Color.black);
            mats[5].SetColor("_EmissionColor", Color.black);

            //zelena i crvena, druga kombinacija
            mats[4].SetColor("_EmissionColor", Color.black);
            mats[1].SetColor("_EmissionColor", Color.red);

            mats[3].SetColor("_EmissionColor", Color.black);
            mats[6].SetColor("_EmissionColor", Color.green);

            yield return new WaitForSeconds(15);




            //isklj obje zelene
            mats[3].SetColor("_EmissionColor", Color.black);
            mats[6].SetColor("_EmissionColor", Color.black);

            //zuta uklj
            mats[2].SetColor("_EmissionColor", Color.yellow);
            mats[5].SetColor("_EmissionColor", Color.yellow);

            yield return new WaitForSeconds(2);

        }
        

    }


    void Update(){}
}
