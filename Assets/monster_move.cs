using System.Collections;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float minX = -1.4f;
    public float maxX = 25f;
    public float minY = 2f;
    public float maxY = 12f;

    IEnumerator Start()
    {
        while (true)
        {
            Vector2 randomPosition = GetRandomPosition();
            yield return MoveToPosition(randomPosition);

            yield return new WaitForSeconds(1f);
        }
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        while (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}