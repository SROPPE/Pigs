using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Pigs.UI
{
    public class TouchController : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] UnityEvent OnToched;
        public void OnPointerClick(PointerEventData eventData)
        {
            OnToched?.Invoke();
        }
    }
}