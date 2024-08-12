using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.TextToImage;
using SKReactor.Plugins;
using System;

var deployment = "";
var model = "";
var endpoint = "";
var key = "";

var builder = Kernel.CreateBuilder();

builder.Services.AddAzureOpenAIChatCompletion(
    deployment, endpoint, key, model);

#pragma warning disable SKEXP0010
builder.Services.AddAzureOpenAITextToImage("Dalle3", endpoint, key);


builder.Plugins.AddFromType<CityWeatherPlugin>();


var kernel = builder.Build();

/*
var prompt = "Give me a list of 10 cool short names for a software development company.";
var result = await kernel.InvokePromptAsync(prompt);
Console.WriteLine(prompt);
Console.WriteLine(result);

OpenAIPromptExecutionSettings settings =
    new() { MaxTokens = 100, Temperature = 0.7 };
KernelArguments arguments = new(settings);

var prompt2 = "Write a summary about Olympic Games in Modern Era";
var result2 = await kernel.InvokePromptAsync(prompt2, arguments);
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine(prompt2);
Console.WriteLine(result2);

var result2b = kernel.InvokePromptStreamingAsync(prompt2);
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(prompt2);
await foreach (var token in result2b)
{
    Console.Write(token);
}

*/


/*
var prompts = kernel.CreatePluginFromPromptDirectory("Prompts");

var city = "Prague";
var kargs = new KernelArguments() { { "destination", city } };
var activities = await kernel.InvokeAsync(
    prompts["SuggestActivities"], kargs);

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine(city);
Console.WriteLine(activities);


string input = "I want to learn about Semantic Kernel with my friends Pablo and Luis";
string language = "French";
KernelArguments arguments = new() { { "input", input }, { "language", language } };

var response = await kernel.InvokeAsync(prompts["GetTranslation"], arguments);
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(input);
Console.WriteLine($"{response}");


string input2 = "I want to learn about Semantic Kernel with my friends Pablo and Luis";
KernelArguments arguments2 = new() { { "input", input2 }};

var response2 = await kernel.InvokeAsync(prompts["GetTranslation"], arguments2);
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine(input2);
Console.WriteLine($"{response2}");

*/

var city4 = "Prague";
KernelArguments args4 = new() { { "city", city4 } };
var result4 = await kernel.InvokeAsync("CityWeatherPlugin", "GetWeather", args4);

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine(city4);
Console.WriteLine(result4);

OpenAIPromptExecutionSettings settings = new()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};
KernelArguments args5 = new(settings);

var prompt5 = "What are the current weather conditions in Prague and in Mexico City? " +
    "I want to know the temperature in Celsius degrees";
var result5 = await kernel.InvokePromptAsync(prompt5, args5);
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(prompt5);
Console.WriteLine(result5);



var prompt6 = "Is it raining in Guanajuato (in Mexico) or in Rome (in Italy) right now?";
var result6 = await kernel.InvokePromptAsync(prompt6, args5);
Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine(prompt6);
Console.WriteLine(result6);


/*
#pragma warning disable SKEXP0001
var dallE = kernel.GetRequiredService<ITextToImageService>();
var imageDescription = "A 3D fluffy tuxedo cat wearing a tie and a hat";

var imageUrl = await dallE.GenerateImageAsync(imageDescription, 1024, 1024);
Console.WriteLine(imageDescription);
Console.WriteLine(imageUrl);

*/