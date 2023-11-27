using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public string currentSelect = "";
    public List<Car> listCar;

    public void AddCar(Car car)
    {
        currentSelect = car.gameObject.name;
        listCar.Add(car);
    }

    public void RemoveAllCAr()
    {
        var particleVFXs = GameManager.Instance.particleVFXs;
        GameObject explosion = Instantiate(particleVFXs[UnityEngine.Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
        Destroy(explosion, .75f);
        
        foreach (var car in listCar)
        {
            GameManager.Instance.GetCurLevel().RemoveObject(car.gameObject);
            Destroy(car.gameObject);
        }

        listCar.Clear();
        currentSelect = "";
    }
}
