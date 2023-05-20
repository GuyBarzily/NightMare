using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform target; // Reference to your character's transform
    public float movementSpeed = 30f; // Adjust the speed as needed
    public Animator animator;
    private int health = 3;

    public void Awake()
    {
        print("Zombie Awake");
        //target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public void Start()
    {
        animator = GetComponent<Animator>();


    }
    public void TakeDamage()
    {
        health--;
        FmsScript player = target.gameObject.GetComponent<FmsScript>();
        player.AddScore();
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
        // Check if the target is null
        if (target == null)
        {
            //target = GameObject.FindGameObjectWithTag("Player").transform;

            Debug.LogWarning("Zombie target is not set!");
            return;
        }

        // Calculate the direction from zombie to target
        Vector3 direction = target.position - transform.position;
        direction.Normalize(); // Normalize the direction to get a unit vector

        // Move the zombie towards the target
        transform.position += direction * movementSpeed * Time.deltaTime;


        Quaternion rotation = Quaternion.LookRotation(direction);
        Quaternion targetRot = Quaternion.Euler(transform.eulerAngles.x, rotation.eulerAngles.y, transform.eulerAngles.z);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.deltaTime * 270f);
    }


}