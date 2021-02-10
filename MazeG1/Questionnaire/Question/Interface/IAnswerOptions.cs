namespace Questionnaire.Question
{
    public interface IAnswerOptions
    {
        string Text { get; set; }

        bool IsValid();
    }
}