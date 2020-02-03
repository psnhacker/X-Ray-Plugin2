using UnityEngine;
using XrCore.Parser;
using System.Globalization;
using System.Collections.Generic;


public class Alife_Generator : MonoBehaviour
{
    public void Generation(Alife_Converter alife)
    {
        Items(alife);
        Anomaly(alife);
        Monster(alife);
        Stalker(alife);
        Physics(alife);
        Destroyable(alife);
        Explosive(alife);
    }
    const float coef = 57.29f;
    private void Items(Alife_Converter data)
    {
        List<string> parse_data = data.items;
        ItemXR[] items = new ItemXR[parse_data.Count];
        for (int i = 0; i < parse_data.Count; i++)
        {
            string[] curentItems = parse_data[i].Split(':');
            items[i] = new ItemXR
            {
                _visual_name = curentItems[0],
                _section_name = curentItems[1],
                _name = curentItems[2],
                _posX = float.Parse(curentItems[3], CultureInfo.InvariantCulture),
                _posY = float.Parse(curentItems[4], CultureInfo.InvariantCulture),
                _posZ = float.Parse(curentItems[5], CultureInfo.InvariantCulture),
                _rotX = float.Parse(curentItems[6], CultureInfo.InvariantCulture),
                _rotY = float.Parse(curentItems[7], CultureInfo.InvariantCulture),
                _rotZ = float.Parse(curentItems[8], CultureInfo.InvariantCulture)
            };
        }
        GameObject _parent = new GameObject("LevelItem");
        for (int i = 0; i < items.Length; i++)
        {
            GameObject instance = Instantiate(Resources.Load(items[i]._visual_name.Trim(), typeof(GameObject))) as GameObject;
            Vector3 leftCoordSystem = new Vector3(0f, 180f, 0f);
            Vector3 _position = new Vector3(items[i]._posX, items[i]._posY, items[i]._posZ);
            Vector3 localEuler = new Vector3(leftCoordSystem.x + (items[i]._rotX * coef), leftCoordSystem.y - (items[i]._rotY * coef), leftCoordSystem.z + (items[i]._rotZ * coef));
            instance.transform.SetParent(_parent.transform);
            instance.transform.localPosition = _position;
            instance.transform.localEulerAngles = localEuler;
            instance.name = items[i]._name;
        }
        _parent.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }
    private void Anomaly(Alife_Converter data)
    {
        List<string> parse_data = data.anomaly;
        Anomaly_ZoneXR[] items = new Anomaly_ZoneXR[parse_data.Count];
        for (int i = 0; i < parse_data.Count; i++)
        {
            string[] curentItems = parse_data[i].Split(':');
            items[i] = new Anomaly_ZoneXR
            {
                _visual_name = "AnomalyVisualEngine",
                _section_name = curentItems[0],
                _name = curentItems[1],
                _posX = float.Parse(curentItems[2], CultureInfo.InvariantCulture),
                _posY = float.Parse(curentItems[3], CultureInfo.InvariantCulture),
                _posZ = float.Parse(curentItems[4], CultureInfo.InvariantCulture),
                _rotX = float.Parse(curentItems[5], CultureInfo.InvariantCulture),
                _rotY = float.Parse(curentItems[6], CultureInfo.InvariantCulture),
                _rotZ = float.Parse(curentItems[7], CultureInfo.InvariantCulture),
                _distance = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _radius = float.Parse(curentItems[9], CultureInfo.InvariantCulture)
            };
        }
        GameObject _parent = new GameObject("LevelAnomaly");
        for (int i = 0; i < items.Length; i++)
        {
            GameObject instance = Instantiate(Resources.Load(items[i]._visual_name, typeof(GameObject))) as GameObject;
            Vector3 leftCoordSystem = new Vector3(0f, 180f, 0f);
            Vector3 _position = new Vector3(items[i]._posX, items[i]._posY, items[i]._posZ);
            instance.transform.SetParent(_parent.transform);
            instance.transform.localPosition = _position;
            instance.name = items[i]._name;
            SphereCollider collider = instance.AddComponent<SphereCollider>();
            collider.isTrigger = true;
            collider.radius = items[i]._radius;
        }
        _parent.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }
    private void Monster(Alife_Converter data)
    {
        List<string> parse_data = data.monster; 
        MonsterXR[] items = new MonsterXR[parse_data.Count];
        for (int i = 0; i < parse_data.Count; i++)
        {
            string[] curentItems = parse_data[i].Split(':');
            items[i] = new MonsterXR
            {
                _visual_name = curentItems[0],
                _section_name = curentItems[1],
                _name = curentItems[2],
                _posX = float.Parse(curentItems[3], CultureInfo.InvariantCulture),
                _posY = float.Parse(curentItems[4], CultureInfo.InvariantCulture),
                _posZ = float.Parse(curentItems[5], CultureInfo.InvariantCulture),
                _rotX = float.Parse(curentItems[6], CultureInfo.InvariantCulture),
                _rotY = float.Parse(curentItems[7], CultureInfo.InvariantCulture),
                _rotZ = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _distance = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _health = float.Parse(curentItems[9], CultureInfo.InvariantCulture)
            };
        }
        GameObject _parent = new GameObject("LevelMonster");
        for (int i = 0; i < items.Length; i++)
        {
            GameObject instance = Instantiate(Resources.Load(items[i]._visual_name.Trim(), typeof(GameObject))) as GameObject;
            Vector3 leftCoordSystem = new Vector3(0f, 180f, 0f);
            Vector3 _position = new Vector3(items[i]._posX, items[i]._posY, items[i]._posZ);
            Vector3 localEuler = new Vector3(leftCoordSystem.x + (items[i]._rotX * coef), leftCoordSystem.y - (items[i]._rotY * coef), leftCoordSystem.z + (items[i]._rotZ * coef));
            instance.transform.SetParent(_parent.transform);
            instance.transform.localPosition = _position;
            instance.transform.localEulerAngles = localEuler;
            instance.name = items[i]._name;
        }
        _parent.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }
    private void Stalker(Alife_Converter data)
    {
        List<string> parse_data = data.stalker; 
        StalkerXR[] items = new StalkerXR[parse_data.Count];
        for (int i = 0; i < parse_data.Count; i++)
        {
            string[] curentItems = parse_data[i].Split(':');
            items[i] = new StalkerXR
            {
                _visual_name = curentItems[0],
                _section_name = curentItems[1],
                _name = curentItems[2],
                _posX = float.Parse(curentItems[3], CultureInfo.InvariantCulture),
                _posY = float.Parse(curentItems[4], CultureInfo.InvariantCulture),
                _posZ = float.Parse(curentItems[5], CultureInfo.InvariantCulture),
                _rotX = float.Parse(curentItems[6], CultureInfo.InvariantCulture),
                _rotY = float.Parse(curentItems[7], CultureInfo.InvariantCulture),
                _rotZ = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _distance = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _money = float.Parse(curentItems[9], CultureInfo.InvariantCulture),
                _health = float.Parse(curentItems[10], CultureInfo.InvariantCulture),
                _character_profile = curentItems[11],
                _items = curentItems[12]
            };
        }
        GameObject _parent = new GameObject("LevelStalker");
        for (int i = 0; i < items.Length; i++)
        {
            GameObject instance = Instantiate(Resources.Load(items[i]._visual_name.Trim(), typeof(GameObject))) as GameObject;
            Vector3 leftCoordSystem = new Vector3(0f, 180f, 0f);
            Vector3 _position = new Vector3(items[i]._posX, items[i]._posY, items[i]._posZ);
            Vector3 localEuler = new Vector3(leftCoordSystem.x + (items[i]._rotX * coef), leftCoordSystem.y - (items[i]._rotY * coef), leftCoordSystem.z + (items[i]._rotZ * coef));
            instance.transform.SetParent(_parent.transform);
            instance.transform.localPosition = _position;
            instance.transform.localEulerAngles = localEuler;
            instance.name = items[i]._name;
        }
        _parent.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }
    private void Physics(Alife_Converter data)
    {
        List<string> parse_data = data.physic_object;
        PhysicsXR[] items = new PhysicsXR[parse_data.Count];
        for (int i = 0; i < parse_data.Count; i++)
        {
            string[] curentItems = parse_data[i].Split(':');
            items[i] = new PhysicsXR
            {
                _visual_name = curentItems[0],
                _section_name = curentItems[1],
                _name = curentItems[2],
                _posX = float.Parse(curentItems[3], CultureInfo.InvariantCulture),
                _posY = float.Parse(curentItems[4], CultureInfo.InvariantCulture),
                _posZ = float.Parse(curentItems[5], CultureInfo.InvariantCulture),
                _rotX = float.Parse(curentItems[6], CultureInfo.InvariantCulture),
                _rotY = float.Parse(curentItems[7], CultureInfo.InvariantCulture),
                _rotZ = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _mass = float.Parse(curentItems[8], CultureInfo.InvariantCulture)
            };
        }
        GameObject _parent = new GameObject("LevelPhysics");
        for (int i = 0; i < items.Length; i++)
        {
            GameObject instance = Instantiate(Resources.Load(items[i]._visual_name.Trim(), typeof(GameObject))) as GameObject;
            Vector3 leftCoordSystem = new Vector3(-90f, 180f, 0f);
            Vector3 _position = new Vector3(items[i]._posX, items[i]._posY, items[i]._posZ);
            Vector3 localEuler = new Vector3(leftCoordSystem.x + (items[i]._rotX * coef), leftCoordSystem.y - (items[i]._rotY * coef), leftCoordSystem.z + (items[i]._rotZ * coef));
            instance.transform.SetParent(_parent.transform);
            instance.transform.localPosition = _position;
            instance.transform.localEulerAngles = localEuler;
            instance.name = items[i]._name;
            BoxCollider coll = instance.AddComponent<BoxCollider>();
            Rigidbody rigidbody = instance.GetComponent<Rigidbody>();
            if (rigidbody == null) rigidbody = instance.AddComponent<Rigidbody>();
            rigidbody.mass = items[i]._mass;
        }
        _parent.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }
    private void Destroyable(Alife_Converter data)
    {
        List<string> parse_data = data.physic_destroyable_object; 
        Physics_DestroyXR[] items = new Physics_DestroyXR[parse_data.Count];
        for (int i = 0; i < parse_data.Count; i++)
        {
            string[] curentItems = parse_data[i].Split(':');
            items[i] = new Physics_DestroyXR
            {
                _visual_name = curentItems[0],
                _section_name = curentItems[1],
                _name = curentItems[2],
                _posX = float.Parse(curentItems[3], CultureInfo.InvariantCulture),
                _posY = float.Parse(curentItems[4], CultureInfo.InvariantCulture),
                _posZ = float.Parse(curentItems[5], CultureInfo.InvariantCulture),
                _rotX = float.Parse(curentItems[6], CultureInfo.InvariantCulture),
                _rotY = float.Parse(curentItems[7], CultureInfo.InvariantCulture),
                _rotZ = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _mass = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _items = curentItems[9]
            };
        }
        GameObject _parent = new GameObject("LevelPhysicsDestroy");
        for (int i = 0; i < items.Length; i++)
        {
            GameObject instance = Instantiate(Resources.Load(items[i]._visual_name.Trim(), typeof(GameObject))) as GameObject;
            Vector3 leftCoordSystem = new Vector3(-90f, 180f, 0f);
            Vector3 _position = new Vector3(items[i]._posX, items[i]._posY, items[i]._posZ);
            Vector3 localEuler = new Vector3(leftCoordSystem.x + (items[i]._rotX * coef), leftCoordSystem.y - (items[i]._rotY * coef), leftCoordSystem.z + (items[i]._rotZ * coef));
            instance.transform.SetParent(_parent.transform);
            instance.transform.localPosition = _position;
            instance.transform.localEulerAngles = localEuler;
            instance.name = items[i]._name;
            BoxCollider coll = instance.AddComponent<BoxCollider>();
            Rigidbody rigidbody = instance.GetComponent<Rigidbody>();
            if (rigidbody == null) rigidbody = instance.AddComponent<Rigidbody>();
            rigidbody.mass = items[i]._mass;
        }
        _parent.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }
    private void Explosive(Alife_Converter data)
    {
        List<string> parse_data = data.explosive;
        ExplosiveXR[] items = new ExplosiveXR[parse_data.Count];
        for (int i = 0; i < parse_data.Count; i++)
        {
            string[] curentItems = parse_data[i].Split(':');
            items[i] = new ExplosiveXR
            {
                _visual_name = curentItems[0],
                _section_name = curentItems[1],
                _name = curentItems[2],
                _posX = float.Parse(curentItems[3], CultureInfo.InvariantCulture),
                _posY = float.Parse(curentItems[4], CultureInfo.InvariantCulture),
                _posZ = float.Parse(curentItems[5], CultureInfo.InvariantCulture),
                _rotX = float.Parse(curentItems[6], CultureInfo.InvariantCulture),
                _rotY = float.Parse(curentItems[7], CultureInfo.InvariantCulture),
                _rotZ = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _mass = float.Parse(curentItems[8], CultureInfo.InvariantCulture),
                _items = curentItems[9]
            };
        }
        GameObject _parent = new GameObject("LevelExplosive");
        for (int i = 0; i < items.Length; i++)
        {
            GameObject instance = Instantiate(Resources.Load(items[i]._visual_name.Trim(), typeof(GameObject))) as GameObject;
            Vector3 leftCoordSystem = new Vector3(-90f, 180f, 0f);
            Vector3 _position = new Vector3(items[i]._posX, items[i]._posY, items[i]._posZ);
            Vector3 localEuler = new Vector3(leftCoordSystem.x + (items[i]._rotX * coef), leftCoordSystem.y - (items[i]._rotY * coef), leftCoordSystem.z + (items[i]._rotZ * coef));
            instance.transform.SetParent(_parent.transform);
            instance.transform.localPosition = _position;
            instance.transform.localEulerAngles = localEuler;
            instance.name = items[i]._name;
            BoxCollider coll = instance.AddComponent<BoxCollider>();
            Rigidbody rigidbody = instance.GetComponent<Rigidbody>();
            if (rigidbody == null) rigidbody = instance.AddComponent<Rigidbody>();
            rigidbody.mass = items[i]._mass;
        }
        _parent.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
    }
}
