using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pigs.Combat
{
    public class BombPlacerController : MonoBehaviour
    {
        [SerializeField] private GameObject bombPrefab;
        [SerializeField] private Transform bombsParent;
        private List<Collider2D> enteringColliders;
        private Dictionary<Vector3, GameObject> bombGrid;
        void Start()
        {
            enteringColliders = new List<Collider2D>();
            bombGrid = new Dictionary<Vector3, GameObject>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Stone"))
            {
                enteringColliders.Add(collision);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Stone"))
            {
                enteringColliders.Remove(collision);
            }
        }
        public void SpawnBomb()
        {
            Vector3 center = new Vector3();
            int count = enteringColliders.Count;

            if (!(count == 2 || count == 4)) return;

            for (int i = 0; i < count; i++)
            {
                center += enteringColliders[i].bounds.center;
            }

            center /= count;
            center.x = (float)Math.Round(center.x, 3);
            center.y = (float)Math.Round(center.y, 3);

            if (!bombGrid.ContainsKey(center))
            {    
                var bomb = Instantiate(bombPrefab, center, Quaternion.identity);
                bombGrid.Add(center, bomb);
                if(bombsParent)
                {
                    bomb.transform.parent = bombsParent;
                }
            
            }
        }
    }
}