namespace haunted_castle
{
    public static class Score
    {
        public static int A1_LightMatch = 2;
        public static int A2_ObtainCandle = 2;
        public static int A_LightCandle = 5;
        public static int B1_ObtainKey = 4;
        public static int B2_ObtainRecipe = 9;
        public static int B3_OpenL = 4;
        public static int C_ReadStrangePurple = 13;
        public static int D_OpenE = 7;
        public static int E_DrinkWater = 7;
        public static int F_LightBars = 7;
        public static int G1_ObtainCrate = 2;
        public static int G2_UseCrate = 7;
        public static int H1_EatApple = 2;
        public static int H2_DropSeeds = 2;
        public static int H4_ObtainBlackberry = 2;
        public static int H5_UseRecipeAsPaper = 2;
        public static int H6_UseBlackberryAsInk = 2;
        public static int H7_UseFeatherAsPen = 2;
        public static int H_OpenDrawbridge = 17;
        public static int J = 4;
        public static int L1_ObtainFlute = 2;
        public static int L2_DropBread = 9;
        public static int M1_OpenCoffin = 2;
        public static int M2_DropBread = 2;
        public static int M3_OpenCase = 4;
        public static int M4_RubLamp = 2;
        public static int M_ObtainRug = 15;
        public static int N_DropGold = 9;
        public static int P1_LightCrate = 2;
        public static int P2_ObtainRope = 2;
        public static int P3_ReadMap = 2;
        public static int P4_RatsEatCheese = 2;
        public static int P5_PlayFlute = 2;
        public static int P6_UseMonocleAsLens = 2;
        public static int P7_UseTelescope = 2;
        public static int P8_ObtainMonocle = 2;
        public static int P_TurnWheel = 21;
        public static int O_Passages = 12;
        public static int T1 = 2, T2 = 2, T3 = 2;
        public static int U1_EatBread = 2;
        public static int V1_DropMonocle = 2;
        public static int V2_DropSilver = 2;
        public static int V_Rainbow = 5;
        public static int U_Jungle = 2;
        public static int U_JungleDone = 36;
        public static int Y_Battle = 20;
        public static int Z_Info = 1;
        public static int W1_Leprechaun = 2;
        public static int W2_UseSpell = 4;
        public static int S_EatCake = 2;
        public static int K_MoatDone = 24;
        public static int X_Dragon = 8;
        public static int X_Tickle = 4;
        public static int Z_Echo = 4;
        public static int Z_Undying = 1;
        public static int Z_FindMe = 1;
        public static int Z_Gesundheit = 4;
        public static int WinAll = 0;

        public static void Addition(int Addition)
        {
            Program.score += Addition;

            if (Program.score > Program.MAXSCORE)
                Program.score = Program.MAXSCORE;
        }
    }
}
