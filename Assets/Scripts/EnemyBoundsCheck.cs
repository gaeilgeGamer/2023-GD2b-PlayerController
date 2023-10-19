using UnityEngine;

public class EnemyBoundsCheck : MonoBehaviour
{
    [Header("Fall Check")]
    [SerializeField] private float minY = -10f;  // Y position below which the enemy is considered fallen off
    
    [Header("Off Screen Check")]
    [Tooltip("Extra space before enemy is considered off screen")]
    [SerializeField] private float screenBuffer = 1.0f;

    private Camera mainCamera;
    private EnemyController enemyController;

    private void Awake()
    {
        mainCamera = Camera.main;
        enemyController = GetComponent<EnemyController>();

        if(!enemyController)
        {
            Debug.LogError("EnemyBoundsCheck is missing EnemyController on the same GameObject!", gameObject);
        }
    }

    private void Update()
    {
        // Check if enemy has fallen off the main level
        if (transform.position.y < minY)
        {
            enemyController.Die();
            return;
        }

        // Check if enemy has moved off the screen i used a tutorial from ...... link  it works by finding the transform point of the enemy and then adding 5f and then comparing it to the camera 
        Vector3 enemyScreenPos = mainCamera.WorldToViewportPoint(transform.position);
        if (enemyScreenPos.x < -screenBuffer || enemyScreenPos.x > 1 + screenBuffer ||
            enemyScreenPos.y < -screenBuffer || enemyScreenPos.y > 1 + screenBuffer)
        {
            enemyController.Die();
        }
    }
}
