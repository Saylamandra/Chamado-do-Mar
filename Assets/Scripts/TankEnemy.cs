using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class TankEnemy : MonoBehaviour
{
    public float stopDistance = 6f;
    public float shootInterval = 2f;
    public float burstRate = 0.2f;
    public int burstCount = 3;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private NavMeshAgent agent;
    private Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("player").transform;
        StartCoroutine(BurstShoot());
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
            // Movimento só na horizontal (eixo X), mantendo a Z
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, agent.speed * Time.deltaTime);
        }

        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    IEnumerator BurstShoot()
{
    while (true)
    {
        yield return new WaitForSeconds(shootInterval);

        for (int i = 0; i < burstCount; i++)
        {
            if (player != null)
            {
                Debug.Log("Disparando projétil"); // <-- ADICIONE AQUI
                Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            }
            yield return new WaitForSeconds(burstRate);
        }
    }
}

}
