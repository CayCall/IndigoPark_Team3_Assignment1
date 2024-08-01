using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
   private GameManager gameManager;
   private gearsInventory gearsInventory;
   public AudioSource genClick;
   public AudioSource genSound;

   private void Start()
   {
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
      gearsInventory = GameObject.Find("Player").GetComponent<gearsInventory>();
      genClick = GameObject.Find("Player").GetComponent<AudioSource>();
      genSound.gameObject.SetActive(false);
   }

   public void GeneratorStart()
   {
      if (gearsInventory.gearsController.Length == 2)
      {
         for (int i = 0; i < gameManager.Lights.Length; i++)
         {
            gameManager.Lights[i].SetActive(true);
         }
         genSound.gameObject.SetActive(true);
         genSound.Play();
      }
   }
}