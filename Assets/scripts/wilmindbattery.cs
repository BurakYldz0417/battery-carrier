using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class wilmindbattery : MonoBehaviour
{
    public GameObject wilmindbat1, wilmindbat2, wilmindbat3, wilmindbat4;
    public GameObject villagebat1, villagebat2, villagebat3, villagebat4;
    public GameObject carbat1, carbat2, carbat3, carbat4;
    public GameObject upgradepanel,carFixplane, nextlevelbutton;
    public int wilmindcontrolinteger = 0;
    public int villagecontrolinteger = 0;
    public int score = 0;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI carhealttext;
    public TextMeshProUGUI nectlevelpricetext;
    public float villagebatseconds = 3f;
    public float wilmindbatseconds = 3f;
    public int carhealt = 500;
    public int downvardcarvalue=1;
    public int plusscore=10;
    public int villagebatupgradescore = 100, wilmindbutupgradescore = 100,carupgradescore=100 ;
    public int nextlevelprice = 650;
    move Move;
   
    void Start()
    {
        upgradepanel.SetActive(false);
        carFixplane.SetActive(false);
        nextlevelbutton.SetActive(false);

        wilmindbat1.SetActive(false);
        wilmindbat2.SetActive(false);
        wilmindbat3.SetActive(false);
        wilmindbat4.SetActive(false);
        carbat1.SetActive(false);
        carbat2.SetActive(false);
        carbat3.SetActive(false);
        carbat4.SetActive(false);
        villagebat1.SetActive(false);
        villagebat2.SetActive(false);
        villagebat3.SetActive(false);
        villagebat4.SetActive(false);
        StartCoroutine(wilmindbatteryy());
    }
    IEnumerator wilmindbatteryy()
    {

        wilmindbat1.SetActive(true);
        wilmindbat2.SetActive(false);
        wilmindbat3.SetActive(false);
        wilmindbat4.SetActive(false);
        yield return new WaitForSeconds(wilmindbatseconds);
        wilmindcontrolinteger++;
        wilmindbat1.SetActive(true);
        wilmindbat2.SetActive(true);
        wilmindbat3.SetActive(false);
        wilmindbat4.SetActive(false);
        yield return new WaitForSeconds(wilmindbatseconds);
        wilmindcontrolinteger++;
        wilmindbat1.SetActive(true);
        wilmindbat2.SetActive(true);
        wilmindbat3.SetActive(true);
        wilmindbat4.SetActive(false);
        wilmindcontrolinteger++;
        yield return new WaitForSeconds(wilmindbatseconds);
        wilmindcontrolinteger++;
        wilmindbat1.SetActive(true);
        wilmindbat2.SetActive(true);
        wilmindbat3.SetActive(true);
        wilmindbat4.SetActive(true);
    }
    IEnumerator villagebattery()
    {
        
        villagebat1.SetActive(true);
        villagebat2.SetActive(true);
        villagebat3.SetActive(true);
        villagebat4.SetActive(true);
        yield return new WaitForSeconds(villagebatseconds);
        villagebat1.SetActive(true);
        villagebat2.SetActive(true);
        villagebat3.SetActive(true);
        villagebat4.SetActive(false);
        villagecontrolinteger++;
        score += plusscore;
        yield return new WaitForSeconds(wilmindbatseconds);
        villagebat1.SetActive(true);
        villagebat2.SetActive(true);
        villagebat3.SetActive(false);
        villagebat4.SetActive(false);
        villagecontrolinteger++;
        score += plusscore;
        yield return new WaitForSeconds(wilmindbatseconds);
        villagebat1.SetActive(true);
        villagebat2.SetActive(false);
        villagebat3.SetActive(false);
        villagebat4.SetActive(false);
        villagecontrolinteger++;
        score += plusscore;
        yield return new WaitForSeconds(wilmindbatseconds);
        villagebat1.SetActive(false);
        villagebat2.SetActive(false);
        villagebat3.SetActive(false);
        villagebat4.SetActive(false);
        villagecontrolinteger++;
        score += plusscore;
        yield return new WaitForSeconds(3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="wilmundplane")
        {
            if (wilmindcontrolinteger % 4 == 0)
            {
                wilmindbat1.SetActive(false);
                wilmindbat2.SetActive(false);
                wilmindbat3.SetActive(false);
                wilmindbat4.SetActive(false);
                StartCoroutine(wilmindbatteryy());
                carbat1.SetActive(true);
                carbat2.SetActive(true);
                carbat3.SetActive(true);
                carbat4.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "villageplane")
        {
            if(villagecontrolinteger%4==0)
            {
            carbat1.SetActive(false);
            carbat2.SetActive(false);
            carbat3.SetActive(false);
            carbat4.SetActive(false);
            
            StartCoroutine(villagebattery());
           upgradepanel.SetActive(false);
            }
            else
            {
                carbat1.SetActive(false);
                carbat2.SetActive(false);
                carbat3.SetActive(false);
                carbat4.SetActive(false);
                villagecontrolinteger++;
            }
        }
        if (collision.gameObject.tag == "upgrades")
        {
           upgradepanel.SetActive(true);
        }
        if (collision.gameObject.tag == "carfixplane")
        {
            carFixplane .SetActive(true);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "plane")
        {
            carhealt = carhealt - downvardcarvalue ;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "upgrades")
        {
            upgradepanel.SetActive(false);
        }
        if (collision.gameObject.tag == "carfixplane")
        {
            carFixplane.SetActive(false);
        }
    }
    public void villagebatupgeade()
    {
        if (score >= villagebatupgradescore)
        {
            villagebatseconds--;
            plusscore += 10;
            score -= villagebatupgradescore;
            villagebatupgradescore += 100;
        }
    }
    public void wilmindbatupgeade()
    {
        if (score >= wilmindbutupgradescore)
        {
            villagebatseconds--;
            score -= wilmindbutupgradescore;
            wilmindbutupgradescore += 100;
        }
    }
    public void carupgrade()
    {if(score>=carupgradescore)
        {
            Move.speed += 0.5f;
            score -= carupgradescore;
            carupgradescore += 100;
        }
        
    }
    public void carfixed()
    {
        if (score >=downvardcarvalue)
        {
            Move.speed += 0.4f;
            score -=downvardcarvalue ;
            carupgradescore += 100;
        }
    }
    public void nextlevel()
    {
        if(score>=nextlevelprice)
        {
            SceneManager.LoadScene(1);
        }
    }
    void Update()
    {
        scoretext.text = "Your money:" + score + "$";
        if (villagebatseconds == 1)
        {
            wilmindbatseconds = 1;
        }
        scoretext.text = "Your money:" + score + "$";
        carhealttext.text = "Car healt " + carhealt;
        if (carhealt == 0)
        {
            SceneManager.LoadScene(0);
        }
        nectlevelpricetext.text = "Next level price:" + nextlevelprice;

        if (score >= nextlevelprice)
        {
            nextlevelbutton.SetActive(true);
        }
        else
        {
            nextlevelbutton.SetActive(false);
        }
    } 
}
