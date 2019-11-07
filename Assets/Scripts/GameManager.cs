using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Mapa działa! Brawo!
namespace SA
{

    public class GameManager : MonoBehaviour
    {
        public int maxHeigt = 15;
        public int maxWidth = 17;
        public Color color1;
        public Color color2;

        GameObject mapObject;
        SpriteRenderer mapRender;
        private void Start()
        {
            CreateMap();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void CreateMap()
        {
            mapObject = new GameObject("Map");
            mapRender = mapObject.AddComponent<SpriteRenderer>();
            Texture2D txt = new Texture2D(maxWidth, maxHeigt); // Stworzenie naszej mapy gry o maksymalnych rozmiarach

            // Tworzenie mapy siatki 
            for (int x = 0; x < maxWidth; x++)
            {
                for (int y = 0; y < maxHeigt; y++)
                {
                    if (x % 2 != 0)
                    {
                        if (y % 2 != 0)
                        {
                            txt.SetPixel(x, y, color1);
                        }
                        else
                        {
                            txt.SetPixel(x, y, color2);
                        }

                    }
                    else
                    {
                        if (y % 2 != 0)
                        {
                            txt.SetPixel(x, y, color2);
                        }
                        else
                        {
                            txt.SetPixel(x, y, color1);
                        }
                    }

                }
            }
            txt.filterMode = FilterMode.Point;
            txt.Apply();
            Rect rect = new Rect(0, 0, maxWidth, maxHeigt);
            Sprite sprite = Sprite.Create(txt, rect, Vector2.one * .5f, 1, 0, SpriteMeshType.FullRect);
            mapRender.sprite = sprite;
        }
    }

}
// Tworzenie mapy