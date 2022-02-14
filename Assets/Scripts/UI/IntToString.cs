using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class IntToString : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void SetInt(int value)
        {
            _text.text = value.ToString();
        }
    }
}

