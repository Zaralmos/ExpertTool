using ExpertTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Views
{
    public static class EvaluationExtensions
    {
        public static Dictionary<string, string> Translation = new Dictionary<string, string>
        {
            { "Hypochondriasis", "Гипохондрия"},
            { "Depression", "Дипрессивность"},
            { "Hysteria", "Истеричность"},
            { "PsychopathicDeviate", "Психопатические отклонения"},
            { "MaculinityFeminity", "Мускулинность-феминность"},
            { "Paranoia", "Паранойя"},
            { "Psychasthenia", "Психастения"},
            { "Schizophrenia", "Шизофрения"},
            { "Hypomania", "Гипомания"},
            { "SocialInteroversion", "Социальность-интроверсия"},
        };

        public static string GetPropertyname(int number)
        {
            return Evaluation.PropertyName(number).Name;
        }

        public static string GetRussianPropertyName(int number)
        {
            return Translation[GetPropertyname(number)];
        }
    }
}
