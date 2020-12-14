
>This is a more thorough full-stack task, we think it might take you somewhere between 6 and 12 hours, depending on your skillset and efforts. 
>So it is OK if it takes two weeks, as we're sure you have only limited time besides work. 
> 
>Also please note that the task should be solved within 2 weeks max (considering christmas ***until 01.01***), to keep it fair among all applicants.
>If you need more time because of your workload or the holidays please let us know upfront.
> 
>Please note that we prefer quality over speed for the test task. The solution should be simple, but production-ready. 
> In other words, we prefer a solution that is not too simple, but also not overly complex.
Your task, should you choose to accept it, is to create a small web frontend.

>On a simple web page, display a forecast of the next 5 days and the current weather data for any/most German cities. 
Users should have the ability to look for the weather forecast by providing a place name or zip code.
The Javascript shouldn't query external weather data providers directly, but instead query your own .NET Core JSON endpoint, which in turn should query OpenWeathermap. If you need an API key to authenticate, use the following: fcadd28326c90c3262054e0e6ca599cd
There are many methods on OpenWeathermap, please concentrate on the following scenario:
•	create API endpoint(s) for retrieving the forecast by city or zipCode. a suggestion would be GET /api/weather/forecast?city=[cityName] and /api/weather/forecast?zipCode=[cityName]  
•	those should return your own json payload (not just a mirror/passthrough of the OpenWeather JSON payload) containing the following data: average temperature and humidity per day build from the multiple values that are returned by the original api, beginning with today and next 5 days, at least containing temperature, humidity and wind speed
•	make sure your returned json is refactoring-resilient, meaning a change to the model class property names shouldn't break the API
In the frontend the application should be as responsive as possible - CSS frameworks like e.g. Bootstrap could be used, custom CSS though is encouraged, whatever looks better. When displaying the data, feel free: table, graph, map, any available data visualization skills should be applied. If you have the skills, use them, it's a valuable thing to show off. If not, it's not a negative point. Just use the best you got.
It is also your task to persist the current weather data each time a user queries weather data of a city in the browser. It is sufficient if you save the name of the city, the temperature and humidity. That should then appear in a separate "history" list in the UI.
Visual quality: here, too, your own skills should be fully realized in terms of CSS, a visually appealing presentation (using just a CSS framework is fine) is a plus.

>Please use Vue.js for the frontend, because it's our stack, 
> it's easy to get started via the new Vue CLI 3 or 4 (not 2!), 
> use npm install @vue/cli -g to install the right one, 
> see https://cli.vuejs.org/guide/creating-a-project.html to create your first project with this CLI with vue create 
> ***(NOT the deprecated vue init)***. 
> We will reject solutions that are generated with vue init or Vue CLI 2..
>We highly recommend using VS Code 
> and the official Vetur extension for a productive experience with Vue single file components 
> (https://vuejs.org/v2/guide/single-file-components.html). 
> But any IDE/editor that supports .vue files and code completion is fine.
On the backend side please use ASP.NET Core (use version v3.1 or the new .NET 5), 
> as this is the stack we use for every new project. 
> It is fine to create two separate folders for the vue.js frontend and the ASP.Net Core back-end, 
> it doesn't have to be in one solution. 
> You should get the latest .NET Core SDK from https://dotnet.microsoft.com/download . 
> Again we recommend VS Code and the C# extension, or JetBrains Rider (you can install a trial) if you are on non-Windows,
> otherwise Visual Studio (Community Edition is free for personal use) is the obvious choice. 
> You should start creating the backend code via dotnet new webapi . 
> Please don't start from a community template or some finished blog post code and only change 2 lines, 
> we want to see your code, or at least you integrating code from different sources.

In the end, please strip your solution of the node_modules and .NET Core packages folders (and any binary output), it should be able to restore packages from scratch just fine (npm install /dotnet run). Either provide us with a Github repo, or .zip (not .rar) the solution and send us a public link, as Gmail blocks attachments with code just too easily.

If you have any more specific questions about the task or the recruiting process, don't hesitate to send us an email