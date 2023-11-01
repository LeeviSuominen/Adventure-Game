using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [SerializeField] private GameObject hero;
  [SerializeField] private GameObject spider;

   int heroLife;
   int spiderLife;

  [SerializeField] private int hero_maxLife;
  [SerializeField] private int spider_maxLife;

  [SerializeField] private GameObject heroWins;
  [SerializeField] private GameObject spiderWins;

  [SerializeField] private GameObject[] hearts;

  bool isHeroDie;
  bool isSpiderDie;

// oliomuuttuja
  private Player player;

  private void Start() {
    heroLife = hero_maxLife;
    spiderLife = spider_maxLife;

    isHeroDie = isSpiderDie = false;

    player = FindObjectOfType<Player>();
  }

  private void Update() {
    if (isHeroDie || isSpiderDie) return;

    if(heroLife <= 0) PlayerDie();

    if(spiderLife <= 0) SpiderDie();
  }

  private void PlayerDie(){
    hero.GetComponent<Animator>().SetTrigger("Die");
    isHeroDie = true;
    spiderWins.SetActive(true);
    AudioManager.instance.Play("WinFanfare");
  }

  public void HurtPlayer(int damageAmount){
    heroLife -= damageAmount;
    UpdateHeartGUI();
  }

  private void SpiderDie(){
    spider.GetComponent<Animator>().enabled = false;
    isSpiderDie = true;
    heroWins.SetActive(true);
    AudioManager.instance.Play("WinFanfare");
  }

  public void HurtSpider(int damageAmount){
    spiderLife -= damageAmount;
  }
  
  public void AddHeart(){
    heroLife += 1;
    UpdateHeartGUI();
  }

  private void UpdateHeartGUI(){
    // silmukka poistaa Herolta yhden sydämmen
    for(int i = 0; i < hearts.Length; i++){
      if(heroLife > i){
        hearts[i].SetActive(true);
      }
      else {
        hearts[i].SetActive(false);
      }
    }

    player.Health = heroLife;
  }

  public void UpdateHeart(int heartAmount){
    heroLife = heartAmount;
    UpdateHeartGUI();
  }
  
}
