using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace rpgStealth
{
    public class DamagePopManager : MonoBehaviour
    {
        [SerializeField] private DamagePop damagePop;
        private ObjectPool<DamagePop> pool;
        [SerializeField] private int defaultAmount;
        [SerializeField] private int maxAmount;

        void OnEnable()
        {
            EventManager.StartListening("OnEnemyHit", OnEnemyHit);
        }

        void OnDisable()
        {
            EventManager.StopListening("OnEnemyHit", OnEnemyHit);
        }

        private void Start()
        {
            pool = new ObjectPool<DamagePop>(OnCreateObject, OnTakeFromPool, OnReturnToPool, OnDestroyObject, false, defaultAmount, maxAmount);
        }

        void OnEnemyHit(Dictionary<string, object> message)
        {
            int damageDealth = (int)message["damageDealth"];
            Vector3 hitPosition = (Vector3)message["hitPosition"];

            DamagePop currentDamagePop = pool.Get();

            currentDamagePop.SetProperties(damageDealth, hitPosition);
            currentDamagePop.Initialize(OnDestroyObject);
        }

        private DamagePop OnCreateObject()
        {
            return Instantiate(damagePop);
        }

        private void OnTakeFromPool(DamagePop poolDamagePop)
        {
            poolDamagePop.Reset();
            poolDamagePop.gameObject.SetActive(true);
        }

        private void OnReturnToPool(DamagePop poolDamagePop)
        {
            poolDamagePop.gameObject.SetActive(false);
        }

        private void OnDestroyObject(DamagePop poolDamagePop)
        {
            pool.Release(poolDamagePop);
        }
    }
}
