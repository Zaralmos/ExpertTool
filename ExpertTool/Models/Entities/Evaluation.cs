using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    /// <summary>
    /// Представляет обёртку над десятью показателдями при оценивании персоны
    /// </summary>
    public class Evaluation
    {
        [NotMapped]
        public byte[] Values = new byte [10];

        static public PropertyInfo PropertyName(int number)
        {
            PropertyInfo result = null;
            switch (number)
            {
                case 0:
                    result = typeof(Evaluation).GetProperty(nameof(Hypochondriasis));
                    break;
                case 1:
                    result = typeof(Evaluation).GetProperty(nameof(Depression));
                    break;
                case 2:
                    result = typeof(Evaluation).GetProperty(nameof(Hysteria));
                    break;
                case 3:
                    result = typeof(Evaluation).GetProperty(nameof(PsychopathicDeviate));
                    break;
                case 4:
                    result = typeof(Evaluation).GetProperty(nameof(MaculinityFeminity));
                    break;
                case 5:
                    result = typeof(Evaluation).GetProperty(nameof(Paranoia));
                    break;
                case 6:
                    result = typeof(Evaluation).GetProperty(nameof(Psychasthenia));
                    break;
                case 7:
                    result = typeof(Evaluation).GetProperty(nameof(Schizophrenia));
                    break;
                case 8:
                    result = typeof(Evaluation).GetProperty(nameof(Hypomania));
                    break;
                case 9:
                    result = typeof(Evaluation).GetProperty(nameof(SocialInteroversion));
                    break;             
            }
            return result;
        }

        public byte Hypochondriasis
        {
            get => Values[0];
            set => Values[0] = value;
        }

        public byte Depression
        {
            get => Values[1];
            set => Values[1] = value;
        }

        public byte Hysteria
        {
            get => Values[2];
            set => Values[2] = value;
        }

        public byte PsychopathicDeviate
        {
            get => Values[3];
            set => Values[3] = value;
        }

        public byte MaculinityFeminity
        {
            get => Values[4];
            set => Values[4] = value;
        }

        public byte Paranoia
        {
            get => Values[5];
            set => Values[5] = value;
        }

        public byte Psychasthenia
        {
            get => Values[6];
            set => Values[6] = value;
        }

        public byte Schizophrenia
        {
            get => Values[7];
            set => Values[7] = value;
        }

        public byte Hypomania
        {
            get => Values[8];
            set => Values[8] = value;
        }

        public byte SocialInteroversion
        {
            get => Values[9];
            set => Values[9] = value;
        }
    }
}
