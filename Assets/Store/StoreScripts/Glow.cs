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

	[SerializeField] private GameEvent OnBonusSelected;
	// Need Collider to work!
	
	private void Start()
	{
		meshRenderer = GetComponent<SpriteRenderer>();
	}
	private void OnMouseOver()
	{
		meshRenderer.sharedMaterial = newMaterial;
		OnBonusSelected.Raise();
		
	}
	private void OnMouseExit()
	{
		meshRenderer.sharedMaterial = originalMaterial;
	}

	
}
