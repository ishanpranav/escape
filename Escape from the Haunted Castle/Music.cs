// Music.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

//namespace haunted_castle
//{
//    class Music
//    {
//        public static bool IsDone = false;
//        public static bool StopBackground = false;
//        private static bool titleNow = true;
//        private static bool backgroundNow = false;

//        public static void PlaySong(string Track)
//        {
//            new Thread(delegate ()
//            {
//                while (true)
//                    if (!StopBackground)
//                        try
//                        {
//                            GetNotesFromFile(FileSystem.root + "MUSIC.NOTE", Track);
//                        }
//                        catch { }
//                    else
//                        break;
//            }).Start();
//        }

//        public static void PlayBackground()
//        {
//            backgroundNow = true;
//            titleNow = false;

//            new Thread(delegate ()
//            {
//                while (true)
//                    if (!StopBackground)
//                        try
//                        {
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "RT_INTRO");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "CUSTOM1_");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "CUSTOM2_");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "CUSTOM3_");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "GERMAN__");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "DANISH__");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "FRENCH__");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "JINGLE__");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "TWINKLE_");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "YNKEEDDL");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "MARYLAMB");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "AULDLANG");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "CAMPTOWN");
//                            GetNotesFromFile(@"Resources\MUSIC.NOTE", "ODETOJOY");
//                        }
//                        catch { }
//            }).Start();
//        }

//        public static void StopIntro()
//        {
//            IsDone = true;
//        }

//        public static void GetNotesFromFile(string filepath, string song)
//        {
//            if (File.Exists(filepath))
//                try
//                {
//                    for (int i = 0; i < File.ReadAllLines(filepath).Length; i++)
//                        if (File.ReadAllLines(filepath)[i].Substring(14, 8) == song)
//                            PlayNotes(File.ReadAllLines(filepath)[i + 1]);
//                }
//                catch { }
//        }

//        public static void PlayNotes(string Notes, int Speed = 500, int Base = 0)
//        {
//            foreach (string Note in Notes.Split(','))
//                if ((titleNow && !IsDone) || (backgroundNow && !StopBackground))
//                {
//                    string[] Fields = Note.Split('-');
//                    int Duration = 0;
//                    int Frequency = 0;

//                    switch (Fields[1].ToLower().Replace("|", ""))
//                    {
//                        case "1":
//                            Duration = Speed;
//                            break;

//                        case "2":
//                            Duration = Speed / 2;
//                            break;

//                        case "2*":
//                            Duration = (Speed / 2) + (Speed / 4);
//                            break;

//                        case "4":
//                            Duration = Speed / 4;
//                            break;

//                        case "4*":
//                            Duration = (Speed / 4) + (Speed / 8);
//                            break;

//                        case "8":
//                            Duration = Speed / 8;
//                            break;

//                        case "16":
//                            Duration = Speed / 16;
//                            break;
//                    }

//                    if (Fields[0].ToLower().Replace("|", "") == "rest")
//                        Thread.Sleep(Duration);
//                    else
//                        switch (Fields[0].ToLower().Replace("|", ""))
//                        {
//                            case "gbelowc":
//                                Frequency = 196;
//                                break;

//                            case "a":
//                                Frequency = 220;
//                                break;

//                            case "a#":
//                                Frequency = 233;
//                                break;

//                            case "b":
//                                Frequency = 247;
//                                break;

//                            case "c":
//                                Frequency = 262;
//                                break;

//                            case "c#":
//                                Frequency = 277;
//                                break;

//                            case "d":
//                                Frequency = 294;
//                                break;

//                            case "d#":
//                                Frequency = 311;
//                                break;

//                            case "e":
//                                Frequency = 330;
//                                break;

//                            case "f":
//                                Frequency = 349;
//                                break;

//                            case "f#":
//                                Frequency = 370;
//                                break;

//                            case "g":
//                                Frequency = 392;
//                                break;

//                            case "g#":
//                                Frequency = 415;
//                                break;
//                        }

//                    Frequency -= Base;
//                    Beep(Frequency, Duration);
//                }
//        }

//        public static void Beep(int Frequency, int Duration)
//        {
//            // Writes frequency and duration to WAV file, then plays.
//            double A = ((100 * (System.Math.Pow(2, 15))) / 1000) - 1;
//            double DeltaFT = 2 * Math.PI * Frequency / 44100.0;

//            int Samples = 441 * Duration / 10;
//            int Bytes = Samples * 4;
//            int[] Hdr = { 0X46464952, 36 + Bytes, 0X45564157, 0X20746D66, 16, 0X20001, 44100, 176400, 0X100004, 0X61746164, Bytes };

//            using (MemoryStream MS = new MemoryStream(44 + Bytes))
//            using (BinaryWriter BW = new BinaryWriter(MS))
//            {
//                for (int I = 0; I < Hdr.Length; I++)
//                    BW.Write(Hdr[I]);

//                for (int T = 0; T < Samples; T++)
//                {
//                    short Sample = System.Convert.ToInt16(A * Math.Sin(DeltaFT * T));
//                    BW.Write(Sample);
//                    BW.Write(Sample);
//                }

//                BW.Flush();
//                MS.Seek(0, SeekOrigin.Begin);

//                using (SoundPlayer SP = new SoundPlayer(MS))
//                    SP.PlaySync();
//            }
//        }
//    }
//}
