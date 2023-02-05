#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#if WINDOWS_PHONE
using Microsoft.Xna.Framework.Input.Touch;
#endif
using Microsoft.Xna.Framework.Media;
#endregion

namespace TopDownShooter
{
    public class SoundControl
    {
        public float volume;
        public SoundEffect sound;
        public SoundEffectInstance instance;

        public SoundControl(string MUSICPATH) 
        {
            sound = null;
            instance = null;
            
            if(MUSICPATH != "")
            {
                ChangeMusic(MUSICPATH);
            }
        }

        public virtual void AdjustVolume(float PERCENT)
        {
            if(instance != null)
            {
                instance.Volume = PERCENT * volume;
            }
        }

        public virtual void ChangeMusic(string MUSICPATH)
        {
            sound = Globals.content.Load<SoundEffect>(MUSICPATH);
            instance = sound.CreateInstance();
            volume = .25f;

            FormOption musicVolume = Globals.optionsMenu.GetOptionValue("Music Volume");
            float musicVolumePercent = 1.0f;
            if(musicVolumePercent != null)
            {
                musicVolumePercent = (float)Convert.ToDecimal(musicVolume.value, Globals.culture) / 30.0f;
            }

            AdjustVolume(musicVolumePercent);
            instance.IsLooped= true;
            instance.Play();
        }



    }
}
