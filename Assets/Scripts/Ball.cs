using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleToBall;
    bool hasStarted = false;
    AudioSource audioSource;
    Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start ()
    {
        paddleToBall = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
        
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(x, y);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 ballVelocity = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            audioSource.Play();
            myRigidBody.velocity += ballVelocity;
        }
    }
}
