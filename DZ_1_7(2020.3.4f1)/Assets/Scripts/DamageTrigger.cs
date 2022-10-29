using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
   private BasePlayerController[] _basePlayerController;
   [SerializeField] private GameManager _gameManager;

   private void Start()
   {
      var collider = GetComponent<Collider>();
      collider.isTrigger = true;
      _basePlayerController = Resources.FindObjectsOfTypeAll(typeof(BasePlayerController)) as BasePlayerController[];
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.GetComponent<BasePlayerController>() == null) return;
      _gameManager.SetDamage(1);
      foreach (var item in _basePlayerController)
      {
         item.ForwardSpeed *= 0.5f;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      foreach (var item in _basePlayerController)
      {
         item.ForwardSpeed *= 2f; 
      }
   }
}
