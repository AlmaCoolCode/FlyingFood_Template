using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject food;

    private void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newFood = Instantiate(food, shootPoint.position, Random.rotation);
            newFood.GetComponent<Rigidbody>().velocity = shootPoint.forward * 30;
        }
    }
}
