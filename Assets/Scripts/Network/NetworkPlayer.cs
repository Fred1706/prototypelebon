using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{

    [SerializeField]
    private InfosPlayer infoPlayer1;

    [SerializeField]
    private InfosPlayer infoPlayer2;

    public Transform root;
    public Transform head;
    public Transform leftHand;
    public Transform RightHand;

    public GameObject headTag;
    public GameObject leftHandTag;
    public GameObject rightHandTag;
    

    


    public Renderer[] meshToDisable;
    // Start is called before the first frame update

    public override void OnNetworkSpawn(){

         if(IsOwner){
            
            foreach(var item in meshToDisable)
            {
            item.enabled = false;
            }
        }



        if(!IsHost && IsOwner){



            headTag.tag = "Player";
            leftHandTag.tag = "Glove";
            rightHandTag.tag = "Glove";
        }
        else if(IsHost && IsOwner){
            headTag.tag = "Player1";
            leftHandTag.tag = "Glove1";
            rightHandTag.tag = "Glove1";
        }


       
    }
  

    // Update is called once per frame
    void Update()
    {
        if(IsOwner){


        
        root.position = RigReferences.Singleton.root.position;
        root.rotation = RigReferences.Singleton.root.rotation;

        head.position = RigReferences.Singleton.head.position;
        head.rotation = RigReferences.Singleton.head.rotation;

        leftHand.position = RigReferences.Singleton.leftHand.position;
        leftHand.rotation = RigReferences.Singleton.leftHand.rotation;
        

        RightHand.position = RigReferences.Singleton.RightHand.position;
        RightHand.rotation = RigReferences.Singleton.RightHand.rotation;
       

        

        }



        if(infoPlayer1.power == true && rightHandTag.tag == "Glove1" && IsHost && IsOwner){
            Debug.Log("JOUER GROS");
            leftHand.localScale =  RigReferences.Singleton.leftHand.localScale;
            RightHand.localScale = RigReferences.Singleton.RightHand.localScale;
        }





        if(infoPlayer1.power == false && rightHandTag.tag == "Glove" && !IsHost && IsOwner){

            Debug.Log("JOUER2 GROS");
            leftHand.localScale = RigReferences.Singleton.leftHand.localScale;
            RightHand.localScale = RigReferences.Singleton.RightHand.localScale;
        }

        

        
    }



    
}
