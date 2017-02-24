//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMelee : MonoBehaviour
//{

//    GameObject player;
//    GameObject meleeTrigger;
//    float swingRate = 0.5f;

//    void Start()
//    {
//        meleeTrigger.active = false;
//        MeleeSwing();
//    }

//    void MeleeSwing()
//    {
//        while (true)
//        {
//            if (Input.GetButtonUp("Fire1"))
//            {

//                player.animation.CrossFade("1h_attack1");
//                meleeTrigger.active = true;
//                yield WaitForSeconds(player.animation["1h_attack1"].length);
//                meleeTrigger.active = false;
//                break;

//                yield WaitForSeconds(swingRate);

//            }
//            else
//            {
//                yield;
//            }
//        }

//    }
//}