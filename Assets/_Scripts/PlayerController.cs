using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;

    private Rigidbody _playerRigidbody;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 moveDir = new Vector3(input.x, 0, input.y ).normalized;

        if(moveDir != Vector3.zero) 
        {
            transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), rotateSpeed);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Vector3 toTarget = (collision.transform.forward - transform.position).normalized;
            EnemyInventory enemyInventory = collision.collider.gameObject.GetComponent<EnemyInventory>();
            Item item = enemyInventory.GetItemMostValue();

            if (Vector3.Dot(toTarget, transform.forward) < 0)
            {
                if (item != null)
                {
                    inventory.AddItem(item);
                    item.transform.SetParent(inventory.containerCollectable.transform);
                    enemyInventory.RemoveItem(item);
                }
            }
        }
    }
}
