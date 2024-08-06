using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barrel : MonoBehaviour, IBarrel
{
    Transform initialPosition;
    Transform target;
    double life;
    public TextMeshProUGUI text;
    public MeshRenderer rewardMeshRender;
    public RewardMaterials[] rewardMaterials;
    [SerializeField] bool killer;

    public bool Killer { get => killer; set { killer = value; } }

    public enum Update
    {
        WeaponDamage,
        SpeedMove,
        RateOfFire,
        HpWall
    }

    public Update reward;

    public void SetBarrel(Transform from, Transform to, double life)
    {
        reward = (Update)Random.Range(0, 3);
        rewardMeshRender.material = rewardMaterials[(int)reward].material;
        transform.position = from.position;
        initialPosition = from;
        target = to;
        this.life = life;
        text.text = life.ToString();
    }

    
    public void StartBarrel()
    {
        gameObject.SetActive(true);
        StartCoroutine(StartingBarrel());
    }


    IEnumerator StartingBarrel()
    {
        float time = 0;

        while (time < Equations.SpeedBarrels())
        {
            transform.position = Vector3.Lerp(initialPosition.position, target.position, time / Equations.SpeedBarrels());
            time += TimeManager.control.GetBarrelTime();
            yield return null;
        }

        transform.position = target.position;

        Die();
    }

    public void ReduceLife(double damage)
    {
        life -= damage;
        text.SetText(life.ToString());
        if (life <= 0)
        {
            switch (reward)
            {
                case Update.WeaponDamage:
                    Equations.UpWeaponDamage();
                    break;
                case Update.SpeedMove:
                    Equations.UpCharacterSpeed();
                    break;
                case Update.RateOfFire:
                    Equations.UpRateOfFire();
                    break;
                case Update.HpWall:
                    break;
                default:
                    break;
            }
            Equations.UpBarrels();
            Die();
        }
    }

    private void OnValidate()
    {
        for (int i = 0; i < rewardMaterials.Length; i++)
        {
            rewardMaterials[i].name = System.Enum.GetNames(typeof(Update))[i];
        }
    }

    public void FinishGame()
    {
        Debug.Log("me desaparezco");
        if (!killer)
            Die();
    }

    public void Die()
    {
        gameObject.SetActive(false);
        BarrelGeneratorManager.instace.UnSubcribe(this);
    }

    [System.Serializable]
    public class RewardMaterials
    {
        [HideInInspector]
        public string name;
        public Material material;
    }
}
