using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
   
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            if(UnityEditor.EditorApplication.isPlaying == true)
            {
                UnityEditor.EditorApplication.isPlaying = false;
                Debug.Log("FIN DEL JUEGO");
            } 
        } 
 }
