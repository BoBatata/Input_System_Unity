using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]

public class CollectableScript : MonoBehaviour
{
    [SerializeField] private Sprite collectableSprite;

    private SpriteRenderer spriteRenderer;
    private int cherrysCollectables;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = collectableSprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().cherrysCollectables++;
            Destroy(this.gameObject);
        }
    }
}
