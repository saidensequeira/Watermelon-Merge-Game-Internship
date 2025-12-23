using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int fruitLevel = 0; // 0 for small, 1 for medium, etc.
    public GameObject nextFruitPrefab; // The fruit this one turns into
    private bool hasMerged = false; // Prevents double-merging bugs

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we hit another object with the "Fruit" script
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        if (otherFruit != null && !hasMerged && !otherFruit.hasMerged)
        {
            // Only merge if the levels are the same (e.g., Cherry + Cherry)
            if (otherFruit.fruitLevel == this.fruitLevel)
            {
                hasMerged = true;
                otherFruit.hasMerged = true;

                // Find the middle point between the two fruits
                Vector3 spawnPos = (transform.position + collision.transform.position) / 2;

                // Spawn the next level fruit if one exists
                if (nextFruitPrefab != null)
                {
                    Instantiate(nextFruitPrefab, spawnPos, Quaternion.identity);
                }

                // Destroy both old fruits
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}
