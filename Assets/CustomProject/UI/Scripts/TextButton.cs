using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace CustomProject.UI
{
    public class TextButton : Button
    {
        #region Properties

        public Action<string> OnClick;
        public string InitialText { get; set; }

        #endregion

        #region Fields

        private TMP_Text _text;

        #endregion

        #region Unity Callbacks

        protected override void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();
            onClick.AddListener(ButtonClicked);
        }

        protected override void OnDestroy()
        {
            onClick.RemoveListener(ButtonClicked);
        }

        #endregion

        #region Callbacks

        private void ButtonClicked()
        {
            OnClick?.Invoke(_text.text);
        }
        #endregion
        #region Public Methods

        public void SetText(string newText)
        {
            _text.text = newText;
        }
        public string GetText()
        {
            return _text.text;
        }
        #endregion
    }
}
