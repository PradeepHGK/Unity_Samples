using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{

    public class AddSprite : MonoBehaviour
    {

        private AddSpriteSubClass _addSpriteSubClass;

        private BoxCollider _boxCol;
        private SpriteRenderer _sprRend;
        public Sprite _sprite;
        public float offset;

        private void AddingSprite()
        {
            GameObject spriteRenderer = new GameObject("SpriteLoader");
            //spriteRenderer.transform.SetParent(this.transform);
            var spriteLoader = spriteRenderer.AddComponent<SpriteRenderer>();

            spriteLoader.sprite = _sprite;
            spriteRenderer.transform.rotation = Quaternion.Euler(90, 0, 0);

            var spriteSize = _boxCol.size;

            var maxCollSize = Mathf.Max(_boxCol.size.x, _boxCol.size.z);

            //var maxlocalSize = Mathf.Max(transform.localScale.x, transform.localScale.z);

            var finalSize = (maxCollSize / 4) + offset;

            spriteRenderer.transform.localScale = Vector3.one * finalSize;

        }

        // Start is called before the first frame update
        void Start()
        {
            _boxCol = gameObject.GetComponent<BoxCollider>();
            AddingSprite();

            _addSpriteSubClass.AddingSprite();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }


    public class AddSpriteSubClass : AddSprite
    {
        public AddSpriteSubClass()
        {

        }


    }

}
