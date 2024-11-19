using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject food;
    [SerializeField] private float shootSpeed = 30;

    private void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject newFood = Instantiate(food, shootPoint.position, Random.rotation);
        newFood.GetComponent<Rigidbody>().velocity = shootPoint.forward * shootSpeed;
    }
}
