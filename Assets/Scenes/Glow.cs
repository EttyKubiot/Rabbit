using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glow : MonoBehaviour
{
	[SerializeField] private Material originalMaterial;
	[SerializeField] private Material newMaterial;
	private SpriteRenderer meshRenderer;

	[SerializeField] private BonusData bonusData;

	[SerializeField] private GameEvent OnSwordSelected;
	// Need Collider to work!
	
	private void Start()
	{
		meshRenderer = GetComponent<SpriteRenderer>();
	}
	private void OnMouseOver()
	{
		meshRenderer.sharedMaterial = newMaterial;
		
		print("bonusName");
	}
	private void OnMouseExit()
	{
		meshRenderer.sharedMaterial = originalMaterial;
	}

	private void OnMouseDown()
	{
		OnSwordSelected.Raise();
	}
}
