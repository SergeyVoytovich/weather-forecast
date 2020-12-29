# weather-forecast
Test solution for demonstrate skills

>##Tasks
> - On a web page display a forecast of the next 5 days and the current weather data for any/most German cities.
> - Users should have the ability to look for the weather forecast by providing a place name or zip code. 
> - The Javascript shouldn't query external weather data providers directly, but instead query your own .NET Core JSON endpoint, which in turn should query ***OpenWeathermap***. 
> - Create API endpoint(s) for retrieving the forecast by city or zipCode. 
>  - GET /api/weather/forecast?city=[cityName] 
>  - GET api/weather/forecast?zipCode=[cityName]  
> - Those should return your own json payload (not just a mirror/passthrough of the OpenWeather JSON payload) containing the 
 following data: 
>  - average temperature 
>  - humidity per day 
>  - beginning with today and next 5 days:
>    - temperature
>    - humidity
>    - wind speed
> - Make sure your returned json is refactoring-resilient (meaning a change to the model class property names shouldn't break the API)
> - In the frontend the application should be as responsive as possible 
>   - CSS frameworks like e.g. Bootstrap could be used
>   - custom CSS though is encouraged, whatever looks better. 
> - When displaying the data, feel free: table, graph, map, any available data visualization skills should be applied. 
> - It is also your task to persist the current weather data each time a user queries weather data of a city in the browser. 
>   - It is sufficient if you save the name of the city, the temperature and humidity. 
>   - That should then appear in a separate "history" list in the UI.
> - Visual quality: here, too, your own skills should be fully realized in terms of CSS, a visually appealing presentation (using just a CSS framework is fine) is a plus.
##Implementation
###Tools
> - JetBrains Rider 2020.3 
> - Node.js v14.15.1. 
> - .Net Core SDK 5.0.101
> - Vue.js 3.0.0
###Architecture
> - Common - common interfaces and implementations (like domain models).
> - Application layer - abstract layer for business logic. 
> - Data - abstract layer for data access. For solution OpenWeatherMap service is a data source (work as IRepository). 
> - Presentation - layer for user interface (includes ASP.Net Web API project to build JSON data and Vue project to build UI).