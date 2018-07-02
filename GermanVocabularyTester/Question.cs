using System;

namespace GermanVocabularyTester
{
    public class Question
    {
        public Word QuestionWord { get; private set; }
        public int Score { get; private set; }

        public Question(Word w, int s)
        {
            QuestionWord = w;
            Score = s;
        }

        public void Display()
        {
            Console.WriteLine($"{QuestionWord.GermanMeaning} - {QuestionWord.EnglishMeaning}");
        }

        public void processQuestion(string answer)
        {
            if (CorrectAnswer(answer))
            {
                Score++;
                Console.WriteLine("Correct!");
            }
            else
            {
                if (Score > 0)
                {
                    Score--;
                }
                Console.WriteLine("Incorect answer.");
            }
        }

        public bool CorrectAnswer(string answer)
        {
            return answer == QuestionWord.GermanMeaning;
        }
    }
}