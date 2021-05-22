using UnityEngine;
using UnityEngine.UI;

namespace DialogueEditor
{
    public class UIConversationButton2 : MonoBehaviour
    {
        public enum eHoverState
        {
            idleOff,
            animatingOn,
            idleOn,
            animatingOff,
        }

        public enum eButtonType
        {
            Option,
            Speech,
            None
        }

        // Getters
        public eButtonType ButtonType { get { return m_buttonType; } }

        // UI Elements
        [SerializeField] private TMPro.TextMeshProUGUI TextMesh = null;
        [SerializeField] private Image OptionBackgroundImage = null;
        private RectTransform m_rect;

        // Node data
        private eButtonType m_buttonType;
        private ConversationNode m_node;    

        // Hovering 
        private float m_hoverT = 0.0f;
        private eHoverState m_hoverState;
        private bool Hovering { get { return (m_hoverState == eHoverState.animatingOn || m_hoverState == eHoverState.animatingOff); } }
        private Vector3 BigSize { get { return Vector3.one * 1.05f; } }


        //--------------------------------------
        // MonoBehaviour
        //--------------------------------------

        private void Awake()
        {
            m_rect = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (Hovering)
            {
                m_hoverT += Time.deltaTime;
                float normalised = m_hoverT / 0.2f;
                bool done = false;
                if (normalised >= 1)
                {
                    normalised = 1;
                    done = true;
                }
                Vector3 size = Vector3.one;
                float ease = EaseOutQuart(normalised);
                

                switch (m_hoverState)
                {
                    case eHoverState.animatingOn:
                        size = Vector3.Lerp(Vector3.one, BigSize, ease);
                        break;
                    case eHoverState.animatingOff:
                        size = Vector3.Lerp(BigSize, Vector3.one, ease);
                        break;
                }

                m_rect.localScale = size;

                if (done)
                {
                    m_hoverState = (m_hoverState == eHoverState.animatingOn) ? eHoverState.idleOn : eHoverState.idleOff;
                }
            }
        }




        //--------------------------------------
        // Input Events
        //--------------------------------------

        public void OnHover(bool hovering)
        {
            if (!ConversationManager2.Instance2.AllowMouseInteraction) { return; }

            if (hovering)
            {
                ConversationManager2.Instance2.AlertHover(this);
            }
            else
            {
                ConversationManager2.Instance2.AlertHover(null);
            }
        }

        public void OnClick()
        {
            if (!ConversationManager2.Instance2.AllowMouseInteraction) { return; }

            switch (m_buttonType)
            {
                case eButtonType.Speech:
                    ConversationManager2.Instance2.SpeechSelected(m_node as SpeechNode);
                    break;

                case eButtonType.Option:
                    ConversationManager2.Instance2.OptionSelected(m_node as OptionNode);
                    break;

                case eButtonType.None:
                    ConversationManager2.Instance2.EndButtonSelected();
                    break;
            }
        }




        //--------------------------------------
        // Public calls
        //--------------------------------------

        public void SetHovering(bool selected)
        {
            if (selected && (m_hoverState == eHoverState.animatingOn || m_hoverState == eHoverState.idleOn)) { return; }
            if (!selected && (m_hoverState == eHoverState.animatingOff || m_hoverState == eHoverState.idleOff)) { return; }

            if (selected)
                m_hoverState = eHoverState.animatingOn;
            else
                m_hoverState = eHoverState.animatingOff;
            m_hoverT = 0f;
        }

        public void SetImage(Sprite sprite, bool sliced)
        {
            if (sprite != null)
            {
                OptionBackgroundImage.sprite = sprite;

                if (sliced)
                    OptionBackgroundImage.type = Image.Type.Sliced;
                else
                    OptionBackgroundImage.type = Image.Type.Simple;
            }
        }

        public void InitButton(OptionNode option)
        {
            // Set font
            if (option.TMPFont != null)
            {
                TextMesh.font = option.TMPFont;
            }
            else
            {
                TextMesh.font = null;
            }
        }

        public void SetAlpha(float a)
        {
            Color c_image = OptionBackgroundImage.color;
            Color c_text = TextMesh.color;
            c_image.a = a;
            c_text.a = a;
            OptionBackgroundImage.color = c_image;
            TextMesh.color = c_text;
        }

        public void SetupButton(eButtonType buttonType, ConversationNode node)
        {
            m_buttonType = buttonType;
            m_node = node;

            switch (m_buttonType)
            {
                case eButtonType.Option:
                    TextMesh.text = node.Text;
                    break;

                case eButtonType.Speech:
                    TextMesh.text = "Continue.";
                    break;

                case eButtonType.None:
                    TextMesh.text = "End.";
                    break;
            }
        }




        //--------------------------------------
        // Util
        //--------------------------------------

        private static float EaseOutQuart(float normalized)
        {
            return (1 - Mathf.Pow(1 - normalized, 4));
        }
    }
}