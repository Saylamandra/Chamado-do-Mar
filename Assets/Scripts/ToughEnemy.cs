using UnityEngine;

public class ToughEnemy : MonoBehaviour
{
    public EnemySpawner spawner;

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.OnToughEnemyDeath();
        }
    }
}
