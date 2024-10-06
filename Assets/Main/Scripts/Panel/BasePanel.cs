using System;
using UniRx;
using UnityEngine;
 

    [RequireComponent(typeof(CanvasGroup))]
    public class BasePanel : MonoBehaviour
    {
        public GameObject Background;
        public GameObject Foreground;
        protected CanvasGroup Canvas { get; private set; }

        [SerializeField] protected bool isOpen;
        protected virtual void Awake()
        {
            Canvas = this.gameObject.GetComponent<CanvasGroup>();
            Init();
        }

        protected virtual void Init()
        {


        }

        /// <summary>
        ///  显示面板
        /// </summary>
        public virtual void Open()
        {
            if (isOpen) return;
            this.gameObject.SetActive(true);
            isOpen = true;
            OnOpen();
        }

        /// <summary>
        /// 隐藏面板
        /// </summary>
        public virtual void Close()
        {
            if (!isOpen) return;
            this.gameObject.SetActive(false);
            isOpen = false;
            OnClose();
        }

        /// <summary>
        /// 在面板显示时调用
        /// </summary>
        protected virtual void OnOpen()
        {

        }

        /// <summary>
        /// 在面板隐藏时调用
        /// </summary>
        protected virtual void OnClose()
        {

        }

        public virtual void ForceOpen()
        {
            this.gameObject.SetActive(true);
            isOpen = true;
        }
        public virtual void ForceClose()
        {
            this.gameObject.SetActive(false);
            isOpen = false;
        }


        private void Start()
        {
            Observer.TestEvnet.Subscribe(Click).AddTo(this);
        }
        private void Click(string obj)
        {
            Debug.Log(obj);
        }

    }

 
