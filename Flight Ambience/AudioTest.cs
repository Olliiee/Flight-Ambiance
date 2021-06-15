using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Un4seen.Bass.AddOn.Fx;
using Un4seen.Bass;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NLog.Filters;
using Org.Strausshome.FS.CrewSoundsNG.Repositories;
using System.IO;

namespace Org.Strausshome.FS.CrewSoundsNG
{
    public partial class AudioTest : Form
    {
        private int audioChannel = 1;
        private int filter = 5;

        public AudioTest()
        {
            InitializeComponent();

            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Handle);
            BassFx.LoadMe();
            BassFx.BASS_FX_GetVersion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string audioFile = @"Profiles\Default\cabin_ger_eng.ogg";

            if (System.IO.File.Exists(audioFile))
            {
                audioChannel = 1;
                if (Bass.BASS_ChannelIsActive(audioChannel) == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    Bass.BASS_ChannelSlideAttribute(0, BASSAttribute.BASS_ATTRIB_VOL, 0f, 1000);
                }

                audioChannel = Bass.BASS_StreamCreateFile($@"{Directory.GetCurrentDirectory()}\{audioFile}", 0L, 0L, BASSFlag.BASS_MUSIC_AUTOFREE);

                Bass.BASS_ChannelSetAttribute(audioChannel, BASSAttribute.BASS_ATTRIB_VOL, 0.4f);

                Bass.BASS_ChannelPlay(audioChannel, false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filter = Bass.BASS_ChannelSetFX(audioChannel, BASSFXType.BASS_FX_BFX_BQF, 0);

            BASS_BFX_BQF filterSettings = new();
            filterSettings.lFilter = BASSBFXBQF.BASS_BFX_BQF_LOWPASS;
            filterSettings.fCenter = 600f;
            filterSettings.fGain = -15f;
            filterSettings.lChannel = BASSFXChan.BASS_BFX_CHANALL;

            var result = Bass.BASS_FXSetParameters(filter, filterSettings);
            if (!result)
            {
                MessageBox.Show($"BASS Error {Bass.BASS_ErrorGetCode()}");
            }

            //filterSettings = new();
            //filterSettings.lFilter = BASSBFXBQF.BASS_BFX_BQF_HIGHPASS;
            //filterSettings.fCenter = 1000f;
            //filterSettings.fGain = -15f;
            //filterSettings.lChannel = BASSFXChan.BASS_BFX_CHANALL;

            //result = Bass.BASS_FXSetParameters(filter, filterSettings);
            //if (!result)
            //{
            //    MessageBox.Show($"BASS Error {Bass.BASS_ErrorGetCode()}");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var test = Bass.BASS_ChannelGetPosition(audioChannel);
            if (test == -1)
            {
                MessageBox.Show($"BASS Error {Bass.BASS_ErrorGetCode()}");
            }

            string audioFile = @"Profiles\Default\cabin_ger_eng.ogg";
            Bass.BASS_ChannelStop(audioChannel);

            //var result = Bass.BASS_FXReset(filter);
            //if (!result)
            //{
            //    MessageBox.Show($"BASS Error {Bass.BASS_ErrorGetCode()}");
            //}

            audioChannel = Bass.BASS_StreamCreateFile($@"{Directory.GetCurrentDirectory()}\{audioFile}", 0L, 0L, BASSFlag.BASS_MUSIC_AUTOFREE);

            Bass.BASS_ChannelSetAttribute(audioChannel, BASSAttribute.BASS_ATTRIB_VOL, 0.4f);

            Bass.BASS_ChannelPlay(audioChannel, false);

            var result = Bass.BASS_ChannelSetPosition(audioChannel, test);
            if (!result)
            {
                MessageBox.Show($"BASS Error {Bass.BASS_ErrorGetCode()}");
            }
        }
    }
}