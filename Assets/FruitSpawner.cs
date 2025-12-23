using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab; // The fruit to drop

    void Update()
    {
        // 1. Make the Spawner follow the mouse X position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, transform.position.y, 0);

        // 2. Drop the fruit when left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fruitPrefab, transform.position, Quaternion.identity);
        }
    }
}
