using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GermanVocabularyTester
{
    class Program
    {
        private static string WordsFileName = @"../../Words.txt";
        private static List<Question> questions;

        private static void Main(string[] args)
        {
            questions = GetQuestions();
            AddQuestion();
        }

        public static List<Question> GetQuestions()
        {
            using (StreamReader sr = new StreamReader(WordsFileName))
            {
                var questions = new List<Question>();
                string input;
                while ((input = sr.ReadLine()) != null)
                {
                    var parametrizedQuestion = input.Split(':');
                    var germanMeaning = parametrizedQuestion[0];
                    var englishMeaning = parametrizedQuestion[1];
                    int score = int.Parse(parametrizedQuestion[2]);
                    questions.Add(new Question(new Word(germanMeaning, englishMeaning), score));
                }

                return questions;
            }
        }

        public static Question nextQuestion()
        {
            if (questions == null) throw new NoNullAllowedException("No questions left!");
            var tmp = questions.First();
            questions.RemoveAt(0);
            return tmp;
        }

        public static void AddQuestion()
        {
            Console.WriteLine("Insert the German word: ");
            var german = Console.ReadLine();
            Console.WriteLine("Insert the English translation: ");
            var english = Console.ReadLine();
            string line = $"{german}:{english}:0" + Environment.NewLine;
            File.AppendAllText(WordsFileName, line);
        }
    }
}