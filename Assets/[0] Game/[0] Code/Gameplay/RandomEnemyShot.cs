using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class RandomEnemyShot : MonoBehaviour
    {
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                var enemies = FindObjectsOfType<Enemy>();

                if (enemies.Length == 0)
                    yield break;
                
                float minY = enemies[0].transform.position.y;

                var enemiesMinY = new List<Enemy>();

                foreach (var enemy in enemies)
                {
                    if (enemy.transform.position.y < minY)
                    {
                        minY = enemy.transform.position.y;
                    }
                }

                foreach (var enemy in enemies)
                {
                    if (enemy.transform.position.y == minY)
                    {
                        enemiesMinY.Add(enemy);
                    }
                }
                
                enemiesMinY[Random.Range(0, enemiesMinY.Count)].Shot();
            }
        }
    }
}