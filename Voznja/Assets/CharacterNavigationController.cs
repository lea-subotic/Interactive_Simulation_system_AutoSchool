 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class CharacterNavigationController : MonoBehaviour
 {
     CharacterController character;
     public int movementSpeed;
     public float rotationSpeed;
     public float stopDistance;
     public Vector3 destination;
     public bool reachedDestination;
 
     private void Awake()
     {
         character = GameObject.Find("Character_Female_Coat_01").GetComponent<CharacterController>();
     }
 
     // Start is called before the first frame update
     void Start()
     {
         movementSpeed = 1;
     }
 
     // Update is called once per frame
     void Update()
     {
         Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //not using t$$anonymous$$s yet
         character.Move(destination * Time.deltaTime * movementSpeed);
         if (destination != Vector3.zero)
         {
             transform.forward = destination;
             reachedDestination = true;
             Debug.Log("reachead destination: " + destination);
         }
 
 
 
     }
 
     public void SetDestination(Vector3 value)
     {
         destination = value;
     }
 }