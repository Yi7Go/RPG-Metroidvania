using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    [SerializeField] private LayerMask destructibleLayer;
    private Player player => GetComponentInParent<Player>();

    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    private void AttackTrigger()
    {

        AudioManager.instance.PlaySFX(2,null);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        Collider2D[] destructiveHitColliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius,destructibleLayer);


        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                EnemyStats _target = hit.GetComponent<EnemyStats>();

                player.stats.DoDamage(_target);

                if (_target != null)
                    player.stats.DoDamage(_target);


                ItemData_Equipment weaponData = Inventory.instance.GetEquipment(EquipmentType.Weapon);

                if (weaponData != null)
                    weaponData.Effect(_target.transform);
            }


        }

        //≈–∂œ∆∆ªµŒÔ∆∑
        foreach (Collider2D hitCollider in destructiveHitColliders)   
        {
            hitCollider.GetComponent<DestructibleObjects>().DestoryObject();
        }

    }



    private void ThrowSword()
    {
        AudioManager.instance.PlaySFX(27, null);
        SkillManger.instance.sword.CreateSword();

    
    }
    

}
