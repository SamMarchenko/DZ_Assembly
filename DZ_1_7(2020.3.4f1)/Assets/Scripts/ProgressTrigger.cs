using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTrigger : MonoBehaviour
{
   [SerializeField] private GameManager _gameManager;

   private void Start()
   {
      var collider = GetComponent<Collider>();
      collider.isTrigger = true;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.GetComponent<BasePlayerController>() == null) return;
      _gameManager.UpdateLevel();
   }
   
}
