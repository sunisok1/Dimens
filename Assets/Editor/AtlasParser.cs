using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class AtlasParser
    {
        [MenuItem("Tools/Atlas/ParseAtlas")]
        public static void ParseAtlas()
        {
            var assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);

            if (!assetPath.EndsWith(".atlas"))
            {
                Debug.LogError("Selected file is not an .atlas file.");
                return;
            }

            var directoryName = Path.GetDirectoryName(assetPath);
            Dictionary<string, Texture2D> atlasTextureDict = GetTextureDict(directoryName);

            List<Atlas> atlases = ParseAtlasFile(File.ReadAllText(assetPath));

            foreach (Atlas atlas in atlases)
            {
                if (!atlasTextureDict.TryGetValue(atlas.name, out Texture2D texture)) continue;
                foreach (var sprite in atlas.Sprites)
                {
                    Texture2D tex = new(sprite.w, sprite.h);
                    Color[] pixels = texture.GetPixels(sprite.x, sprite.y, sprite.w, sprite.h);
                    tex.SetPixels(pixels);
                    tex.Apply();
                    var bytes = tex.EncodeToPNG();
                    var path = Path.Combine(directoryName, sprite.name + ".png");
                    // 检查目录是否存在，不存在则创建
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    File.WriteAllBytes(path, bytes);
                    Debug.Log("Saved Sprite: " + path);
                }

                var texturePath = AssetDatabase.GetAssetPath(texture);
                var textureImporter = AssetImporter.GetAtPath(texturePath) as TextureImporter;

                if (textureImporter != null)
                {
                    textureImporter.spriteImportMode = SpriteImportMode.Multiple;

                    textureImporter.spritesheet = atlas.Sprites.Select(sprite => new SpriteMetaData
                    {
                        name = sprite.name,
                        rect = new Rect(sprite.x, sprite.y, sprite.w, sprite.h),
                        pivot = new Vector2(0.5f, 0.5f)
                    }).ToArray();
                    AssetDatabase.ImportAsset(texturePath, ImportAssetOptions.ForceUpdate);
                }
            }
        }

        private static Dictionary<string, Texture2D> GetTextureDict(string directoryPath)
        {
            if (directoryPath == null) return new();
            var paths = Directory.GetFiles(directoryPath, "*.png");
            Dictionary<string, Texture2D> atlasTextureDict = paths.Select(AssetDatabase.LoadAssetAtPath<Texture2D>).ToDictionary(texture2D => texture2D.name);
            return atlasTextureDict;
        }

        private static List<Atlas> ParseAtlasFile(string fileContent)
        {
            var lines = fileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<Atlas> atlases = new();
            var i = 0;
            Atlas atlas = null;
            while (i < lines.Length)
            {
                var name = lines[i].Trim();

                if (name.EndsWith(".png"))
                {
                    if (atlas != null)
                    {
                        atlases.Add(atlas);
                    }

                    var texNameLine = lines[i].Trim();
                    var texName = texNameLine.Split('.')[0];
                    var sizeLine = lines[i + 1];
                    if (!sizeLine.StartsWith("size:")) throw new Exception("Expected 'size:' prefix not found in line");
                    var sizeParts = sizeLine[5..].Split(',');
                    var atlasSize = new Vector2Int(int.Parse(sizeParts[0].Trim()), int.Parse(sizeParts[1].Trim()));
                    atlas = new(atlasSize, texName);
                    i += 5;
                }
                else
                {
                    //Parse x,y
                    var xyLine = lines[i + 2].Trim();
                    if (!xyLine.StartsWith("xy:")) throw new Exception("Expected 'xy:' prefix not found in line.");
                    var xy = xyLine[3..].Split(',');
                    var x = int.Parse(xy[0]);
                    var y = int.Parse(xy[1]);
                    //Parse w,h
                    var whLine = lines[i + 3].Trim();
                    if (!whLine.StartsWith("size:")) throw new Exception("Expected 'size:' prefix not found in line.");
                    var wh = whLine[5..].Split(',');
                    var w = int.Parse(wh[0]);
                    var h = int.Parse(wh[1]);
                    atlas.Add(name, x, y, w, h);
                    i += 7;
                }
            }

            atlases.Add(atlas);

            return atlases;
        }

        private class Atlas
        {
            private Vector2Int size;
            public readonly string name;

            public readonly List<AtlasSprite> Sprites;

            public Atlas(Vector2Int size, string name)
            {
                this.size = size;
                this.name = name;
                Sprites = new List<AtlasSprite>();
            }

            public void Add(string name, int x, int y, int w, int h)
            {
                Sprites.Add(new AtlasSprite(name, x, size.y - y - h, w, h));
            }
        }

        private class AtlasSprite
        {
            public readonly string name;
            public readonly int x;
            public readonly int y;
            public readonly int w;
            public readonly int h;

            public AtlasSprite(string name, int x, int y, int w, int h)
            {
                this.name = name;
                this.x = x;
                this.y = y;
                this.w = w;
                this.h = h;
            }
        }
    }
}