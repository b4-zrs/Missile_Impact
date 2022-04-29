using UnityEngine;
using System.Collections;

public class MissileControl : MonoBehaviour
{
	public float missileSpeed;
	private Vector3 playerPos;
	private readonly float playerPosXClamp = 3.0f;
	private readonly float playerPosYClamp = 3.0f;

	
	private void MovingRestrictions()
	{
		//変数に自分の今の位置を入れる
		this.playerPos = transform.position;

		//playerPos変数のxとyに制限した値を入れる
		//playerPos.xという値を-playerPosXClamp～playerPosXClampの間に収める
		this.playerPos.x = Mathf.Clamp(this.playerPos.x, -this.playerPosXClamp, this.playerPosXClamp);
		this.playerPos.y = Mathf.Clamp(this.playerPos.y, -this.playerPosYClamp, this.playerPosYClamp);

		transform.position = new Vector3(this.playerPos.x, this.playerPos.y, this.playerPos.z);
	}
	

	// speedを制御する
	public float speed = 10;
	public float moveForceMultiplier;

	// 水平移動時に機首を左右に向けるトルク
	public float yawTorqueMagnitude = 30.0f;

	// 垂直移動時に機首を上下に向けるトルク
	public float pitchTorqueMagnitude = 60.0f;

	// 水平移動時に機体を左右に傾けるトルク
	public float rollTorqueMagnitude = 30.0f;

	// バネのように姿勢を元に戻すトルク
	public float restoringTorqueMagnitude = 100.0f;

	private Vector3 Player_pos;
	private new Rigidbody rigidbody;

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();

		// バネ復元力でゆらゆら揺れ続けるのを防ぐため、angularDragを大きめにしておく
		rigidbody.angularDrag = 15.0f;
	}

	void Update()
	{
		// 前進は自動
		transform.Translate(0f, 0f, missileSpeed * Time.deltaTime);

		this.MovingRestrictions();
	}

	void FixedUpdate()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		// xとyにspeedを掛ける
		rigidbody.AddForce(x * speed, y * speed, 0);

		Vector3 moveVector = Vector3.zero;

		rigidbody.AddForce(moveForceMultiplier * (moveVector - rigidbody.velocity));

		// プレイヤーの入力に応じて姿勢をひねろうとするトルク
		Vector3 rotationTorque = new Vector3(-y * pitchTorqueMagnitude, x * yawTorqueMagnitude, -x * rollTorqueMagnitude);

		// 現在の姿勢のずれに比例した大きさで逆方向にひねろうとするトルク
		Vector3 right = transform.right;
		Vector3 up = transform.up;
		Vector3 forward = transform.forward;
		Vector3 restoringTorque = new Vector3(forward.y - up.z, right.z - forward.x, up.x - right.y) * restoringTorqueMagnitude;

		// 機体にトルクを加える
		rigidbody.AddTorque(rotationTorque + restoringTorque);
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
	// 前進は自動
	transform.Translate(0f, 0f , missileSpeed * Time.deltaTime);

	// 旋回
	miuTurnInputValue = Input.GetAxis("Horizontal");
	float turn = miuTurnInputValue * 150 * Time.deltaTime;
	Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
	miuRb.MoveRotation(miuRb.rotation * turnRotation);

	// 機首（上昇、下降）
	miuNoseInputValue = Input.GetAxis("Vertical");
	float noseTurn = -miuNoseInputValue * 60 * Time.deltaTime;
	Quaternion turnNoseRotation = Quaternion.Euler(noseTurn, 0, 0);
	miuRb.MoveRotation(miuRb.rotation * turnNoseRotation);

 private Vector2 playerPos;
    private readonly float playerPosXClamp = 3.0f;
    private readonly float playerPosYClamp = 3.0f;

    private void Update()
    {
        ////前進処理
        transform.Translate(Vector3.up * this.moveSpeed * Time.deltaTime);
        // 移動制限処理
        this.MovingRestrictions();

*/

