using UnityEngine;
using UnityEngine.EventSystems;

 
    public class NavigateButton : MonoBehaviour, IPointerClickHandler
    {
        public void ChooseThis()
        {
            foreach (var item in transform.parent.GetComponentsInChildren<NavigateButton>())
            {
                if (item == this)
                {
                    item.OnChoose();
                }
                else
                {
                    item.OnLose();
                }
            }
        }
        public GameObject loseShow;
        public GameObject chooseShow;
        public BasePanel targetPage;
        protected void OnChoose()
        {
            chooseShow.SetActive(true);
            loseShow.SetActive(false);
            targetPage?.Open();
        }
        protected virtual void OnLose()
        {
            chooseShow.SetActive(false);
            loseShow.SetActive(true);
            targetPage?.Close();
        }
        public bool isStartChoose = false;

        private void Start()
        {
            if (isStartChoose)
            {
                ChooseThis();
            }

        }


        public void OnPointerClick(PointerEventData eventData)
        {
            ChooseThis();
        }
    }

 

