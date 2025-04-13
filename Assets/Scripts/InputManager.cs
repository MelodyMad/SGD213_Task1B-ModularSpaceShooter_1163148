using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Create a variable movement from the Movement script and shooting from ShootingScript
    private EngineBase movement;
    private ShootingScript shooting;

    // Start is called before the first frame update
    void Start()
    {
        // The components from the Movement script and ShootingScript are retrieved for the corresponding variables
        movement = GetComponent<EngineBase>();
        shooting = GetComponent<ShootingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // A variable called input where the Horizontal Input recorded will be stored
        float input = Input.GetAxis("Horizontal");
        // The object will move horizontally left and right depending on the left and right input received as the function Move is in the Movement script
        movement.MovePlayer(Vector2.right * input);
        
        // If the Left mouse button is clicked or the space bar is pressed the object will Shoot
        if (Input.GetButton("Fire1") || Input.GetButton("Jump"))
        {
            // If the ShootingScript is attached
            if (shooting != null)
            {
                // Shoot the bullet using the Shoot function in ShootingScript
                shooting.Shoot();
            }
            else
            {
                // In the unity console, say that there is no shooting script attached
                Debug.Log("Attach a shooting script");
            }
            
        }
    }
}
