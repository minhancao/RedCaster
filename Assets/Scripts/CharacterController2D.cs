using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	public static bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    public GameObject spellShieldBar;
    public GameObject spellShieldBarFill;
    public GameObject spellShield;

    public GameObject shieldCooldown;

    public bool coolDown = false;
    public float timeStamp;

    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	private void Awake()
	{
        shieldCooldown.GetComponent<Text>().text = "SHIELD COOLDOWN: 0";
        spellShieldBarFill.GetComponent<shieldBarFill>().Start();
        Debug.Log(spellShieldBarFill.GetComponent<shieldBarFill>().returnBarAmount());
        spellShieldBar.SetActive(false);
        spellShieldBarFill.SetActive(false);
        spellShield.SetActive(false);

        m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}

        if (spellShieldBarFill.GetComponent<shieldBarFill>().returnBarAmount() <= 0 && !coolDown)
        {
            coolDown = true;
            timeStamp = (float)(Time.time + 3);
        }

        if(coolDown)
        {
            if (timeStamp <= Time.time)
            {
                Debug.Log("Cooldown done");
                coolDown = false;
                spellShieldBarFill.GetComponent<shieldBarFill>().setBarAmountBack();
                timeStamp = 0;
            }

            float coolDown1 = timeStamp - Time.time;
            if (coolDown1 > 0)
            {
                shieldCooldown.GetComponent<Text>().text = "SHIELD COOLDOWN: " + ((int)coolDown1).ToString();
            }
        }

        /* CONTROL CHANGE */
        if (Input.GetKey(Controls.player.shield) && !coolDown)
        //if (Input.GetKey(KeyCode.Space) && !coolDown)
        {
             spellShieldBar.SetActive(true);
             spellShieldBarFill.SetActive(true);
             spellShield.SetActive(true);
        }

        
    }

    public Transform characterPos()
    {
        return transform;
    }

    //void SpellShield()
    //{
    //    Vector3 help = shieldPoint.position;
    //    help.x -= 0.6f;
    //    Instantiate(spellShield, firePoint.position, firePoint.rotation);
    //    Instantiate(spellShieldBar, shieldPoint.position, shieldPoint.rotation);

    //    if (!CharacterController2D.m_FacingRight)
    //    {
    //        help.x += 1.2f;
    //    }
    //    Instantiate(spellShieldBarFill, help, shieldPoint.rotation);

    //}


    public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	public void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
	}
}
