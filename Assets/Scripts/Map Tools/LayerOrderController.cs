using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pigs.MapTools
{
    public class LayerOrderController : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerSprite"))
            {
                var sprite = collision.GetComponent<SpriteRenderer>();
                sprite.sortingOrder+=2;
            }

        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("PlayerSprite"))
            {
                var sprite = collision.GetComponent<SpriteRenderer>();
                sprite.sortingOrder-=2;
            }

        }
    }
}