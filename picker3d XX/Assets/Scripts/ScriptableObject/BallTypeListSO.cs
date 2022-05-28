using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BallTypeList")]
public class BallTypeListSO : ScriptableObject
{
    public List<BallTypeSO> ballTypeList;

}
