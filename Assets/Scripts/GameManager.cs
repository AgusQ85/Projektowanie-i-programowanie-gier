using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// git
namespace SA
{

    public class GameManager : MonoBehaviour
    {
        public int maxHeigt = 15;
        public int maxWidth = 17;
        public Color color1;
        public Color color2;
        public Color playerColor = Color.black;

        GameObject playerObj;
        

        GameObject mapObject;
        SpriteRenderer mapRender;

        Node[,] grid;
        private void Start()
        {
            CreateMap();
            PlacePlayer();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void CreateMap()
        {
            grid = new Node[maxWidth, maxHeigt];
            mapObject = new GameObject("Map");
            mapRender = mapObject.AddComponent<SpriteRenderer>();
            Texture2D txt = new Texture2D(maxWidth, maxHeigt); // Stworzenie naszej mapy gry o maksymalnych rozmiarach

            // Tworzenie mapy siatki 
            for (int x = 0; x < maxWidth; x++)
            {

                
                
                for (int y = 0; y < maxHeigt; y++)
                {
                    Vector3 tp = Vector3.zero;
                    tp.x = x;
                    tp.y = y;
                    Node n = new Node()
                    {

                        x = x,
                        y = y,
                        worldPosition = tp

                    };
                    grid[x, y] = n;
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
        void PlacePlayer()
        {
            playerObj = new GameObject("Player");
            SpriteRenderer playerRender = playerObj.AddComponent<SpriteRenderer>();
            playerRender.sprite = createSprite(playerColor);
            playerRender.sortingOrder = 1;
            playerObj.transform.position = GetNode(3, 3).worldPosition;
        }

        Node GetNode(int x, int y)
        {
            if (x < 0 || x > maxWidth - 1 || y < 0 || y > maxHeigt - 1)
                return null; 
            return grid[x, y];
        }
       Sprite createSprite(Color targetColor)
        {
            Texture2D txt = new Texture2D(1, 1);
            txt.SetPixel(0,0, targetColor);

            txt.filterMode = FilterMode.Point;
            Rect rect = new Rect(0, 0, 1, 1);
             return Sprite.Create(txt, rect, Vector2.one * .5f, 1, 0, SpriteMeshType.FullRect);
            
        }
    }

}
// Tworzenie mapy