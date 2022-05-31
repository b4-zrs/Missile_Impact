using System.Collections;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
	public float missileSpeed;
	private Vector3 playerPos;
	private readonly float playerPosXClamp = 3.0f;
	private readonly float playerPosYClamp = 3.0f;

	private void MovingRestrictions()
	{
		//�ϐ��Ɏ����̍��̈ʒu������
		this.playerPos = transform.position;

		//playerPos�ϐ���x��y�ɐ��������l������
		//playerPos.x�Ƃ����l��-playerPosXClamp�`playerPosXClamp�̊ԂɎ��߂�
		this.playerPos.x = Mathf.Clamp(this.playerPos.x, -this.playerPosXClamp, this.playerPosXClamp);
		this.playerPos.y = Mathf.Clamp(this.playerPos.y, -this.playerPosYClamp, this.playerPosYClamp);

		transform.position = new Vector3(this.playerPos.x, this.playerPos.y, this.playerPos.z);
	}

	// speed�𐧌䂷��
	public float speed = 10;
	public float moveForceMultiplier;

	// �����ړ����ɋ@������E�Ɍ�����g���N
	public float yawTorqueMagnitude = 30.0f;

	// �����ړ����ɋ@����㉺�Ɍ�����g���N
	public float pitchTorqueMagnitude = 60.0f;

	// �����ړ����ɋ@�̂����E�ɌX����g���N
	public float rollTorqueMagnitude = 30.0f;

	// �o�l�̂悤�Ɏp�������ɖ߂��g���N
	public float restoringTorqueMagnitude = 100.0f;

	private Vector3 Player_pos;
	private new Rigidbody rigidbody;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();

		// �o�l�����͂ł����h�ꑱ����̂�h�����߁AangularDrag��傫�߂ɂ��Ă���
		rigidbody.angularDrag = 15.0f;
	}

	void Update()
	{
		// �O�i�͎���
		transform.Translate(0f, 0f, missileSpeed * Time.deltaTime);

		this.MovingRestrictions();
	}

	void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		// x��y��speed���|����
		rigidbody.AddForce(x * speed, y * speed, 0);

		Vector3 moveVector = Vector3.zero;

		rigidbody.AddForce(moveForceMultiplier * (moveVector - rigidbody.velocity));

		// �v���C���[�̓��͂ɉ����Ďp�����Ђ˂낤�Ƃ���g���N
		Vector3 rotationTorque = new Vector3(-y * pitchTorqueMagnitude, x * yawTorqueMagnitude, -x * rollTorqueMagnitude);

		// ���݂̎p���̂���ɔ�Ⴕ���傫���ŋt�����ɂЂ˂낤�Ƃ���g���N
		Vector3 right = transform.right;
		Vector3 up = transform.up;
		Vector3 forward = transform.forward;
		Vector3 restoringTorque = new Vector3(forward.y - up.z, right.z - forward.x, up.x - right.y) * restoringTorqueMagnitude;

		// �@�̂Ƀg���N��������
		rigidbody.AddTorque(rotationTorque + restoringTorque);
	}

	/*
	void OnCollisionEnter(Collision collision)
	{
		//Destroy(this.gameObject);
		Destroy(collision.gameObject);
		Time.timeScale = 0;
	}
	*/

	//public class rocketPower : MonoBehaviour

		Rigidbody rb;
		public GameObject explode;//explodeにはunity上でprefabを関連付けます
	    public GameObject fire;
	    public GameObject smoke;
	    void Start()
		{
			rb = this.GetComponent<Rigidbody>(); //衝突時にオブジェクトを消す際に使用
		}
	
		void OnCollisionEnter(Collision collision) //衝突時の処理
		{
			//Destroy(this.gameObject);
			if (collision.gameObject.tag == "Enemy")
			//タグで限定（他のオブジェクトに衝突した場合は呼び出さない
			{
				rb.isKinematic = true; //位置を固定
				this.transform.localScale = Vector3.zero; //みえない大きさにする
				Instantiate(explode, this.transform.position, Quaternion.identity);
			//ぶつかった位置にexplodeというprefabを配置する
			
			Destroy(fire);
			Destroy(smoke);
		}
		
		Time.timeScale = 0;

		}
	}


/*
private float miuTurnInputValue;
private Rigidbody miuRb;
private float miuNoseInputValue;

public float missileSpeed;



// Start is called before the first frame update
void Start()
{
	miuRb = GetComponent<Rigidbody>();
}

// Update is called once per frame
void Update()
{
	// �O�i�͎���
	transform.Translate(0f, 0f , missileSpeed * Time.deltaTime);

	// ����
	miuTurnInputValue = Input.GetAxis("Horizontal");
	float turn = miuTurnInputValue * 150 * Time.deltaTime;
	Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
	miuRb.MoveRotation(miuRb.rotation * turnRotation);

	// �@��i�㏸�A���~�j
	miuNoseInputValue = Input.GetAxis("Vertical");
	float noseTurn = -miuNoseInputValue * 60 * Time.deltaTime;
	Quaternion turnNoseRotation = Quaternion.Euler(noseTurn, 0, 0);
	miuRb.MoveRotation(miuRb.rotation * turnNoseRotation);

 private Vector2 playerPos;
    private readonly float playerPosXClamp = 3.0f;
    private readonly float playerPosYClamp = 3.0f;

    private void Update()
    {
        ////�O�i����
        transform.Translate(Vector3.up * this.moveSpeed * Time.deltaTime);
        // �ړ���������
        this.MovingRestrictions();

*/