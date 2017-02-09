using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class UILevel2 : UILevel1
{


	public Transform cameraPos0;
	public Transform cameraPos1;
	public Transform cameraPos2;

	public Image m_black;

	private CameraForward m_CameraFoward;

	void Awake()
	{
		m_CameraFoward = Camera.main.gameObject.GetComponent<CameraForward> ();
	}
	// Use this for initialization
	void Start ()
	{
		base.Start ();
		OnDialoguePressed ();

	}


	protected override void InitText ()
	{
		m_listDialogue.Add ("长老看不下去 找了年轻的勇士软软");
		m_listDialogue.Add ("<长老>村子的未来就靠你惹 在深山里有一直回隐身的恶龙看守者水晶矿");
		m_listDialogue.Add ("<勇士>可是我怕死啊 能不能不去啊\n<长老>天了噜！你太让我失望惹 看来这些前没有用惹");
		m_listDialogue.Add ("<勇士> 丘都麻袋！为了全村的幸福\n请问是支付宝转账么？我开不了发票");

	}

	protected override void InitAction ()
	{
		m_listAction.Add (Action0);
		m_listAction.Add (Action1);
		m_listAction.Add (Action2);
		m_listAction.Add (Action3);

		m_listAction.Add (ActionFinish);

	}

	private void ReSetTransform(Transform t)
	{
		t.localPosition = Vector3.zero;
		t.localEulerAngles = Vector3.zero;
		t.localScale = Vector3.zero;
	}

	void Action0 ()
	{
		Camera.main.transform.SetParent (cameraPos0);
		ReSetTransform (Camera.main.transform);
		m_CameraFoward.m_arrow = Camera.main.transform.forward;

	}

	void Action1 ()
	{
		Camera.main.transform.SetParent (cameraPos1);
		ReSetTransform (Camera.main.transform);
		m_CameraFoward.m_arrow = Camera.main.transform.forward;
	}

	void Action2 ()
	{
		Camera.main.transform.SetParent (cameraPos2);
		ReSetTransform (Camera.main.transform);
		m_CameraFoward.m_arrow = Camera.main.transform.forward*-1;
	}

	void Action3 ()
	{
		Camera.main.transform.SetParent (cameraPos0);
		ReSetTransform (Camera.main.transform);
		m_CameraFoward.m_arrow = Camera.main.transform.right;
	}


	void ActionFinish()
	{
		Debug.Log ("finish");
		StartCoroutine (IEFinish ());
	}
		
	IEnumerator IEFinish()
	{
		yield return new WaitForSeconds(1.0f);
		t_title.text = "于是勇者开始了旅程";
		t_title.DOFade (1.0f, 1.0f);

		yield return new WaitForSeconds (1.0f);
		m_black.gameObject.SetActive (true);
		m_black.DOFade (1.0f, 1.0f);

		yield return new WaitForSeconds (1.0f);
		SceneManager.LoadScene ("level2");
	}
}
