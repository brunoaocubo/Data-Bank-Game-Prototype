using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyInventory inventory;
    [SerializeField] private float moveRadius = 10f;

    private Rigidbody npcRigidbody;
    private NavMeshAgent navMeshAgent;
    private Vector3 randomDestination;

    private void Start()
    {
        npcRigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        MoveToRandomLocation();
    }

    private void Update()
    {
        // Verifica se o NPC chegou perto o suficiente do destino e redefine o destino aleatório
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            MoveToRandomLocation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 toTarget = (other.transform.forward - transform.position).normalized;
            PlayerInventory playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            Item item = playerInventory.GetItemMostValue();

            if (item != null)
            {
                if (Vector3.Dot(toTarget, transform.forward) > 0)
                {
                    this.inventory.AddItem(item);
                    item.transform.SetParent(inventory.containerCollectable.transform);
                    playerInventory.RemoveItem(item);
                }
            }
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            ContactPoint closestContact = collision.contacts[0];
            
            foreach (ContactPoint contact in collision.contacts)
            {
                //Verifica se o ponto de contato está mais à frente do objeto
                if (Vector3.Dot(contact.normal, collision.transform.forward) > Vector3.Dot(closestContact.normal, collision.transform.forward))
                {
                    closestContact = contact;
                }
            }

            //Verificar se o ponto de contato está à frente do objeto
            if (Vector3.Dot(closestContact.normal, collision.transform.forward) < 0)
            {
                EnemyInventory enemyInventory = collision.collider.gameObject.GetComponent<EnemyInventory>();
                Item item = enemyInventory.GetItemMostValue();

                if (item != null)
                {
                    inventory.AddItem(item);
                    item.transform.SetParent(inventory.containerCollectable.transform);
                    enemyInventory.RemoveItem(item);
                }
            }
        }
    }

    private void MoveToRandomLocation()
    {
        // Gera um novo destino aleatório dentro do raio de movimento
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, moveRadius, -1);
        randomDestination = navHit.position;

        // Move o NPC para o novo destino
        navMeshAgent.SetDestination(randomDestination);
    }
}
