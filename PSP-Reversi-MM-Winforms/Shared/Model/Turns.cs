﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PSP_Reversi_MM_Winforms.Shared.Model
{
    public class Turns : ITurns
    {
        public int currentTurn { get; set; } = 0;
    }
}