<template>
  <WeatherForecast message="Welcome to weather forecast" />
</template>

<script>
import WeatherForecast from "./components/WeatherForecast";

export default {
  name: "App",
  components: {
    WeatherForecast
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 30px;
}
</style>
