using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
   private GameManager gameManager;

   private void Start()
   {
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
   }
   
   public void GeneratorStart()
   {
      if (gameManager.gearsController.Length == 2)
      {
         for (int i = 0; i < gameManager.Lights.Length; i++)
         {
            gameManager.Lights[i].SetActive(true);
         }
      }
   }
}