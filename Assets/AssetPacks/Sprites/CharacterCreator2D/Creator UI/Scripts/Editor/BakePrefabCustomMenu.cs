using System;
using System.Collections.Generic;
using System.IO;
using CharacterCreator2D;
using CharacterCreator2D.UI;
using CharacterCreator2D.Utilities;
using CharacterCreator2D.Utilities.Humanoid;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;
using Object = UnityEngine.Object;

namespace CharacterEditor2D.UI
{
    public static class BakePrefabCustomMenu
    {
        [InitializeOnLoadMethod]
        private static void SetEvent()
        {
            UICreator.onBakeCharacterAsPrefab = BakeAsPrefab;
        }

        private static void BakeAsPrefab()
        {
            if (!EditorApplication.isPlaying) return;
            var cvs = Object.FindObjectsOfType<CharacterViewer>();
            if (cvs != null && cvs.Length > 0)
            {
                foreach (var character in cvs)
                {
                    switch (character.bodyType)
                    {
                        case BodyType.Male:
                        case BodyType.Female:
                            break;
                        default:
                            EditorUtility.DisplayDialog("Bake Information",
                                "Only support Male and Female body type only.", "Ok");
                            continue;
                    }

                    var path = CharacterUtils.ShowSaveFileDialog("Save Character", "Baked Character", "prefab", true);
                    if (!string.IsNullOrEmpty(path))
                    {
                        var fileName = Path.GetFileNameWithoutExtension(path);
                        var folderPath = path.Remove(path.LastIndexOf(fileName) - 1);
                        var tcharacter = Object.Instantiate(character);
                        tcharacter.Unbake();
                        var charGO = tcharacter.gameObject;
                        charGO.name = fileName;
                        ExtractTexture(tcharacter, folderPath + "/" + fileName + "_Textures");
                        ExtractMaterial(tcharacter, folderPath + "/" + fileName + "_Materials");
                        Object.DestroyImmediate(tcharacter);
                        Selection.activeObject = PrefabUtility.SaveAsPrefabAsset(charGO, path);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                        Object.DestroyImmediate(charGO);
                    }
                }

                Resources.UnloadUnusedAssets();
            }
        }

        private static void ExtractTexture(CharacterViewer character, string path)
        {
            try
            {
                if (EditorUtils.MakeSureAssetFolderExist(path))
                {
                    var textureAtlases = new List<Object>();
                    var bakedTexturePaths = new List<(SlotCategory, string)>();
                    var categories = Enum.GetValues(typeof(SlotCategory)) as SlotCategory[];
                    for (var i = 0; i < categories.Length; i++)
                    {
                        var category = categories[i];
                        if (category == SlotCategory.SkinDetails) continue;
                        var filePath = path + "/" + character.gameObject.name + "_" + category + ".png";
                        EditorUtility.DisplayProgressBar("Render Texture", filePath.Remove(0, 7),
                            (float)(i + 1) / categories.Length);
                        var targetTexture =
                            HumanoidSlotRenderer.RenderToTexture2D(character, category, TextureFormat.RGBAFloat, false);
                        if (targetTexture)
                        {
                            var png = targetTexture.EncodeToPNG();
                            Object.DestroyImmediate(targetTexture);
                            var textur = AssetDatabase.LoadAssetAtPath<Texture>(filePath);
                            if (textur) AssetDatabase.DeleteAsset(filePath);
                            File.WriteAllBytes(filePath, png);
                            bakedTexturePaths.Add((category, filePath));
                        }
                    }

                    AssetDatabase.Refresh();
                    for (var i = 0; i < bakedTexturePaths.Count; i++)
                    {
                        var texturePath = bakedTexturePaths[i];
                        EditorUtility.DisplayProgressBar("Slice Sprites", texturePath.Item1.ToString(),
                            (float)(i + 1) / bakedTexturePaths.Count);
                        AssignToRenderer(character, texturePath.Item1, texturePath.Item2);
                        if (texturePath.Item1 != SlotCategory.Cape && texturePath.Item1 != SlotCategory.Skirt)
                            textureAtlases.Add(AssetDatabase.LoadAssetAtPath<Texture2D>(texturePath.Item2));
                    }

                    /////////// atlas ////////////////
                    var atlasPath = path + "/" + character.gameObject.name + "_Atlas.spriteatlas";
                    var spriteAtlas = new SpriteAtlas();
                    spriteAtlas.Add(textureAtlases.ToArray());
                    AssetDatabase.CreateAsset(spriteAtlas, atlasPath);
                    //////////////////////////////////
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }
        }

        private static void AssignToRenderer(CharacterViewer character, SlotCategory category, string targetTexPath)
        {
            var partSlot = character.slots.GetSlot(category);
            var sprites = SpriteSlicerUtils.SliceSprite(AssetDatabase.GetAssetPath(partSlot.assignedPart.texture),
                targetTexPath);
            var texture = AssetDatabase.LoadAssetAtPath<Texture2D>(targetTexPath);
            var charTrans = character.transform;

            switch (category)
            {
                case SlotCategory.Cape:
                case SlotCategory.Skirt:
                    charTrans.AssignClothTexture(category, texture, false);
                    break;
                case SlotCategory.MainHand:
                case SlotCategory.OffHand:
                    charTrans.AssignWeaponSprites(category, (partSlot.assignedPart as Weapon).weaponCategory, sprites);
                    break;
                default:
                    if (SetupData.partLinks.TryGetValue(category, out var links))
                        charTrans.AssignSprites(links, sprites);
                    break;
            }
        }

        private static void ExtractMaterial(CharacterViewer character, string path)
        {
            if (EditorUtils.MakeSureAssetFolderExist(path))
            {
                var shader = Shader.Find("Sprites/Default");

                //material for SpriteRenderer
                var spriteMaterial = new Material(shader);
                var filePath = path + "/" + character.gameObject.name;
                foreach (var spriteRenderer in character.GetComponentsInChildren<SpriteRenderer>(true))
                {
                    spriteRenderer.color = Color.white;
                    spriteRenderer.sharedMaterial = spriteMaterial;
                }

                AssetDatabase.CreateAsset(spriteMaterial, filePath + "_Sprite.mat");

                //material for SkinnedMeshRenderer
                SkinnedMeshRenderer renderer;
                Texture tempTexture;
                if (character.transform.GetRenderer(SetupData.capeLink, out renderer) &&
                    renderer.gameObject.activeInHierarchy)
                {
                    tempTexture = renderer.sharedMaterial.mainTexture;
                    var capeMaterial = new Material(shader);
                    capeMaterial.mainTexture = tempTexture;
                    renderer.sharedMaterial = capeMaterial;
                    AssetDatabase.CreateAsset(capeMaterial, filePath + "_Cape.mat");
                }

                if (character.transform.GetRenderer(SetupData.skirtLink, out renderer) &&
                    renderer.gameObject.activeInHierarchy)
                {
                    tempTexture = renderer.sharedMaterial.mainTexture;
                    var skirtMaterial = new Material(shader);
                    skirtMaterial.mainTexture = tempTexture;
                    renderer.sharedMaterial = skirtMaterial;
                    AssetDatabase.CreateAsset(skirtMaterial, filePath + "_Skirt.mat");
                }
            }
        }
    }
}