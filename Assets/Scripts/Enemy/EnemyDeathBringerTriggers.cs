using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathBringerTriggers : Enemy_AnimationTriggers
{
    private Enemy_DeathBringer enemyDeathBringer => GetComponentInParent<Enemy_DeathBringer>();

    private void AttackTrigger()
    {
        AudioManager.instance.PlaySFX(1, null);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                PlayerStats target = hit.GetComponent<PlayerStats>();
                enemy.stats.DoDamage(target);
            }

        }

    }

    private void Relocate() => enemyDeathBringer.FindPosition();

    private void MakeInvisible() => enemyDeathBringer.fx.MakeTransprent(true);

    private void MakeVisible() => enemyDeathBringer.fx.MakeTransprent(false);


}
