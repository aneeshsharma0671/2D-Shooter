using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField] string activatorTag = null;
    [SerializeField] bool deactivateOnExit = false;
    [SerializeField] bool activateTransition = false;
    [SerializeField] bool firstTrigger = false;
    [SerializeField] GameObject[] objects = null;
    PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(activatorTag) && player.isOnGround)
        {
            foreach (var obj in objects)
                obj.SetActive(true);
           // if(activateTransition)
           // GameManager.PlayCameraTranstion();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (deactivateOnExit && collision.CompareTag(activatorTag) && player.isOnGround)
        {
            foreach (var obj in objects)
                obj.SetActive(false);
            if(firstTrigger)
            {
                activateTransition = true;
            }
        }
    }
}
