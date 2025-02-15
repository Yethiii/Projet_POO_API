namespace Projet_POO_API;

using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;

public class QuizResponse
{
    [JsonPropertyName("results")]
    public List<Question> Results { get; set; }
}

public class Question
{
    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("difficulty")]
    public string Difficulty { get; set; }

    [JsonPropertyName("question")]
    public string Text { get; set; }

    [JsonPropertyName("correct_answer")]
    public string CorrectAnswer { get; set; }

    [JsonPropertyName("incorrect_answers")]
    public List<string> IncorrectAnswers { get; set; }
    
    public string DecodedText => WebUtility.HtmlDecode(Text);
    public string DecodedCorrectAnswer => WebUtility.HtmlDecode(CorrectAnswer);
    public List<string> DecodedIncorrectAnswers => IncorrectAnswers.ConvertAll(WebUtility.HtmlDecode);
}

public class CategoryResponse
{
    [JsonPropertyName("trivia_categories")]
    public List<Categorie> Categories { get; set; }
}

public class Categorie
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}