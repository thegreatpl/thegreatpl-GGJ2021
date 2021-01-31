using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class AssetImporter : MonoBehaviour
{
    [MenuItem("AssetImport/LoadAnimations")]
    public static void LoadAnimations()
    {
        // var path = AssetDatabase.GetAssetPath()


        using (var gameController = new PrefabUtility.EditPrefabContentsScope("Assets/Prefabs/GameController.prefab"))
        {
            var animations = new List<AnimationLayerObj>();

            //load the human sprites
            var directories = Directory.GetDirectories("Assets/Resources/Sprites/Humanoid");
            foreach (var direct in directories)
            {
                var files = Directory.GetFiles(direct)
                    .Where(x => new string[] { ".png", ".jpg" }.Contains(Path.GetExtension(x))).ToList();

                foreach (var file in files)
                {
                    Debug.Log(file);
                    var name = Path.GetFileNameWithoutExtension(file);
                    var animationObj = new AnimationLayerObj()
                    {
                        layer = Path.GetFileName(direct),
                        Name = name,
                        Animations = GenerateAnimations($"Assets/Resources/Sprites/Humanoid/{Path.GetFileName(direct)}/{Path.GetFileName(file)}")
                    };


                    animations.Add(animationObj); 
                }
            }

            //load the CHICKENS!
            animations.Add(LoadChickens()); 



            var gamemanager = gameController.prefabContentsRoot.GetComponent<GameManager>();

            gamemanager.animationLayers = animations; 
        }
    }


    static List<AnimationObj> GenerateAnimations(string filename)
    {
        List<AnimationObj> animationObjs = new List<AnimationObj>();

        var sprites = AssetDatabase.LoadAllAssetsAtPath(filename).Where(x => x is Sprite).Cast<Sprite>().ToList();

        var name = Path.GetFileNameWithoutExtension(filename); 

        animationObjs.Add(new AnimationObj()
        {
            Name = "idleleft",
            Sprites = new Sprite[] { sprites.FirstOrDefault(x =>x.name == $"{name}_69") }
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "idleright",
            Sprites = new Sprite[] { sprites.FirstOrDefault(x => x.name == $"{name}_87") }
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "idleup",
            Sprites = new Sprite[] { sprites.FirstOrDefault(x => x.name == $"{name}_60")  }
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "idledown",
            Sprites = new Sprite[] { sprites.FirstOrDefault(x => x.name == $"{name}_78")  }
        });

        animationObjs.Add(new AnimationObj()
        {
            Name = "walkleft",
            Sprites = GetWalkAnimation(sprites, name, 69)
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "walkright",
            Sprites = GetWalkAnimation(sprites, name, 87) 
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "walkup",
            Sprites = GetWalkAnimation(sprites, name, 60)
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "walkdown",
            Sprites = GetWalkAnimation(sprites, name, 78)
        });


        animationObjs.Add(new AnimationObj()
        {
            Name = "Death",
            Sprites = GetWalkAnimation(sprites, name, 172, 5)
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "Dead",
            Sprites = new Sprite[] { sprites.FirstOrDefault(x => x.name == $"{name}_177") }
        });

        return animationObjs;
    }


    static AnimationLayerObj LoadChickens()
    {
        var animationObj = new AnimationLayerObj()
        {
            Name = "Chicken",
            layer = "Chicken",
            
        };
        var sprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Resources/Sprites/Chickens/chicken_walk.png").Where(x => x is Sprite).Cast<Sprite>().ToList();
        var animationObjs = new List<AnimationObj>();

        string name = "chicken_walk"; 
        animationObjs.Add(new AnimationObj()
        {
            Name = "idleleft",
            Sprites = new Sprite[] { sprites.FirstOrDefault(x => x.name == $"{name}_4") }
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "idleright",
            Sprites = new Sprite[] { sprites.FirstOrDefault(x => x.name == $"{name}_12") }
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "idleup",
            Sprites = new Sprite[] { sprites.FirstOrDefault(x => x.name == $"{name}_0") }
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "idledown",
            Sprites = new Sprite[] { sprites.FirstOrDefault(x => x.name == $"{name}_8") }
        });

        animationObjs.Add(new AnimationObj()
        {
            Name = "walkleft",
            Sprites = GetWalkAnimation(sprites, name, 4, 4)
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "walkright",
            Sprites = GetWalkAnimation(sprites, name, 12, 4)
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "walkup",
            Sprites = GetWalkAnimation(sprites, name, 0, 4)
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "walkdown",
            Sprites = GetWalkAnimation(sprites, name, 8, 4)
        });



        var attksprites = AssetDatabase.LoadAllAssetsAtPath("Assets/Resources/Sprites/Chickens/chicken_eat.png").Where(x => x is Sprite).Cast<Sprite>().ToList();

        animationObjs.Add(new AnimationObj()
        {
            Name = "attackup",
            Sprites = ChickenAttackSprite(attksprites, "chicken_eat", 0)
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "attackleft",
            Sprites = ChickenAttackSprite(attksprites, "chicken_eat", 4)
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "attackdown",
            Sprites = ChickenAttackSprite(attksprites, "chicken_eat", 8)
        });
        animationObjs.Add(new AnimationObj()
        {
            Name = "attackright",
            Sprites = ChickenAttackSprite(attksprites, "chicken_eat", 12)
        });


        animationObj.Animations = animationObjs; 

        return animationObj; 
    }

    static Sprite[] GetWalkAnimation(List<Sprite> sprites, string name, int startno, int total = 9)
    {
        List<Sprite> spriteret = new List<Sprite>();
        for (int idx = startno; idx < startno + total; idx++)
        {
            spriteret.Add(sprites.FirstOrDefault(x => x.name == $"{name}_{idx}")); 
        }
        return spriteret.ToArray(); 
    }


    static Sprite[] ChickenAttackSprite(List<Sprite> sprites, string name, int startno)
    {
        var retval = new Sprite[5];

        retval[0] = sprites.FirstOrDefault(x => x.name == $"{name}_{startno}");
        retval[1] = sprites.FirstOrDefault(x => x.name == $"{name}_{startno + 1}");
        retval[2] = sprites.FirstOrDefault(x => x.name == $"{name}_{startno + 1}");
        retval[3] = sprites.FirstOrDefault(x => x.name == $"{name}_{startno + 1}");
        retval[4] = sprites.FirstOrDefault(x => x.name == $"{name}_{startno}");


        return retval; 
    }


    [MenuItem("AssetImport/LoadSounds")]
    public static void LoadSoundFX()
    {
        using (var gameController = new PrefabUtility.EditPrefabContentsScope("Assets/Prefabs/Main Camera.prefab"))
        {
            var sounds = new List<MusicObj>(); 

            foreach(var file in Directory.GetFiles("Assets/Sounds/Effects"))
            {
                if (!(new string[] { ".mp3", ".wav" }.Contains(Path.GetExtension(file))))
                    continue;
                
                var sound = new MusicObj(); 
                sound.Name = Path.GetFileNameWithoutExtension(file);

                var clip = AssetDatabase.LoadAllAssetsAtPath($"Assets/Sounds/Effects/{ Path.GetFileName(file)}").Cast<AudioClip>(); 

                var tags = new List<string>();
                if (sound.Name.Contains("message sound"))
                    tags.Add("message");
                if (sound.Name.Contains("find egg"))
                    tags.Add("find_egg");
                if (sound.Name.Contains("voices"))
                    tags.Add("voices");
                if (sound.Name.Contains("Pecked"))
                    tags.Add("pecked");
                if (sound.Name.Contains("footstep"))
                    tags.Add("footsteps");
                if (sound.Name.Contains("chicken calls"))
                    tags.Add("chickencall");
                if (sound.Name.Contains("Boss damage"))
                    tags.Add("bossdamage");
                if (sound.Name.Contains("chicken disintergrate"))
                    tags.Add("chickendeath"); 


                sound.AudioClip = clip.FirstOrDefault(x => true); 

                sound.Tags = tags.ToArray();

                sounds.Add(sound); 

            }





            var soundsfx = gameController.prefabContentsRoot.GetComponentInChildren<SoundEffectPlayerScript>();
            //var union = soundsfx.SoundEffects.Select(x => new { x.Name }).Union(sounds.Select(x => new { x.Name }));
            soundsfx.SoundEffects = sounds; 
        }
    }
}
