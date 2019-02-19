using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class playerController : MonoBehaviour {

	[SerializeField]
	private int moveTime;
	[SerializeField]
	private Transform start;

	private bool deth;

	private Vector3 mousePoint;

	// Start is called before the first frame update
	void Start()
	{
		deth = false;
		this.transform.position = new Vector3(start.position.x, 2.0f, start.position.z);
	}

	// Update is called once per frame
	void Update()
	{
		if (deth != true)
		{
			// マウスの更新
			mouseUpdate();

			// マウスの座標をからレイを飛ばして2dに変換
			this.transform.DOMoveX(mousePoint.x, moveTime);
			this.transform.DOMoveZ(mousePoint.z, moveTime);
		}
		else
		{
			// 死亡時

		}
	}

	void mouseUpdate()
	{
		Vector2 touchScreenPosition = Input.mousePosition;

		touchScreenPosition.x = Mathf.Clamp(touchScreenPosition.x, 0.0f, Screen.width);
		touchScreenPosition.y = Mathf.Clamp(touchScreenPosition.y, 0.0f, Screen.height);

		Camera gameCamera = Camera.main;
		Ray touchPointToRay = gameCamera.ScreenPointToRay(touchScreenPosition);

		RaycastHit hitInfo = new RaycastHit();
		if (Physics.Raycast(touchPointToRay, out hitInfo))
		{
			mousePoint = hitInfo.point;
			mousePoint = new Vector3(mousePoint.x, mousePoint.y + 0.5f, mousePoint.z);
		}
		// デバッグ機能を利用して、スクリーンビューでレイが出ているか見てみよう。
		Debug.DrawRay(touchPointToRay.origin, touchPointToRay.direction * 1000.0f);

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "block")
		{
			Debug.Log("playerDeth");
			deth = true;
		}
	}

	public bool getDeth()
	{
		return deth;
	}
}
