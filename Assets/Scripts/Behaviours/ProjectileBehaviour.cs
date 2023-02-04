﻿using UnityEngine;

[RequireComponent(typeof(OnTriggerDo))]
public class ProjectileBehaviour : MonoBehaviour, IMovable {
  [SerializeField] public Projectile config = null;
  private OnTriggerDo triggerDo = null;

  private void Awake() {
    triggerDo = GetComponent<OnTriggerDo>();
  }

  private void Update() {
    DoMovement();
  }

  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }

  public void MakeDamage() {
    if (triggerDo.otherCollider.tag == "Wall") return;

    switch (gameObject.layer) {
      case 11: // Proyectil enemigo
        InputProvider.TriggerOnHasDamage(config.damage);
        break;
      case 8: // Proyectil player
        triggerDo.statsTarget.TakeLife(config.damage);
        break;
      default: break;
    }
  }

  public void DoMovement() {
    transform.position += transform.up * Time.deltaTime * config.speed * 5f;
  }

  public void DoMovement(Vector3 direction) {
    throw new System.NotImplementedException();
  }
}