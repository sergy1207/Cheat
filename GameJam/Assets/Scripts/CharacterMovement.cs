using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float velocity;

    CharacterController controller;
    public Transform runningQuad;
    public Transform standingQuad;

    float horizontal;
    float vertical;

    enum Looking
    {
        LEFT, RIGHT
    }
    Looking currentLooking, nextLooking;

    bool isStanding;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        isStanding = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        horizontal = 0;
        vertical = 0;

        currentLooking = nextLooking = Looking.LEFT;

        runningQuad.gameObject.SetActive(false);
        standingQuad.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal == 0 && vertical == 0)
        {
            isStanding = true;

            runningQuad.gameObject.SetActive(false);
            standingQuad.gameObject.SetActive(true);
        }
        else
        {
            if (isStanding)
            {
                isStanding = false;

                runningQuad.gameObject.SetActive(true);
                standingQuad.gameObject.SetActive(false);
            }

            if (horizontal < 0)
            {
                nextLooking = Looking.LEFT;
            }
            else
            {
                nextLooking = Looking.RIGHT;
            }
        }

        if (currentLooking != nextLooking)
        {
            if (nextLooking == Looking.LEFT)
                runningQuad.localScale = new Vector3(1, 1, 1);
            else
                runningQuad.localScale = new Vector3(-1, 1, 1);

            currentLooking = nextLooking;
        }

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        controller.Move(direction * velocity * Time.deltaTime);
    }
}
