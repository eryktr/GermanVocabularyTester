namespace GermanVocabularyTester
{
    public class Word
    {
        public string GermanMeaning { get; private set; }
        public string EnglishMeaning { get; private set; }

        public Word(string german, string english)
        {
            GermanMeaning = german;
            EnglishMeaning = english;

        }

    }

}