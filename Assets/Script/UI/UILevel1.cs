using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class UILevel1 : MonoBehaviour
{

	public Text t_title;
	public Text t_dialogue;
	public GameObject crystal;

	private float dialogueGap = 0.7f;


	protected List<string> m_listDialogue = new List<string> ();
	protected List<Action> m_listAction = new List<Action> ();

	protected int dialogueIndex = 0;
	[HideInInspector]
	public bool b_clickSleep = false;

	// Use this for initialization
	protected virtual void Start ()
	{
		InitText ();
		InitAction();
	}

	protected virtual void InitText ()
	{
		t_title.DOFade (1f, 1f).SetDelay(1f);


		m_listDialogue.Add ("壹千年前,在与世隔绝的村子里,大家过着和平快乐的日子");
		m_listDialogue.Add ("直到有一天，村里的能量之源”海尔”水晶体失去了能量");
		m_listDialogue.Add ("失去精源的村民们只得纷纷离开村子\n前往蓝翔魔法技工学院学习赖以生存的本能");
	}


	protected virtual void InitAction ()
	{
		m_listAction.Add (Action1);
		m_listAction.Add (Action2);
		m_listAction.Add (ActionEmpty);
		m_listAction.Add (ActionLaset);
	}

	private void Action1 ()
	{
		t_title.DOFade (0, 1f);
	}


	private void Action2()
	{
		crystal.transform.DOScale (0, 1.0f).SetDelay (.5f).OnStepComplete(()=>{
			crystal.SetActive(false);
		});

		CameraForward forward = Camera.main.GetComponent<CameraForward> ();
		forward.m_delay = 0.5f;
		forward.enabled = true;

	}

	private void ActionEmpty ()
	{
		
	}

	private void ActionLaset ()
	{
		SceneManager.LoadScene ("level1");
	}

	public void OnDialoguePressed ()
	{
		if (b_clickSleep)
			return;
		
		if(dialogueIndex<m_listDialogue.Count)
			t_dialogue.text = m_listDialogue [dialogueIndex];
		if(dialogueIndex<m_listAction.Count)
			m_listAction [dialogueIndex] ();
		
//		StartCoroutine (IETextButtonSleep ());

		TextButtonSleep ();
		dialogueIndex++;
	}


	IEnumerator ShowDialogue (string[] lines, float delay)
	{
		yield return new WaitForSeconds (delay);

		for (int i = 0; i < lines.Length; i++) {
			t_dialogue.text = lines [i];
			yield return dialogueGap;
		}
	}

	IEnumerator IETextButtonSleep (float during = 0.3f)
	{
		b_clickSleep = true;
		yield return null;
		b_clickSleep = false;

	}

	void TextButtonSleep (float during = 0.3f)
	{
		b_clickSleep = true;
		b_clickSleep = false;

	}

}
