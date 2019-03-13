using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GevorderdProgrammerenPracticumWeek5
{
    public class MorseTree
    {
        #region given code

        private char character;
        private MorseTree dot;
        private MorseTree dash;

        public MorseTree AddCharacter(char c, string morsecode)
        {
            c = Char.ToLower(c);
            if (morsecode == "")
                character = c;
            else if (morsecode[0] == '.')
            {
                if (dot == null)
                    dot = new MorseTree();
                dot.AddCharacter(c, morsecode.Remove(0, 1));
            }
            else
            {
                if (dash == null)
                    dash = new MorseTree();
                dash.AddCharacter(c, morsecode.Remove(0, 1));
            }

            return this;
        }

        #endregion

        public char GiveCharacterByMorseCode(string morsecode)
        {
            return morsecode == "" ? character :
                morsecode[0] == '.' ? dot?.GiveCharacterByMorseCode(morsecode.Substring(1)) ?? '?' :
                dash?.GiveCharacterByMorseCode(morsecode.Substring(1)) ?? '?';
        }

        public string GiveMorsecode(char c)
        {
            return GiveMorsecode(char.ToLower(c), "");
        }

        string GiveMorsecode(char c, string code)
        {
            return c == character ? code : $"{dot?.GiveMorsecode(c, code + ".")}{dash?.GiveMorsecode(c, code + "-")}";
        }
    }
}