using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class UIButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler, IPointerEnterHandler
{
	public new bool enabled { get; set; }
	public bool makeSound = false;
	protected bool inside = false;
	protected bool clicked = false;
	public bool keyable = true;

	void Awake()
	{
		enabled = true;
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		if (enabled && inside)
		{
			Release();
			if (makeSound)
			{
                //if (ButtonSfx != null)
                //{
                //    if (ButtonSfx.butonUsed != null)
                //        ButtonSfx.PlayThisOrThatSound();
                //    else
                //    {
                //        ButtonSfx.PlayTheSound();
                //    }
                //}
                //else
                //    SoundManager.control.PlaySound(SoundManager.SoundsEffect.OptionHover, true);
                //GameControl.control.menuButton.Play();
            }
		}
		clicked = false;
		transform.localScale = Vector3.one;
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		if (enabled)
		{
			Press();
		}
		clicked = true;
		transform.localScale = Vector3.one * 1.05f;
	}

	public virtual void OnPointerExit(PointerEventData ped)
	{
		if (enabled)
		{
			Exit();
		}
		inside = false;
		transform.localScale = Vector3.one;
	}

	public virtual void OnPointerEnter(PointerEventData ped)
	{
		inside = true;
		if (clicked)
		{
			transform.localScale = Vector3.one * 1.05f;
		}
	}

	public abstract void Press();

	public abstract void Release();

	public abstract void Exit();

}
