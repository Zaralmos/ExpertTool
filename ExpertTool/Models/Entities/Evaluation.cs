using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    /// <summary>
    /// Представляет обёртку над десятью показателдями при оценивании персоны
    /// </summary>
    [ComplexType]
    public class Evaluation
    {
        public int Id { get; set; }

        [NotMapped]
        public byte[] Values = new byte [10];

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

        public byte Socialbyteroversion
        {
            get => Values[9];
            set => Values[9] = value;
        }
    }
}
